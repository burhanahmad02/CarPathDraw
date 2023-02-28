using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Events;

namespace SimpleUI.ScrollExtensions 
{
	public class ScrollPoint : MonoBehaviour{
		private bool initialized = false;
		protected Vector2 centeredPosition;
		protected ScrollRectController scrollController;
		protected ScrollRect scrollRect;
		private RectTransform rect;
		protected float distance;
		public UnityEvent OnFocus, OnFocusLost;
		private bool dirty = true;
		public event Action OnDirty;

		protected virtual void Awake()
		{
			Initialize();
		}

		void Initialize()
		{
			scrollController = GetComponentInParent<ScrollRectController>();
			scrollRect = GetComponentInParent<ScrollRect>();
			rect = transform as RectTransform;
			initialized = true;
		}

		public void Focus()
		{
			OnFocus.Invoke();
		}

		public void Defocus()
		{
			OnFocusLost.Invoke();
		}

		public Vector2 DifferenceToFocus{
			get
			{
				if(!initialized) 
					Initialize();
				Vector2 ScrollCenter = ScrollPosition;
				Vector2 difference = Vector2.zero;
				if (scrollRect.vertical)
					difference.y = Mathf.Abs(ScrollCenter.y - ScrollPosition.y);
				if (scrollRect.horizontal)
					difference.x = Mathf.Abs(ScrollCenter.x - ScrollPosition.x);
				return difference;
			}
		}
		public float DistanceToFocus{
			get
			{
				if(!initialized) 
					Initialize();
				return AbsoluteDistanceToPosition(scrollRect.normalizedPosition);
			}
		}
		public float AbsoluteDistanceToPosition(Vector2 normalizedPosition)
		{
			return Mathf.Abs(DistanceToPosition(normalizedPosition));
		}
		public float DistanceToPosition(Vector2 normalizedPosition)
		{
			if(!initialized) 
				Initialize();
			if (scrollRect.vertical && !scrollRect.horizontal)
			{
				distance = normalizedPosition.y - ScrollPosition.y;
			}
			else if (scrollRect.horizontal && !scrollRect.vertical)
			{
				distance = normalizedPosition.x - ScrollPosition.x;
			}
			else
			{
				distance = Vector2.Distance(normalizedPosition, ScrollPosition);
			}
			return distance;
		}

		public bool LeftOfFocus
		{
			get { return ScrollPosition.x < scrollRect.horizontalNormalizedPosition; }
		}
		public bool RightOfFocus
		{
			get { return ScrollPosition.x > scrollRect.horizontalNormalizedPosition; }
		}
		public bool AboveFocus
		{
			get { return ScrollPosition.y > scrollRect.verticalNormalizedPosition; }
		}
		public bool BelowFocus
		{
			get { return ScrollPosition.y < scrollRect.verticalNormalizedPosition; }
		}

		public Vector2 ScrollPosition
		{
			get
			{
				if (!initialized) 
					Initialize();
				if (Dirty)
				{
					centeredPosition = scrollController.GetCenteredNormalizedPosition(rect);
					Dirty = false;
				}
				return centeredPosition;
			}
		}

		public RectTransform Rect
		{
			get { return rect; }
			
		}
		public bool Dirty {
			get { return dirty; }
			set
			{
				dirty = value;
				if (OnDirty != null)
					OnDirty();
			} 
		}
	}
}
