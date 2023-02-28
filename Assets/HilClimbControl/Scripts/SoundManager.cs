using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {
	
	private static SoundManager instance;
	public static SoundManager Instance{
		get{
			return instance;
		}
	}
	
	public AudioSource [] s1;
	public AudioSource [] m1;
	public AudioClip[] c1;
	
	public GameObject soundOffButton;
	public GameObject soundon;

	
	
	public void SoundON()
	{
		PlayerPrefs.SetInt ("sound", 0);
		soundOffButton.SetActive (true);
		SoundOnOff ();
	}
	public void SoundOFF()
	{
		PlayerPrefs.SetInt ("sound", 1);
		soundOffButton.SetActive (false);
		SoundOnOff ();
	}
	public void SoundOnOff()
	{
		soundState=PlayerPrefs.GetInt ("sound", 1);
		if(soundState == 1)
		{
//			for (int i = 0; i < s1.Length; i++)
//				if (Application.loadedLevelName == "Game") {
//					SoundManager.Instance.s1 [i].mute = false;
//				}
				soundOffButton.SetActive (false);
			soundon.SetActive (true);
			//			sound=true;
			
		}
		else
		{
			for(int i=0;i<s1.Length;i++)
				if (Application.loadedLevelName == "Game") {
					SoundManager.Instance.s1 [i].mute = true;
				}
			soundOffButton.SetActive (true);
			soundon.SetActive (false);
			//			sound=false;
			
		}
	}
//		public GameObject musciOffButton;
//		public GameObject musicon;
//		public void MusicON()
//		{
//			PlayerPrefs.SetInt ("music", 0);
//			musciOffButton.SetActive (true);
//					MusicOnOff ();
//		}
//		public void MusicOFF()
//		{
//			
//			PlayerPrefs.SetInt ("music", 1);
//			musciOffButton.SetActive (false);
//				MusicOnOff ();
//		}
//	
//		public void MusicOnOff()
//		{
//			musicState=PlayerPrefs.GetInt ("music", 1);
//			if (musicState == 1) {
//			for (int i=0; i<s1.Length; i++) 
//				SoundManager.Instance.m1[i].mute = false;
//				musciOffButton.SetActive (false);
//				musicon.SetActive (true);
//
//		} else {
//
//				for (int i=0; i<s1.Length; i++)
//				SoundManager.Instance.m1 [i].mute = true;
//				musciOffButton.SetActive (true);
//				musicon.SetActive (false);
//			}
//
//		}
//	
	public GameObject musicOffButton;
	public GameObject musicon;
	public void MusicON()
	{
		PlayerPrefs.SetInt ("music", 0);
		musicOffButton.SetActive (true);
		MusicOnOff ();
	}
	public void MusicOFF()
	{
		PlayerPrefs.SetInt ("music", 1);
		musicOffButton.SetActive (false);
		MusicOnOff ();
	}
	public void MusicOnOff()
	{
		musicState=PlayerPrefs.GetInt ("music", 1);
		if(musicState == 1 )
		{
			for(int i=0;i<m1.Length;i++)
				SoundManager.Instance.m1[i].mute = false;
			musicOffButton.SetActive (false);
			musicon.SetActive (true);
			//			sound=true;
			
		}
		else
		{
			for(int i=0;i<m1.Length;i++)
				SoundManager.Instance.m1[i].mute = true;
			musicOffButton.SetActive (true);
			musicon.SetActive (false);
			//			sound=false;
			
		}
	}
	public int musicState=1;
	public int soundState=1;
	
	
	void Awake()
	{
		instance = this;
	}
	void Start()
	{
		SoundOnOff ();
				MusicOnOff ();
	}
	
	void Update()
	{
		SoundOnOff ();
			MusicOnOff ();
	}
	public void startSoundclip()
	{
		//		s1[0].clip = c1[0];
		//		s1 [0].Play ();
		//s1[0].PlayOneShot(c1[0], 1.0f);
	}
	public void PlayMenu()
	{
		if(!m1[0].isPlaying){
			m1[0].clip=c1[0];
			//Menu.clip.
			m1[0].Play();
			//			Debug.Log("Menu");
		}
	}
}
