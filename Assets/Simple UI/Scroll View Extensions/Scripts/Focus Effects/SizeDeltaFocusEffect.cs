namespace SimpleUI.ScrollExtensions
{
	using UnityEngine;

	public class SizeDeltaFocusEffect : BaseFocusEffect
	{
		public RectTransform rectTransform;
		public bool useX, useY;
		private Vector2 effectVector;
		
		public Vector2 referenceSize;

		protected override void SetEffect(float strength)
		{
			effectVector.x = useX ? referenceSize.x * strength : referenceSize.x;
			effectVector.y = useY ? referenceSize.y * strength : referenceSize.y;
			rectTransform.sizeDelta = effectVector;
		}
	}
}