using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Permissions;

namespace SimpleEasing
{
	/// <summary>
	/// The Tween class stores the animation information;
	/// </summary>
	[Serializable]
	public class Tween {
		public float from, to, restTime, originalTime, progress;
		public Vector2 fromVector2, toVector2;
		public Vector3 fromVector3, toVector3;
		public Quaternion fromQuaternion, toQuaternion;
		public Color fromColor, toColor;
		public Func<float, float, float, float> easeFunctionDelegate;
		private Action<float> valueSetter;
		private Action<Vector2> valueSetterVector2;
		private Action<Vector3> valueSetterVector3;
		private Action<Quaternion> valueSetterQuaternion;
		private Action<Color> valueSetterColor;
		public Func<float> deltaTimeDelegate;
		public Action OnComplete;
		public TweenType type = TweenType.f;
		public TweenRepeat repeat = TweenRepeat.Once;
		public Coroutine animationRoutine;
		public bool pooled = false;
		
		private static readonly Stack<Tween> pool = new Stack<Tween>();

		public enum TweenType
		{
			delay, f, v2, v3, col, quat 
		}
		
		#region Tween Constructors
		/// <summary>
		/// Use this for animating float values. The first parameter has to be a setter for the float
		/// </summary>
		/// <param name="valueSetter">Value setter.</param>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		/// <param name="length">Length.</param>
		/// <param name="easeType">Ease type.</param>
		/// <param name="unscaled">If set to <c>true</c> unscaled.</param>
		/// <param name="repeat">Repeat.</param>
		/// <param name="OnComplete">On complete.</param>
		public Tween(Action<float> valueSetter, float from, float to, float length, EasingTypes easeType = EasingTypes.Linear,bool unscaled = false, TweenRepeat repeat = TweenRepeat.Once ,Action OnComplete = null)
		{
			SetFloatParameters(valueSetter, from, to);
			SetAnimationParameters(length, EasingFunctions.Function(easeType), unscaled, repeat, OnComplete);
		}
		public Tween(Action<float> valueSetter, float from, float to, float length, AnimationCurve curve, bool unscaled = false, TweenRepeat repeat = TweenRepeat.Once ,Action OnComplete = null)
		{
			SetFloatParameters(valueSetter, from, to);
			SetAnimationParameters(length, EasingFunctions.AnimationCurveFunction(curve), unscaled, repeat, OnComplete);
		}
		public Tween(Action<float> valueSetter, float from, float to, TweenSettings settings, Action OnComplete = null)
		{
			SetFloatParameters(valueSetter, from, to);
			SetAnimationParameters(settings, OnComplete);
		}

