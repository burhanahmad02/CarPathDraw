using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePad2 : MonoBehaviour
{
    public BoxCollider2D collider2D;
    //bool variable opendoor to mark the time when the door is being opened
    public bool openDoor;
    //animation variable to pass the reference of pressure pad animation in inspector
    public Animation pressurePadAnim;
    //animation variable to pass the reference of door pad animation in inspector
    public Animation doorAnim;

    public void Start()
    {
        collider2D.enabled = true;
        openDoor = false;
    }
    private void OnTriggerEnter2D (Collider2D other)
    {
        // If the car or drawing line passes through this object it will animate this object and the door at the same time
        if(other.gameObject.CompareTag("Car") || other.gameObject.CompareTag("line"))
        {
            //bool set to true when the door is being opened
            openDoor = true;
            
            //animation for pressure pad/ or button
            pressurePadAnim.Play("PressurePad");
            //audio source attached to the pressure pad is played here
            gameObject.GetComponent<AudioSource>().Play();
        }
        //Do door open animation script.
    }

    public void Update()
    {
        //animation for door
        if (openDoor)
        {
            collider2D.enabled = false;
            if (GameManager.EnvirenmentNo == 35)
            {
                doorAnim.Play("Door");
            }
            else if (GameManager.EnvirenmentNo == 36)
            {
                doorAnim.Play("Dooranim");
            }
            else if (GameManager.EnvirenmentNo == 37)
            {
                doorAnim.Play("Door1");
            }
            else if (GameManager.EnvirenmentNo == 38)
            {
                doorAnim.Play("Door2");
            }
            else if (GameManager.EnvirenmentNo == 39)
            {
                doorAnim.Play("Door2");
            }
            else if (GameManager.EnvirenmentNo == 40)
            {
                doorAnim.Play("revertDoor");
            }
            else if (GameManager.EnvirenmentNo == 41)
            {
                doorAnim.Play("revertDoor1");
            }
            else if (GameManager.EnvirenmentNo == 42)
            {
                doorAnim.Play("revertDoor2");
            }
            else if (GameManager.EnvirenmentNo == 43)
            {
                //doorAnim.Play("revertDoor3");
                doorAnim.Play("revertDoor4");
            }
            else if (GameManager.EnvirenmentNo == 44)
            {
                doorAnim.Play("Door3");
            }
            else if (GameManager.EnvirenmentNo == 49)
            {
                doorAnim.Play("trigDoor2");
                
            }
            //bool set to false when the door has been opened
            openDoor = false;
        }
    }

}
