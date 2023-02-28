using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class DistanceCovered : MonoBehaviour {


	public  float DistanceTravelled=0f;
	public Vector2 lastPosition;
	Text Dist;
	Text Speed;
		void Start () 
	{
		lastPosition = transform.position;

	}
	

	void Update () {
		Rigidbody2D rb=GetComponent<Rigidbody2D>();
		//if (GameObject.FindGameObjectWithTag ("distance")) 
		//{
		//	Dist = GameObject.FindGameObjectWithTag ("distance").GetComponent<Text> ();
		//	Dist.text = Mathf.FloorToInt (DistanceTravelled).ToString();
		//}
		//if (GameObject.FindGameObjectWithTag ("speed")) 
		//{
		//	Speed = GameObject.FindGameObjectWithTag ("speed").GetComponent<Text> ();
		//	Speed.text = Mathf.FloorToInt (rb.velocity.magnitude).ToString();
		//}
		//DistanceTravelled += Vector2.Distance (transform.position, lastPosition);


		//lastPosition = transform.position;
	}
}
