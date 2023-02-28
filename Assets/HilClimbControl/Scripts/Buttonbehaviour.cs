using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buttonbehaviour : MonoBehaviour
{
    public BoxCollider2D boxCollider;
    public GameObject[] fallingObjects;
    public Rigidbody2D[] rbs;
    public Animation fallingObjButton;
    public bool fallSpike;

    public void Awake()
    {
        foreach (Rigidbody2D rigidBody in  rbs)
        {
            rigidBody.bodyType = RigidbodyType2D.Static;
        }

        fallSpike = false;
    }

    // Start is called before the first frame update
    public void Start()
    {
        boxCollider.enabled = true;
        fallSpike = false;
        fallingObjects = GameObject.FindGameObjectsWithTag("falling");
        // initialize array with same number of elements.
        rbs = new Rigidbody2D[fallingObjects.Length];
        // loop through each GameObject and cache its rigidbody.
        for (int i = 0; i < fallingObjects.Length; ++i) {
            // get GameObject at index `i`
            GameObject fall = fallingObjects[i];
            // set rigidbody at index `i`
            rbs[i] = fall.GetComponent<Rigidbody2D>();
               
        }

        foreach (Rigidbody2D rigidBody in  rbs)
        {
            rigidBody.bodyType = RigidbodyType2D.Static;
        }
        

    }

  

    private void OnTriggerEnter2D (Collider2D other)
    {
        // If the car or drawing line passes through this object it will animate this object and the door at the same time
        if(other.gameObject.CompareTag("Car") || other.gameObject.CompareTag("line"))
        {
            //bool set to true when the door is being opened
            
            
            //animation for pressure pad/ or button
            fallingObjButton.Play("PressurePad");
            //audio source attached to the pressure pad is played here
            gameObject.GetComponent<AudioSource>().Play();
            fallSpike = true;
            
        }

        //Do door open animation script.
    }

    public void Update()
    {
        foreach (Rigidbody2D rb in rbs)
        {
            if (fallSpike)
            {
                boxCollider.enabled = false;
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.gravityScale = 10f;


            }
            

            if (!fallSpike)
            {
                rb.bodyType = RigidbodyType2D.Static;
            }
        }
    }
}
