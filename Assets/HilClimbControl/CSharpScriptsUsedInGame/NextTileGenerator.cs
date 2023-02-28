using UnityEngine;

using System.Collections;

public class NextTileGenerator : MonoBehaviour {
	
	//private bool bShowGUI = false;
	public GameObject hoard;
	public Transform tile;
	void Awake(){
		// You must initialize Dialoguer before using it!
//		Dialoguer.Initialize();
		
	}
	void OnTriggerEnter2D (Collider2D other){
		if (other.tag == "Player") {
			//Dialoguer.StartDialogue (11);
//			Debug.Log ("new tile");
//			Destroy(this.gameObject);
			Instantiate(hoard,new Vector2 (tile.transform.position.x, tile.transform.position.y), Quaternion.identity);
//			GameObject.FindGameObjectWithTag("Respawn").GetComponent<DestroyTile>().enabled=true;
		}
	}
}