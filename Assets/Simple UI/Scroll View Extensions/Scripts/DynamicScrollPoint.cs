namespace SimpleUI.ScrollExtensions
{
	using UnityEngine;

	public class DynamicScrollPoint : ScrollPoint
	{
		public BoundFloat OnFocusDistanceChanged = new BoundFloat(1f);
		
		protected override void Awake()
		{
			base.Awake();
			scrollRect.onValueChanged.AddListener(UpdateDistance);
		}

		protected virtual void Start()
		{
			UpdateDistance(scrollRect.normalizedPosition);
		}

		private void UpdateDistance(Vector2 normalizedPosition)
		{
			OnFocusDistanceChanged.Value = AbsoluteDistanceToPosition(normalizedPosition);
		}
	}
}
