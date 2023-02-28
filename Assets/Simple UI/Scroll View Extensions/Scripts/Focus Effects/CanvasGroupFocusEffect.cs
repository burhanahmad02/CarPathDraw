namespace SimpleUI.ScrollExtensions
{
	using UnityEngine;

	public class CanvasGroupFocusEffect : BaseFocusEffect
	{
		public CanvasGroup canvasGroup;

		protected override void SetEffect(float strength)
		{
			canvasGroup.alpha = strength;
		}
	}
}