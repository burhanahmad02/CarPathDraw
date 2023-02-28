using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpDownScript : MonoBehaviour
{

    public float MovingLimit=10;
    private Vector3 frometh;
    private Vector3 untoeth;
    public float speed = 1f;
    bool onScreen;
    void Start()
    {
       
        frometh = new Vector3(transform.position.x, transform.position.y + MovingLimit, transform.position.z);
        untoeth = new Vector3(transform.position.x,transform.position.y-MovingLimit,transform.position.z); 
    }
    private void LateUpdate()
    {
        if (transform.position.x - GameManager.Instance.CurrrentCar.transform.position.x <= 300 && transform.position.x - GameManager.Instance.CurrrentCar.transform.position.x >= -300&&VehicleSimpleControl.DistanceCovered>=1500)
        {
            onScreen = true;
        }
        else
        {
            onScreen = false;
        }

        if (onScreen)
        {
           // this.GetComponent<EdgeCollider2D>().enabled = true;
            transform.position = Vector3.Lerp(frometh, untoeth, Mathf.SmoothStep(0f, 1f, Mathf.PingPong(Time.time / speed, 1f)));
        }
        else
        {
           // this.GetComponent<EdgeCollider2D>().enabled = false;
        }
    }
}
