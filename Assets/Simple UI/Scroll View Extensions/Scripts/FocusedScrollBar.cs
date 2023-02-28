namespace SimpleUI.ScrollExtensions
{
	using UnityEngine.EventSystems;
	using UnityEngine;

	public class FocusedScrollBar : MonoBehaviour, IEndDragHandler
	{
		public ScrollFocusController focusController;
		
		public void OnEndDrag(PointerEventData eventData)
		{
			focusController.MovementFinished();
		}
	}
}