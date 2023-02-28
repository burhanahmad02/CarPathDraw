using UnityEngine;
using System.Collections;

public class FlipCheck : MonoBehaviour {
	public GameObject prefab;
	public AudioClip impact1;
	AudioSource audio;
	public static Vector2 cardestroy;

	void Start()
	{
		audio = GetComponent<AudioSource>();
	}
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D coll) 
	{
		if (coll.gameObject.tag == "Ground" ) 
		{	
			
			audio.PlayOneShot(impact1, 0.95F);		

			Instantiate(prefab,transform.position, Quaternion.identity);
//			GameObject car=GameObject.FindGameObjectsWithTag ("Player");
			Destroy(GameObject.FindGameObjectWithTag ("Car"),0.01f);
			if (FlipCheck.cardestroy.magnitude <= 0) {
				//GUIManager.Instance.OnGameOver ();


			} else if (FlipCheck.cardestroy.magnitude > 0) {

				//GUIManager.Instance.resume ();
			}
		}
	}

}
