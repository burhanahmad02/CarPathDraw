using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointbehavior : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.GetChild(0).GetComponent<Animator>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            if (GameManager.Instance.Level_fail == false)
            {
                GetComponent<BoxCollider2D>().enabled = false;
                GameManager.carpos = this.transform.position;
                this.transform.GetChild(0).GetComponent<Animator>().enabled = true;
            }

        }

    }
}
