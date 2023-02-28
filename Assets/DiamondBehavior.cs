using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class DiamondBehavior : MonoBehaviour
{
    public static int DiamondCount;
    bool a;
    private void Start()
    {
        a = false;
    }
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Car")
        {
            this.GetComponent<BoxCollider2D>().enabled = false;
            transform.parent = Camera.main.transform;
            GameManager.CoinCollectSound = true;
            GetComponents<DOTweenAnimation>()[0].DOPlay();
            if (GameObject.FindGameObjectWithTag("bost") != null)
            {
                GameObject.FindGameObjectWithTag("bost").GetComponent<DOTweenAnimation>().DORestart();
            }
            if(GameManager.DiamondCount<10&&a==false)
            {
                a = true;
                GameManager.DiamondCount++;
            }
            
            // GameManager.Total_Coin_Score += CoinValue;
        }

    }
    public void OnComplete()
    {
        Destroy(this.gameObject, 1);
    }
}
