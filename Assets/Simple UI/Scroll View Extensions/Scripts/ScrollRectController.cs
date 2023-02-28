using UnityEngine;
using UnityEngine.UI;

namespace SimpleUI.ScrollExtensions
{
	/// <summary>
	/// Scroll rect controller. Can be used to bring something inside a ScrollRect
	/// into focus
	/// </summary>
	[AddComponentMenu("Simple UI/ Scroll View Extensions/ Scroll Rect Controller", 1000)]
	public class ScrollRectController : MonoBehaviour {
		
		private bool initialized;
		private RectTransform m_ContentRect, m_ViewRect;
		private Vector3[] ViewRectWorldCoordinates = new Vector3[4], ContentRectWorldCoordinates = new Vector3[4];
		private Vector3 centerPosition, difference;
		public ScrollRect scrollRect;
		private Vector2 viewRectWorldSize, contentRectWorldSize, normalizedDifference;
		
		public virtual void Awake()
		{
			if(!initialized) 
				Initialize();
		}
		public void CenterOn(RectTransform centerTransform)
		{
			scrollRect.normalizedPosition = GetCenteredNormalizedPosition(centerTransform);
		}
		//Calculate the normalized position for which the supplied rect transform is centered inside the
		//view rect. Note that layouted rect transforms report their position incorrectly in the Awake and Start
		//functions
		public Vector2 GetCenteredNormalizedPosition(RectTransform TransformToCenterOn)
		{	
			if(!initialized) 
				Initialize();
			m_ViewRect.GetWorldCorners(ViewRectWorldCoordinates);
			m_ContentRect.GetWorldCorners(ContentRectWorldCoordinates);
			centerPosition = Vector3.Lerp(ViewRectWorldCoordinates[0], ViewRectWorldCoordinates[2], 0.5f);
			
			difference = centerPosition - TransformToCenterOn.position;
			viewRectWorldSize.x = Vector3.Distance(ViewRectWorldCoordinates[0], ViewRectWorldCoordinates[3]); 
			viewRectWorldSize.y = Vector3.Distance(ViewRectWorldCoordinates[0], ViewRectWorldCoordinates[1]);

			contentRectWorldSize.x = Vector3.Distance(ContentRectWorldCoordinates[0], ContentRectWorldCoordinates[3]);
			contentRectWorldSize.y = Vector3.Distance(ContentRectWorldCoordinates[0], ContentRectWorldCoordinates[1]);

			normalizedDifference.x = difference.x / (contentRectWorldSize.x - viewRectWorldSize.x);
			normalizedDifference.y = difference.y / (contentRectWorldSize.y - viewRectWorldSize.y);
			
			Vector2 normalizedPosition = scrollRect.normalizedPosition - normalizedDifference;
			normalizedPosition.x = (float.IsNaN(normalizedPosition.x)) ? 0f : normalizedPosition.x;
			normalizedPosition.y = (float.IsNaN(normalizedPosition.y)) ? 0f : normalizedPosition.y;
			if (scrollRect.movementType != ScrollRect.MovementType.Unrestricted)
			{
				normalizedPosition.x = Mathf.Clamp01(normalizedPosition.x);
				normalizedPosition.y = Mathf.Clamp01(normalizedPosition.y);
			}
			return normalizedPosition;
		}
		public void Initialize()
		{
			m_ContentRect = scrollRect.content;
			m_ViewRect = scrollRect.viewport;
			initialized = true;
		}
	}
}