using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GUIManager : MonoBehaviour {
    private static GUIManager instance;
    public static GUIManager Instance
    {
        get
        {
            return instance;
        }
    }
    void Awake()
    {
        instance = this;
    }
	
	public bool raceboo;
	public bool reverseboo;
	
//
	void Start () 
    {
		
//		Debug.Log(PlayerPrefs.GetInt ("levelunlock"));

		Time.timeScale = 1;
//		
   	}
	
	
	public void raceon()
	{
		raceboo = true;
		
	}
	public void raceoff()
	{
		raceboo = false;
		
	}
	public void reverseon()
	{
		reverseboo = true;
		
	}
	public void reverseoff()
	{
		reverseboo = false;
		
	}
	



	// Update is called once per frame
	void Update () 
    {
//		timer.text = ScoreManager.Instance.GetTimeString((int)secs);
//		secs -= Time.deltaTime;
		


        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            raceon();
        }
        if (Input.GetKeyUp(KeyCode.RightArrow))
        {
            raceoff();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            reverseon();
        }
        if (Input.GetKeyUp(KeyCode.LeftArrow))
        {
            reverseoff();
        }


       
	}
    
}
