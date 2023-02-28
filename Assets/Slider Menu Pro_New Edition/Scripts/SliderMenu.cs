using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

//===========================Begin Scroll Type And Scrollbar Direction================================
public enum scrolltype{
	Horizontal,Vertical
}
public enum scrollbarhorizontaldirection{
	LeftToRight,RightToLeft
}
public enum scrollbarverticaldirection{
	BottomToTop,TopToBottom
}
//============================End Scroll Type And Scrollbar Direction=================================


//=======================================Begin Slides Align===========================================
public enum slidesverticalalign{
	Top,Middle,Bottom
}
public enum slideshorizontalalign{
	Left,Center,Right
}
//========================================End Slides Align============================================


//===================================Begin Previous Button Align======================================
public enum previousbuttonhorizontalalign{
	Left,Center,Right
}
public enum previousbuttonverticalalign{
	Top,Middle,Bottom
}
//====================================End Previous Button Align=======================================


//=====================================Begin Next Button Align========================================
public enum nextbuttonhorizontalalign{
	Left,Center,Right
}
public enum nextbuttonverticalalign{
	Top,Middle,Bottom
}
//======================================End Next Button Align=========================================



public class SliderMenu : MonoBehaviour {
	

	//=======================================Begin Main Objects===========================================
	public		bool							MainObjectBlock;
	public 		Canvas 							SliderMenuCanvas;										//Custom Canvas Object (Scroll Object Parent)
	public 		GameObject 						ScrollObject;											//Object That has Scroll Rect Component (Slides Content Parent)
	public 		GameObject 						SlidesContent;											//Slides Parent
	public 		List<GameObject> 				Slides;													//Slides
	//========================================End Main Objects============================================

	//======================================Begin Scroll Settings=========================================
	public		bool							ScrollSettingsBlock;
	public 		scrolltype 						ScrollType;												//Scroll type is horizontal or vertical

	//-------------------------------------------------------------------------------Horizontal scroll bar
	public		bool 							ShowHorizontalScrollbar; 								//Enable or disable horizontal scrollbar
	public 		Scrollbar 						HorizontalScrollbar;									//Horizontal Scrollbar Object
	public 		slidesverticalalign 			SlidesVerticalAlign;									//Slide's Vertical Align

	//---------------------------------------------------------------------------------Vertical scroll bar
	public		bool 							ShowVerticalScrollbar;									//Enable or disable vertical scrollbar
	public 		Scrollbar 						VerticalScrollbar;										//Vertical Scrollbar Object
	public 		slideshorizontalalign 			SlidesHorizontalAlign;									//Slide's Horizontal Align

	//-----------------------------------------------------------------------------------Scroll With Arrow
	public		bool							ScrollWithArrowBlock;
	public 		bool 							ScrollWithArrow;										//Enable Scroll With Arrow Keys
	public 		bool 							LeftAndRight;											//Enable Scroll With Left And Right Arrow Keys
	public		bool							HorizontalArrowStepByStep;								//Step By Step
	public 		bool 							UpAndDown;												//Enable Scroll With Down And Up Arrow Keys
	public		bool							VerticalArrowStepByStep;								//Step By Step

	public		float							ArrowTransition	= 0.1f;									//Transition Value
	//---------------------------------------------------------------------------------Scroll With Buttons
	public		bool							ScrollWithButtonsBlock;
	public 		bool 							ScrollWithButtons 				= true;					//Enable Scroll With Buttons
	public 		GameObject 						ScrollButtons;											//Define Scroll Buttons Group Object

	//Previous Button
	private 	GameObject 						PreviousButtonObject;									//For Define Previous Button Object (Automatically)
	public 		Sprite 							PreviousButtonImage;									//Previous Button Image
	public 		previousbuttonhorizontalalign 	PreviousButtonHorizontalAlign;							//Previous Button's Horizontal Align
	public 		previousbuttonverticalalign 	PreviousButtonVerticalAlign;							//Previous Button's Vertical Align
	public 		Vector4 						PreviousButtonMargin;									//Previous Button's Margin
	private 	bool 							PreviousButtonActive			= true;					//If The First Slide Is Active Previous Button Will Disable

	//Next Button
	private 	GameObject 						NextButtonObject;										//For Define Next Button Object (Automatically)
	public 		Sprite 							NextButtonImage;										//Next Button Image
	public 		nextbuttonhorizontalalign 		NextButtonHorizontalAlign;								//Next Button's Horizontal Align
	public 		nextbuttonverticalalign 		NextButtonVerticalAlign;								//Next Button's Vertical Align
	public 		Vector4 						NextButtonMargin;										//Next Button's Margin
	private 	bool 							NextButtonActive				= true;					//If The Last Slide Is Active Next Button Will Disable

	public 		float 							ButtonTransition;										//Button's Transition

	//--------------------------------------------------------------------------------Slider Magnet Effect
	public 		bool 							SliderMagnet;											//Enable Slider Magnet Effect
	public 		float 							MagnetTransition;										//Transition For Slider Magnet Effect
	//=======================================End Scroll Settings==========================================



	//======================================Begin Slides Property=========================================
	public		bool							SlidesPropertyBlock;
	public 		int 							SlidesInView;											//Number Of Slides In View
	public 		bool 							DefaultOffset;											//Enable Default Offset For Active Slide
	public 		int 							ActiveSlideOffset;										//Define Active Slide Offset If Default Offset Is Disabled
	public 		Vector2 						SlideSize;												//Slide Size Vector (x For Width And y For Height)
	public 		Vector4 						SlideMargin;											//Slide Margin Vector(x For Margin Top, y For Margin Right, z For Margin Bottom, And w For Margin Left)
	//=======================================End Slides Property==========================================

	//=========================================Begin Animation============================================
	public		bool							AnimationBlock;
	//############################################################Begin Previous Slides Animation Settings
	//Position Animation
	public		bool							PreviousPositionAnimation;
	public 		float 							PreviousOffset;											
	public 		float 							PreviousOffsetTransition 	= 0.1f;						

	//Scale Animation
	public		bool							PreviousScaleAnimation;
	public 		Vector2 						PreviousScale				= new Vector2(1,1);			
	public 		float 							PreviousScaleTransition 	= 0.1f;						

	//Rotation Animation
	public		bool							PreviousRotateAnimation;
	public 		Vector3 						PreviousRotation			= new Vector3(1,1,1);		
	public 		float 							PreviousRotationTransition 	= 0.1f;						

	//Color Animation
	public		bool							PreviousColorAnimation;
	public 		Color 							PreviousColor				= new Color(1,1,1,255);		
	public 		float 							PreviousColorTransition 	= 0.1f;						

	//Blur Animation
	public		bool 							PreviousBlurAnimation;									
	public		Material						PreviousBlurMaterial;									
	public		float							PreviousBlurDistance		= 0.02f;					 
	public		float							PreviousBlurTransition		= 0.01f;					

	//Order
	public		int								PreviousSiblingIndex;									
	//##############################################################End Previous Slides Animation Settings


	//##############################################################Begin Active Slides Animation Settings
	//Position Animation
	public		bool							ActivePositionAnimation;
	public 		float 							ActiveOffset;											
	public 		float 							ActiveOffsetTransition 		= 0.1f;						

	//Scale Animation
	public		bool							ActiveScaleAnimation;
	public 		Vector2 						ActiveScale 				= new Vector2(1,1);			
	public 		float 							ActiveScaleTransition 		= 0.1f;						

	//Rotation Animation
	public		bool							ActiveRotateAnimation;
	public 		Vector3 						ActiveRotation				= new Vector3(1,1,1);		
	public 		float 							ActiveRotationTransition 	= 0.1f;						

	//Color Animation
	public		bool							ActiveColorAnimation;
	public 		Color 							ActiveColor					= new Color(1,1,1,255);		
	public 		float 							ActiveColorTransition		= 0.1f;						

