using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Analytics;

public class Finish : MonoBehaviour
{
    public static int checkCount = 0;
    public bool isParticlePlayed;
    public GameObject particleSuccess;
    public bool hasPlayed;
    //int variables for current, next and previous levels
    /*public int currentLevel = 1;
    public int nextLevel = 2;
    public int previousLevel;*/
    //GameObjects for LevelComplete and LevelFail Panel
   // public GameObject levelComplete;
   // public GameObject level_Fail;
    //Bool variable to enable or disable car movespeed
   // public static bool stopCar = true;
    //bool variables for level pass and level fail panels
    //public bool levelPass;
    //public bool levelFail;
    //Float variable for total time to complete a level
   // public float levelTimer = 15f;
    //Instance of class
    public Collider2D collider2D;
    private static Finish _instance = null;
    public static Finish Instance { get { return _instance; } }
    private void Awake()
    {
        isParticlePlayed = false;
        particleSuccess.SetActive(false);
        hasPlayed = false;
       // levelPass = false;
        _instance = null;
        if (_instance != null && _instance != this)
        {
          
            
        }
        else
        {
            _instance = this;
        }
        //gameObject.GetComponent<DOTweenAnimation>().enabled = false;
        DOTween.Pause("flag");
        
    }

    private void Start()
    {
        isParticlePlayed = false;
        particleSuccess.SetActive(false);
        hasPlayed = false;
    }

   

    private void OnTriggerEnter2D(Collider2D collision)
      {
          if (collision.gameObject.CompareTag("Car") )

          {
             
              DOTween.Play("flag");
              //VehicleSimpleControl._instance.RacePress = false;
              //VehicleSimpleControl._instance.rigidBody.bodyType = RigidbodyType2D.Static;
              //VehicleSimpleControl._instance.RacePress = false;
              GameManager.Instance.levelPass = true;
              if (GameManager.Instance.env == 49)
              {
                  GameManager.startRandom = true;
              }
              if (!hasPlayed)
              {
                  gameObject.GetComponent<AudioSource>().Play();
                  hasPlayed = true;
              }

              if (!isParticlePlayed)
              {
                  particleSuccess.SetActive(true);
                  isParticlePlayed = true;
              }
              
              
              
              
              VehicleSimpleControl.Instance.GetComponent<AudioSource>().enabled = false;
              VehicleSimpleControl.Instance.GetComponent<AudioSource>().volume = 0;
              VehicleSimpleControl.Instance.GetComponent<AudioSource>().pitch = 0;
             
        
              /*stopCar = true;
              VehicleSimpleControl._instance.rigidBody.bodyType = RigidbodyType2D.Static;
              VehicleSimpleControl._instance.moveSpeed = 0;*/
              //levelPass = true;
              



          }
          /*if (levelPass)
          {
              Invoke(nameof(LevelPass),1.5f);
              
          }*/
  
      }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Car") )
              
        {
            Debug.Log("Levelll" + GameManager.EnvirenmentNo);
            Debug.Log("Levellllll"+GameManager.Instance.env);
            PlayerPrefs.SetInt("ReloadLevel",GameManager.Instance.env+1);
            //PlayerPrefs.SetInt("EnvironmentNo",);
            if(checkCount==0)
            {
                if (GameManager.lastLevel)
                {
                    //removes the number/level from the list which was loaded, this prevents the repetition of levels
                    GameManager.Instance.randomLevels.RemoveAt(GameManager.EnvirenmentNo);
                    //stores the random level list in playerprefs
                    PlayerPrefs.SetString("randomLevels", string.Join(",",GameManager.Instance.randomLevels.ToArray()));
                    checkCount++;
                }  
            }
            /**/
            GameManager.Instance.levelReward = true;
            if (!isParticlePlayed)
            {
                particleSuccess.SetActive(true);
                isParticlePlayed = true;
            }

            //VehicleSimpleControl._instance.RacePress = false;
            //VehicleSimpleControl._instance.rigidBody.bodyType = RigidbodyType2D.Static;
            //VehicleSimpleControl._instance.RacePress = false;
            VehicleSimpleControl.Instance.GetComponent<AudioSource>().enabled = false;
            VehicleSimpleControl.Instance.GetComponent<AudioSource>().volume = 0;
            VehicleSimpleControl.Instance.GetComponent<AudioSource>().pitch = 0;
            /*stopCar = true;
            VehicleSimpleControl._instance.rigidBody.bodyType = RigidbodyType2D.Static;
            VehicleSimpleControl._instance.moveSpeed = 0;*/
            //levelPass = true;



        }
        /*if (levelPass)
        {
            Invoke(nameof(LevelPass),1.5f);
            
        }*/
  
    }

    /*
    private void OnTriggerExit2D(Collider2D other)
    {
        
        levelPass = false;
        levelComplete.SetActive(false);
    }
*/


    /*public void Update()
    {
       levelTimer -= Time.deltaTime;
      // Debug.Log(levelTimer);
        if(levelTimer <= 0 && !levelPass)
        {
            //GameOver Panel
            levelFail = true;
            if (levelFail)
            {
                LevelFail();
            }
           
            
        }
        
    }*/

    /*public void LevelPass()
    {
        if (levelPass)
        {
            stopCar = true;
            Time.timeScale = 0f;
            currentLevel = currentLevel + 1;
            nextLevel += 1;
            previousLevel = currentLevel - 1;
            levelComplete.SetActive(true);
            if (LinesDrawer.Instance.transformObj.transform.childCount > 0)
            {
                DestroyImmediate(LinesDrawer.Instance.transformObj.GetChild(0).gameObject);
            }
           
        }

        levelPass = false;

    }*/

    /*public void LevelFail()
    {
        stopCar = true;
        Time.timeScale = 0f;
        level_Fail.SetActive(true);
       
    }*/
}
