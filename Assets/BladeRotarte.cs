using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BladeRotarte : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0, 0, 50 * Time.deltaTime);
        if (transform.position.x - GameManager.Instance.CurrrentCar.transform.position.x <= 100 && transform.position.x - GameManager.Instance.CurrrentCar.transform.position.x >= -100)
        {
            this.GetComponent<AudioSource>().enabled = true;
        }
        else
        {
            this.GetComponent<AudioSource>().enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            this.GetComponent<CircleCollider2D>().enabled = false;
            VehicleSimpleControl.Instance.DestroyBike();
            GameManager.Instance.Level_fail = true;
            Invoke("DestroyBlade", 3);
        }
    }
    public void DestroyBlade()
    {
        Destroy(this.transform.parent.transform.parent.gameObject);
    }
}
