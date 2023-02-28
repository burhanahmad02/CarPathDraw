using System;

namespace SimpleEasing
{
	
using UnityEngine;
using System.Collections;

	/// <summary>
	/// Editing and Displaying Tween information in the Editor 
	/// </summary>
	[System.Serializable]
	public class TweenSettings
	{
		[Obsolete("Confusing if inconsistently used, enclosing class " +
		          "should decide whether easing information is applied"),
		 HideInInspector]
		public bool eased = true;
		public bool useCustomCurve = false;
		public EasingTypes easing = EasingTypes.QuadraticOut;
		[Tooltip("A curve going from 0 to 1")]
		public AnimationCurve animationCurve = AnimationCurve.EaseInOut(0f, 0f, 1f, 1f);
		public float animationLength = 1f;
		[Tooltip("Whether timescale affects the easing")]
		public bool unscaledTime = false;
		public TweenRepeat animationRepeat = TweenRepeat.Once;
	}
}
