using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimalBehavior : MonoBehaviour
{
 
    bool one;
    // Start is called before the first frame update
    void Start()
    {
        one = false;
    }

    // Update is called once per frame
    //private void Update()
    //{
    //    if (transform.position.x - GameManager.Instance.CurrrentCar.transform.position.x <= 100 && transform.position.x - GameManager.Instance.CurrrentCar.transform.position.x >= -100)
    //    {
    //        if (PlayerPrefs.GetInt("sound") == 0)
    //        {
    //            GetComponent<AudioSource>().enabled = true;
    //        }
    //    }
    //    else
    //    {
    //        if (PlayerPrefs.GetInt("sound") == 0)
    //        {
    //            GetComponent<AudioSource>().enabled = false;
    //        }
    //    }
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (GameManager.StartShieldEffect == false)
        {
            if (this.gameObject.tag == "animal")
            {
                if (collision.gameObject.tag == "Car" && one == false||collision.gameObject.tag=="line")
                {
                    one = true;
                    this.GetComponent<BoxCollider2D>().enabled = false;
                    GameManager.Instance.PopUpText.gameObject.SetActive(true);
                    GameManager.Instance.PopUpText.text = "Path Draw Over Animal";
                    //  GetComponent<ExplosionForce2D>().enabled = true;
                    if (PlayerPrefs.GetInt("sound") == 0)
                    {
                        GetComponent<AudioSource>().enabled = true;
                    }
                    
                    GameManager.Instance.Level_fail = true;
                    Destroy(gameObject, 1f);
                }
            }
            else if (this.gameObject.tag == "bird" )
            {
                if (collision.gameObject.tag == "line" && one == false && collision.gameObject.GetComponent<DestroyPath>().canDestroy == false)
                {
                    Debug.Log("aaaa");
                    one = true;
                    this.GetComponent<BoxCollider2D>().enabled = false;
                    if (PlayerPrefs.GetInt("sound") == 0)
                    {
                        GetComponent<AudioSource>().enabled = true;
                    }
                    GameManager.Instance.PopUpText.gameObject.SetActive(true);
                    GameManager.Instance.PopUpText.text = "Path Draw Over Bird";
                    GameManager.Instance.Level_fail = true;
                    Destroy(gameObject, 1f);
                }
               
                if (collision.gameObject.tag == "Car" && one == false)
                {
                    one = true;
                    this.GetComponent<BoxCollider2D>().enabled = false;
                    if (PlayerPrefs.GetInt("sound") == 0)
                    {
                        GetComponent<AudioSource>().enabled = true;
                    }

                    GameManager.Instance.Level_fail = true;
                    Destroy(gameObject, 1f);
                    if (this.gameObject.tag == "bird")
                    {
                        GameManager.Instance.PopUpText.gameObject.SetActive(true);
                        GameManager.Instance.PopUpText.text = "Car Hits Bird";
                    }
                    else if (this.gameObject.tag == "animal")
                    {
                        GameManager.Instance.PopUpText.gameObject.SetActive(true);
                        GameManager.Instance.PopUpText.text = "Car Hits Animal";
                    }
                }
            }
        }
        else
        {

            if (collision.gameObject.tag == "Car" && this.gameObject.tag == "animal" || this.gameObject.tag == "bird")
            {
                this.GetComponent<BoxCollider2D>().enabled = false;
                GetComponent<ExplosionForce2D>().enabled = true;
                if (PlayerPrefs.GetInt("sound") == 0)
                {

                    GetComponent<AudioSource>().enabled = true;
                }
                Destroy(gameObject);
            }
            else if (one == false && collision.gameObject.tag == "line"&&this.gameObject.tag=="animal")
            {
                one = true;
                this.GetComponent<BoxCollider2D>().enabled = false;
                GameManager.Instance.PopUpText.gameObject.SetActive(true);
                GameManager.Instance.PopUpText.text = "Path Draw Over Animal";
                //  GetComponent<ExplosionForce2D>().enabled = true;
                if (PlayerPrefs.GetInt("sound") == 0)
                {
                    GetComponent<AudioSource>().enabled = true;
                }

                GameManager.Instance.Level_fail = true;
                Destroy(gameObject, 1f);
            }
            else if (collision.gameObject.tag == "line" && one == false && collision.gameObject.GetComponent<DestroyPath>().canDestroy == false&&this.gameObject.tag=="bird")
            {
                Debug.Log("aaaa");
                one = true;
                this.GetComponent<BoxCollider2D>().enabled = false;
                if (PlayerPrefs.GetInt("sound") == 0)
                {
                    GetComponent<AudioSource>().enabled = true;
                }
                GameManager.Instance.PopUpText.gameObject.SetActive(true);
                GameManager.Instance.PopUpText.text = "Path Draw Over Bird";
                GameManager.Instance.Level_fail = true;
                Destroy(gameObject, 1f);
            }

        }



    }
}
