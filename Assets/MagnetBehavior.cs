using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class MagnetBehavior : MonoBehaviour
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
            GameManager.MagnetStart = true;
            transform.parent = Camera.main.transform;
            GetComponents<DOTweenAnimation>()[0].DOPlay();

            this.GetComponent<AudioSource>().PlayOneShot(fuelClip);
        }
      
       
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        this.GetComponent<BoxCollider2D>().isTrigger = enabled;
    }
    public void OnComplete()
    {
        Destroy(this.gameObject, 5);
    }
}