		/// <summary>
		/// Use this for animating a Vector2
		/// </summary>
		/// <param name="valueSetter">Value setter.</param>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		/// <param name="length">Length.</param>
		/// <param name="easeType">Ease type.</param>
		/// <param name="unscaled">If set to <c>true</c> unscaled.</param>
		/// <param name="repeat">Repeat.</param>
		/// <param name="OnComplete">On complete.</param>
		public Tween(Action<Vector2> valueSetter, Vector2 from, Vector2 to, float length, EasingTypes easeType = EasingTypes.Linear,bool unscaled = false, TweenRepeat repeat = TweenRepeat.Once, Action OnComplete= null)
		{
			SetVector2Parameters(valueSetter, from, to);
			SetAnimationParameters(length, EasingFunctions.Function(easeType), unscaled, repeat, OnComplete);
		}
		public Tween(Action<Vector2> valueSetter, Vector2 from, Vector2 to, float length, AnimationCurve curve,bool unscaled = false, TweenRepeat repeat = TweenRepeat.Once, Action OnComplete= null)
		{
			SetVector2Parameters(valueSetter, from, to);
			SetAnimationParameters(length, EasingFunctions.AnimationCurveFunction(curve), unscaled, repeat, OnComplete);
		}
		public Tween(Action<Vector2> valueSetter, Vector2 from, Vector2 to, TweenSettings settings, Action OnComplete= null)
		{
			SetVector2Parameters(valueSetter, from, to);
			SetAnimationParameters(settings, OnComplete);
		}
		/// <summary>
		/// Use this for animating a Vector3
		/// </summary>
		/// <param name="valueSetter">Value setter.</param>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		/// <param name="length">Length.</param>
		/// <param name="easeType">Ease type.</param>
		/// <param name="unscaled">If set to <c>true</c> unscaled.</param>
		/// <param name="repeat">Repeat.</param>
		/// <param name="OnComplete">On complete.</param>
		public Tween(Action<Vector3> valueSetter, Vector3 from, Vector3 to, float length, EasingTypes easeType = EasingTypes.Linear,bool unscaled = false, TweenRepeat repeat = TweenRepeat.Once, Action OnComplete= null)
		{
			SetVector3Parameters(valueSetter, from, to);
			SetAnimationParameters(length, EasingFunctions.Function(easeType), unscaled, repeat, OnComplete);
		}
		public Tween(Action<Vector3> valueSetter, Vector3 from, Vector3 to, float length, AnimationCurve curve,bool unscaled = false, TweenRepeat repeat = TweenRepeat.Once, Action OnComplete= null)
		{
			SetVector3Parameters(valueSetter, from, to);
			SetAnimationParameters(length, EasingFunctions.AnimationCurveFunction(curve), unscaled, repeat, OnComplete);
		}
		public Tween(Action<Vector3> valueSetter, Vector3 from, Vector3 to, TweenSettings settings, Action OnComplete= null)
		{
			SetVector3Parameters(valueSetter, from, to);
			SetAnimationParameters(settings, OnComplete);
		}
		/// <summary>
		/// Use this for animating rotations
		/// </summary>
		/// <param name="valueSetter">Value setter.</param>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		/// <param name="length">Length.</param>
		/// <param name="easeType">Ease type.</param>
		/// <param name="unscaled">If set to <c>true</c> unscaled.</param>
		/// <param name="repeat">Repeat.</param>
		/// <param name="OnComplete">On complete.</param>
		public Tween(Action<Quaternion> valueSetter, Quaternion from, Quaternion to, float length, EasingTypes easeType = EasingTypes.Linear,bool unscaled = false, TweenRepeat repeat = TweenRepeat.Once, Action OnComplete= null)
		{
			SetQuaternionParameters(valueSetter, from, to);
			SetAnimationParameters(length, EasingFunctions.Function(easeType), unscaled, repeat, OnComplete);
		}
		public Tween(Action<Quaternion> valueSetter, Quaternion from, Quaternion to, float length, AnimationCurve curve, bool unscaled = false, TweenRepeat repeat = TweenRepeat.Once, Action OnComplete= null)
		{
			SetQuaternionParameters(valueSetter, from, to);
			SetAnimationParameters(length, EasingFunctions.AnimationCurveFunction(curve), unscaled, repeat, OnComplete);
		}
		public Tween(Action<Quaternion> valueSetter, Quaternion from, Quaternion to, TweenSettings settings, Action OnComplete= null)
		{
			SetQuaternionParameters(valueSetter, from, to);
			SetAnimationParameters(settings, OnComplete);
		}
		/// <summary>
		/// Use this for animating colors
		/// </summary>
		/// <param name="valueSetter">Value setter.</param>
		/// <param name="from">From.</param>
		/// <param name="to">To.</param>
		/// <param name="length">Length.</param>
		/// <param name="easeType">Ease type.</param>
		/// <param name="unscaled">If set to <c>true</c> unscaled.</param>
		/// <param name="repeat">Repeat.</param>
		/// <param name="OnComplete">On complete.</param>
		public Tween(Action<Color> valueSetter, Color from, Color to, float length, EasingTypes easeType = EasingTypes.Linear,bool unscaled = false, TweenRepeat repeat = TweenRepeat.Once, Action OnComplete= null)
		{
			SetColorParameters(valueSetter, from, to);
			SetAnimationParameters(length, EasingFunctions.Function(easeType), unscaled, repeat, OnComplete);
		}
		public Tween(Action<Color> valueSetter, Color from, Color to, float length, AnimationCurve curve,bool unscaled = false, TweenRepeat repeat = TweenRepeat.Once, Action OnComplete= null)
		{
			SetColorParameters(valueSetter, from, to);
			SetAnimationParameters(length, EasingFunctions.AnimationCurveFunction(curve), unscaled, repeat, OnComplete);
		}
		public Tween(Action<Color> valueSetter, Color from, Color to, TweenSettings settings, Action OnComplete= null)
		{
			SetColorParameters(valueSetter, from, to);
			SetAnimationParameters(settings, OnComplete);
		}

