namespace SimpleUI.ScrollExtensions
{
	using UnityEngine;

	public class FocusSwitch : MonoBehaviour
	{
		public DynamicScrollPoint scrollPoint;
		[Range(0,1f)]
		public float switchDistance = 0.1f;
		public BoundBool OnSwitchState = new BoundBool(false);

		private void Awake()
		{
			scrollPoint.OnFocusDistanceChanged.AddListener(CheckState);
		}
		private void CheckState(float distance)
		{
			bool newState = distance < switchDistance;
			if (newState != OnSwitchState.Value)
				OnSwitchState.Value = newState;
		}
	}
}
