using System.Linq;
using SimpleEasing;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace SimpleUI.ScrollExtensions
{
	using System.Collections.Generic;
	using UnityEngine;
	[AddComponentMenu("Simple UI/ Scroll View Extensions/ Scroll Focus Controller", 1001)]
	public class ScrollFocusController : UIBehaviour, IInitializePotentialDragHandler, IBeginDragHandler, IEndDragHandler, IScrollHandler
	{
		public ScrollRect scrollRect;
		public EasedScrollRectMover scrollMover;
		public List<ScrollPoint> focusPoints = new List<ScrollPoint>();
		public ScrollPoint first;
		public float scrollTimeOut = 0.5f;
		public bool snap = true;
		[Header("In case inertia is enabled, elements will snap at this threshold")]
		public float minVelocityForSnap = 150f;
		private ScrollPoint current;
		private bool scrolling = false;
		private float scrollPauseTime = 0f;
		private UniqueCoroutine inertiaWatchRoutine = new UniqueCoroutine();


		protected override void Start()
		{
			if (first != null)
			{
				current = first;
				current.Focus();
				scrollMover.scrollController.CenterOn(current.Rect);	
			}
		}

		public void OnInitializePotentialDrag(PointerEventData eventData)
		{
			MovementStarted();
		}

		public void OnBeginDrag(PointerEventData eventData)
		{
			MovementStarted();
		}

		public void OnEndDrag(PointerEventData eventData)
		{
			MovementFinished();
		}

		public void OnScroll(PointerEventData eventData)
		{
			OnScrollMove();
		}
		public void OnScrollMove()
		{
			scrolling = true;
			scrollPauseTime = 0f;
			MovementStarted();
		}

		private void Update()
		{
			if (scrolling)
			{
				if (scrollPauseTime > scrollTimeOut)
				{
					scrolling = false;
					MovementFinished();
				}
				else
					scrollPauseTime += Time.deltaTime;
			}
		}
		public void MovementStarted()
		{
			inertiaWatchRoutine.StopCoroutine();
		}

		public void MovementFinished()
		{
			inertiaWatchRoutine.StopCoroutine();
			
			if (snap)
			{
				if (scrollRect.inertia && !VelocityBelowMinimum())
				{
					inertiaWatchRoutine.ReplaceOrStartCoroutine(Scheduler.DoWhen(VelocityBelowMinimum, MovementFinished));
					return;
				}
				MoveTo(FindNearest());
			}
			else
				ChangeFocus(FindNearest());
		}

		bool VelocityBelowMinimum()
		{
			return scrollRect.velocity.magnitude < minVelocityForSnap;
		}

		public ScrollPoint FindNearest()
		{
			Vector2 currentPosition = scrollRect.normalizedPosition;
			
			var nearestFocusPoint = focusPoints.OrderBy(x =>
			{
				return x.AbsoluteDistanceToPosition(currentPosition);
			}).First();
			return nearestFocusPoint;
		}

		protected override void OnRectTransformDimensionsChange()
		{
			base.OnRectTransformDimensionsChange();
			focusPoints.ForEach(point => point.Dirty = true);
		}
		void ChangeFocus(ScrollPoint point)
		{
			if (current == point)
				return;
			current.Defocus();
			point.Focus();
			current = point;
		}
		public void MoveTo(ScrollPoint point)
		{
			if (current != point)
			{
				current.Defocus();
				scrollMover.MoveTo(point.ScrollPosition, ()=> point.Focus());
				current = point;
			}
			//otherwise just move back
			else
				scrollMover.MoveTo(point.ScrollPosition);
		}
	}
}
