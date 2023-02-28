using UnityEngine.UI;

namespace SimpleUI.ScrollExtensions
{
	using UnityEngine;
	/// <summary>
	/// Layouted elements report incorrect positions during start and awake phase, this script forces
	/// layout groups to do the necessary calculations on awake
	/// </summary>
	public class ForceLayoutInitialization : MonoBehaviour
	{
		public HorizontalOrVerticalLayoutGroup layoutGroup;
		
		void Awake()
		{
			if (layoutGroup != null && layoutGroup.enabled)
			{
				layoutGroup.CalculateLayoutInputHorizontal();
				layoutGroup.SetLayoutHorizontal();
				layoutGroup.CalculateLayoutInputVertical();
				layoutGroup.SetLayoutVertical();
			}
		}
	}
}