		public Tween(float seconds)
		{
			this.originalTime = seconds;
			this.type = TweenType.delay;
		}
		public Tween()
		{
			
		}
		#endregion

		#region Animation
		public Coroutine Play()
		{
			return TweenManager.instance.PlayTween(this);
		}
		public Coroutine PlayFromStart()
		{
			Reset();
			return Play();
		}
		public void Stop()
		{
			if(animationRoutine != null)
				TweenManager.instance.StopTween(animationRoutine);
		}
		public void StopAndRelease()
		{
			if(animationRoutine != null)
				TweenManager.instance.StopAndReleaseTween(this);
		}
		public void Reset()
		{
			this.restTime = this.originalTime;
		}
		#endregion

		#region Tween Value Setters
		public Vector2 Vector2Value
		{
			set {
				this.valueSetterVector2(value);
			}
		}
		public Vector3 Vector3Value
		{
			set {
				this.valueSetterVector3(value);
			}
		}
		public Quaternion QuaternionValue
		{
			set {
				this.valueSetterQuaternion(value);
			}
		}
		public Color ColorValue
		{
			set {
				this.valueSetterColor(value);
			}
		}
		public float FloatValue 
		{
			set {
				this.valueSetter(value);
			}
		}
		#endregion

		#region Tween Helper Functions

		public void SwitchTargets()
		{
			Swap<float>(ref from, ref to);
			Swap<Vector2>(ref fromVector2, ref toVector2);
			Swap<Vector3>(ref fromVector3, ref toVector3);
			Swap<Color>(ref fromColor, ref toColor);
		}
		public static void Swap<T>(ref T param1, ref T param2)
		{
			T tmp = param1;
			param1 = param2;
			param2 = tmp;
		}
		public static Func<float> TimeFunction(bool unscaled)
		{
			return unscaled ? (Func<float>)(()=>Time.unscaledDeltaTime) : (Func<float>)(()=> Time.deltaTime);
		}
		void SetAnimationParameters( float length, Func<float, float, float, float> easingFunction, bool unscaled = false, TweenRepeat repeat = TweenRepeat.Once ,Action OnComplete = null)
		{
			this.easeFunctionDelegate = easingFunction;
			this.restTime = this.originalTime = length;
			this.OnComplete = OnComplete;
			this.repeat = repeat;
			this.pooled = false;
			this.deltaTimeDelegate = TimeFunction(unscaled);
		}
		void SetAnimationParameters(TweenSettings settings, Action OnComplete = null)
		{
			var easingFunction = settings.useCustomCurve
				? EasingFunctions.AnimationCurveFunction(settings.animationCurve)
				: EasingFunctions.Function(settings.easing);
			SetAnimationParameters(settings.animationLength, easingFunction,
				settings.unscaledTime, settings.animationRepeat, OnComplete);
		}

		void SetFloatParameters(Action<float> valueSetter, float from, float to)
		{
			this.valueSetter = valueSetter;
			this.from = from;
			this.to = to;
			this.type = TweenType.f;
		}

		void SetVector2Parameters(Action<Vector2> valueSetter, Vector2 from, Vector2 to)
		{
			this.valueSetterVector2 = valueSetter;
			this.fromVector2 = from;
			this.toVector2 = to;
			this.type = TweenType.v2;
		}

