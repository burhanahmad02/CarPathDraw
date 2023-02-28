using UnityEngine;
using System.Collections;

public class AddForce : MonoBehaviour {


	// Use this for initialization
	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {			//coll.gameObject.SendMessage("ApplyDamage", 10);
			GetComponent<Rigidbody2D>().AddForce(Vector2.right*1500,ForceMode2D.Force);
			Destroy(this.gameObject,0.5f);
		}
	}
}


