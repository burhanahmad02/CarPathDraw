using UnityEngine;
using System.Collections;

public class EngineSound : MonoBehaviour {
	private static EngineSound instance;
	public static EngineSound Instance
	{
		get
		{
			return instance;
		}
	}
	void Awake()
	{
		instance = this;
		carSound = GetComponent<AudioSource>();
		wj = GetComponent<WheelJoint2D>();
	}
	//audiosource reference
	private AudioSource carSound;
	
	//the range for audio source pitch
	private const float lowPtich = 0.5f;
	private const float highPitch = 5f;
	
	//change the reductionFactor to 0.1f if you are using the rigidbody velocity as parameter to determine the pitch
	private const float reductionFactor = .001f;
	
	//Rigidbody2D carRigidbody;
	private float userInput;
	//wheeljoint2d reference
	WheelJoint2D wj;
	

	
	void FixedUpdate()
	{
		//get the userInput
		if (GUIManager.Instance.raceboo == true || GUIManager.Instance.reverseboo == true )

		{
			userInput = 1;
		}
//		if (FakeGui.Instance.raceboo == false)
//			
//		{
//			userInput = 0;
//		}
		//get the absolute value of jointSpeed
		float forwardSpeed =Mathf.Abs(wj.jointSpeed);
		//float forwardSpeed = transform.InverseTransformDirection(carRigidbody.velocity).x;
		//calculate the pitch factor which will be added to the audio source
		float pitchFactor = Mathf.Abs (forwardSpeed * reductionFactor * userInput) ;
		//clamp the calculated pitch factor between lowPitch and highPitch
		carSound.pitch = Mathf.Clamp (pitchFactor, lowPtich, highPitch);
	}
	
}
