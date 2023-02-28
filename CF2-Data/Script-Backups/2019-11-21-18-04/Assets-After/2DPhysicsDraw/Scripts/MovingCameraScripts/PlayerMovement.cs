// Code auto-converted by Control Freak 2 on Thursday, November 21, 2019!
// PlayerMovement.cs is part of 2D Physics Draw asset for Uunity 3D
// Made by Daniel C Menezes
// Contact: d.cavalcante.m@gmail.com
// Asset Store URL: http://u3d.as/otD

using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float Speed = 0f;
    private float movex = 0f;
    //private float movey = 0f;

    // Use this for initialization
    void Start()
    {
        Speed = 5f;
    }

    // Update is called once per frame
    void Update()
    {

        if (ControlFreak2.CF2Input.GetKey(KeyCode.A))
            movex = -1;
        else if (ControlFreak2.CF2Input.GetKey(KeyCode.D))
            movex = 1;
        else
            movex = 0;
    }

    void FixedUpdate()
    {

        this.GetComponent<Rigidbody2D>().velocity = new Vector2(movex * Speed, this.GetComponent<Rigidbody2D>().velocity.y);
    }
}
