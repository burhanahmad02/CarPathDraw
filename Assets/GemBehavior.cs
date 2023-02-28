using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GemBehavior : MonoBehaviour
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<Rigidbody2D>().gravityScale = 0;
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;

        GetComponent<BoxCollider2D>().isTrigger = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            GetComponent<BoxCollider2D>().enabled = false;
            PlayerPrefs.SetInt("gems", PlayerPrefs.GetInt("gems") + 1);
            transform.parent = Camera.main.transform;
            GetComponents<DOTweenAnimation>()[0].DOPlay();

            this.GetComponent<AudioSource>().PlayOneShot(fuelClip);
           

        }

    }
    public void OnComplete()
    {
        Destroy(this.gameObject, 5);
    }
}