	//Blur Animation
	public		bool 							ActiveBlurAnimation;									
	public		Material						ActiveBlurMaterial;										
	public		float							ActiveBlurDistance			= 0.02f;					
	public		float							ActiveBlurTransition		= 0.01f;					

	//Order
	public		int								ActiveSiblingIndex;										
	//################################################################End Active Slides Animation Settings

	//################################################################Begin Next Slides Animation Settings
	//Position Animation
	public		bool							NextPositionAnimation;
	public 		float 							NextOffset;											
	public 		float 							NextOffsetTransition 		= 0.1f;					

	//Scale Animation
	public		bool							NextScaleAnimation;
	public 		Vector2 						NextScale 					= new Vector2(1,1);		
	public 		float 							NextScaleTransition 		= 0.1f;					

	//Rotation Animation
	public		bool							NextRotateAnimation;
	public 		Vector3 						NextRotation				= new Vector3(1,1,1);	
	public 		float 							NextRotationTransition 		= 0.1f;					

	//Color Animation
	public		bool							NextColorAnimation;
	public 		Color 							NextColor					= new Color(1,1,1,255);	
	public 		float 							NextColorTransition			= 0.1f;					

	//Blur Animation
	public		bool 							NextBlurAnimation;									
	public		Material						NextBlurMaterial;									
	public		float							NextBlurDistance			= 0.02f;				
	public		float							NextBlurTransition			= 0.01f;				

	//Order
	public		int								NextSiblingIndex;									
	//##################################################################End Next Slides Animation Settings
	//==========================================End Animation=============================================


	//=====================================Begin Other Properties=========================================
	//Scroll Step
	private 	float 							n;														//Use For Calculate Scroll Step
	private 	float 							ScrollStep;												//Scroll Step Of Horizontal And Vertical Slider					
	private 	float 							k							= 0;
	private 	bool 							ButtonClicked				= false;
	//=======================================End Other Properties=========================================


