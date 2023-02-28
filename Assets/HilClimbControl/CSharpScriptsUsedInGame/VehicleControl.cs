using UnityEngine; 
using System.Collections; 
using UnityEngine.UI; 

public class VehicleControl : MonoBehaviour { 
	private static VehicleControl instance;
	public static VehicleControl Instance
	{
		get
		{
			return instance;
		}
	}
	void Awake()
	{
		instance = this;
		
	}
	//reference to the wheel joints
	WheelJoint2D[] wheelJoints; 
	//center of mass of the car
	public Transform centerOfMass;
	//reference tot he motor joint
	JointMotor2D motorBack;  
	JointMotor2D motorBack1;
	//horizontal movement keyboard input
	public float dir; 
	//input for rotation of the car
	public float torqueDir;
	//max fwd speed which the car can move at
	public float maxFwdSpeed = -3000;
	//max bwd speed
	public float maxBwdSpeed = 1500f;
	//the rate at which the car accelerates
	public float accelerationRate = 600;
	//the rate at which car decelerates
 	public float decelerationRate = -2000;
	//how soon the car stops on braking
	float brakeSpeed = 5000f;
	//acceleration due to gravity
	float gravity = 9.81f;
	//angle in which the car is at wrt the ground
	float slope = 0;
	float torqueforce=40f;
	float torqueforce1=40f;
	//reference to the wheels
	public Transform rearWheel;
	public Transform frontWheel;
	public int rotation;
	public bool decelerate;
	public static float dist=0;
//	public SliderJoint2;
	//Checking Player Hitting Ground or Not
	public Slider distance;
	bool slider=true;

	// Use this for initialization 
	void Start () {
		
		//set the center of mass of the car
		GetComponent<Rigidbody2D>().centerOfMass = centerOfMass.transform.localPosition;
		//get the wheeljoint components
		wheelJoints = gameObject.GetComponents<WheelJoint2D>(); 
		//get the reference to the motor of rear wheels joint
		motorBack = wheelJoints[0].motor; 
		motorBack1 = wheelJoints[1].motor; 
		decelerate = true;



	}  
	void Update()
	{
		
		//Vector3 finish = GameObject.FindGameObjectWithTag ("Finish").transform.position;	
		//dist = Vector2.Distance (finish, transform.position);

		if (GameObject.FindGameObjectWithTag ("Slider") && slider == true)
		{
			
			distance = GameObject.FindGameObjectWithTag ("Slider").GetComponent<Slider> ();
			distance.maxValue = dist;
			slider = false;
		}
		if (slider==false) 
		{
			distance.value = distance.maxValue - dist;
		}
		//if (SoundManager.Instance.soundState == 0) {
		
		//	gameObject.GetComponent<AudioSource>().enabled=false;
		//}
		//if (SoundManager.Instance.soundState == 1) {
			
		//	gameObject.GetComponent<AudioSource>().enabled=true;
		//}
		if (CheckGrounded.Instance.isGrounded == false) {
			

				motorBack.motorSpeed -= Time.deltaTime * 1000; 
				motorBack1.motorSpeed -= Time.deltaTime * 1000;

			if (torqueDir == 1) { 
				GetComponent<Rigidbody2D> ().AddTorque (torqueforce1 * Time.timeScale * (-rotation) * (-torqueDir), ForceMode2D.Force);
				GetComponent<Rigidbody2D> ().gravityScale = 0.1f;
			
			} 
		
			if (torqueDir == -1) { 
				GetComponent<Rigidbody2D> ().AddTorque (torqueforce * Time.timeScale * rotation * torqueDir, ForceMode2D.Force);
				GetComponent<Rigidbody2D> ().gravityScale = 0.1f;

			}
			if (torqueDir == 0) {
				GetComponent<Rigidbody2D> ().AddTorque (0, ForceMode2D.Force);

			}
		} else {
			GetComponent<Rigidbody2D> ().gravityScale = 1f;
		}
	}
	
