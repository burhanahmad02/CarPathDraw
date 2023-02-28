using UnityEngine;
using System.Collections;

public class SmoothFollow2D : MonoBehaviour {
	
	private Vector3 velocity = Vector3.zero;
	public Transform target;
	void Start ()
	{
//		target = GameObject.FindGameObjectWithTag ("Player").transform;
	}
	// Update is called once per frame
	void Update () 
	{
		if (GameObject.FindGameObjectWithTag ("Player")) {
			target = GameObject.FindGameObjectWithTag ("Player").transform;
           // target.position = new Vector3(GameObject.FindGameObjectWithTag("Player").transform.position.x, GameObject.FindGameObjectWithTag("Player").transform.position.y - 10, GameObject.FindGameObjectWithTag("Player").transform.position.z);
        }
		if (target)
		{
			Vector3 point = GetComponent<Camera>().WorldToViewportPoint(new Vector3(target.position.x, target.position.y, target.position.z));
			Vector3 delta = target.position - GetComponent<Camera>().ViewportToWorldPoint(new Vector3(0.2f, 0.5f, point.z)); //(new Vector3(0.5, 0.5, point.z));
			Vector3 destination =new Vector3(transform.position.x, transform.position.y+10, transform.position.z) + delta;
			transform.position = Vector3.SmoothDamp(new Vector3(transform.position.x, transform.position.y-10, transform.position.z), destination, ref velocity, 0);
		}
		
	}
}