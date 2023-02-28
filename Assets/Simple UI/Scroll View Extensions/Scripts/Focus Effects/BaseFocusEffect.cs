namespace SimpleUI.ScrollExtensions
{
	using System;
	using UnityEngine;
	using SimpleEasing;

	public class BaseFocusEffect : MonoBehaviour
	{
		public DynamicScrollPoint dynamicScrollPoint;
		[Range(0, 1f)]
		public float minEffectDistance = 0.3f;
		public float minEffectValue = 0.5f, maxEffectValue = 1f;
		public EasingTypes interpolation = EasingTypes.Linear;
		private Func<float, float, float, float> interpolationFunction;
		protected float effectStrength = 0f;

		protected virtual void Start()
		{
			interpolationFunction = EasingFunctions.Function(interpolation);
			dynamicScrollPoint.OnFocusDistanceChanged.AddListener(CalculateEffectStrength);
			CalculateEffectStrength(dynamicScrollPoint.OnFocusDistanceChanged.Value);
		}

		void CalculateEffectStrength(float normalizedDistance)
		{
			if (normalizedDistance > minEffectDistance)
			{
				effectStrength = minEffectValue;
			}
			else
			{
				float t = 1f - normalizedDistance / minEffectDistance;
				effectStrength = interpolationFunction(minEffectValue, maxEffectValue, t);
			}
			SetEffect(effectStrength);
		}

		protected virtual void SetEffect(float strength)
		{
			//apply effect in derived class
		}
	}
}
