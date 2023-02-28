using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphaReduced : MonoBehaviour
{
    //public Transform Car;
    public Collider2D Collider2D;
    public static bool IgnoreCollision;

    public void Awake()
    {
        IgnoreCollision = false;
    }

    public void Start()
    {
        IgnoreCollision = false;
    }

    public void Update()
    {
        Physics2D.IgnoreLayerCollision( 3, 12 ,true);
        /*if (IgnoreCollision)
        {
            Physics2D.IgnoreLayerCollision( 12, 8 ,true);
            Physics2D.IgnoreLayerCollision( 12, 9 ,true);
        }*/
       
       // Physics2D.IgnoreLayerCollision( 3, 8 ,true);
        if (VehicleSimpleControl._instance.RacePress)
        {
            VehicleSimpleControl._instance.rigidBody.bodyType = RigidbodyType2D.Dynamic;
            gameObject.GetComponent<Collider2D>().isTrigger = true;
            Collider2D.enabled = false;
            IgnoreCollision = true;

        }
        else if (!VehicleSimpleControl._instance.RacePress)
        {
            IgnoreCollision = false;
           // VehicleSimpleControl._instance.rigidBody.bodyType = RigidbodyType2D.Static;
            gameObject.GetComponent<Collider2D>().isTrigger = false;
        }
    }
    

   
}
