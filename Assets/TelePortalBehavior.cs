using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePortalBehavior : MonoBehaviour
{
    public AudioClip TeleportSound;
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
            if (GameManager.Instance.Level_fail == false)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<AudioSource>().PlayOneShot(TeleportSound);
            
                GameManager.abc = false;
            }
           


        }

    }
}
