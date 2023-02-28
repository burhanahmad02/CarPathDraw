 
// Code auto-converted by Control Freak 2 on Thursday, November 21, 2019!
// Code auto-converted by Control Freak 2 on Thursday, November 21, 2019!

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class VehicleSimpleControl : MonoBehaviour
{
	public bool isDone;
	//public Rigidbody2D spikeBody;
	//public Transform alphaReduced; 
	public string Alphareduced = "Ignored";
	public Rigidbody2D rigidBody;
	public float maxSpeed;
	public float aceleration;
	public float breakForce;
	public bool reverse;
	public float reverseMaxSpeed;
	 float frontForce=10000;
	 float backForce=10000;
	public bool wheelie;
	public GameObject[] wheels;
	public LayerMask whatIsGround;
	public Wheel_Options wheelOptions;
	public AudioClip engineSound;
	private bool grounded;
	private float pitchModifier;
	private float minPitch;
	private float maxPitch;
    public float torqueDir;
    float torqueforce = 800f;
    float torqueforce1 = 800f;
    public int VehicleGravityForce;
    public int VehicleMass;
    public int rotation;
    public ParticleSystem ps1;
    public ParticleSystem ps2;
    public GameObject COM;
    public static Vector3 StartPosition;
    public static float DistanceCovered;
    public  float FuelLevel;
    bool flip;
    public static bool BackFlipBool;
    public static bool FrontFlipBool;
    public float t;
    public static bool CarInsideWater;
 
    public Material DirtMaterial;
    public float speed;
    public ParticleSystem Smoke;
    public static bool OneTime;
    public static bool only;
    bool a;
    public  bool RacePress;
    public bool BrakePress;
    public int inputaxis;
    float value;
    public bool revivegameee;
    public static VehicleSimpleControl _instance;
    public static VehicleSimpleControl Instance { get { return _instance; } }
    // public static int flip_score;
   
    public static float NextCarUpdateMultiplyer;
    public bool BodyColide;
    private void Awake()
    {
	    isDone = false;
		//rigidBody.bodyType = RigidbodyType2D.Static;
        _instance = this;
        if (GetComponent<Rigidbody2D>() == null)
			//UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(gameObject, "Assets/Scripts/VehicleSimpleControl.cs (25,4)", "RigidBody2D");
		if (GetComponent<AudioSource>() == null)
			gameObject.AddComponent<AudioSource>();
		if (engineSound == null)
			return;
		GetComponent<AudioSource>().clip = engineSound;
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
	    if (other.gameObject.CompareTag("stop"))
	    {
		    GetComponent<AudioSource>().volume = 0;
		    GetComponent<AudioSource>().pitch = 0;
		    RacePress = false;
		    speed = 0;
		    aceleration = 0;
		    rigidBody.bodyType = RigidbodyType2D.Static;
		    StopVehicle.Instance.stopVehicle = true;

	    }
	 
    }

    private void Start()
    {
	    isDone = false;
		//rigidBody.bodyType = RigidbodyType2D.Static;
        RacePress = false;
        BrakePress = false;
		BodyColide = false;
        inputaxis = 0;
        BackFlipBool = false;
        FrontFlipBool = false;
        CarInsideWater = false;
        a = false;
        OneTime = false;
        only = false;
        GenerateStones.car = this.transform;
        BirdBehavior.car = this.transform;
       
      
       
            maxSpeed = maxSpeed + GameManager.CurrentEngineValue;
            reverseMaxSpeed = reverseMaxSpeed + GameManager.CurrentEngineValue;
            VehicleMass = VehicleMass -GameManager.CurrentfarwardValue;
            aceleration = aceleration + (float)GameManager.CurrentEngineValue / 5;
            breakForce = breakForce + (float)GameManager.CurrentEngineValue / 5;
            wheelOptions.mass = wheelOptions.mass - (float)GameManager.CurrentTyreValue / 2;
            wheelOptions.dampingRatio = wheelOptions.dampingRatio - (float)GameManager.CurrentTyreValue / 10;
       // maxSpeed = maxSpeed + (NextCarUpdateMultiplyer / 250);

        FuelLevel = 100;   
      //  StartPosition = transform.position;    
        rotation = 1;
        GetComponent<Rigidbody2D>().centerOfMass = COM.transform.localPosition;
        for (int wheelPosition = 0; wheelPosition < this.wheels.Length; ++wheelPosition)
		{
			if (wheels[wheelPosition] == null)
			{
				wheels = new GameObject[0];
				Debug.Log("Wheel not assigned.");
				return;
			}
			else if (wheels[wheelPosition].GetComponent<CircleCollider2D>() == null)
			{
				wheels = new GameObject[0];
				Debug.Log("Circle collider no assigned to the wheel.");
				return;
			}
			else
				this.addWheelJoint2D(wheelPosition);
		}
		GetComponent<AudioSource>().loop = true;
		GetComponent<AudioSource>().Play();
		minPitch = 1f;
		maxPitch = 4f;

        if (GameManager.Instance.checkrevive)
        {
            GameManager.Instance.checkrevive = false;

            maxSpeed = maxSpeed + NextCarUpdateMultiplyer / 1000;
            Debug.Log("qqqqqqqqqqq");

            
        }
        else
        {
            NextCarUpdateMultiplyer = 500;
        }


    }

    /*IEnumerator BecomeStatic()
    {
	    yield return new WaitForSeconds(1.5f);
	    rigidBody.bodyType = RigidbodyType2D.Static;
	   
    }*/
    public void BecomeStatic()
    {
	   
	    rigidBody.bodyType = RigidbodyType2D.Static;
	   
    }
	private void Update()
	{
		if (gameObject.layer == 9)
		{
			BodyColide = false;
		}
		
		if (GameManager.Instance.levelPass)
		{
			t = 0;
			
		}
		if (!GameManager.Instance.ready)
		{
			t = 0;
			
		}
		if (GameManager.Instance.drawmanag)
		{
			if (DrawingManager.Instance.paths.Contains(DrawingManager.Instance.clone) && DrawingManager.Instance.drawCount > 0 && DrawingManager.Instance.startMoving)
			{
				Debug.Log("movinggggggggg");
				rigidBody.bodyType = RigidbodyType2D.Dynamic;
			}
			else
			{
				Debug.Log("staticccccc");
				if (!isDone)
				{
					
					rigidBody.bodyType = RigidbodyType2D.Static;
					isDone = true;
				}
				//Invoke(nameof(BecomeStatic),1.5f);
				//StartCoroutine(BecomeStatic());

			}
			Physics2D.IgnoreLayerCollision( 3, 12 ,true);
			if (DistanceCovered >= NextCarUpdateMultiplyer)
			{
				NextCarUpdateMultiplyer += 500;
				maxSpeed += 3;

			}
		}
		
        

        //if (Input.acceleration.x > 0)
        //{
        //    value = 1;
        //}
        //else if (Input.acceleration.x < 0)
        //{
        //    value = -1;
        //}
        //else
        //{
        //    value = 0;
        //}
        //GetComponent<Rigidbody2D>().AddTorque(value*10000);
        if (BrakePress)
        {
            inputaxis = -1;
        }
        else if (RacePress)
        {
            inputaxis = 1;
        }
        else
        {
            inputaxis = 0;
        }

        var smokeparticle = Smoke.emission;
        smokeparticle.rateOverTime =1+GetComponent<Rigidbody2D>().velocity.magnitude*0.25f;


        if (GameManager.BostStart == false &&OneTime==true)
        {
           
            maxSpeed = maxSpeed -10;
            reverseMaxSpeed = reverseMaxSpeed -5;
           
            aceleration = aceleration -5;
            breakForce = breakForce -5;
            Debug.Log("a");
            transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(true);
            transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(false);
            OneTime = false;
        }
        else if(GameManager.BostStart == true && OneTime == true)
        {
            Debug.Log("b");
            OneTime = false;
            maxSpeed = maxSpeed+10;
            reverseMaxSpeed = reverseMaxSpeed+5;

            aceleration = aceleration +5;
            breakForce = breakForce+5;
            transform.GetChild(0).transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(0).transform.GetChild(1).gameObject.SetActive(true);

        }


        if (GameManager.StartSlowMoEffect == false && only == true)
        {

            maxSpeed = maxSpeed + 10;
           
            only = false;
        }
        else if (GameManager.StartSlowMoEffect == true && only == true)
        {
          
           
            maxSpeed = maxSpeed - 10;
           
            only = false;

        }





        if (GameManager.StartShieldEffect)
        {
            transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            transform.GetChild(0).transform.GetChild(2).gameObject.SetActive(false);
        }



        if(CarInsideWater==false && GameManager.Instance.isCarRunning)
        {
            t += Time.deltaTime*2.5f;
            GameManager.LowFuelInidication = false;

        }
        else if(CarInsideWater == true)
        {
            GameManager.LowFuelInidication = true;
            t += Time.deltaTime*10;
        }

        if (t >= 1)
        {
           
            FuelLevel = FuelLevel - t;
            t = 0;
        }
        if (FuelLevel < 1)
        {
            FuelLevel = 0;
        }
        if (FuelLevel < 20)
        {
            GameManager.LowFuelInidication = true;
        }
        else
        {
            if (CarInsideWater == false)
            {
                GameManager.LowFuelInidication = false;
            }
            
        }
       
       // Debug.Log(FuelLevel);


        if ( BodyColide)
        {
            GameManager.Instance.Level_fail = true;
            DestroyBike();
        }

        if (FuelLevel <= 1)
        {
            if (GameManager.Instance.Level_fail == false)
            {
                GameManager.Instance.PopUpText.gameObject.SetActive(true);
                GameManager.Instance.PopUpText.text = "Fuel Finished";
                GameManager.Instance.Level_fail = true;
            }
        }



        if (transform.position.x >= StartPosition.x)
        {
            DistanceCovered = transform.position.x - StartPosition.x;
          
            //DistanceCovered = DistanceCovered/2;
        }
        else
        {
            DistanceCovered = 0;
        }

        //  Debug.Log(DistanceCovered);

        if (PlayerPrefs.GetInt("sound") == 0)
        {
            GetComponent<AudioSource>().enabled = true;
            UpdateEngineSound();
        }
        else
        {
            GetComponent<AudioSource>().enabled = false;
        }
       
		IsGrounded();
        //CheckGroundeOnBothwheels();

        torqueDir = Input.acceleration.x;
        //Debug.Log("s "+GetComponent<Rigidbody2D>().velocity.magnitude);



        var emission1 = ps1.emission;
        var emission2 = ps2.emission;
        DirtMaterial.color = GameManager.Instance.TracksColor[GameManager.EnvirenmentNo];
       

        if (DetectCollision.BackWheelMud == true)
        {

            emission1.rateOverTime = GetComponent<Rigidbody2D>().velocity.magnitude;
        }
        else
        {
            emission1.rateOverTime = 0;
        }


        if (DetectCollision.FrontWheelMud == true)
        {

            emission2.rateOverTime = GetComponent<Rigidbody2D>().velocity.magnitude;
        }
        else
        {
            emission2.rateOverTime = 0;
        }


        if (transform.rotation.eulerAngles.z > 210 && transform.rotation.eulerAngles.z < 220)
        {
           
            flip = true;
        }
        if (transform.rotation.eulerAngles.z > 320 && flip) //backflip is done
        {
            BackFlipBool = true;
            flip = false;
        }
        else
        {
            BackFlipBool = false;
          
        }

        if (transform.rotation.eulerAngles.z < 30 && flip) //frontflip is done
        {
            FrontFlipBool = true;
            flip = false;

        }
        else
        {
            FrontFlipBool = false;
           
        }

       
    }
    public void DestroyBike()
    {
        if (!a)
        {
	        Finish.Instance.collider2D.enabled = false;
            a = true;
            GetComponent<Rigidbody2D>().interpolation = RigidbodyInterpolation2D.None;
            GetComponent<Rigidbody2D>().mass = 1;
            GetComponent<Rigidbody2D>().gravityScale = 1;
            GetComponent<Rigidbody2D>().drag = 0;
            GetComponent<Rigidbody2D>().angularDrag = 25;
            //wheels[0].GetComponent<CircleCollider2D>().enabled = false;
           // wheels[1].GetComponent<CircleCollider2D>().enabled = false;
            //this.transform.GetChild(1).GetComponent<PolygonCollider2D>().enabled = false;
            this.GetComponents<WheelJoint2D>()[0].enabled = false;
            this.GetComponents<WheelJoint2D>()[1].enabled = false;
            
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            wheels[0].GetComponent<ExplosionForce2D>().enabled = true;
            wheels[1].GetComponent<ExplosionForce2D>().enabled = true;
            this.transform.GetChild(0).GetComponent<ExplosionForce2D>().enabled = true;
            this.GetComponent<VehicleSimpleControl>().enabled = false;
        }
       
    }
    private void LateUpdate()
    {

        //if (Input.GetAxis("Vertical") >0)
        //{
        //    Debug.Log("upper");
        //    GetComponent<Rigidbody2D>().AddTorque(torqueforce1 * Time.timeScale * (-rotation) * (-torqueDir), ForceMode2D.Force);
        //    GetComponent<Rigidbody2D>().AddTorque(torqueforce1 * (torqueDir) * (1), ForceMode2D.Force);

        //    GetComponent<Rigidbody2D>().angularDrag = 0.01f;

        //}

        //if (Input.GetAxis("Vertical") < 0)
        //{
        //    Debug.Log("lower");
        //    GetComponent<Rigidbody2D>().AddTorque(torqueforce * Time.timeScale * rotation * torqueDir, ForceMode2D.Force);
        //    GetComponent<Rigidbody2D>().AddTorque(torqueforce * (torqueDir), ForceMode2D.Force);
        //    GetComponent<Rigidbody2D>().angularDrag = 0.01f;

        //}
        //if (Input.GetAxis("Vertical") == 0)
        //{
        //    GetComponent<Rigidbody2D>().AddTorque(0, ForceMode2D.Force);


        //}


      




            if (DetectCollision.BackTyreOnGround == true && DetectCollision.FrontTyreOnGround == true)
        {

                wheels[0].GetComponent<Rigidbody2D>().mass = (float)(wheelOptions.mass / 1);
                wheels[1].GetComponent<Rigidbody2D>().mass = (float)(wheelOptions.mass / 1);
                GetComponent<Rigidbody2D>().mass = (float)(VehicleMass / 1);

            
        }
        else
        {
           
          
            GetComponent<Rigidbody2D>().angularDrag = 0.01f;

            

            wheels[0].GetComponent<Rigidbody2D>().gravityScale = wheelOptions.gravityScale; 
             wheels[1].GetComponent<Rigidbody2D>().gravityScale = wheelOptions.gravityScale;
            GetComponent<Rigidbody2D>().gravityScale =VehicleGravityForce;



            wheels[0].GetComponent<Rigidbody2D>().mass = wheelOptions.mass;
            wheels[1].GetComponent<Rigidbody2D>().mass = wheelOptions.mass;
            GetComponent<Rigidbody2D>().mass = VehicleMass;
            //Debug.Log(GameManager.GravityScale * 2);
        }

    }

    private void FixedUpdate()
	{
		this.AcelerateVehicle();
       // this.RotateVehicle();

        //Camera.main.transform.position = Vector3.Lerp(Camera.main.transform.position, new Vector3(this.transform.position.x + 40, this.transform.position.y , Camera.main.transform.position.z), Time.deltaTime * 25f);

    }

    public void addWheelJoint2D(int wheelPosition)
	{
		WheelJoint2D wheelJoint2D = gameObject.AddComponent<WheelJoint2D>() as WheelJoint2D;
		if (!wheels[wheelPosition].GetComponent<Rigidbody2D>())
			wheels[wheelPosition].AddComponent<Rigidbody2D>();
		wheelJoint2D.connectedBody = wheels[wheelPosition].GetComponent<Rigidbody2D>();
		JointSuspension2D jointSuspension2D = new JointSuspension2D();
		// ISSUE: explicit reference operation
		jointSuspension2D.angle = 90f;
		jointSuspension2D.dampingRatio = wheelOptions.dampingRatio;
		jointSuspension2D.frequency = wheelOptions.frequency;
		wheelJoint2D.suspension = jointSuspension2D;
		wheelJoint2D.anchor = wheels[wheelPosition].transform.localPosition;
		wheels[wheelPosition].GetComponent<Rigidbody2D>().mass = wheelOptions.mass;
		wheels[wheelPosition].GetComponent<Rigidbody2D>().gravityScale = wheelOptions.gravityScale;
        wheels[wheelPosition].GetComponent<Rigidbody2D>().collisionDetectionMode=CollisionDetectionMode2D.Continuous;
    }
	
	public void UpdateEngineSound()
	{
        //pitchModifier = maxPitch - minPitch;
        //GetComponent<AudioSource>().pitch = minPitch + GetComponent<Rigidbody2D>().velocity.x / maxSpeed * pitchModifier;
        //((Component) this).get_audio().set_pitch(this.minPitch + (float) ((Component) this).get_rigidbody2D().get_velocity().x / this.maxSpeed * this.pitchModifier);
        if (!GameManager.Instance.levelPass)
        {
	        speed = 0.5f + GetComponent<Rigidbody2D>().velocity.magnitude * 0.03f;
	        speed = Mathf.Clamp(speed, 0.5f,2.8f);
	        GetComponent<AudioSource>().pitch = speed;  
        }
        else
        {
	        speed = 0;
	        GetComponent<AudioSource>().pitch = speed;
        }
        


    }
	
	public void IsGrounded()
	{
      
        for (int index = 0; index < wheels.Length; ++index)
		{
          
            if (Physics2D.OverlapCircle(wheels[index].transform.position, wheels[index].GetComponent<CircleCollider2D>().radius * wheels[index].transform.localScale.x, whatIsGround.value))
			//if (Object.op_Implicit((Object) Physics2D.OverlapCircle(Vector2.op_Implicit(this.wheels[index].get_transform().get_position()), ((CircleCollider2D) this.wheels[index].GetComponent<CircleCollider2D>()).get_radius() * (float) this.wheels[index].get_transform().get_localScale().x, LayerMask.op_Implicit(this.whatIsGround))))
			{
                
				grounded = true;
              
                break;
               
			}
			else
            { 
				grounded = false;
             

            }


            
        }
	}
   




    public void AcelerateVehicle()
	{
		if (inputaxis > 0f && grounded)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + aceleration, GetComponent<Rigidbody2D>().velocity.y);

			if (GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
				return;

			GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else if (inputaxis < 0f && grounded)
		{

			if (GetComponent<Rigidbody2D>().velocity.x > aceleration)
			{
				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x - breakForce, GetComponent<Rigidbody2D>().velocity.y);
			}
			else
			{
				if (!reverse)
					return;

				GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x - aceleration, GetComponent<Rigidbody2D>().velocity.y);

				if (GetComponent<Rigidbody2D>().velocity.x > reverseMaxSpeed * -1.0f)
					return;

				GetComponent<Rigidbody2D>().velocity = new Vector2(-reverseMaxSpeed, GetComponent<Rigidbody2D>().velocity.y);
			}
		}
		else
		{
           
            if (GetComponent<Rigidbody2D>().velocity.x <= 0.0f || !grounded)
            {
                return;
                
            }
				

	

            if (GetComponent<Rigidbody2D>().velocity.x >= 0.0f)
            {
                return;
               
            }

			GetComponent<Rigidbody2D>().velocity = new Vector2(0.0f, GetComponent<Rigidbody2D>().velocity.y);
            Debug.Log("d");
        }
	}
	
	public void RotateVehicle()
	{
		if (Input.GetAxis("Vertical") > 0.0f && GetComponent<Rigidbody2D>().velocity.x > aceleration * 2.0f)
		{
			if (grounded && !wheelie || GetComponent<Rigidbody2D>().angularVelocity <= -frontForce * 10.0f)
				return;

			GetComponent<Rigidbody2D>().AddTorque(-frontForce);
		}
		else
		{
			if (Input.GetAxis("Vertical") >= 0.0f || (GetComponent<Rigidbody2D>().velocity.x <= aceleration * 2.0f || grounded && !wheelie || GetComponent<Rigidbody2D>().angularVelocity >= backForce * 10.0f))
				return;
			GetComponent<Rigidbody2D>().AddTorque(backForce);
		}
	}

    public void ConsumeFuel()
    {
        FuelLevel--;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
	    if ( collision.gameObject.CompareTag("line")||collision.gameObject.layer == 9)
	    {
		    BodyColide = false;
	    }
	    else if (collision.gameObject.CompareTag("Ground")||collision.gameObject.CompareTag("falling")||collision.gameObject.CompareTag("door"))
	    {
		     BodyColide = true;
	    }
        /*if (GameManager.StartShieldEffect == false)
        {
            BodyColide = true;
           

        }*/
        else
        {
            if (collision.gameObject.tag == "stone" || collision.gameObject.tag == "animal" || collision.gameObject.tag == "bird")
            {
                Destroy(collision.gameObject);
            }
            else
            {
                //BodyColide = true;
            }
        }
        
       
        //Debug.Log("sv");
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
	    if ( collision.gameObject.CompareTag("line")||collision.gameObject.layer == 9)

	    {
		    BodyColide = false;
	    }
        BodyColide = false;
    }	
}
