using System;
using UnityEngine;

[RequireComponent(typeof (AudioSource))]
[RequireComponent(typeof (Rigidbody2D))]
[Serializable]
public class Wheel_Options
{
	public float dampingRatio ;
	public float frequency ;
	public float mass ;
	public float gravityScale;
}