	void Update () {
		//==================================Begin Calculate Scroll Step Value=================================
		n = Slides.Count-1;
		ScrollStep = 1/n;
		//===================================End Calculate Scroll Step Value==================================






		//====================================Begin Horizontal Slider Menu====================================
		if (ScrollType == scrolltype.Horizontal) { 

			//####################################Begin Change Resolution Settings For Slides In View Property
			SliderMenuCanvas.GetComponent<CanvasScaler> ().matchWidthOrHeight 	= 0;

			SliderMenuCanvas.GetComponent<CanvasScaler> ().referenceResolution 	= new Vector2 (
				(SlideSize.x + SlideMargin.y + SlideMargin.w) * SlidesInView,
				SliderMenuCanvas.GetComponent<CanvasScaler> ().referenceResolution.y
			);
			//######################################End Change Resolution Settings For Slides In View Property

			//########################################################################Begin Change Scroll Type
			//Horizontal Scroll Enable And Vertical Scroll Disable

			//Automatically Define Horizontal Scrollbar By "HorizontalScrollbar" Value.
			ScrollObject.GetComponent<ScrollRect> ().horizontalScrollbar 	= HorizontalScrollbar;


			if (ShowHorizontalScrollbar == true) {
				HorizontalScrollbar.gameObject.SetActive (true);
			} else {
				HorizontalScrollbar.gameObject.SetActive (false);
			}
			ScrollObject.GetComponent<ScrollRect> ().horizontal = true;
			ScrollObject.GetComponent<ScrollRect> ().vertical 				= false;
			VerticalScrollbar.gameObject.SetActive (false);
			//##########################################################################End Change Scroll Type

			//########################################################################Begin Change Slides Size
			SlidesContent.GetComponent<RectTransform> ().sizeDelta = new Vector2 (
				(Slides.Count + SlidesInView - 1) * (SlideSize.x + SlideMargin.y + SlideMargin.w),
				(SlideSize.y + SlideMargin.x + SlideMargin.z)
			);
			//##########################################################################End Change Slides Size

			//#####################################Begin Work On Previous Slides, Active Slide, And Next Slids
			for(int i=0;i<Slides.Count;i++){			//For Set All Slides
				Slides [i].GetComponent<RectTransform> ().sizeDelta = SlideSize;
				for(int j=0;j<Slides.Count;j++){		//For Conditions. Such As Previous Slides, Active Silde, Next Slides, And Others. For Other Conditions You Can Compare i and j.
					if (HorizontalScrollbar.GetComponent<Scrollbar> ().value > (ScrollStep / 2) + (i - 1) * ScrollStep && HorizontalScrollbar.GetComponent<Scrollbar> ().value <= Mathf.Clamp ((ScrollStep / 2) + i * ScrollStep, 0, 1)) {
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Active Slide
						if (j == i) {
							//------------------------------------------------------------------------Begin Position Animation
							if (ActivePositionAnimation) {
								if (SlidesVerticalAlign == slidesverticalalign.Top) {																										//If Slides Align To Top
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2,
											//Y
											Mathf.Lerp (
												Slides [j].GetComponent<RectTransform> ().localPosition.y, 																				//Current Position.y
												SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y - (ActiveScale.y) * (SlideSize.y / 2) - (SlideMargin.x) + ActiveOffset, 		//Target Position.y
												ActiveOffsetTransition																													//Transition Position.y
											),
											//Z
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											Mathf.Lerp (
												Slides [j].GetComponent<RectTransform> ().localPosition.y, 																				//Current Position.y
												SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y - (ActiveScale.y) * (SlideSize.y / 2) - (SlideMargin.x) + ActiveOffset, 		//Target Position.y
												ActiveOffsetTransition																													//Transition Position.y
											), 
											//Z
											10
										);
									}
								} else if (SlidesVerticalAlign == slidesverticalalign.Middle) {																								//If Slides Align To Middle
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											Mathf.Lerp (
												Slides [j].GetComponent<RectTransform> ().localPosition.y,																				//Current Position.y
												SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + ActiveOffset, 														//Target Position.y
												ActiveOffsetTransition																													//Transition Position.y
											),
											//Z
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											Mathf.Lerp (
												Slides [j].GetComponent<RectTransform> ().localPosition.y,																				//Current Position.y
												SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + ActiveOffset,															//Target Position.y 
												ActiveOffsetTransition																													//Transition Position.y
											), 
											//Z
											10);
									}
								} else if (SlidesVerticalAlign == slidesverticalalign.Bottom) {																								//If Slides Align To Bottom
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											Mathf.Lerp (
												Slides [j].GetComponent<RectTransform> ().localPosition.y, 																				//Current Position.y
												(ActiveScale.y) * (SlideSize.y / 2) + (SlideMargin.z) + ActiveOffset, 																	//Target Position.y
												ActiveOffsetTransition																													//Transition Position.y
											),
											//Z
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											Mathf.Lerp (
												Slides [j].GetComponent<RectTransform> ().localPosition.y, 																				//Current Position.y
												(ActiveScale.y) * (SlideSize.y / 2) + (SlideMargin.z) + ActiveOffset, 																	//Target Position.y
												ActiveOffsetTransition 																													//Transition Position.y
											), 
											//Z
											10 
										);
									}
								}
							} else {
								if (SlidesVerticalAlign == slidesverticalalign.Top) {																										//If Slides Align To Top
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2,
											//Y
											SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y - (ActiveScale.y) * (SlideSize.y / 2) - (SlideMargin.x) + ActiveOffset,
											//Z
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y - (ActiveScale.y) * (SlideSize.y / 2) - (SlideMargin.x) + ActiveOffset,
											//Z
											10
										);
									}
								} else if (SlidesVerticalAlign == slidesverticalalign.Middle) {																								//If Slides Align To Middle
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + ActiveOffset,
											//Z
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + ActiveOffset,
											//Z
											10);
									}
								} else if (SlidesVerticalAlign == slidesverticalalign.Bottom) {																								//If Slides Align To Bottom
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											(ActiveScale.y) * (SlideSize.y / 2) + (SlideMargin.z) + ActiveOffset,
											//Z
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											(ActiveScale.y) * (SlideSize.y / 2) + (SlideMargin.z) + ActiveOffset,
											//Z
											10 
										);
									}
								}
							}
							//--------------------------------------------------------------------------End Position Animation

							//---------------------------------------------------------------------------Begin Scale Animation
							if (ActiveScaleAnimation) {
								Slides [j].transform.localScale = Vector2.Lerp (Slides [j].transform.localScale, ActiveScale, ActiveScaleTransition);
							} else {
								Slides [j].transform.localScale = ActiveScale;
							}
							//-----------------------------------------------------------------------------End Scale Animation

							//------------------------------------------------------------------------Begin Rotation Animation
							Vector3 RotationVector = Slides[j].GetComponent<RectTransform> ().localEulerAngles;
							if (ActiveRotateAnimation) {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = Vector3.Lerp (RotationVector, ActiveRotation, ActiveRotationTransition); 
							} else {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = new Vector3 (ActiveRotation.x,ActiveRotation.y,ActiveRotation.z); 
							}
							//--------------------------------------------------------------------------End Rotation Animation

							//---------------------------------------------------------------------------Begin Color Animation
							if (ActiveColorAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = Vector4.Lerp (Slides [j].GetComponent<Image> ().color, ActiveColor, ActiveColorTransition);
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = Vector4.Lerp (Slides [j].GetComponent<RawImage> ().color,	ActiveColor, ActiveColorTransition);
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = ActiveColor;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = ActiveColor;
								}
							}
							//-----------------------------------------------------------------------------End Color Animation

							//----------------------------------------------------------------------------Begin Blur Animation
							if (ActiveBlurAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().material = ActiveBlurMaterial;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().material = ActiveBlurMaterial;
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().material = null;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().material = null;
								}
							}
							//------------------------------------------------------------------------------End Blur Animation


							//---------------------------------------------------------------Begin Set Sibilin Of Active Slide
							Slides [j].gameObject.transform.SetSiblingIndex(ActiveSiblingIndex);
							//-----------------------------------------------------------------End Set Sibilin Of Active Slide

							//------------------------------------------------Begin Enable Or Disable Previous And Next Button
							//If The First Slide Is Active, Previous Button Must Be Disable.
							//If The Last Slide Is Active, Next Button Must Be Disable.
							if (j == 0) {										//If The First Slide Is Active
								PreviousButtonActive 	= false;
							} else {
								PreviousButtonActive 	= true;
							}

							if (j == Slides.Count - 1) {						//If The Last Slide Is Active
								NextButtonActive 		= false;
							} else {
								NextButtonActive 		= true;
							}
							//--------------------------------------------------End Enable Or Disable Previous And Next Button
						}
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Active Slide


						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Previous Slides
						else if(j < i){
							//---------------------------------------------------------------Begin Previous Position Animation
							if (PreviousPositionAnimation) {
								if (SlidesVerticalAlign == slidesverticalalign.Top) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											Mathf.Lerp (
												Slides [j].GetComponent<RectTransform> ().localPosition.y, 
												SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y - (ActiveScale.y) * (SlideSize.y / 2) - (SlideMargin.x) + PreviousOffset, 
												PreviousOffsetTransition
											),
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											Mathf.Lerp (
												Slides [j].GetComponent<RectTransform> ().localPosition.y, 
												SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y - (ActiveScale.y) * (SlideSize.y / 2) - (SlideMargin.x) + PreviousOffset, 
												PreviousOffsetTransition
											),
											10
										);
									}
								} else if (SlidesVerticalAlign == slidesverticalalign.Middle) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.y, 
												SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + PreviousOffset, 
												PreviousOffsetTransition
											),
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.y, 
												SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + PreviousOffset, 
												PreviousOffsetTransition
											),
											10
										);
									}
								} else if (SlidesVerticalAlign == slidesverticalalign.Bottom) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.y, 
												(ActiveScale.y) * (SlideSize.y / 2) + (SlideMargin.z) + PreviousOffset, 
												PreviousOffsetTransition
											),
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.y, 
												(ActiveScale.y) * (SlideSize.y / 2) + (SlideMargin.z) + PreviousOffset, 
												PreviousOffsetTransition
											),
											10
										);
									}
								}
							} else {
								if (SlidesVerticalAlign == slidesverticalalign.Top) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y - (ActiveScale.y) * (SlideSize.y / 2) - (SlideMargin.x) + PreviousOffset,
											//Z
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y - (ActiveScale.y) * (SlideSize.y / 2) - (SlideMargin.x) + PreviousOffset, 
											//Z
											10
										);
									}
								} else if (SlidesVerticalAlign == slidesverticalalign.Middle) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + PreviousOffset, 
											//Z
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + PreviousOffset,
											//Z
											10
										);
									}
								} else if (SlidesVerticalAlign == slidesverticalalign.Bottom) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											(ActiveScale.y) * (SlideSize.y / 2) + (SlideMargin.z) + PreviousOffset,
											//Z
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											(ActiveScale.y) * (SlideSize.y / 2) + (SlideMargin.z) + PreviousOffset, 
											//Z
											10
										);
									}
								}
							}
							//-----------------------------------------------------------------End Previous Position Animation



							//------------------------------------------------------------------Begin Previous Scale Animation
							if (PreviousScaleAnimation) {
								Slides [j].transform.localScale = Vector2.Lerp (Slides [j].transform.localScale, PreviousScale, PreviousScaleTransition);
							} else {
								Slides [j].transform.localScale = PreviousScale;
							}
							//--------------------------------------------------------------------End Previous Scale Animation

							//------------------------------------------------------------------------Begin Rotation Animation
							Vector3 RotationVector = Slides[j].GetComponent<RectTransform>().localEulerAngles;
							if (PreviousRotateAnimation) {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = Vector3.Lerp (RotationVector, PreviousRotation, PreviousRotationTransition);
							} else {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = PreviousRotation;
							}
							//--------------------------------------------------------------------------End Rotation Animation

							//------------------------------------------------------------------Begin Previous Color Animation
							if (PreviousColorAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = Vector4.Lerp (Slides [j].GetComponent<Image> ().color, PreviousColor, PreviousColorTransition);
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = Vector4.Lerp (Slides [j].GetComponent<RawImage> ().color,	PreviousColor, PreviousColorTransition);
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = PreviousColor;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = PreviousColor;
								}
							}
							//--------------------------------------------------------------------End Previous Color Animation

							//-------------------------------------------------------------------Begin Previous Blur Animation
							if (PreviousBlurAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().material = PreviousBlurMaterial;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().material = PreviousBlurMaterial;
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().material = null;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().material = null;
								}
							}
							//---------------------------------------------------------------------End Previous Blur Animation

							//----------------------------------------------------------Begin Sibilin Index Of Previous Slides
							Slides [j].gameObject.transform.SetSiblingIndex(PreviousSiblingIndex);
							//------------------------------------------------------------End Sibilin Index Of Previous Slides

						}
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Previous Slides

						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Next Slides
						else if(j > i){
							//-------------------------------------------------------------------Begin Next Position Animation
							if (NextPositionAnimation) {
								if (SlidesVerticalAlign == slidesverticalalign.Top) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.y, 
												SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y - (ActiveScale.y) * (SlideSize.y / 2) - (SlideMargin.x) + NextOffset, NextOffsetTransition
											),
											//Z
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.y, 
												SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y - (ActiveScale.y) * (SlideSize.y / 2) - (SlideMargin.x) + NextOffset, 
												NextOffsetTransition
											),
											//Z
											10
										);
									}
								} else if (SlidesVerticalAlign == slidesverticalalign.Middle) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + NextOffset,
											//Z
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + NextOffset,
											//Z
											10
										);
									}
								} else if (SlidesVerticalAlign == slidesverticalalign.Bottom) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											(ActiveScale.y) * (SlideSize.y / 2) + (SlideMargin.z) + NextOffset,
											//Z
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2,
											//Y
											(ActiveScale.y) * (SlideSize.y / 2) + (SlideMargin.z) + NextOffset, 
											//Z
											10
										);
									}
								}
							} else {
								if (SlidesVerticalAlign == slidesverticalalign.Top) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y - (ActiveScale.y) * (SlideSize.y / 2) - (SlideMargin.x) + NextOffset,
											//Z
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y - (ActiveScale.y) * (SlideSize.y / 2) - (SlideMargin.x) + NextOffset,
											//Z
											10
										);
									}
								} else if (SlidesVerticalAlign == slidesverticalalign.Middle) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + NextOffset,
											//Z
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + NextOffset,
											//Z
											10
										);
									}
								} else if (SlidesVerticalAlign == slidesverticalalign.Bottom) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											((SlidesInView - 1) / 2) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2, 
											//Y
											(ActiveScale.y) * (SlideSize.y / 2) + (SlideMargin.z) + NextOffset,
											//Z
											10
										);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (
											//X
											(ActiveSlideOffset - 1) * (SlideSize.x + SlideMargin.w + SlideMargin.y) + (j + 1) * SlideMargin.w + (j) * (SlideMargin.y) + (2 * j + 1) * SlideSize.x / 2,
											//Y
											(ActiveScale.y) * (SlideSize.y / 2) + (SlideMargin.z) + NextOffset,
											//Z
											10
										);
									}
								}
							}
							//---------------------------------------------------------------------End Next Position Animation

							//----------------------------------------------------------------------Begin Next Scale Animation
							if (NextScaleAnimation) {
								Slides [j].transform.localScale = Vector2.Lerp (Slides [j].transform.localScale, NextScale, NextScaleTransition);
							} else {
								Slides [j].transform.localScale = NextScale;
							}
							//------------------------------------------------------------------------End Next Scale Animation

							//-------------------------------------------------------------------Begin Next Rotation Animation
							Vector3 RotationVector = Slides[j].GetComponent<RectTransform>().localEulerAngles;
							if (NextRotateAnimation) {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = Vector3.Lerp (RotationVector, NextRotation, NextRotationTransition);
							} else {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = NextRotation;
							}
							//---------------------------------------------------------------------End Next Rotation Animation

							//----------------------------------------------------------------------Begin Next Color Animation
							if (NextColorAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = Vector4.Lerp (Slides [j].GetComponent<Image> ().color, NextColor, NextColorTransition);
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = Vector4.Lerp (Slides [j].GetComponent<RawImage> ().color,	NextColor, NextColorTransition);
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = NextColor;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = NextColor;
								}
							}
							//------------------------------------------------------------------------End Next Color Animation

							//-----------------------------------------------------------------------Begin Next Blur Animation
							if (NextBlurAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().material = NextBlurMaterial;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().material = NextBlurMaterial;
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().material = null;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().material = null;
								}
							}
							//-------------------------------------------------------------------------End Next Blur Animation

							//--------------------------------------------------------------Begin Sibilin Index Of Next Slides
							Slides [j].gameObject.transform.SetSiblingIndex(NextSiblingIndex);
							//----------------------------------------------------------------End Sibilin Index Of Next Slides

						}
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Next Slides
					}
				}
			}
			//#######################################End Work On Previous Slides, Active Slide, And Next Slids


			//#############################################################################Begin Slider Magnet
			if (SliderMagnet) {
				if (!Input.GetMouseButton (0) || (Input.touchSupported && Input.touchCount == 0)) {				//If Not Drag (In Desktop And Mobile Platform)
					for (int s = 0; s < Slides.Count; s++) {
						if (HorizontalScrollbar.GetComponent<Scrollbar> ().value > (ScrollStep / 2) + (s - 1) * ScrollStep && HorizontalScrollbar.GetComponent<Scrollbar> ().value <= Mathf.Clamp ((ScrollStep / 2) + s * ScrollStep, 0, 1)) {
							HorizontalScrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp (
								HorizontalScrollbar.GetComponent<Scrollbar> ().value,							//Current Value
								s * ScrollStep,																	//Target Value
								MagnetTransition																//Transition For Magnet
							);
						}
					}
				}
			}
			//###############################################################################End Slider Magnet

			//###########################################Begin Left And Right Arrow For Previous And Next Step
			if (ScrollWithArrow) {
				//Scroll With Left And Right Arrow
				if (LeftAndRight) {
					if (HorizontalArrowStepByStep) {
						if (Input.GetKeyDown (KeyCode.LeftArrow)) {
							PreviousButton ();
						} 
						if (Input.GetKeyDown (KeyCode.RightArrow)) {
							NextButton ();
						}
					} else {
						if (Input.GetKey (KeyCode.LeftArrow)) {
							PreviousButton ();
						} 
						if (Input.GetKey (KeyCode.RightArrow)) {
							NextButton ();
						}
					}

					if (Input.GetMouseButton (0) || (Input.touchSupported && Input.touchCount == 0)) {		//If Not Drag (In Desktop And Mobile Platform)
						ButtonClicked = false;
					}

					//Change Scrollbar Value
					if (ButtonClicked == true) {
						HorizontalScrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp(
							HorizontalScrollbar.GetComponent<Scrollbar> ().value,							//Current Value
							k,																				//Target Value (Calculat From PreviousButton And NextButton Functions)
							ArrowTransition																	//Left And Right Arrow Transition
						);
					}
				}

				//Scroll With Down And Up Arrow
				if(UpAndDown){
					if (VerticalArrowStepByStep) {
						if (Input.GetKeyDown (KeyCode.DownArrow)) {
							PreviousButton ();
						} 
						if (Input.GetKeyDown (KeyCode.UpArrow)) {
							NextButton ();
						}
					} else {
						if (Input.GetKey (KeyCode.DownArrow)) {
							PreviousButton ();
						} 
						if (Input.GetKey (KeyCode.UpArrow)) {
							NextButton ();
						}
					}

					if (Input.GetMouseButton (0) || (Input.touchSupported && Input.touchCount == 0)) {
						ButtonClicked = false;
					}
					if (ButtonClicked == true) {
						HorizontalScrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp (
							HorizontalScrollbar.GetComponent<Scrollbar> ().value, 
							k,
							ArrowTransition
						);
					}
				}
			}
			//#############################################End Left And Right Arrow For Previous And Next Step

			//##################################################################Begin Previous And Next Button
			if (ScrollWithButtons == true) {
				ScrollButtons.SetActive (true);								//Show Previous And Next Button Object

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Find Button Objects
				PreviousButtonObject 										= GameObject.Find (ScrollButtons.name + "/Previous");		//Find Previous Button Object
				NextButtonObject 											= GameObject.Find (ScrollButtons.name + "/Next");			//Find Next Button Object
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Find Button Objects

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Define Button's Image
				PreviousButtonObject.GetComponent<Image> ().sprite 			= PreviousButtonImage;										//Define Previous Button's Image
				NextButtonObject.GetComponent<Image> ().sprite 				= NextButtonImage;											//Define Next Button's Image
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Define Button's Image

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Enable Or Diable Buttons
				//More: You Can Go To Active Slide Setting (When j==i) And See PreviousButtonActive And NextButtonActive Parameter
				PreviousButtonObject.GetComponent<Button> ().interactable 	= PreviousButtonActive;										//Enable Previous Button
				NextButtonObject.GetComponent<Button> ().interactable 		= NextButtonActive;											//Enable Next Button

				if (Input.GetMouseButton (0) || (Input.touchSupported && Input.touchCount == 0)) {
					ButtonClicked = false;
				}
				if (ButtonClicked == true) {
					HorizontalScrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp (
						HorizontalScrollbar.GetComponent<Scrollbar> ().value, 
						k,
						ButtonTransition
					);
				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Enable Or Diable Buttons

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Previous Button Position
				if (PreviousButtonVerticalAlign == previousbuttonverticalalign.Top) {
					if(PreviousButtonHorizontalAlign == previousbuttonhorizontalalign.Left){
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2 + 
							Mathf.Clamp (
								PreviousButtonMargin.w,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2
							),
							//Y
							SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2-Mathf.Clamp (PreviousButtonMargin.x,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2)
						);
					} else if(PreviousButtonHorizontalAlign == previousbuttonhorizontalalign.Center){
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							0,
							//Y
							SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2 - 
							Mathf.Clamp (
								PreviousButtonMargin.x,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2
							)
						);
					} else if(PreviousButtonHorizontalAlign == previousbuttonhorizontalalign.Right){
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2 - 
							Mathf.Clamp (
								PreviousButtonMargin.y,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2
							),
							//Y
							SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2 - 
							Mathf.Clamp (
								PreviousButtonMargin.x,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2
							)
						);
					}
				} 
				else if (PreviousButtonVerticalAlign == previousbuttonverticalalign.Middle) {
					if(PreviousButtonHorizontalAlign == previousbuttonhorizontalalign.Left){
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2 + 
							Mathf.Clamp (
								PreviousButtonMargin.w,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2
							), 
							//Y
							0
						);
					} else if(PreviousButtonHorizontalAlign == previousbuttonhorizontalalign.Center){
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (0, 0);
					} else if(PreviousButtonHorizontalAlign == previousbuttonhorizontalalign.Right){
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2 - 
							Mathf.Clamp (
								PreviousButtonMargin.y,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2
							),
							//Y
							0
						);
					}
				}
				else if (PreviousButtonVerticalAlign == previousbuttonverticalalign.Bottom) {
					if(PreviousButtonHorizontalAlign == previousbuttonhorizontalalign.Left){
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2 + 
							Mathf.Clamp (
								PreviousButtonMargin.w,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2
							),
							//Y
							-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2 + 
							Mathf.Clamp (
								PreviousButtonMargin.z,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2
							)
						);
					} else if(PreviousButtonHorizontalAlign == previousbuttonhorizontalalign.Center){
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							0,
							//Y
							-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2 + 
							Mathf.Clamp (
								PreviousButtonMargin.z,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2
							)
						);
					} else if(PreviousButtonHorizontalAlign == previousbuttonhorizontalalign.Right){
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2 - 
							Mathf.Clamp (
								PreviousButtonMargin.y,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2
							), 
							//Y
							-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2 + 
							Mathf.Clamp (
								PreviousButtonMargin.z,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2
							)
						);
					}

				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Previous Button Position

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Next Button Position
				if (NextButtonVerticalAlign == nextbuttonverticalalign.Top) {
					if(NextButtonHorizontalAlign == nextbuttonhorizontalalign.Left){
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + NextButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2 + 
							Mathf.Clamp (
								NextButtonMargin.w,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2
							), 
							//Y
							SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 - NextButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2 -
							Mathf.Clamp (
								NextButtonMargin.x,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2
							)
						);
					} else if(NextButtonHorizontalAlign == nextbuttonhorizontalalign.Center){
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							0, 
							//Y
							SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 - NextButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2 - 
							Mathf.Clamp (
								NextButtonMargin.x,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2
							)
						);
					} else if(NextButtonHorizontalAlign == nextbuttonhorizontalalign.Right){
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 - NextButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2 - 
							Mathf.Clamp (
								NextButtonMargin.y,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2
							),
							//Y
							SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 - NextButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2 - 
							Mathf.Clamp (
								NextButtonMargin.x,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2
							)
						);
					}
				} 
				else if (NextButtonVerticalAlign == nextbuttonverticalalign.Middle) {
					if(NextButtonHorizontalAlign == nextbuttonhorizontalalign.Left){
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + NextButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2 + 
							//Y
							Mathf.Clamp (
								NextButtonMargin.w,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2
							),
							0
						);
					} else if(NextButtonHorizontalAlign == nextbuttonhorizontalalign.Center){
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (0, 0);
					} else if(NextButtonHorizontalAlign == nextbuttonhorizontalalign.Right){
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 - NextButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2 - 
							Mathf.Clamp (
								NextButtonMargin.y,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2
							),
							//Y
							0
						);
					}
				}
				else if (NextButtonVerticalAlign == nextbuttonverticalalign.Bottom) {
					if(NextButtonHorizontalAlign == nextbuttonhorizontalalign.Left){
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + NextButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2 + 
							Mathf.Clamp (
								NextButtonMargin.w,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2
							),
							//Y
							-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + NextButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2 + 
							Mathf.Clamp (
								NextButtonMargin.z,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2
							)
						);
					}else if(NextButtonHorizontalAlign == nextbuttonhorizontalalign.Center){
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							0,
							//Y
							-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + NextButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2 + 
							Mathf.Clamp (
								NextButtonMargin.z,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2
							)
						);
					}else if(NextButtonHorizontalAlign == nextbuttonhorizontalalign.Right){
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (
							//X
							SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 - NextButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2 - 
							Mathf.Clamp (
								NextButtonMargin.y,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2
							),
							//Y
							-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + NextButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2 + 
							Mathf.Clamp (
								NextButtonMargin.z,
								0,
								SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2
							)
						);
					}
				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Next Button Position
			} else {
				ScrollButtons.SetActive (false);			//Hide Previous And Next Button Object
			}
			//####################################################################End Previous And Next Button
		}
		//=====================================End Horizontal Slider Menu=====================================




		//=====================================Begin Vertical Slider Menu=====================================
		else if(ScrollType==scrolltype.Vertical){
			//####################################Begin Change Resolution Settings For Slides In View Property
			SliderMenuCanvas.GetComponent<CanvasScaler> ().matchWidthOrHeight 	= 1;
			SliderMenuCanvas.GetComponent<CanvasScaler> ().referenceResolution 	= new Vector2 (
				SliderMenuCanvas.GetComponent<CanvasScaler> ().referenceResolution.x,
				(SlideSize.y+SlideMargin.x+SlideMargin.z)*SlidesInView
			);
			//######################################End Change Resolution Settings For Slides In View Property

			//########################################################################Begin Change Scroll Type
			//Vertical Scroll Enable And Horizontal Scroll Disable

			//Automatically Define Vertical Scrollbar By "VerticalScrollbar" Value.
			ScrollObject.GetComponent<ScrollRect> ().verticalScrollbar = VerticalScrollbar;

			if (ShowVerticalScrollbar == true) {
				VerticalScrollbar.gameObject.SetActive (true);
			} else {
				VerticalScrollbar.gameObject.SetActive (false);
			}
			ScrollObject.GetComponent<ScrollRect> ().vertical = true;
			ScrollObject.GetComponent<ScrollRect> ().horizontal = false;
			HorizontalScrollbar.gameObject.SetActive (false);

			//##########################################################################End Change Scroll Type

			//########################################################################Begin Change Slides Size
			if (DefaultOffset) {
				SlidesContent.GetComponent<RectTransform> ().sizeDelta = new Vector2 (SlideSize.x+SlideMargin.y+SlideMargin.w,(Slides.Count+SlidesInView-1)*(SlideSize.y+SlideMargin.x+SlideMargin.z));
			} else {
				SlidesContent.GetComponent<RectTransform> ().sizeDelta = new Vector2 (SlideSize.x+SlideMargin.y+SlideMargin.w,(Slides.Count+SlidesInView-1)*(SlideSize.y+SlideMargin.x+SlideMargin.z));
			}
			//##########################################################################End Change Slides Size

			//#####################################Begin Work On Previous Slides, Active Slide, And Next Slids
			for(int i=0;i<Slides.Count;i++){
				Slides [i].GetComponent<RectTransform> ().sizeDelta = SlideSize;
				for(int j=0;j<Slides.Count;j++){
					if (VerticalScrollbar.GetComponent<Scrollbar> ().value > (ScrollStep / 2) + (i - 1) * ScrollStep && VerticalScrollbar.GetComponent<Scrollbar> ().value <= Mathf.Clamp ((ScrollStep / 2) + i * ScrollStep, 0, 1)) {
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Active Slide
						if (j == i) {
							//------------------------------------------------------------------------Begin Position Animation
							if (ActivePositionAnimation) {
								if (SlidesHorizontalAlign == slideshorizontalalign.Left) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, (ActiveScale.x) * (SlideSize.x / 2) + (SlideMargin.w) + ActiveOffset, ActiveOffsetTransition), ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (i) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, (ActiveScale.x) * (SlideSize.x / 2) + (SlideMargin.w) + ActiveOffset, ActiveOffsetTransition), (ActiveSlideOffset - 1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (i) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									}
								} else if (SlidesHorizontalAlign == slideshorizontalalign.Center) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + ActiveOffset, ActiveOffsetTransition), ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition =	new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + ActiveOffset, ActiveOffsetTransition), (ActiveSlideOffset - 1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									}
								} else if (SlidesHorizontalAlign == slideshorizontalalign.Right) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x - (ActiveScale.x) * (SlideSize.x / 2) - (SlideMargin.y) + ActiveOffset, ActiveOffsetTransition), ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x - (ActiveScale.x) * (SlideSize.x / 2) - (SlideMargin.y) + ActiveOffset, ActiveOffsetTransition), (ActiveSlideOffset - 1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									}
								}
							} else {
								if (SlidesHorizontalAlign == slideshorizontalalign.Left) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 ((ActiveScale.x) * (SlideSize.x / 2) + (SlideMargin.w) + ActiveOffset, ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (i) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 ((ActiveScale.x) * (SlideSize.x / 2) + (SlideMargin.w) + ActiveOffset, (ActiveSlideOffset - 1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (i) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									}
								} else if (SlidesHorizontalAlign == slideshorizontalalign.Center) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + ActiveOffset, ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition =	new Vector3 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + ActiveOffset, (ActiveSlideOffset - 1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									}
								} else if (SlidesHorizontalAlign == slideshorizontalalign.Right) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x - (ActiveScale.x) * (SlideSize.x / 2) - (SlideMargin.y) + ActiveOffset, ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x - (ActiveScale.x) * (SlideSize.x / 2) - (SlideMargin.y) + ActiveOffset, (ActiveSlideOffset - 1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									}
								}
							}
							//--------------------------------------------------------------------------End Position Animation

							//---------------------------------------------------------------------------Begin Scale Animation
							if (ActiveScaleAnimation) {
								Slides [j].transform.localScale = Vector2.Lerp (Slides [j].transform.localScale, ActiveScale, ActiveScaleTransition);
							} else {
								Slides [j].transform.localScale = ActiveScale;
							}
							//-----------------------------------------------------------------------------End Scale Animation

							//------------------------------------------------------------------------Begin Rotation Animation
							Vector3 RotationVector = Slides[j].GetComponent<RectTransform>().localEulerAngles;
							if (ActiveRotateAnimation) {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = Vector3.Lerp (RotationVector, ActiveRotation, ActiveRotationTransition); 
							} else {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = ActiveRotation; 
							}
							//--------------------------------------------------------------------------End Rotation Animation

							//---------------------------------------------------------------------------Begin Color Animation
							if (ActiveColorAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = Vector4.Lerp (Slides [j].GetComponent<Image> ().color, ActiveColor, ActiveColorTransition);
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = Vector4.Lerp (Slides [j].GetComponent<RawImage> ().color,	ActiveColor, ActiveColorTransition);
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = ActiveColor;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = ActiveColor;
								}
							}
							//-----------------------------------------------------------------------------End Color Animation

							//----------------------------------------------------------------------------Begin Blur Animation
							if (ActiveBlurAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().material = ActiveBlurMaterial;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().material = ActiveBlurMaterial;
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().material = null;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().material = null;
								}
							}
							//------------------------------------------------------------------------------End Blur Animation

							//------------------------------------------------------------Begin Sibilin Index Of Active Slides
							Slides [j].gameObject.transform.SetSiblingIndex(ActiveSiblingIndex);
							//--------------------------------------------------------------End Sibilin Index Of Active Slides

							if (j == 0) {
								PreviousButtonActive 	= false;
							} else {
								PreviousButtonActive 	= true;
							}
							if (j == Slides.Count - 1) {
								NextButtonActive 		= false;
							} else {
								NextButtonActive 		= true;
							}

						}
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Active Slide

						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Previous Slides
						else if(j<i){
							//------------------------------------------------------------------------Begin Position Animation
							if (PreviousPositionAnimation) {
								if (SlidesHorizontalAlign == slideshorizontalalign.Left) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, (ActiveScale.x) * (SlideSize.x / 2) + (SlideMargin.w) + PreviousOffset, PreviousOffsetTransition), ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (i) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, (ActiveScale.x) * (SlideSize.x / 2) + (SlideMargin.w) + PreviousOffset, PreviousOffsetTransition), (ActiveSlideOffset - 1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (i) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									}
								} else if (SlidesHorizontalAlign == slideshorizontalalign.Center) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + PreviousOffset, PreviousOffsetTransition), ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition =	new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + PreviousOffset, PreviousOffsetTransition), (ActiveSlideOffset - 1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									}
								} else if (SlidesHorizontalAlign == slideshorizontalalign.Right) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x - (ActiveScale.x) * (SlideSize.x / 2) - (SlideMargin.y) + PreviousOffset, PreviousOffsetTransition), ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x - (ActiveScale.x) * (SlideSize.x / 2) - (SlideMargin.y) + PreviousOffset, PreviousOffsetTransition), (ActiveSlideOffset - 1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									}
								}
							} else {
								if (SlidesHorizontalAlign == slideshorizontalalign.Left) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 ((ActiveScale.x) * (SlideSize.x / 2) + (SlideMargin.w) + PreviousOffset, ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (i) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 ((ActiveScale.x) * (SlideSize.x / 2) + (SlideMargin.w) + PreviousOffset, (ActiveSlideOffset - 1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (i) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									}
								} else if (SlidesHorizontalAlign == slideshorizontalalign.Center) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + PreviousOffset, ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition =	new Vector3 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + PreviousOffset, (ActiveSlideOffset - 1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									}
								} else if (SlidesHorizontalAlign == slideshorizontalalign.Right) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x - (ActiveScale.x) * (SlideSize.x / 2) - (SlideMargin.y) + PreviousOffset, ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x - (ActiveScale.x) * (SlideSize.x / 2) - (SlideMargin.y) + PreviousOffset, (ActiveSlideOffset - 1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									}
								}
							}
							//--------------------------------------------------------------------------End Position Animation

							//---------------------------------------------------------------------------Begin Scale Animation
							if (PreviousScaleAnimation) {
								Slides [j].transform.localScale = Vector2.Lerp (Slides [j].transform.localScale, PreviousScale, PreviousScaleTransition);
							} else {
								Slides [j].transform.localScale = PreviousScale;
							}
							//-----------------------------------------------------------------------------End Scale Animation

							//---------------------------------------------------------------------------Begin Rotation Animation
							if (PreviousRotateAnimation) {
								Vector3 RotationVector=Slides[j].GetComponent<RectTransform>().localEulerAngles;
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = Vector3.Lerp (RotationVector, PreviousRotation, PreviousRotationTransition);
							} else {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = PreviousRotation;
							}
							//-----------------------------------------------------------------------------End Rotation Animation

							//------------------------------------------------------------------------------Begin Color Animation
							if (PreviousColorAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = Vector4.Lerp (Slides [j].GetComponent<Image> ().color, PreviousColor, PreviousColorTransition);
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = Vector4.Lerp (Slides [j].GetComponent<RawImage> ().color,	PreviousColor, PreviousColorTransition);
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = PreviousColor;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = PreviousColor;
								}
							}
							//--------------------------------------------------------------------------------End Color Animation

							//-------------------------------------------------------------------------------Begin Blur Animation
							if (PreviousBlurAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().material = PreviousBlurMaterial;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().material = PreviousBlurMaterial;
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().material = null;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().material = null;
								}
							}
							//---------------------------------------------------------------------------------End Blur Animation

							//---------------------------------------------------------------Begin Sibilin Index Of Active Slides
							Slides [j].gameObject.transform.SetSiblingIndex(PreviousSiblingIndex);
							//-----------------------------------------------------------------End Sibilin Index Of Active Slides

						}
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Previous Slides

						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Next Slides
						else if(j>i){
							//---------------------------------------------------------------------------Begin Position Animation
							if (NextPositionAnimation) {
								if (SlidesHorizontalAlign == slideshorizontalalign.Left) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, (ActiveScale.x) * (SlideSize.x / 2) + (SlideMargin.w) + NextOffset, NextOffsetTransition), ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (i) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, (ActiveScale.x) * (SlideSize.x / 2) + (SlideMargin.w) + NextOffset, NextOffsetTransition), (ActiveSlideOffset - 1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (i) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									}
								} else if (SlidesHorizontalAlign == slideshorizontalalign.Center) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + NextOffset, NextOffsetTransition), ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition =	new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + NextOffset, NextOffsetTransition), (ActiveSlideOffset - 1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									}
								} else if (SlidesHorizontalAlign == slideshorizontalalign.Right) {
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x - (ActiveScale.x) * (SlideSize.x / 2) - (SlideMargin.y) + NextOffset, NextOffsetTransition), ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									} else {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (Mathf.Lerp (Slides [j].GetComponent<RectTransform> ().localPosition.x, SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x - (ActiveScale.x) * (SlideSize.x / 2) - (SlideMargin.y) + NextOffset, NextOffsetTransition), (ActiveSlideOffset - 1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2, 10);
									}
								}
							} else {
								if (SlidesHorizontalAlign==slideshorizontalalign.Left) {
									if (DefaultOffset) {
										Slides[j].GetComponent<RectTransform>().localPosition= new Vector3((ActiveScale.x)*(SlideSize.x/2)+(SlideMargin.w)+NextOffset,((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (i) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2,10);
									} else {
										Slides[j].GetComponent<RectTransform>().localPosition= new Vector3((ActiveScale.x)*(SlideSize.x/2)+(SlideMargin.w)+NextOffset,(ActiveSlideOffset-1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (i) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2,10);
									}
								}
								else if(SlidesHorizontalAlign==slideshorizontalalign.Center){
									if (DefaultOffset) {
										Slides[j].GetComponent<RectTransform>().localPosition = new Vector3 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2+NextOffset, ((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2,10);
									} else {
										Slides[j].GetComponent<RectTransform>().localPosition =	new Vector3 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2+NextOffset, (ActiveSlideOffset-1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2,10);
									}
								}
								else if(SlidesHorizontalAlign==slideshorizontalalign.Right){
									if (DefaultOffset) {
										Slides [j].GetComponent<RectTransform> ().localPosition = new Vector3 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x - (ActiveScale.x) * (SlideSize.x / 2) - (SlideMargin.y) + NextOffset,((SlidesInView - 1) / 2) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2,10);
									} else {
										Slides[j].GetComponent<RectTransform>().localPosition= new Vector3 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x - (ActiveScale.x) * (SlideSize.x / 2) - (SlideMargin.y) + NextOffset,(ActiveSlideOffset-1) * (SlideSize.y + SlideMargin.z + SlideMargin.x) + (j + 1) * SlideMargin.z + (j) * (SlideMargin.x) + (2 * j + 1) * SlideSize.y / 2,10);
									}
								}
							}
							//-----------------------------------------------------------------------------End Position Animation

							//---------------------------------------------------------------------------Begin Scale Animation
							if (NextScaleAnimation) {
								Slides [j].transform.localScale = Vector2.Lerp (Slides [j].transform.localScale, NextScale, NextScaleTransition);
							} else {
								Slides [j].transform.localScale = NextScale;
							}
							//-----------------------------------------------------------------------------End Scale Animation

							//---------------------------------------------------------------------------Begin Rotation Animation
							if (NextRotateAnimation) {
								Vector3 RotationVector=Slides[j].GetComponent<RectTransform>().localEulerAngles;
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = Vector3.Lerp (RotationVector, NextRotation, NextRotationTransition);
							} else {
								Slides [j].GetComponent<RectTransform> ().localEulerAngles = NextRotation;
							}
							//-----------------------------------------------------------------------------End Rotation Animation

							//------------------------------------------------------------------------------Begin Color Animation
							if (NextColorAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = Vector4.Lerp (Slides [j].GetComponent<Image> ().color, NextColor, NextColorTransition);
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = Vector4.Lerp (Slides [j].GetComponent<RawImage> ().color,	NextColor, NextColorTransition);
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().color = NextColor;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().color = NextColor;
								}
							}
							//--------------------------------------------------------------------------------End Color Animation

							//-------------------------------------------------------------------------------Begin Blur Animation
							if (NextBlurAnimation) {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().material = NextBlurMaterial;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().material = NextBlurMaterial;
								}
							} else {
								if (Slides [j].GetComponent<Image> ()) {
									Slides [j].GetComponent<Image> ().material = null;
								} else if (Slides [j].GetComponent<RawImage> ()) {
									Slides [j].GetComponent<RawImage> ().material = null;
								}
							}
							//---------------------------------------------------------------------------------End Blur Animation

							//---------------------------------------------------------------Begin Sibilin Index Of Active Slides
							Slides [j].gameObject.transform.SetSiblingIndex(NextSiblingIndex);
							//-----------------------------------------------------------------End Sibilin Index Of Active Slides

						}
						//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Next Slides
					}
				}
			}
			//#######################################End Work On Previous Slides, Active Slide, And Next Slids


			//#############################################################################Begin Slider Magnet
			if (SliderMagnet) {
				if (!Input.GetMouseButton (0) || (Input.touchSupported && Input.touchCount == 0)) {
					for (int s = 0; s < Slides.Count; s++) {
						if (VerticalScrollbar.GetComponent<Scrollbar> ().value > (ScrollStep / 2) + (s - 1) * ScrollStep && VerticalScrollbar.GetComponent<Scrollbar> ().value <= Mathf.Clamp ((ScrollStep / 2) + s * ScrollStep, 0, 1)) {
							VerticalScrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp (
								VerticalScrollbar.GetComponent<Scrollbar> ().value, 
								s * ScrollStep,
								MagnetTransition
							);
						}
					}
				}
			}
			//###############################################################################End Slider Magnet


			//##############################################Begin Down And Up Arrow For Previous And Next Step
			if (ScrollWithArrow) {
				if (LeftAndRight) {
					if (HorizontalArrowStepByStep) {
						if (Input.GetKeyDown (KeyCode.LeftArrow)) {
							PreviousButton ();
						} 
						if (Input.GetKeyDown (KeyCode.RightArrow)) {
							NextButton ();
						}
					} else {
						if (Input.GetKey (KeyCode.LeftArrow)) {
							PreviousButton ();
						} 
						if (Input.GetKey (KeyCode.RightArrow)) {
							NextButton ();
						}
					}

					if (Input.GetMouseButton (0) || (Input.touchSupported && Input.touchCount == 0)) {
						ButtonClicked = false;
					}
					if (ButtonClicked == true) {
						VerticalScrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp(
							VerticalScrollbar.GetComponent<Scrollbar> ().value, 
							k, 
							ArrowTransition
						);
					}
				}
				if(UpAndDown){
					if (Input.GetKeyDown (KeyCode.DownArrow)) {
						PreviousButton ();
					} 
					if (Input.GetKeyDown (KeyCode.UpArrow)) {
						NextButton ();
					}
					if (Input.GetMouseButton (0) || (Input.touchSupported && Input.touchCount == 0)) {
						ButtonClicked = false;
					}
					if (ButtonClicked == true) {
						VerticalScrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp (
							VerticalScrollbar.GetComponent<Scrollbar> ().value, 
							k,
							ArrowTransition
						);
					}
				}
			}
			//################################################End Down And Up Arrow For Previous And Next Step


			//##################################################################Begin Previous And Next Button
			if (ScrollWithButtons == true) {
				ScrollButtons.SetActive (true);

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Find Button Objects
				PreviousButtonObject = GameObject.Find (ScrollButtons.name + "/Previous");
				NextButtonObject = GameObject.Find (ScrollButtons.name + "/Next");
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Find Button Objects

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Define Button's Image
				PreviousButtonObject.GetComponent<Image> ().sprite = PreviousButtonImage;
				NextButtonObject.GetComponent<Image> ().sprite = NextButtonImage;
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Define Button's Image

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Enable Or Diable Buttons
				//More: You Can Go To Active Slide Setting (When j==i) And See PreviousButtonActive And NextButtonActive Parameter
				PreviousButtonObject.GetComponent<Button> ().interactable = PreviousButtonActive;
				NextButtonObject.GetComponent<Button> ().interactable = NextButtonActive;

				if (Input.GetMouseButton (0) || (Input.touchSupported && Input.touchCount == 0)) {
					ButtonClicked = false;
				}
				if (ButtonClicked == true) {
					VerticalScrollbar.GetComponent<Scrollbar> ().value = Mathf.Lerp(
						VerticalScrollbar.GetComponent<Scrollbar> ().value, 
						k, 
						ButtonTransition
					);
				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Enable Or Diable Buttons

				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Previous Button Position
				if (PreviousButtonHorizontalAlign == previousbuttonhorizontalalign.Left) {
					if (PreviousButtonVerticalAlign == previousbuttonverticalalign.Top) {
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2+Mathf.Clamp (PreviousButtonMargin.w,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2), SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2-Mathf.Clamp (PreviousButtonMargin.x,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2));
					}else if (PreviousButtonVerticalAlign == previousbuttonverticalalign.Middle) {
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2+Mathf.Clamp (PreviousButtonMargin.w,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2),0);
					}else if (PreviousButtonVerticalAlign == previousbuttonverticalalign.Bottom) {
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2+Mathf.Clamp (PreviousButtonMargin.w,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2), -SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2+Mathf.Clamp (PreviousButtonMargin.z,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2));
					}
				} 
				else if (PreviousButtonHorizontalAlign == previousbuttonhorizontalalign.Center) {
					if (PreviousButtonVerticalAlign == previousbuttonverticalalign.Top) {
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (0 , SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2-Mathf.Clamp (PreviousButtonMargin.x,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2));
					}else if (PreviousButtonVerticalAlign == previousbuttonverticalalign.Middle) {
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (0 , 0);
					}else if (PreviousButtonVerticalAlign == previousbuttonverticalalign.Bottom) {
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (0 , -SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2+Mathf.Clamp (PreviousButtonMargin.z,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2));
					}
				}
				else if (PreviousButtonHorizontalAlign == previousbuttonhorizontalalign.Right) {
					if (PreviousButtonVerticalAlign == previousbuttonverticalalign.Top) {
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2-Mathf.Clamp (PreviousButtonMargin.y,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2), SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2-Mathf.Clamp (PreviousButtonMargin.x,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2));
					}else if (PreviousButtonVerticalAlign == previousbuttonverticalalign.Middle) {
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2-Mathf.Clamp (PreviousButtonMargin.y,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2), 0);
					}else if (PreviousButtonVerticalAlign == previousbuttonverticalalign.Bottom) {
						PreviousButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 - PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2-Mathf.Clamp (PreviousButtonMargin.y,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2), -SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2+Mathf.Clamp (PreviousButtonMargin.z,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2));
					}
				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Previous Button Position


				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>Begin Next Button Position
				if (NextButtonHorizontalAlign == nextbuttonhorizontalalign.Left) {
					if (NextButtonVerticalAlign == nextbuttonverticalalign.Top) {
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + NextButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2+Mathf.Clamp (NextButtonMargin.w,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2), SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 - NextButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2-Mathf.Clamp (NextButtonMargin.x,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2));
					}else if (NextButtonVerticalAlign == nextbuttonverticalalign.Middle) {
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + NextButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2+Mathf.Clamp (NextButtonMargin.w,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2),0);
					}else if (NextButtonVerticalAlign == nextbuttonverticalalign.Bottom) {
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (-SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 + NextButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2+Mathf.Clamp (NextButtonMargin.w,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2), -SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + NextButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2+Mathf.Clamp (NextButtonMargin.z,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2));
					}
				} 
				else if (NextButtonHorizontalAlign == nextbuttonhorizontalalign.Center) {
					if (NextButtonVerticalAlign == nextbuttonverticalalign.Top) {
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (0 , SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 - NextButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2-Mathf.Clamp (NextButtonMargin.x,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2));
					}else if (NextButtonVerticalAlign == nextbuttonverticalalign.Middle) {
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (0 , 0);
					}else if (NextButtonVerticalAlign == nextbuttonverticalalign.Bottom) {
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (0 , -SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + NextButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2+Mathf.Clamp (NextButtonMargin.z,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2));
					}
				}
				else if (NextButtonHorizontalAlign == nextbuttonhorizontalalign.Right) {
					if (NextButtonVerticalAlign == nextbuttonverticalalign.Top) {
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 - NextButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2-Mathf.Clamp (NextButtonMargin.y,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2), SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 - NextButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2-Mathf.Clamp (NextButtonMargin.x,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2));
					}else if (NextButtonVerticalAlign == nextbuttonverticalalign.Middle) {
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 - NextButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2-Mathf.Clamp (NextButtonMargin.y,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2), 0);
					}else if (NextButtonVerticalAlign == nextbuttonverticalalign.Bottom) {
						NextButtonObject.GetComponent<RectTransform> ().localPosition = new Vector2 (SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.x / 2 - NextButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2-Mathf.Clamp (NextButtonMargin.y,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.x/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.x / 2), -SliderMenuCanvas.GetComponent<RectTransform> ().sizeDelta.y / 2 + NextButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2+Mathf.Clamp (NextButtonMargin.z,0,SliderMenuCanvas.GetComponent<RectTransform>().sizeDelta.y/2-PreviousButtonObject.GetComponent<RectTransform> ().sizeDelta.y / 2));
					}
				}
				//>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>End Next Button Position

			} else {
				ScrollButtons.SetActive (false);
			}
			//####################################################################End Previous And Next Button
		}
		//======================================End Vertical Slider Menu======================================

	}


	//....................................Begin Next Button's Function....................................
	public void NextButton(){
		if(ScrollType==scrolltype.Horizontal){
			k = HorizontalScrollbar.GetComponent<Scrollbar> ().value;
		}
		else if(ScrollType==scrolltype.Vertical){
			k = VerticalScrollbar.GetComponent<Scrollbar> ().value;
		}
		k = Mathf.Clamp (k+ScrollStep,0,1);
		ButtonClicked = true;
	}
	//.....................................End Next Button's Function.....................................

	//..................................Begin Previous Button's Function..................................
	public void PreviousButton(){
		if(ScrollType==scrolltype.Horizontal){
			k = HorizontalScrollbar.GetComponent<Scrollbar> ().value;
		}
		else if(ScrollType==scrolltype.Vertical){
			k = VerticalScrollbar.GetComponent<Scrollbar> ().value;
		}
		k = Mathf.Clamp (k-ScrollStep,0,1);
		ButtonClicked = true;
	}
	//...................................End Previous Button's Function...................................

}
