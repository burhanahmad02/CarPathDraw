using UnityEngine;
using System.Collections;

public class movecamera : MonoBehaviour {
	bool move;
	public GameObject Panel;
	public GameObject button;
	// Use this for initialization
	void Start () {
		Invoke ("movethis", 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if (move == true) {
			Vector2 start = GameObject.FindGameObjectWithTag ("start").transform.position;
			Vector2 end = GameObject.FindGameObjectWithTag ("Finish").transform.position;
			//MainCamera.transform.position = Vector2.MoveTowards (start, end, 2.0f);
			transform.Translate (Vector2.left * Time.deltaTime*7.5f);
			float dist=Vector2.Distance (transform.position, end);
			if (dist > 1 && dist < 5) 
			{
				move = false;
				Panel.SetActive (true);
				this.gameObject.GetComponent<movecamera> ().enabled = false;
				this.gameObject.GetComponent<SmoothFollow2D> ().enabled = true;
				button.SetActive (false);
			}

		}

//		if()
		}
	void movethis()
	{
		move=true;
	}
	public void skip()
	{
		move = false;
		Panel.SetActive (true);
		this.gameObject.GetComponent<movecamera> ().enabled = false;
		this.gameObject.GetComponent<SmoothFollow2D> ().enabled = true;
		button.SetActive (false);
	}
}
