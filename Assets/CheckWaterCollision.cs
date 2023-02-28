using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckWaterCollision : MonoBehaviour
{
   
    // Start is called before the first frame update
    private void Start()
    {
       
    }
   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
           // GetComponent<BoxCollider2D>().enabled = false;
           VehicleSimpleControl.Instance.DestroyBike();
            GameManager.Instance.Level_fail = true;
            
            
        }
    }

}
