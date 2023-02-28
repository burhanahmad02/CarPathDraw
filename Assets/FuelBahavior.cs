using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class FuelBahavior : MonoBehaviour
{
    public AudioClip fuelClip;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            transform.parent = Camera.main.transform;
            //commented this line because of the terraingenerator script
            //MyTerrain2DGenerator.GenerateFuel = false;

            GetComponents<DOTweenAnimation>()[0].DOPlay();
            VehicleSimpleControl.Instance.FuelLevel = 100;
            this.GetComponent<AudioSource>().PlayOneShot(fuelClip);
        }
      
    }
    public void OnComplete()
    {
        Destroy(this.gameObject, 5);
    }
}
