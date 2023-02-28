using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class StopVehicle : MonoBehaviour
{
    private static StopVehicle _instance = null;
    public static StopVehicle Instance { get { return _instance; } }
    public bool stopVehicle;

    public void Start()
    {
        stopVehicle = false;
    }

    public void Awake()
    {
        _instance = null;
        if (_instance != null && _instance != this)
        {
          
            
        }
        else
        {
            _instance = this;
        }
        stopVehicle = false;
    }
    //stops the vehicle once the level is completed , this collider checks if the level is completed and the vehicle is colliding then the vehicle stops
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.CompareTag("Car") )

        {
            Debug.Log("stopppppppp");
            stopVehicle = true;
            VehicleSimpleControl._instance.RacePress = false;
            VehicleSimpleControl._instance.speed = 0;
            VehicleSimpleControl._instance.rigidBody.bodyType = RigidbodyType2D.Static;
            VehicleSimpleControl.Instance.GetComponent<AudioSource>().enabled = false;
            VehicleSimpleControl.Instance.GetComponent<AudioSource>().volume = 0;
            VehicleSimpleControl.Instance.GetComponent<AudioSource>().pitch = 0;

        }
        /*if (levelPass)
        {
            Invoke(nameof(LevelPass),1.5f);
            
        }*/
  
    }
}
