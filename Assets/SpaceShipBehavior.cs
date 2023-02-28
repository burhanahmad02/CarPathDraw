using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipBehavior : MonoBehaviour
{
    bool check;
    // Start is called before the first frame update
    void Start()
    {
        check = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (GameManager.Instance.CurrrentCar.transform.position.x >= this.transform.position.x+500)
        {
            Destroy(this.gameObject);

        }

        if (this.transform.position.x-80 <= GameManager.Instance.CurrrentCar.transform.position.x&&check==false)
        {
            check = true;
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;

        }
        if (check)
        {
           // abc();
        }
        
    }
    public void abc()
    {
        if (transform.position.x - GameManager.Instance.CurrrentCar.transform.position.x <= 100 && transform.position.x - GameManager.Instance.CurrrentCar.transform.position.x >= -100)
        {
            this.GetComponent<AudioSource>().enabled = true;
        }
       
        Vector3 screenPoint = Camera.main.WorldToViewportPoint(transform.position);
        bool onScreen = screenPoint.z > 0 && screenPoint.x > 0 && screenPoint.x < 1 && screenPoint.y > 0 && screenPoint.y < 1;
        //Debug.Log(screenPoint);
        if (onScreen)
        {
           
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            this.GetComponent<Rigidbody2D>().mass = 100;
        }
        if (collision.gameObject.tag == "Car")
        {
            this.transform.GetChild(0).gameObject.SetActive(true);
            Invoke("destroythis", 3);
            //VehicleSimpleControl.Instance.DestroyBike();
           // GameManager.Instance.Level_fail = true;
        }

    }
    public void destroythis()
    {
       // Destroy(this.gameObject);
    }
}