	//all physics based assignment done here
	void FixedUpdate(){
		//add ability to rotate the car around its axis
		//horizontal movement input. same as torqueDir. Could have avoided it, but decided to 
		//use it since some of you might want to use the Vertical axis for the torqueDir

//		torqueDir = Input.GetAxis ("Horizontal"); 

		//determine the cars angle wrt the horizontal ground
		slope = transform.localEulerAngles.z;
		
		//convert the slope values greater than 180 to a negative value so as to add motor speed 
		//based on the slope angle
		if(slope>=180)
			slope = slope - 360;

		//check if there is any input from the user
		torqueDir=dir = Input.GetAxis("Horizontal"); 
		
		if (GUIManager.Instance.raceboo == true) {
			
			if (CheckGrounded.Instance.isGrounded == true) {
				dir=1;
			}
				
			torqueDir = 1;
		}
		if (GUIManager.Instance.raceboo == false && GUIManager.Instance.reverseboo == false) {
			
			
			torqueDir=0;
			dir=0;
			
		}
		if (GUIManager.Instance.reverseboo == true) {
			
			if (CheckGrounded.Instance.isGrounded == true) {
				dir=-1;
			}


			torqueDir = -1;
		}

		//add speed accordingly in forward direction
		if (dir > 0 && CheckGrounded.Instance.isGrounded == true ) {


			motorBack.motorSpeed = Mathf.Clamp (motorBack.motorSpeed - (dir * accelerationRate - gravity * Mathf.Sin ((slope * Mathf.PI) / 180) * 80) * Time.deltaTime, maxFwdSpeed, maxBwdSpeed);
			motorBack1.motorSpeed = Mathf.Clamp (motorBack1.motorSpeed - (dir * accelerationRate - gravity * Mathf.Sin ((slope * Mathf.PI) / 180) * 80) * Time.deltaTime, maxFwdSpeed, maxBwdSpeed);
			decelerate=true;
		}
		//add speed accordingly in backward direction
		if (dir < 0 && ((motorBack.motorSpeed<=0 && motorBack1.motorSpeed<=0) ||  (motorBack.motorSpeed>=0 && motorBack1.motorSpeed>=0)) && CheckGrounded.Instance.isGrounded == true ) {	//add speed accordingly
			
			motorBack.motorSpeed = Mathf.Clamp (motorBack.motorSpeed - (dir * accelerationRate - gravity * Mathf.Sin ((slope * Mathf.PI) / 180) * 80) * Time.deltaTime, maxFwdSpeed, maxBwdSpeed);
			motorBack1.motorSpeed = Mathf.Clamp (motorBack1.motorSpeed - (dir * accelerationRate - gravity * Mathf.Sin ((slope * Mathf.PI) / 180) * 80) * Time.deltaTime, maxFwdSpeed, maxBwdSpeed);
//			Debug.Log("i am in!");
		}
		//will apply break ,apply decelerate on tyres
		if (dir < 0 && decelerate==true )
		{
		
//			motorBack.motorSpeed = Mathf.Clamp(motorBack.motorSpeed + brakeSpeed*Time.deltaTime, maxFwdSpeed, 0);
//			motorBack1.motorSpeed = Mathf.Clamp(motorBack1.motorSpeed + brakeSpeed*Time.deltaTime, maxFwdSpeed, 0);
			decelerate=false;
		}

        //if no input and car is moving forward or no input and car is stagnant and is on an inclined plane with negative slope

        //		motorBack1.motorSpeed = Mathf.Clamp(motorBack1.motorSpeed -(dir*accelerationRate - gravity*Mathf.Sin((slope * Mathf.PI)/180)*80 )*Time.deltaTime, maxFwdSpeed, maxBwdSpeed)
        if ((dir == 0 && motorBack.motorSpeed < 0) || (dir == 0 && motorBack.motorSpeed == 0 && slope < 0))
        {
            //decelerate the car while adding the speed if the car is on an inclined plane
            Debug.Log("1");
            motorBack.motorSpeed = Mathf.Clamp(motorBack.motorSpeed - (decelerationRate - gravity*Mathf.Sin((slope * Mathf.PI)/180)*80)*Time.deltaTime, maxFwdSpeed, 0);
            motorBack1.motorSpeed = Mathf.Clamp(motorBack1.motorSpeed - (decelerationRate - gravity*Mathf.Sin((slope * Mathf.PI)/180)*80)*Time.deltaTime, maxFwdSpeed, 0);
           // this.gameObject.GetComponent<Rigidbody2D>().drag = 15;
           

            // motorBack1.motorSpeed = Mathf.Clamp(motorBack1.motorSpeed - (decelerationRate - gravity*Mathf.Sin((slope * Mathf.PI)/180)*80)*Time.deltaTime, maxFwdSpeed, 0);
        }
        //if no input and car is moving backward or no input and car is stagnant and is on an inclined plane with positive slope
        else if ((dir == 0 && motorBack.motorSpeed > 0) || (dir == 0 && motorBack.motorSpeed == 0 && slope > 0))
        {
            Debug.Log("2");
            //this.gameObject.GetComponent<Rigidbody2D>().drag = 15;
         
            //
            //decelerate the car while adding the speed if the car is on an inclined plane
            motorBack.motorSpeed = Mathf.Clamp(motorBack.motorSpeed -(-decelerationRate - gravity*Mathf.Sin((slope * Mathf.PI)/180)*80)*Time.deltaTime, 0, maxBwdSpeed);
            motorBack1.motorSpeed = Mathf.Clamp(motorBack1.motorSpeed -(-decelerationRate - gravity*Mathf.Sin((slope * Mathf.PI)/180)*80)*Time.deltaTime, 0, maxBwdSpeed);
        }
        else if ((dir == 0 && motorBack.motorSpeed > 0 && motorBack1.motorSpeed > 0) || (dir == 0 && motorBack.motorSpeed < 0 && motorBack1.motorSpeed < 0))
        {
            //decelerate the car while adding the speed if the car is on an inclined plane
            Debug.Log("3");
            motorBack.motorSpeed = Mathf.Clamp(motorBack.motorSpeed - (-decelerationRate - gravity * Mathf.Sin((slope * Mathf.PI) / 180) * 80) * Time.deltaTime, 0, maxBwdSpeed);
            motorBack1.motorSpeed = Mathf.Clamp(motorBack1.motorSpeed - (-decelerationRate - gravity * Mathf.Sin((slope * Mathf.PI) / 180) * 80) * Time.deltaTime, 0, maxBwdSpeed);
        }
        else
        {
            this.gameObject.GetComponent<Rigidbody2D>().drag = 0.1f;
        }
		
		

		//connect the motor to the joint
		wheelJoints[0].motor = motorBack; 
		wheelJoints[1].motor = motorBack1;

      //  wheelJoints[0].useMotor = false;
      //  wheelJoints[0].useMotor = false;

    }
	
}

