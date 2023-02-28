using UnityEngine;
using System.Collections;

public class FakeGui : MonoBehaviour {
	private static FakeGui instance;
	public static FakeGui Instance
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
	public void Restart()
	{
		Application.LoadLevel(0);
		
	}
}
