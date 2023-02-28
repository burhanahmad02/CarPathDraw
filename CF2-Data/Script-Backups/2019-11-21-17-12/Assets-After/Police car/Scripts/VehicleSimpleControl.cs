// Code auto-converted by Control Freak 2 on Thursday, November 21, 2019!
using UnityEngine;

public class VehicleSimpleControl : MonoBehaviour
{
	public float maxSpeed;
	public float aceleration;
	public float breakForce;
	public bool reverse;
	public float reverseMaxSpeed;
	 float frontForce;
	 float backForce;
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

    private void Awake()
	{
		if (GetComponent<Rigidbody2D>() == null)
			UnityEngineInternal.APIUpdaterRuntimeServices.AddComponent(gameObject, "Assets/Scripts/VehicleSimpleControl.cs (25,4)", "RigidBody2D");
		if (GetComponent<AudioSource>() == null)
			gameObject.AddComponent<AudioSource>();
		if (engineSound == null)
			return;
		GetComponent<AudioSource>().clip = engineSound;
	}
	
	private void Start()
	{
        //ps1 = GetComponent<ParticleSystem>();
        //ps2 = GetComponent<ParticleSystem>();
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
	}
	
	private void Update()
	{
		UpdateEngineSound();
		IsGrounded();
        //CheckGroundeOnBothwheels();

        torqueDir = ControlFreak2.CF2Input.GetAxis("Horizontal");
        //Debug.Log("s "+GetComponent<Rigidbody2D>().velocity.magnitude);



        var emission1 = ps1.emission;
        var emission2 = ps2.emission;


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

    }
    private void LateUpdate()
    {
        





        if (DetectCollision.BackTyreOnGround == true && DetectCollision.FrontTyreOnGround == true)
        {
            GetComponent<Rigidbody2D>().angularDrag = 1.5f;
            GetComponent<Rigidbody2D>().mass = VehicleMass / 5;
            GetComponent<Rigidbody2D>().gravityScale = VehicleGravityForce / 2;
            wheels[0].GetComponent<Rigidbody2D>().mass = wheelOptions.mass / 5;
            wheels[1].GetComponent<Rigidbody2D>().mass = wheelOptions.mass / 5;
            wheels[0].GetComponent<Rigidbody2D>().gravityScale = wheelOptions.gravityScale / 3;
            wheels[1].GetComponent<Rigidbody2D>().gravityScale = wheelOptions.gravityScale / 3;


            if (torqueDir == 1)
            {
                // GetComponent<Rigidbody2D>().AddTorque(torqueforce1 * Time.timeScale * (-rotation) * (-torqueDir), ForceMode2D.Force);
                GetComponent<Rigidbody2D>().AddTorque(torqueforce1 * (torqueDir) * (1), ForceMode2D.Force);
               
                GetComponent<Rigidbody2D>().angularDrag = 0.01f;

            }

            if (torqueDir == -1)
            {
                // GetComponent<Rigidbody2D>().AddTorque(torqueforce * Time.timeScale * rotation * torqueDir, ForceMode2D.Force);
                GetComponent<Rigidbody2D>().AddTorque(torqueforce * (torqueDir), ForceMode2D.Force);
               
                GetComponent<Rigidbody2D>().angularDrag = 0.01f;

            }
            if (torqueDir == 0)
            {
                GetComponent<Rigidbody2D>().AddTorque(0, ForceMode2D.Force);
               

            }
        }
        else
        {
            GetComponent<Rigidbody2D>().gravityScale = VehicleGravityForce;
            GetComponent<Rigidbody2D>().angularDrag = 0.01f;
            GetComponent<Rigidbody2D>().mass = VehicleMass;
            wheels[0].GetComponent<Rigidbody2D>().mass = wheelOptions.mass;
            wheels[1].GetComponent<Rigidbody2D>().mass = wheelOptions.mass;
            wheels[0].GetComponent<Rigidbody2D>().gravityScale = wheelOptions.gravityScale;
            wheels[1].GetComponent<Rigidbody2D>().gravityScale = wheelOptions.gravityScale;


        }

    }

    private void FixedUpdate()
	{
		this.AcelerateVehicle();
        //this.RotateVehicle();


        

      








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
	}
	
	public void UpdateEngineSound()
	{
		pitchModifier = maxPitch - minPitch;
        //GetComponent<AudioSource>().pitch = minPitch + GetComponent<Rigidbody2D>().velocity.x / maxSpeed * pitchModifier;
        //((Component) this).get_audio().set_pitch(this.minPitch + (float) ((Component) this).get_rigidbody2D().get_velocity().x / this.maxSpeed * this.pitchModifier);
        GetComponent<AudioSource>().pitch = 1+GetComponent<Rigidbody2D>().velocity.magnitude*0.01f;

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
		if (ControlFreak2.CF2Input.GetAxis("Horizontal") > 0f && grounded)
		{
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x + aceleration, GetComponent<Rigidbody2D>().velocity.y);

			if (GetComponent<Rigidbody2D>().velocity.x < maxSpeed)
				return;

			GetComponent<Rigidbody2D>().velocity = new Vector2(maxSpeed, GetComponent<Rigidbody2D>().velocity.y);
		}
		else if (ControlFreak2.CF2Input.GetAxis("Horizontal") < 0f && grounded)
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
				

			//GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x - aceleration, GetComponent<Rigidbody2D>().velocity.y);

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
		if (ControlFreak2.CF2Input.GetAxis("Vertical") > 0.0f && GetComponent<Rigidbody2D>().velocity.x > aceleration * 2.0f)
		{
			if (grounded && !wheelie || GetComponent<Rigidbody2D>().angularVelocity <= -frontForce * 10.0f)
				return;

			GetComponent<Rigidbody2D>().AddTorque(-frontForce);
		}
		else
		{
			if (ControlFreak2.CF2Input.GetAxis("Vertical") >= 0.0f || (GetComponent<Rigidbody2D>().velocity.x <= aceleration * 2.0f || grounded && !wheelie || GetComponent<Rigidbody2D>().angularVelocity >= backForce * 10.0f))
				return;
			GetComponent<Rigidbody2D>().AddTorque(backForce);
		}
	}


  

}
