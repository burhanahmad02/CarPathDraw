using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveTiles : MonoBehaviour
{
    public static bool firsttile;
    public GameObject[] Tiles;
    private IEnumerator coroutine;
    // Start is called before the first frame update
    void Start()
    {
        if (firsttile)
        {
            firsttile = false;
            for (int i = 0; i < Tiles.Length; i++)
            {
                Tiles[i].SetActive(true);
            }

        }
        else
        {
            coroutine = ActiveTileSets();
            StartCoroutine(coroutine);
        }
       
            
        
    }

    IEnumerator ActiveTileSets()
    {
        for (int i = 0; i < Tiles.Length; i++)
        {
            yield return new WaitForSeconds(1f);
            Tiles[i].SetActive(true);
        }
           
       
    }
}
