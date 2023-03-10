// GUI Animator FREE
// Version: 1.1.0
// Compatilble: Unity 5.4.0 or higher, more info in Readme.txt file.
//
// Developer:							Gold Experience Team (https://www.ge-team.com)
// Unity Asset Store:					https://www.assetstore.unity3d.com/en/#!/content/58843
// GE Store:							https://www.ge-team.com/en/products/gui-animator-free/
// Full version on Unity Asset Store:	https://www.assetstore.unity3d.com/en/#!/content/28709
// Full version on GE Store:			https://www.ge-team.com/en/products/gui-animator-for-unity-ui/
//
// Please direct any bugs/comments/suggestions to geteamdev@gmail.com

#region Namespaces

using UnityEngine;
using System.Collections;

using UnityEngine.UI;

#endregion

// ######################################################################
// GA_UUI_DemoBasicControlledByScripts class
// This class shows buttons and it plays Move-In and Move-Out animations when user pressed the buttons.
// ######################################################################

public class GA_UUI_DemoBasicControlledByScripts : MonoBehaviour
{

	// ########################################
	// MonoBehaviour functions
	// ########################################

	#region MonoBehaviour Functions

	private float m_WaitTime = 4.0f;
	private float m_WaitTimeCount = 0;
	private bool m_ShowMoveInButton = true;

	// Use this for initialization
	void Awake()
	{
		// Set GSui.Instance.m_AutoAnimation to false, 
		// this will let you control all GUI Animator elements in the scene via scripts.
		if (enabled)
		{
			GSui.Instance.m_GUISpeed = 1.0f;
			GSui.Instance.m_AutoAnimation = false;
		}
	}

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{

		// Count down timer for MoveIn/MoveOut buttons
		if (m_WaitTimeCount > 0 && m_WaitTimeCount <= m_WaitTime)
		{
			m_WaitTimeCount -= Time.deltaTime;
			if (m_WaitTimeCount <= 0)
			{
				m_WaitTimeCount = 0;

				// Switch status of m_ShowMoveInButton
				m_ShowMoveInButton = !m_ShowMoveInButton;
			}
		}
	}

	void OnGUI()
	{
		// Show GUI button when ready
		if (m_WaitTimeCount <= 0)
		{
			Rect rect = new Rect((Screen.width - 250) / 2, (Screen.height - 50) / 2, 250, 50);
			// Show MoveIn button
			if (m_ShowMoveInButton == true)
			{
				if (GUI.Button(rect, "Play Animations"))
				{
					// Play MoveIn animations
					GSui.Instance.MoveIn(this.transform, true);
					m_WaitTimeCount = m_WaitTime;
				}
			}
			// Show MoveOut button
			else
			{
				if (GUI.Button(rect, "Play Out-animations"))
				{
					// Play MoveOut animations
					GSui.Instance.MoveOut(this.transform, true);
					m_WaitTimeCount = m_WaitTime;
				}
			}
		}
	}

	#endregion // MonoBehaviour Functions
}
