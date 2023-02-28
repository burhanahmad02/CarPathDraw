namespace SimpleEasing
{
	
using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

	public sealed class TweenManager : UnitySingleton<TweenManager> {
		private readonly WaitForEndOfFrame wait = new WaitForEndOfFrame();

		#if UNITY_EDITOR
			public List<Tween> activeTweens = new List<Tween>();
		#endif


		#region Public Tween Starters

		/// <summary>
		/// Plays a tween and returns a Coroutine which you can cache 
		/// to abort the Tween later
		/// </summary>
		/// <param name="t">Tween.</param>
		public Coroutine PlayTween(Tween t)
		{
			#if UNITY_EDITOR
				activeTweens.Add(t);
			#endif
			var routine = StartCoroutine(Animate(t));
			t.animationRoutine = routine;
			return routine;
		}
		/// <summary>
		/// Chains the tweens for sequential execution
		/// </summary>
		/// <param name="tweens">Tweens.</param>
		public Coroutine ChainTweens(params Tween[] tweens)
		{
			var tweenEnumerators = new IEnumerator[tweens.Length];
			for (int i = 0, tweensLength = tweens.Length; i < tweensLength; i++) {
				Tween t = tweens [i];
				tweenEnumerators[i] = Animate (t);
			}
			return StartCoroutine(Chain(tweenEnumerators));
		}
		#endregion

		#region Animate
		private IEnumerator Animate(Tween t)
		{
			//store the easeCall in this Action depending on Tweentype
			Action easeCall;
			switch (t.type) {
				case Tween.TweenType.delay:
				yield return new WaitForSeconds(t.originalTime);
					yield break;
				case Tween.TweenType.f:
				easeCall = () =>
				{
					t.FloatValue = t.easeFunctionDelegate(t.from, t.to, t.progress);
				};
					break;
				case Tween.TweenType.v2:
				easeCall = () =>
				{
					t.Vector2Value = VectorHelper.EaseVector2(t.easeFunctionDelegate,t.fromVector2, t.toVector2, t.progress);
				};
					break;
				case Tween.TweenType.v3:
				easeCall = () =>
				{
					t.Vector3Value = VectorHelper.EaseVector3(t.easeFunctionDelegate,t.fromVector3, t.toVector3, t.progress);
				};
					break;
				case Tween.TweenType.quat:
				easeCall = () =>
				{
					t.QuaternionValue = VectorHelper.EaseQuaternion(t.easeFunctionDelegate, t.fromQuaternion, t.toQuaternion, t.progress);
				};
				break;
				case Tween.TweenType.col:
				easeCall = () =>
				{
					t.ColorValue = VectorHelper.EaseColor(t.easeFunctionDelegate,t.fromColor, t.toColor, t.progress);
				};
					break;
				default:
					throw new ArgumentOutOfRangeException ();
			}
			//the actual easing over time
			while(t.restTime > 0)
			{
				t.restTime -= t.deltaTimeDelegate();
				t.progress = 1f - t.restTime/t.originalTime;
				easeCall();
				yield return wait;
			}
			if(t.OnComplete != null) 
				t.OnComplete();
			if(t.repeat == TweenRepeat.Once)
				Tween.Release(t);
			else
				CheckRepeat(t);
			
			#if UNITY_EDITOR
				activeTweens.Remove(t);
			#endif
		}
		#endregion

		#region Convenience Functions
		private IEnumerator Chain(params IEnumerator[] enumerators)
		{
			for (int j = 0, enumeratorsLength = enumerators.Length; j < enumeratorsLength; j++) {
				IEnumerator i = enumerators [j];
				yield return StartCoroutine (i);
			}
		}
		public void StopAllTweens(){
			StopAllCoroutines();
		}
		public void StopAndReleaseTween(Tween tween){
			StopTween(tween.animationRoutine);
			Tween.Release(tween);
			
			#if UNITY_EDITOR
				activeTweens.Remove(tween);
			#endif
		}
		public void StopTween(Coroutine cor){
			StopCoroutine(cor);
		}
		public static void Dispose()
		{
			if(HasInstance) 
			{
				instance.StopAllTweens();
				Destroy(instance);
			}
		}
		private void CheckRepeat(Tween t)
		{
			t.restTime = t.originalTime;
			if(t.repeat == TweenRepeat.PingPong) t.SwitchTargets();
			if(t.repeat == TweenRepeat.PingPong || t.repeat == TweenRepeat.Loop) StartCoroutine(Animate (t));
		}

		#endregion

	}
}