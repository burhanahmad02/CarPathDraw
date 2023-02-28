using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CoinBehavior : MonoBehaviour
{
    public int CoinValue;
    float elapsed;
    bool transition;
    bool onetime;
    int r;

    // Start is called before the first frame update
    void Start()
    {
        this.GetComponent<CircleCollider2D>().radius = 3f;
        elapsed = 0;
        transition = false;
        onetime = false;
        r = Random.Range(0,2);
        if (VehicleSimpleControl.DistanceCovered > 0 && VehicleSimpleControl.DistanceCovered <= 500)
        {

            if (r == 0)
            {
                CoinValue = 5;
            }
            else if (r == 1)
            {
                CoinValue = 10;
            }
            else if (r == 2)
            {
                CoinValue = 50;
            }
        }
        else if (VehicleSimpleControl.DistanceCovered > 500 && VehicleSimpleControl.DistanceCovered <= 1000)
        {

            if (r == 0)
            {
                CoinValue = 10;
            }
            else if (r == 1)
            {
                CoinValue = 50;
            }
            else if (r == 2)
            {
                CoinValue = 100;
            }
        }
        else if (VehicleSimpleControl.DistanceCovered > 1000 && VehicleSimpleControl.DistanceCovered <= 1500)
        {

            if (r == 0)
            {
                CoinValue = 50;
            }
            else if (r == 1)
            {
                CoinValue = 100;
            }
            else if (r == 2)
            {
                CoinValue = 500;
            }
        }
        else if (VehicleSimpleControl.DistanceCovered > 1500)
        {

            if (r == 100)
            {
                CoinValue = 50;
            }
            else if (r == 1)
            {
                CoinValue = 500;
            }
            else if (r == 2)
            {
                CoinValue = 1000;
            }
        }
        if (CoinValue == 5)
        {
            transform.GetChild(0).gameObject.SetActive(true);

        }
        else if (CoinValue == 10)
        {
            transform.GetChild(1).gameObject.SetActive(true);

        }
        else if (CoinValue == 50)
        {
            transform.GetChild(2).gameObject.SetActive(true);

        }
        else if (CoinValue == 100)
        {
            transform.GetChild(3).gameObject.SetActive(true);

        }
        else if (CoinValue == 500)
        {
            transform.GetChild(4).gameObject.SetActive(true);

        }
        else if (CoinValue == 1000)
        {
            transform.GetChild(5).gameObject.SetActive(true);

        }
    }
    private void Update()
    {
        if (GameManager.StartMagnetEffect == true)
        {
            
            if (transform.position.x - GameManager.Instance.CurrrentCar.transform.position.x<=50 && transform.position.x - GameManager.Instance.CurrrentCar.transform.position.x >= -50 && onetime ==false)
            {
                onetime = true;
                transition = true;
            }

        }
        if (transition)
        {
            elapsed += Time.deltaTime*0.2f;
            transform.position = Vector3.Lerp(transform.position, GameManager.Instance.CurrrentCar.transform.localPosition, elapsed);
        }
        if (elapsed >= 1)
        {
            transition = false;
        }
    }

    // Update is called once per frame

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {


            this.GetComponent<CircleCollider2D>().enabled = false;
            transform.parent = Camera.main.transform;
            GameManager.CoinCollectSound = true;
            GetComponents<DOTweenAnimation>()[0].DOPlay();
            if(GameObject.FindGameObjectWithTag("score")!=null)
            {
                GameObject.FindGameObjectWithTag("score").GetComponent<DOTweenAnimation>().DORestart();
            }
           
            GameManager.Coin_Score += CoinValue;
            GameManager.Total_Coin_Score += CoinValue;
           
        }
     
    }
    public void OnComplete()
    {
        Destroy(this.gameObject);
    }
}
