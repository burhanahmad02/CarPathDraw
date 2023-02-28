using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class LevelsToUnlock : MonoBehaviour {
	public  GameObject[] Levels;
	public GameObject Mission1;
	public GameObject Mission2;
	// Use this for initialization
	void Start () 
	{
//		PlayerPrefs.DeleteAll ();
//		PlayerPrefs.SetInt ("levelunlock", 24);
		for (int i = 0; i <= PlayerPrefs.GetInt ("levelunlock"); i++) {
			if (i < 24) {
				Levels [i].GetComponent<Button> ().interactable = true;
			}
				for (int j = 1; j <= PlayerPrefs.GetInt ("levelunlock"); j++) {

				Levels [j-1].transform.GetChild (0).gameObject.SetActive (true);

			}
		}

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (PlayerPrefs.GetInt ("levelunlock") >= 8) {
			Mission1.GetComponent<Button> ().interactable = true;
		}
		if (PlayerPrefs.GetInt ("levelunlock") >= 16) {
			Mission2.GetComponent<Button> ().interactable = true;
		}
	}
}
