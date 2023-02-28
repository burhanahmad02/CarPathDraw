using UnityEngine;
using System.Collections;

public class CoinsScore : MonoBehaviour {
	public int star=1;
	public bool startouch;
	public AudioClip impact;
	AudioSource audio;


	void Start()
	{
		audio = GetComponent<AudioSource>();
	}
	// Use this for initialization
	void OnTriggerEnter2D(Collider2D coll) {
		if (coll.gameObject.tag == "Player") {	
			//coll.gameObject.SendMessage("ApplyDamage", 10);
			audio.PlayOneShot(impact, 0.7F);
			GetComponent<PolygonCollider2D>().enabled=false;

			startouch=true;
			GetComponent<Animator>().enabled=true;
			Destroy(this.gameObject,0.25f);
		}
	}
	void Update ()
	{if (startouch == true) {
			ScoreManager.Instance.star+=star;
		}
		startouch = false;

	}
}