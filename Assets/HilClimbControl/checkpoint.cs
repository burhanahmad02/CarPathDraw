using UnityEngine;
using System.Collections;

public class checkpoint : MonoBehaviour {
	public GameObject Checkpoint;
	public static bool pointtaken;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Player") {
			
//			FlipCheck.cardestroy = this.gameObject.transform.parent.gameObject.transform.position;	
			FlipCheck.cardestroy = coll.transform.GetChild(0).transform.position;	
			pointtaken = true;
			Destroy (this.gameObject);


		}
	}
}
