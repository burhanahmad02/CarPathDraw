using System;

namespace SimpleUI.ScrollExtensions
{
	using UnityEngine;
	using UnityEngine.UI;
	using UnityEngine.EventSystems;
	using SimpleEasing;

	public class EasedScrollRectMover : MonoBehaviour, IInitializePotentialDragHandler, IBeginDragHandler
	{
		public ScrollRectController scrollController;
		public ScrollRect scrollRect;
		public CanvasGroup canvasGroup;
		[Tooltip("Either block User Input during Movement or end the Movement on User Input")]
		public bool blockInputDuringScroll = true;
		public TweenSettings settings;
		private UniqueCoroutine scrollRoutine = new UniqueCoroutine();
		public bool Moving { get; private set; }

		public void MoveTo(RectTransform rect)
		{
			MoveTo(rect, null);
		}
		public void MoveTo(float scrollPosition)
		{
			MoveTo(scrollPosition, null);
		}
		public void MoveTo(Vector2 scrollPosition)
		{
			MoveTo(scrollPosition, null);
		}
		public void MoveTo(RectTransform rect, Action onEndAnimation = null)
		{
			var normalizedPosition = scrollController.GetCenteredNormalizedPosition(rect);
			MoveTo(normalizedPosition, onEndAnimation);
		}
		public void MoveTo(float scrollPosition, Action onEndAnimation = null)
		{
			if (blockInputDuringScroll)
			{
				BlockScrollRectInput();
			}
				
			Moving = true;
			Action<float> horizontalSetter = (float scrollValue) =>
				scrollRect.horizontalNormalizedPosition = scrollValue;
			Action<float> verticalSetter = (float scrollValue) =>
				scrollRect.verticalNormalizedPosition = scrollValue;
			Action onFinished = () =>
			{
				Moving = false;
				if (blockInputDuringScroll)
					ResetScrollRectInput();
				if (onEndAnimation != null)
					onEndAnimation();
			};
			var tween = Tween.Get(scrollRect.vertical ? verticalSetter : horizontalSetter, 
				scrollRect.vertical ? scrollRect.verticalNormalizedPosition : scrollRect.horizontalNormalizedPosition, 
				scrollPosition, settings, onFinished);
			tween.Play();
			scrollRoutine.ReplaceOrStartTween(tween);
		}
		public void MoveTo(Vector2 scrollPosition, Action onEndAnimation = null)
		{
			if(blockInputDuringScroll) 
				BlockScrollRectInput();
			Moving = true;
			Action onFinished = () =>
			{
				Moving = false;
				if (blockInputDuringScroll)
					ResetScrollRectInput();
				if (onEndAnimation != null)
					onEndAnimation();
			};
			var tween = Tween.Get((Vector2 scroll)=> scrollRect.normalizedPosition = scroll, 
				scrollRect.normalizedPosition, scrollPosition, settings, onFinished);
			tween.Play();
			scrollRoutine.ReplaceOrStartTween(tween);
		}

		public void OnInitializePotentialDrag(PointerEventData eventData)
		{
			if(!blockInputDuringScroll) 
				AbortScrollMovement();
		}

		public void OnBeginDrag (PointerEventData eventData)
		{
			if(!blockInputDuringScroll) 
				AbortScrollMovement();
		}
		public void AbortScrollMovement()
		{
			scrollRoutine.StopCoroutine();
		}
		private void BlockScrollRectInput()
		{
			scrollRect.enabled = false;
			canvasGroup.blocksRaycasts = false;
		}
		private void ResetScrollRectInput()
		{
			scrollRect.enabled = true;
			canvasGroup.blocksRaycasts = true;
		}
	}
}