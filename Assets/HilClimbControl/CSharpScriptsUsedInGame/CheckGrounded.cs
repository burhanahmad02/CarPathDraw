using UnityEngine;
using System.Collections;

public class CheckGrounded : MonoBehaviour {
	private static CheckGrounded instance;
	public static CheckGrounded Instance
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
	//flag to find out if the object is grounded
	public bool isGrounded = false;
	
	//Empty gameobject created to determine the bounds/center of the object
	public Transform GroundCheck1;
	//public Transform GroundCheck2; //uncomment this for OverlapArea
	
	//The layer for which the overlap has to be detected 
	public LayerMask ground_layers;
	
	//All the Physics related things to be done here
	void FixedUpdate(){
		//check if the empty object created overlaps with the 'ground_layers' within a radius of 1 units
		isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, this.GetComponent<CircleCollider2D>().radius, ground_layers);
		
		//uncomment this and comment the above line, if you are using a rectangle or somewhat similar shaped object
		//isGrounded = Physics2D.OverlapArea(GroundCheck1.position, GroundCheck2.position, ground_layers); 
		
//		Debug.Log("Grounded: "+isGrounded);
		
	}
	
}