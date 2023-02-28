using UnityEngine;
using System.Collections;

public class instatiatatecanvas : MonoBehaviour 
{

	public GameObject canvas;

	void Awake ()
	{

		if (GameObject.FindObjectOfType<Dontdestroyonload> ()) 
		{
			Destroy (gameObject);
		} 

		else 
		{
			Instantiate (canvas);
		}
			
	}
	// Use this for initialization
	void Start () 
	{
//		GUIManager.Instance.loadingScreenObj.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
}
