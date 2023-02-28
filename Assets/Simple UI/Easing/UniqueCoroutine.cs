using System;

namespace SimpleEasing
{
using UnityEngine;
using System.Collections;

	/// <summary>
	/// Helper class for coroutines that can be overriden.
	/// </summary>
	public class UniqueCoroutine{
		private Coroutine coroutine = null;
		private MonoBehaviour callingScript = null;
		private Tween currentTween;

		public UniqueCoroutine(IEnumerator enumerator, MonoBehaviour script)
		{
			coroutine = script.StartCoroutine(enumerator);
			callingScript = script;
		}
		public UniqueCoroutine(){}

		public void StopCoroutine()
		{
			if(coroutine != null && callingScript != null)
			{
				callingScript.StopCoroutine(coroutine);
			}
		}
		public void ReplaceOrStartCoroutine(IEnumerator enumerator, MonoBehaviour script)
		{
			ReplaceOrStartCoroutine(script.StartCoroutine(enumerator));
			callingScript = script;
		}
		/// <summary>
		/// Assumes that the Coroutine was started on the MonoBehaviour that was passed in
		/// </summary>
		/// <param name="routine">Routine.</param>
		/// <param name="script">Script.</param>
		public void ReplaceOrStartCoroutine(Coroutine routine, MonoBehaviour script)
		{
			ReplaceOrStartCoroutine(routine);
			callingScript = script;
		}
		/// <summary>
		/// This assumes that the calling Script hasn't changed
		/// </summary>
		/// <param name="routine">Routine.</param>
		public void ReplaceOrStartCoroutine(Coroutine routine)
		{
			StopCoroutine();
			coroutine = routine;
		}
		public void ReplaceOrStartTween(Coroutine routine)
		{
			callingScript = TweenManager.instance;
			StopCoroutine();
			coroutine = routine;
		}
		//Releases the previous tween back into the pool
		public void ReplaceOrStartTween(Tween t)
		{
			callingScript = TweenManager.instance;
			if (currentTween != null)
				currentTween.StopAndRelease();	
			coroutine = t.animationRoutine;
			currentTween = t;
			Action onFinish = t.OnComplete;
			t.OnComplete = () =>
			{
				if (onFinish != null)
					onFinish();
				currentTween = null;
			};
		}
		public bool IsRunning{
			get{
				return coroutine != null;
			}
		}
	}
	public static class CoroutineExtensionMethods
	{
		public static UniqueCoroutine StartUniqueCoroutine(this MonoBehaviour script, IEnumerator enumerator)
		{
			return new UniqueCoroutine(enumerator ,script);
		}
	}
}
