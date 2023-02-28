using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	
	private static ScoreManager instance;
	public static ScoreManager Instance
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
	
	public int star;
	public Text Star;
	public int totalstar=0;
	public Text TotalStar1;
	public Text TotalStar2;
	public Text TotalStar3;
	public Text TotalStar4;
	public Text TotalStar5;
	public Text TotalStar6;
	public int starearn;
	
	
	
	
	
	
	
	// Use this for initialization
	void Start () 
	{
		totalstar=PlayerPrefs.GetInt ("totalstar");

	}
	
	string timeString;
	
	
	public string GetTimeString(int timeTkn)
	{
		int min = timeTkn / 60;
		int sec = timeTkn % 60;
		if(sec<10 && min<10)
			timeString = "0" + min.ToString() + ":0" + sec.ToString();
		else if (sec > 9 && min < 10)
			timeString = "0" + min.ToString() + ":" + sec.ToString();
		else if (sec < 10 && min > 9)
			timeString =  min.ToString() + ":0" + sec.ToString();
		else
			timeString = min.ToString()+ ":" +sec.ToString();
		return timeString;
	}
	
	
	public void SaveStar()
	{
		totalstar += star;
		PlayerPrefs.SetInt ("totalstar",totalstar);
		
	}
	
	
	
	// Update is called once per frame
	void Update ()
	{
		Star.text = "" + star;
		if (totalstar >= 0 && Application.loadedLevelName=="MainMenu") {
			totalstar = PlayerPrefs.GetInt ("totalstar");
			TotalStar1.text = PlayerPrefs.GetInt ("totalstar").ToString ();
			TotalStar2.text = PlayerPrefs.GetInt ("totalstar").ToString ();
			TotalStar3.text = PlayerPrefs.GetInt ("totalstar").ToString ();
			TotalStar4.text = PlayerPrefs.GetInt ("totalstar").ToString ();
			TotalStar5.text = PlayerPrefs.GetInt ("totalstar").ToString ();
			TotalStar6.text = PlayerPrefs.GetInt ("totalstar").ToString ();
		}
	}
	
	
}