		void SetVector3Parameters(Action<Vector3> valueSetter, Vector3 from, Vector3 to)
		{
			this.valueSetterVector3 = valueSetter;
			this.fromVector3 = from;
			this.toVector3 = to;
			this.type = TweenType.v3;
		}

		void SetQuaternionParameters(Action<Quaternion> valueSetter, Quaternion from, Quaternion to)
		{
			this.valueSetterQuaternion = valueSetter;
			this.fromQuaternion = from;
			this.toQuaternion = to;
			this.type = TweenType.quat;
		}

		void SetColorParameters(Action<Color> valueSetter, Color from, Color to)
		{
			this.valueSetterColor = valueSetter;
			this.fromColor = from;
			this.toColor = to;
			this.type = TweenType.col;
		}

		#endregion

		#region Pooling
		/// <summary>
		/// Retrieve a pooled Tween if possible, avoiding allocation;
		/// </summary>
		/// <param name="valueSetter"></param>
		/// <param name="from"></param>
		/// <param name="to"></param>
		/// <param name="settings"></param>
		/// <param name="OnComplete"></param>
		/// <returns></returns>
		public static Tween Get(Action<float> valueSetter, float from, float to, TweenSettings settings, Action OnComplete = null)
		{
			if (pool.Count < 1)
			{
				return new Tween(valueSetter, from, to, settings, OnComplete);
			}
			Tween pooled = pool.Pop();
			pooled.SetFloatParameters(valueSetter, from, to);
			pooled.SetAnimationParameters(settings, OnComplete);
			return pooled;
		}
		public static Tween Get(Action<Vector2> valueSetter, Vector2 from, Vector2 to, TweenSettings settings, Action OnComplete= null)
		{
			if (pool.Count < 1)
			{
				return new Tween(valueSetter, from, to, settings, OnComplete);
			}
			Tween pooled = pool.Pop();
			pooled.SetVector2Parameters(valueSetter, from, to);
			pooled.SetAnimationParameters(settings, OnComplete);
			return pooled;
		}
		public static Tween Get(Action<Vector3> valueSetter, Vector3 from, Vector3 to, TweenSettings settings, Action OnComplete= null)
		{
			if (pool.Count < 1)
			{
				return new Tween(valueSetter, from, to, settings, OnComplete);
			}
			Tween pooled = pool.Pop();
			pooled.SetVector3Parameters(valueSetter, from, to);
			pooled.SetAnimationParameters(settings, OnComplete);
			return pooled;
		}
		public static Tween Get(Action<Quaternion> valueSetter, Quaternion from, Quaternion to, TweenSettings settings, Action OnComplete= null)
		{
			if (pool.Count < 1)
			{
				return new Tween(valueSetter, from, to, settings, OnComplete);
			}
			Tween pooled = pool.Pop();
			pooled.SetQuaternionParameters(valueSetter, from, to);
			pooled.SetAnimationParameters(settings, OnComplete);
			return pooled;
		}
		public static Tween Get(Action<Color> valueSetter, Color from, Color to, TweenSettings settings, Action OnComplete= null)
		{
			if (pool.Count < 1)
			{
				return new Tween(valueSetter, from, to, settings, OnComplete);
			}
			Tween pooled = pool.Pop();
			pooled.pooled = false;
			pooled.SetColorParameters(valueSetter, from, to);
			pooled.SetAnimationParameters(settings, OnComplete);
			return pooled;
		}
		public static void Release(Tween t)
		{
			t.pooled = true;
			pool.Push(t);
		}
		public static void SetPool(int size)
		{
			int missing = size - pool.Count;
			if (missing < 1)
				return;
			for (int i = 0; i < missing; i++)
			{
				pool.Push(new Tween());
			}
		}

		public static int PoolSize
		{
			get { return pool.Count; }
		}

		#endregion
	}
}