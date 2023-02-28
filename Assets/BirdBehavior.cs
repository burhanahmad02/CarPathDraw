using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdBehavior : MonoBehaviour
{
    bool one;


    public static Transform car;
    // Start is called before the first frame update
    void Start()
    {
        one = false;
        transform.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (car != null)
        {
            // car = GameManager.Instance.Vehicles[GameManager.EnvirenmentNo].transform;
           // car = GameObject.FindGameObjectWithTag("Car").transform;
            if (transform.localPosition.x - 200 <= car.localPosition.x && one == false)
            {
                Debug.Log("aaaaaaaaa");
                one = true;
                transform.GetChild(0).gameObject.SetActive(true);

            }
        }
    }
}
