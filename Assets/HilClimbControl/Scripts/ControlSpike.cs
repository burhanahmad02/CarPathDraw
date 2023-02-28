using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlSpike : MonoBehaviour
{
    private static ControlSpike _instance = null;
    public static ControlSpike Instance { get { return _instance; } }
    public Rigidbody2D fallingBody;
    public Rigidbody2D fallingBody1;

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
        fallingBody.bodyType = RigidbodyType2D.Static;
        fallingBody1.bodyType = RigidbodyType2D.Static;

    }

    // Start is called before the first frame update
    void Start()
    {
        fallingBody.bodyType = RigidbodyType2D.Static;
        fallingBody1.bodyType = RigidbodyType2D.Static;
    }
    public void DropSpikes()
    {
        
            fallingBody.bodyType = RigidbodyType2D.Dynamic;
            fallingBody.gravityScale = 10f;
            fallingBody1.bodyType = RigidbodyType2D.Dynamic;
            fallingBody1.gravityScale = 10f;
        
        
    }

    public void Update()
    {
        if (DrawingManager.Instance.paths.Contains(DrawingManager.Instance.clone) &&
            VehicleSimpleControl._instance.RacePress)
        {
            Invoke(nameof(DropSpikes), 0f);
        }

    }
    // Update is called once per frame
   
  
}
