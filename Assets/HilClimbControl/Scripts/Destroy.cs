using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	void OnTriggerEnter(Collider col)
	{
		//Destroy (col.gameObject);
		//Preferences.Instance.Save ();
	}
	// Update is called once per frame
	void Update () {
	
	}
}
