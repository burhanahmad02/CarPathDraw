using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateStones : MonoBehaviour
{
    public GameObject StonePrefab;
    bool gen;
    bool one;
    float t;
    GameObject stone;
    public static Transform car;
    int count;

    // Start is called before the first frame update
    void Start()
    {
        gen = false;
        one = false;
        t = 0;
        transform.parent = null;
        count = 0;
      //  car = GameObject.FindGameObjectWithTag("Car").transform;
        // car = GameObject.FindGameObjectWithTag("Car").transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (car!=null)
        {
          
            // car = GameManager.Instance.Vehicles[GameManager.EnvirenmentNo].transform;

            if (transform.localPosition.x-70 <= car.localPosition.x && one == false)
            {
                Debug.Log("aaaaaaaaa");
                one = true;
               
            }
        }


        if (t <= 0 && one == true)
        {
            t = 2;
            gen = true;
        }


        if (gen == true)
        {
            count++;
            gen = false;
            if (count <= 5)
            {
               
                stone = Instantiate(StonePrefab, transform.position, Quaternion.identity) as GameObject;
                Destroy(stone, 15);
            }
            
            
            
        }

        if (t >=0&&t<=2.1f&&one==true)
        {
            t -= Time.deltaTime ;
          //  Debug.Log(t);

        }
        if (count >= 5)
        {
            Destroy(this.gameObject);
        }
        if (DestroyPath.IntantDestroy == true&&one)
        {
            Destroy(gameObject);
        }
        
    }
}
