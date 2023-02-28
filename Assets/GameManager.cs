using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using SimpleUI.ScrollExtensions;
using DG.Tweening;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;
using DG.Tweening;
using UnityEngine.Analytics;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    public static GameManager Instance
    {
        get { return _instance; }
    }

    
    //private DrawingManager drawingManager;
    //constant iteger Max which contains 50 as its value
    public const int Max = 51;
    //list for all the levels to be randomized
    public  List<int> randomLevels = new List<int>();
    //ready bool to enable or disable the ready button when the level starts 
    public bool ready;
    //ready button which allows the user to start drawing whenever they are ready
    public GameObject readyButton;
    //test animations on buttons for teting the levels 1 to 50
    public Animation testButton;
    public Animation testButton1;
    public Animation testButton2;
    public Animation testButton3;
    public Animation testButton4;
    public Animation testButton5;
    public Animation testButton6;
    public Animation testButton7;
    public Animation testButton8;
    public Animation testButton9;
    public Animation testButton10;
    public Animation testButton11;
    public Animation testButton12;
    public Animation testButton13;
    public Animation testButton14;
    public Animation testButton15;
    public Animation testButton16;
    public Animation testButton17;
    public Animation testButton18;
    public Animation testButton19;
    public Animation testButton20;
    public Animation testButton21;
    public Animation testButton22;
    public Animation testButton23;
    public Animation testButton24;
    public Animation testButton25;
    public Animation testButton26;
    public Animation testButton27;
    public Animation testButton28;
    public Animation testButton29;
    public Animation testButton30;
    public Animation testButton31;
    public Animation testButton32;
    public Animation testButton33;
    public Animation testButton34;
    public Animation testButton35;
    public Animation testButton36;
    public Animation testButton37;
    public Animation testButton38;
    public Animation testButton39;
    public Animation testButton40;
    public Animation testButton41;
    public Animation testButton42;
    public Animation testButton43;
    public Animation testButton44;
    public Animation testButton45;
    public Animation testButton46;
    public Animation testButton47;
    public Animation testButton48;
    public Animation testButton49;

   //bool to check if the current level is last level or level 50
    public static bool lastLevel;
    //bool to start randomizing the levels
    public static bool startRandom;
    //static integer named currentlevel which starts itereating +1 after 50th level and is used on planettext name, e.g. Level 51, 52 53 and so on.
    public static int currentLevel = 50 ;
    //reset button allows the user to destroy path they have drawn
    public GameObject resetButton;
    public bool levelReward;
    public bool coinReward;
    public bool coinRewardVideo;
    public GameObject RewardPanel;
    public GameObject startVehicle;
    public Animation buttonAnim;
   //public int currentlevel = 0;
   public int i;
    public bool levelPass;
    public bool levelFail;
    public GameObject MAinMenuPanel;
    public GameObject LevelFAilPanel;
    public GameObject LevelCompletePanel;
    public GameObject LoadingPanel;
    public GameObject[] Vehicles;
    public Text GamePlayScoreText;
    public Slider FuelSlider;
    public static int EnvirenmentNo;
    public int env;
    public Text InstructionText;
    public GameObject VehiclesScrollView;
    public static int Car_number;
    public GameObject[] Cars;
    //test
    public GameObject[] Envs;
    public Text SpeedText;
    public GameObject GamePlayPanel;
    bool InAir;
    public Text FrontFlipText;
    public Text BackFlipText;
    public Text InAirText;
    public Text InAirScoreText;
    bool AddInAirScore;
    int InAirAdder;
    float Air_Score;
    int Total_InAirScore;
    int frontFlip;
    int backFlip;
    bool restvalue;
    int Total_Flip_Score;
    public static int Coin_Score;
    public static int Total_Coin_Score;
    int All_Scores_Sum;
    public bool Level_fail;
    bool OneTime;
    public Text LevelFailInAirScoreText;
    public Text TotalFlipScoreText;
    public Text TotalCoinsScoreText;
    public Text GrandTotalText;
    public Button EnvNextBtn;
    public Button EnvUnlockBtnCoin;
    public Text EnvPurchaseAmountCoinText;
    public Button VehicleNextBtn;
    public Button VehicleUnlockBtnCoin;
    public Text VehiclePriceCoinText;
    int EnvPrice;
    int CarPrice;
    public GameObject EnvSelectionPanel;
    public GameObject CarSelectionPanel;
    public GameObject UpdateBtn;
    public GameObject UpdatePanel;
    public Text EngineUpdatePriceText;
    public Text FarwardUpdatePriceText;
    public Text SuspentionUpdatePriceText;
    public Text TyreUpdatePriceText;
    public Text EngineLevelAchieveText;
    public Text SuspebsionLevelAchieveText;
    public Text TyreLevelAchieveText;
    public Text FarwardLevelAchieveText;
    public Button UpdateEngineBtn;
    public Button UpdateTyresBtn;
    public Button UpdateSuspentionBtn;
    public Button UpdatefarwardBtn;
    public Button DeGradeEngineBtn;
    public Button DegradeTyresBtn;
    public Button DegradeSuspentionBtn;
    public Button DegradefarwardBtn;
    public Slider EngineSlider;
    public Slider TyresSlider;
    public Slider SuspentionSlider;
    public Slider farwardSlider;
    public AudioClip CoinCollect; 
    public AudioClip coinncollect;
    public AudioSource CoinCollectAudioSource;
    public static bool CoinCollectSound;
    public static bool LowFuelInidication;
    public GameObject LowFuelAlertText;
    public GameObject CarInWaterSound;
    public GameObject TrackGenerator;
    public GameObject RayCastPoint;
    float dis;
    public LayerMask whatIsGround;
    public Text coinsscrore;
    string planetName;
    public Text PlanetNameText;
    public Text PlanetGrivityText;
    public Color[] TracksColor;
   // public float duration = 1.0f;
    private float elapsed = 0.0f;
    private bool transition = false;
    public Text LevelFailText;
    public static bool ReviveGame;
    public Button ReviveBtn;
    public GameObject RevivePanel;
    public GameObject SoundOffBtn;
    public GameObject SoundOnBtn;
    public GameObject MusicOffBtn;
    public GameObject MusicOnBtn;
    public GameObject VibrationOffBtn;
    public GameObject VibrationOnBtn;
    public GameObject BackGroundMusic;
    public AudioClip BtnSound;
    public static float DiamondCount;
    public Image BostFillImage;
    public Button BostBtn;
    public static bool BostStart;
    public static Vector3 carpos;
    public Text planetText;
   // public GameObject TutorialPanel;
    public Image MagnetImag;

    public Slider ShieldSlider;
    public Text SlowMoText;
    public static bool MagnetStart;
    public static bool StartMagnetEffect;

    public static bool ShieldStart;
    public static bool StartShieldEffect;

    public static bool SlowMoStart;
    public static bool StartSlowMoEffect;

    float MagnetTime;
    float ShieldTime;
    float SlowMotionTime;
    bool t;
    public GameObject MagnetPrefab;
    public GameObject CurrrentCar;

    public GameObject AbilityPanel;
    public GameObject AbilityPanelGamePlay;
    bool MagnetAbility;
    bool BoostAbility;
    bool ShieldAbility;
    bool SlowMotionAbility;

    public Button MagnetAbilityBtn;
    public Button BoostAbilityBtn;
    public Button ShieldAbilityBtn;
    public Button SlowMoAbilityBtn;

    public Button GameAddMagnetAbilityBtn;
    public Button GameAddBoostAbilityBtn;
    public Button GameAddFuelBtn;
    public Button GameAddShieldAbilityBtn;
    public Button GameAddSlowMoAbilityBtn;
    public Text LowCashText;
    public Text LowCashTextGamePlay;
    public bool drawmanag;
    public GameObject Drawmanag;
    public AudioClip CarDestroySound;
    public static bool abc;
    public Text AbiltyPanelCoinText1;

    public Text AbiltyPanelCoinText2;

    public AudioClip BostSound;
    int currentenv;
    int j;

    public static bool VideoReward;
    public static bool revivevideo;
    public Button UnlockAllVehicleBTn;
    public Button UnlockAllModesBtn;
    public GameObject StartTimer;
    public bool isCarRunning;
    public Text DistanceCoverdText;
    public GameObject TileSets;
    public float CameraMaxValue;
    public Slider CameraSlider;
    public static int CurrentEngineValue;
    public static int CurrentSuspensionValue;
    public static int CurrentTyreValue;
    public static int CurrentfarwardValue;
    public Text UpdatePanelScore;
    public Button SlowMoBtn;
    public Text scoretext1;
    public Text scoretext2;
    public Text abxtext;
    public Text abytext;
    public Text abztext;
    public Button RemoveAdsBtn;
    public bool checkrevive;
    int b = 0;
    public Text PopUpText;
    public Animation coinAnimation;
    public bool coinUpdate;
    public GameObject coinsAudio;
    public AudioClip coinnCollect;
    public bool closeLoading;
    private void Awake()
    {
       
        
       // EnvirenmentNo = PlayerPrefs.GetInt("EnvironmentNo");
        closeLoading = false;
        ready = false;
        PlayerPrefs.SetInt("Score", 1000000000);
        //resetButton.SetActive(true);
        levelReward = false;
        startVehicle.SetActive(false);
        
        drawmanag = false;
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
        }
        coinReward = false;
    }


    public void CloseTutorial()
    {
        if (readyButton.activeInHierarchy)
        {
            //TutorialPanel.SetActive(false);
            
            
                //readyButton.SetActive(false);
                /*StartTimer.gameObject.SetActive(true);
                Invoke("HideTimer", 4);*/
                
                //ready = false;
                Invoke("StartTheCar", 4);
            
            
        }

    }

    void Start()
    {
        randomLevels = new List<int>(Enumerable.Range(1, Max));
        if (lastLevel)
        {
            // PlayerPrefs.SetInt("startRandom",startRandom?1:0);
            //planetText.text = "Level " + currentLevel;
            randomLevels.Clear();
            // PlayerPrefs.GetString("randomLevels", string.Spl(",",GameManager.Instance.randomLevels.ToArray())
            randomLevels.AddRange(PlayerPrefs.GetString("randomLevels").Split(',').Select(s => int.Parse(s)));
        }
        if (PlayerPrefs.GetInt("ReloadLevel")==0||PlayerPrefs.GetInt("ReloadLevel") == 1 || 
            PlayerPrefs.GetInt("ReloadLevel")== 2 ||PlayerPrefs.GetInt("ReloadLevel") == 3 
            || PlayerPrefs.GetInt("ReloadLevel") == 4 
            || PlayerPrefs.GetInt("ReloadLevel") == 5 
            || PlayerPrefs.GetInt("ReloadLevel") == 6
            || PlayerPrefs.GetInt("ReloadLevel")== 7 || PlayerPrefs.GetInt("ReloadLevel") == 8 || 
            PlayerPrefs.GetInt("ReloadLevel") == 9 || PlayerPrefs.GetInt("ReloadLevel") == 10)
        {
            Cars[7].SetActive(true);
            Cars[7].transform.position = new Vector3(Cars[7].transform.position.x, 957,
                Cars[7].transform.position.z);
            CurrentEngineValue = PlayerPrefs.GetInt("car" + 7 + "engine");
            CurrentfarwardValue = PlayerPrefs.GetInt("car" + 7 + "farward");
            CurrentSuspensionValue = PlayerPrefs.GetInt("car" + 7 + "suspension");
            CurrentTyreValue = PlayerPrefs.GetInt("car" + 7 + "tyres");
            //CarPrice = Car_number * 100000;
        }
        else if(PlayerPrefs.GetInt("ReloadLevel") == 11 || PlayerPrefs.GetInt("ReloadLevel") == 12
                         || PlayerPrefs.GetInt("ReloadLevel") == 13 || PlayerPrefs.GetInt("ReloadLevel") == 14 || PlayerPrefs.GetInt("ReloadLevel") == 15
                         ||PlayerPrefs.GetInt("ReloadLevel") == 16 || PlayerPrefs.GetInt("ReloadLevel") == 17 || PlayerPrefs.GetInt("ReloadLevel") == 18 
                         || PlayerPrefs.GetInt("ReloadLevel") == 19 || PlayerPrefs.GetInt("ReloadLevel") == 20)
                 {
                     Cars[8].SetActive(true);
                     Cars[8].transform.position = new Vector3(Cars[8].transform.position.x, 957,
                         Cars[8].transform.position.z);
                     CurrentEngineValue = PlayerPrefs.GetInt("car" + 8 + "engine");
                     CurrentfarwardValue = PlayerPrefs.GetInt("car" + 8 + "farward");
                     CurrentSuspensionValue = PlayerPrefs.GetInt("car" + 8 + "suspension");
                     CurrentTyreValue = PlayerPrefs.GetInt("car" + 8 + "tyres");
                 }
        else if(PlayerPrefs.GetInt("ReloadLevel") == 21 || PlayerPrefs.GetInt("ReloadLevel") == 22 || 
                PlayerPrefs.GetInt("ReloadLevel") == 23 || PlayerPrefs.GetInt("ReloadLevel") == 24 
                || PlayerPrefs.GetInt("ReloadLevel") == 25 || PlayerPrefs.GetInt("ReloadLevel") == 26
                ||PlayerPrefs.GetInt("ReloadLevel") == 27 || PlayerPrefs.GetInt("ReloadLevel") == 28 || 
                PlayerPrefs.GetInt("ReloadLevel") == 29 
                || PlayerPrefs.GetInt("ReloadLevel") == 30)
        {
            Cars[11].SetActive(true);
            Cars[11].transform.position = new Vector3(Cars[11].transform.position.x, 957,
                Cars[11].transform.position.z);
            CurrentEngineValue = PlayerPrefs.GetInt("car" + 11 + "engine");
            CurrentfarwardValue = PlayerPrefs.GetInt("car" + 11 + "farward");
            CurrentSuspensionValue = PlayerPrefs.GetInt("car" + 11 + "suspension");
            CurrentTyreValue = PlayerPrefs.GetInt("car" + 11 + "tyres");
        }
        else if(PlayerPrefs.GetInt("ReloadLevel") == 31 || PlayerPrefs.GetInt("ReloadLevel") == 32 || 
                PlayerPrefs.GetInt("ReloadLevel") == 33 || PlayerPrefs.GetInt("ReloadLevel") == 34 
                || PlayerPrefs.GetInt("ReloadLevel") == 35 || PlayerPrefs.GetInt("ReloadLevel") == 36
                ||PlayerPrefs.GetInt("ReloadLevel") == 37 || PlayerPrefs.GetInt("ReloadLevel") == 38 || 
                PlayerPrefs.GetInt("ReloadLevel") == 39 
                || PlayerPrefs.GetInt("ReloadLevel") == 40)
        {
            Cars[10].SetActive(true);
            Cars[10].transform.position = new Vector3(Cars[10].transform.position.x, 957,
                Cars[10].transform.position.z);
            CurrentEngineValue = PlayerPrefs.GetInt("car" + 10 + "engine");
            CurrentfarwardValue = PlayerPrefs.GetInt("car" + 10 + "farward");
            CurrentSuspensionValue = PlayerPrefs.GetInt("car" + 10 + "suspension");
            CurrentTyreValue = PlayerPrefs.GetInt("car" + 10 + "tyres");
        }
        else if(PlayerPrefs.GetInt("ReloadLevel") == 41 || PlayerPrefs.GetInt("ReloadLevel") == 42 || 
                PlayerPrefs.GetInt("ReloadLevel") == 43 || PlayerPrefs.GetInt("ReloadLevel") == 44 
                || PlayerPrefs.GetInt("ReloadLevel") == 45 || PlayerPrefs.GetInt("ReloadLevel") == 46
                ||PlayerPrefs.GetInt("ReloadLevel") == 47 || PlayerPrefs.GetInt("ReloadLevel") == 48 || 
                PlayerPrefs.GetInt("ReloadLevel") == 49 
                || PlayerPrefs.GetInt("ReloadLevel") == 50)
        {
            Cars[15].SetActive(true);
            Cars[15].transform.position = new Vector3(Cars[15].transform.position.x, 957,
                Cars[15].transform.position.z);
            CurrentEngineValue = PlayerPrefs.GetInt("car" + 15 + "engine");
            CurrentfarwardValue = PlayerPrefs.GetInt("car" + 15 + "farward");
            CurrentSuspensionValue = PlayerPrefs.GetInt("car" + 15 + "suspension");
            CurrentTyreValue = PlayerPrefs.GetInt("car" + 15 + "tyres");
        }
        Finish.checkCount = 0;
        //EnvirenmentNo = PlayerPrefs.GetInt("EnvironmentNo");
        closeLoading = false;
        coinUpdate = false;
       
        //currentLevel = PlayerPrefs.GetInt("CurrentLevel");
        ready = false;
       //readyButton.SetActive(true);
        //EnvirenmentNo = PlayerPrefs.GetInt("CurrentLevel");
        resetButton.SetActive(true);
        levelReward = false;
        startVehicle.SetActive(true);
        startVehicle.GetComponent<Button>().enabled = false;
        startVehicle.GetComponent<Animation>().enabled = false;
        coinReward = false;
        drawmanag = false;
        env = EnvirenmentNo;
        levelPass = false;
        
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        AudioListener.pause = false;
        checkrevive = false;

        abc = false;
        ActiveTiles.firsttile = true;
        revivevideo = false;
        VideoReward = false;
        isCarRunning = false;
        coinRewardVideo = false;
        t = false;

        planetName = "";
        DiamondCount = 0;
        ReviveGame = false;
        BostStart = false;
        MagnetTime = 0;
        ShieldTime = 0;
        SlowMotionTime = 0;

        SoundCheck();
        MusicCheck();
        VibrationCheck();
        MagnetStart = false;
        StartMagnetEffect = false;
        ShieldStart = false;
        StartShieldEffect = false;
        SlowMoStart = false;
        StartSlowMoEffect = false;
        VehicleSimpleControl.DistanceCovered = 0;
        VehicleSimpleControl.OneTime = false;
        Drawmanag.gameObject.SetActive(false);
        
        Invoke("close", 1);
        if (PlayerPrefs.GetInt("restart") == 0)
        {
            Time.timeScale = 1;
            PlayerPrefs.SetInt("env0", 2);
            PlayerPrefs.SetInt("car0", 2);
            Level_fail = false;
            InAir = false;
            Air_Score = 0;
            Total_InAirScore = 0;
            AddInAirScore = false;
            Car_number = 0;
            InAirAdder = 0;
            frontFlip = 0;
            backFlip = 0;
            restvalue = false;
            Total_Flip_Score = 0;
            OneTime = false;

            Coin_Score = 0;
            Total_Coin_Score = 0;
            All_Scores_Sum = 0;
            EnvirenmentNo = 1;
            CoinCollectSound = false;
            LowFuelInidication = false;
            MagnetAbility = false;
            BoostAbility = false;
            ShieldAbility = false;
            SlowMotionAbility = false;

            if (PlayerPrefs.GetInt("car" + Car_number + "engine") == 0)
            {
                PlayerPrefs.SetInt("car" + Car_number + "engine", 1);
            }

            if (PlayerPrefs.GetInt("car" + Car_number + "suspension") == 0)
            {
                PlayerPrefs.SetInt("car" + Car_number + "suspension", 1);
            }

            if (PlayerPrefs.GetInt("car" + Car_number + "tyres") == 0)
            {
                PlayerPrefs.SetInt("car" + Car_number + "tyres", 1);
            }

            if (PlayerPrefs.GetInt("car" + Car_number + "farward") == 0)
            {
                PlayerPrefs.SetInt("car" + Car_number + "farward", 1);
            }

            CurrentEngineValue = PlayerPrefs.GetInt("car" + Car_number + "engine");
            CurrentfarwardValue = PlayerPrefs.GetInt("car" + Car_number + "farward");
            CurrentSuspensionValue = PlayerPrefs.GetInt("car" + Car_number + "suspension");
            CurrentTyreValue = PlayerPrefs.GetInt("car" + Car_number + "tyres");

        }

        if (PlayerPrefs.GetInt("restart") == 1)
        {
            Time.timeScale = 1;
            PlayerPrefs.SetInt("restart", 0);

            Level_fail = false;
            InAir = false;
            Air_Score = 0;
            Total_InAirScore = 0;
            AddInAirScore = false;
            InAirAdder = 0;
            frontFlip = 0;
            backFlip = 0;
            restvalue = false;
            Total_Flip_Score = 0;
            OneTime = false;

            Coin_Score = 0;
            Total_Coin_Score = 0;
            All_Scores_Sum = 0;
            CoinCollectSound = false;
            LowFuelInidication = false;
            MAinMenuPanel.SetActive(false);
            LoadingPanel.SetActive(true);
            GamePlayPanel.SetActive(true);
            GetEnvirementInfo(EnvirenmentNo);
            
         //   VehicleSimpleControl._instance.rigidBody.bodyType = RigidbodyType2D.Static;
            GameStart();
        }

        ShowBannerTop();
        /*if (PlayerPrefs.GetInt("next") == 1)
        {
            Time.timeScale = 1;
            PlayerPrefs.SetInt("next", 0);

            //Level_fail = false;
            //InAir = false;
            Air_Score = 0;
            Total_InAirScore = 0;
            AddInAirScore = false;
            InAirAdder = 0;
            frontFlip = 0;
            backFlip = 0;
            restvalue = false;
            Total_Flip_Score = 0;
            OneTime = true;

            Coin_Score = 0;
            Total_Coin_Score = 0;
            All_Scores_Sum = 0;
            CoinCollectSound = false;
            LowFuelInidication = false;
            MAinMenuPanel.SetActive(false);
            LoadingPanel.SetActive(true);
            GamePlayPanel.SetActive(true);
            GetEnvirementInfo(EnvirenmentNo);
            GameStart();
        }*/
    }

    public void close()
    {
        TileSets.SetActive(false);
    }

    public void ReadyTrue()
    {
        ready = true;
    }
    public void LevelFail()
    {
        Drawmanag.SetActive(false);
        LevelFailText.gameObject.SetActive(false);
        GamePlayPanel.SetActive(false);
        LevelFAilPanel.SetActive(true);
        /*Invoke(nameof(Stop),1.5f);*/
        //gameObject.GetComponent<>().enabled = false;
        //All_Scores_Sum = Total_Coin_Score;
        StartCoroutine(AddScore());
        PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + All_Scores_Sum);
        Debug.Log("Sum  " + All_Scores_Sum);
        //ShowInterstial();
        ShowBannerTop();
        Time.timeScale = 0f;
        levelFail = true;
        levelPass = false;
    }

    /*public void Stop()
    {
        VehicleSimpleControl.Instance.rigidBody.bodyType = RigidbodyType2D.Static;
    }*/
    public void LevelComplete()  //  <-  its a standalone method
    {
       
       // PlayerPrefs.SetInt("CurrentLevel",currentLevel);
        levelReward = false;
        Drawmanag.SetActive(false);
        VehicleSimpleControl.Instance.BodyColide = false;
        //EnvirenmentNo = EnvirenmentNo + 1;
        if (EnvirenmentNo == 50)
        {
            lastLevel = true;
            PlayerPrefs.SetInt("lastLevel",lastLevel?1:0);
            PlayerPrefs.SetInt("startRandom",startRandom?1:0);
            startRandom = true;
            //PlayerPrefs.SetInt("CurrentLevel", EnvirenmentNo);
           
        }
        if (levelPass)
        {
          
            Finish.Instance.particleSuccess.SetActive(false);
           // currentLevel ++;
            //LevelFailText.gameObject.SetActive(false);
            GamePlayPanel.SetActive(false);
            //yield return new WaitForSeconds(1);
            LevelCompletePanel.SetActive(true);
            All_Scores_Sum = Total_Coin_Score;
            StartCoroutine(AddScore());
            PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") + All_Scores_Sum);
            Debug.Log("Sum  " + All_Scores_Sum);
            //ShowInterstial();
            ShowBannerTop();
            levelFail = false;  
        }

    }
   

    IEnumerator AddScore()
    {
        float inairsc = 0;

        float totalcoinsc = 0;
        float flipsc = 0;
        float sumsc = 0;
        float duration = 2.5f;
        for (float t = 0.0f; t < duration; t += Time.fixedDeltaTime)
        {
          

            totalcoinsc = (int) Mathf.Lerp(totalcoinsc, Total_Coin_Score, t / duration);
           
            sumsc = (int) Mathf.Lerp(flipsc, All_Scores_Sum, t / duration);
           
            TotalCoinsScoreText.text = totalcoinsc.ToString();
           
            if (coinUpdate)
            {
               GrandTotalText.text = sumsc.ToString(PlayerPrefs.GetInt("score").ToString());
            
            }
            
            yield return null;
        }

    
        TotalCoinsScoreText.text = Total_Coin_Score.ToString();
      
        if (coinUpdate)
        {
            GrandTotalText.text = PlayerPrefs.GetInt("score").ToString();
            coinUpdate = false;
        }
       
    }

    public void closetext()
    {
        LowCashText.gameObject.SetActive(false);
        LowCashTextGamePlay.gameObject.SetActive(false);
    }

    public void NextBtn()
    {
    }

    void Update()
    {
        if (closeLoading)
        {
            closeLoading = false;
            
            Invoke(nameof(Ready),0.2f);
        }
        //keeps the lastlevel bool true once the level 50 has been played to keep randomizing the levels from randomlevels list
        if (lastLevel)
        {
            lastLevel = true;
        }
        if (levelPass)
        {
            VehicleSimpleControl.Instance.BodyColide = false;
        }

        
        Camera.main.transform.GetChild(EnvirenmentNo).gameObject.transform.localScale =
            new Vector3(Camera.main.orthographicSize / 3f, Camera.main.orthographicSize / 3f, 1);
        scoretext1.text = PlayerPrefs.GetInt("score").ToString();
        scoretext2.text = PlayerPrefs.GetInt("score").ToString();
        DistanceCoverdText.text = ((int) (VehicleSimpleControl.DistanceCovered)).ToString();
        if (PlayerPrefs.GetInt("env1") == 2 && PlayerPrefs.GetInt("env2") == 2 && PlayerPrefs.GetInt("env3") == 2 &&
            PlayerPrefs.GetInt("env4") == 2)
        {
            UnlockAllModesBtn.gameObject.SetActive(false);
        }

        if (PlayerPrefs.GetInt("car1") == 2 && PlayerPrefs.GetInt("car2") == 2 && PlayerPrefs.GetInt("car3") == 2 &&
            PlayerPrefs.GetInt("car4") == 2 && PlayerPrefs.GetInt("car5") == 2 && PlayerPrefs.GetInt("car6") == 2)
        {
            UnlockAllVehicleBTn.gameObject.SetActive(false);
        }
        else
        {
            UnlockAllVehicleBTn.gameObject.SetActive(true);
        }

        if (PlayerPrefs.GetInt("removeads") >= 2)
        {
            RemoveAdsBtn.gameObject.SetActive(false);
        }
        else
        {
            RemoveAdsBtn.gameObject.SetActive(true);
        }

        if (AbilityPanel.activeInHierarchy)
        {
            AbiltyPanelCoinText1.text = PlayerPrefs.GetInt("score").ToString();

        }

        if (AbilityPanelGamePlay.activeInHierarchy)
        {
            AbiltyPanelCoinText2.text = PlayerPrefs.GetInt("score").ToString();


            if (VehicleSimpleControl.Instance.FuelLevel < 20)
            {
                GameAddFuelBtn.interactable = true;
                GameAddFuelBtn.transform.GetChild(0).GetComponent<Image>().color = new Color32(255, 255, 255, 255);
            }
            else
            {
                GameAddFuelBtn.interactable = false;
                GameAddFuelBtn.transform.GetChild(0).GetComponent<Image>().color = new Color32(73, 73, 73, 255);
            }

            if (MagnetTime < 0.01)
            {
                GameAddMagnetAbilityBtn.interactable = true;
                GameAddMagnetAbilityBtn.transform.GetChild(0).GetComponent<Image>().color =
                    new Color32(255, 255, 255, 255);
            }
            else
            {
                GameAddMagnetAbilityBtn.interactable = false;
                GameAddMagnetAbilityBtn.transform.GetChild(0).GetComponent<Image>().color =
                    new Color32(73, 73, 73, 255);
            }

            if (DiamondCount < 10)
            {
                GameAddBoostAbilityBtn.interactable = true;
                GameAddBoostAbilityBtn.transform.GetChild(0).GetComponent<Image>().color =
                    new Color32(255, 255, 255, 255);
            }
            else
            {
                GameAddBoostAbilityBtn.interactable = false;
                GameAddBoostAbilityBtn.transform.GetChild(0).GetComponent<Image>().color = new Color32(73, 73, 73, 255);
            }


            if (SlowMotionAbility == false)
            {
                GameAddSlowMoAbilityBtn.interactable = true;
                GameAddSlowMoAbilityBtn.transform.GetChild(0).GetComponent<Image>().color =
                    new Color32(255, 255, 255, 255);
            }
            else
            {
                GameAddSlowMoAbilityBtn.interactable = false;
                GameAddSlowMoAbilityBtn.transform.GetChild(0).GetComponent<Image>().color =
                    new Color32(73, 73, 73, 255);
            }


            if (ShieldTime < 0.01)
            {
                GameAddShieldAbilityBtn.interactable = true;
                GameAddShieldAbilityBtn.transform.GetChild(0).GetComponent<Image>().color =
                    new Color32(255, 255, 255, 255);
            }
            else
            {
                GameAddShieldAbilityBtn.interactable = false;
                GameAddShieldAbilityBtn.transform.GetChild(0).GetComponent<Image>().color =
                    new Color32(73, 73, 73, 255);
            }


        }

        if (LowCashText.gameObject.activeInHierarchy || LowCashTextGamePlay.gameObject.activeInHierarchy)
        {
            Invoke("closetext", 2);
        }


        if (ReviveGame == true)
        {
            
            Drawmanag.SetActive(false);
            Time.timeScale = 1;
            PopUpText.gameObject.SetActive(false);
            AudioListener.pause = false;
            DiamondCount = 0;
            ReviveGame = false;
            LevelFailText.gameObject.SetActive(false);
            RevivePanel.SetActive(false);
            Level_fail = false;
            OneTime = false;
            Destroy(CurrrentCar.gameObject);
            DestroyPath.IntantDestroy = true;
            RanDomExplosionForce.instantDestroy = true;

            CurrrentCar =
                Instantiate(Vehicles[Car_number], new Vector3(carpos.x, carpos.y, 1),
                    Quaternion.identity) as GameObject;
            CurrrentCar.gameObject.SetActive(true);
            CurrrentCar.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
           
          
            Invoke("StartTheCar", 4);
            
         
            VehicleSimpleControl.Instance.FuelLevel = 100;
            checkrevive = true;
        } 
        if (coinReward == true)
        {
            
            Time.timeScale = 1;
            PopUpText.gameObject.SetActive(false);
            AudioListener.pause = false;
            coinReward = false;
            RewardPanel.SetActive(false);
        }

        if (MAinMenuPanel.activeInHierarchy)
        {
            coinsscrore.text = PlayerPrefs.GetInt("score").ToString();

        }

        if (UpdatePanel.activeInHierarchy)
        {

            UpdatePanelScore.text = PlayerPrefs.GetInt("score").ToString();

            EngineSlider.value = CurrentEngineValue;
            farwardSlider.value = CurrentfarwardValue;
            SuspentionSlider.value = CurrentSuspensionValue;
            TyresSlider.value = CurrentTyreValue;



            if (CurrentEngineValue >= 10)
            {
                UpdateEngineBtn.interactable = false;
            }
            else
            {
                UpdateEngineBtn.interactable = true;
            }

            if (CurrentEngineValue <= 1)
            {
                DeGradeEngineBtn.interactable = false;
            }
            else
            {
                DeGradeEngineBtn.interactable = true;
            }

            if (CurrentSuspensionValue >= 10)
            {
                UpdateSuspentionBtn.interactable = false;
            }
            else
            {
                UpdateSuspentionBtn.interactable = true;
            }

            if (CurrentSuspensionValue <= 1)
            {
                DegradeSuspentionBtn.interactable = false;
            }
            else
            {
                DegradeSuspentionBtn.interactable = true;
            }

            if (CurrentTyreValue >= 10)
            {
                UpdateTyresBtn.interactable = false;
            }
            else
            {
                UpdateTyresBtn.interactable = true;
            }

            if (CurrentTyreValue <= 1)
            {
                DegradeTyresBtn.interactable = false;
            }
            else
            {
                DegradeTyresBtn.interactable = true;
            }

            if (CurrentfarwardValue >= 10)
            {
                UpdatefarwardBtn.interactable = false;
            }
            else
            {
                UpdatefarwardBtn.interactable = true;
            }

            if (CurrentfarwardValue <= 1)
            {
                DegradefarwardBtn.interactable = false;
            }
            else
            {
                DegradefarwardBtn.interactable = true;
            }

            if ((PlayerPrefs.GetInt("car" + Car_number + "engine") <= CurrentEngineValue))
            {
                EngineUpdatePriceText.gameObject.SetActive(true);
                EngineUpdatePriceText.text = (PlayerPrefs.GetInt("car" + Car_number + "engine") * 4000).ToString();
            }
            else
            {
                EngineUpdatePriceText.gameObject.SetActive(false);
            }

            if ((PlayerPrefs.GetInt("car" + Car_number + "farward") <= CurrentfarwardValue))
            {
                FarwardUpdatePriceText.gameObject.SetActive(true);
                FarwardUpdatePriceText.text = (PlayerPrefs.GetInt("car" + Car_number + "farward") * 4000).ToString();
            }
            else
            {
                FarwardUpdatePriceText.gameObject.SetActive(false);
            }

            if ((PlayerPrefs.GetInt("car" + Car_number + "suspension") <= CurrentSuspensionValue))
            {
                SuspentionUpdatePriceText.gameObject.SetActive(true);
                SuspentionUpdatePriceText.text = 
                    (PlayerPrefs.GetInt("car" + Car_number + "suspension") * 4000).ToString();
            }
            else
            {
                SuspentionUpdatePriceText.gameObject.SetActive(false);
            }

            if ((PlayerPrefs.GetInt("car" + Car_number + "tyres") <= CurrentTyreValue))
            {
                TyreUpdatePriceText.gameObject.SetActive(true);
                TyreUpdatePriceText.text = (PlayerPrefs.GetInt("car" + Car_number + "tyres") * 4000).ToString();
            }
            else
            {
                TyreUpdatePriceText.gameObject.SetActive(false);
            }
            EngineLevelAchieveText.text = CurrentEngineValue.ToString();
            SuspebsionLevelAchieveText.text = CurrentSuspensionValue.ToString();
            TyreLevelAchieveText.text = CurrentTyreValue.ToString();
            FarwardLevelAchieveText.text = CurrentfarwardValue.ToString();
        }

        if (EnvSelectionPanel.activeInHierarchy)
        {
            GetEnvirementInfo(EnvirenmentNo);
            PlanetNameText.text = planetName.ToString(); 
            if (PlayerPrefs.GetInt("env" + EnvirenmentNo) == 2)
            {
                EnvUnlockBtnCoin.gameObject.SetActive(false);
            }
         
        }

        if (CarSelectionPanel.activeInHierarchy)
        {
            if (PlayerPrefs.GetInt("car" + Car_number) == 2)
            {
                VehicleUnlockBtnCoin.gameObject.SetActive(false);

                VehicleNextBtn.gameObject.SetActive(true);
              //  UpdateBtn.SetActive(true);
            }
            else
            {
                VehicleUnlockBtnCoin.gameObject.SetActive(true);

                VehicleNextBtn.gameObject.SetActive(false);
                VehiclePriceCoinText.text = CarPrice.ToString();

                UpdateBtn.SetActive(false);
            }
        }

        if (Level_fail == true && OneTime == false)
        {
            OneTime = true;
            isCarRunning = false;
            Level_fail = false;
            if (VehicleSimpleControl.Instance.FuelLevel > 1)
            {
                if (PlayerPrefs.GetInt("sound") == 0)
                {
                    this.GetComponent<AudioSource>().PlayOneShot(CarDestroySound);
                }

              
            }

            LevelFailText.gameObject.SetActive(true);
            Invoke("ShowRevivePanel", 3);
        } 
        if (levelReward)
        {
            levelReward = false;
            //PlayerPrefs.SetInt("EnvironmentNo",EnvirenmentNo);

            Invoke("LevelComplete",3);
           // Invoke("ShowCoinRewardPanel", 3);
        }

        if (LoadingPanel.activeInHierarchy)
        {
            Invoke("CloseLoading", 0.35f);
        }

        if (GamePlayPanel.activeInHierarchy)
        {


            if (ShieldStart == true)
            {
                ShieldStart = false;
                ShieldTime = 1;
            }

            if (ShieldTime > 0.01f && ShieldTime < 1.01f && isCarRunning)
            {
                ShieldTime -= Time.deltaTime * 0.06f;
            }

            if (ShieldTime > 0.02f)
            {
                ShieldSlider.gameObject.SetActive(true);
                ShieldSlider.value = ShieldTime;
                StartShieldEffect = true;

            }

            if (ShieldTime < 0.01)
            {
                ShieldSlider.gameObject.SetActive(false);
                StartShieldEffect = false;

            }


            if (SlowMoStart == true)
            {
                t = false;
                SlowMoStart = false;
                VehicleSimpleControl.only = true;
                SlowMotionTime = 1;
            }

            if (SlowMotionTime > 0.01f && SlowMotionTime < 1.01f && isCarRunning)
            {
                SlowMotionTime -= Time.deltaTime * 0.06f;
            }

            if (SlowMotionTime > 0.02f)
            {
                SlowMoText.gameObject.SetActive(true);
                SlowMoText.text = ((Mathf.FloorToInt(SlowMotionTime * 10))).ToString();
                StartSlowMoEffect = true;


            }

            if (SlowMotionTime < 0.01 && t == false)
            {
                t = true;
                SlowMoText.gameObject.SetActive(false);
                VehicleSimpleControl.only = true;
                StartSlowMoEffect = false;
            }

            if (MagnetStart == true)
            {
                MagnetStart = false;
                MagnetTime = 1;
            }

            if (MagnetTime > 0.01f && MagnetTime < 1.01f && isCarRunning)
            {
                MagnetTime -= Time.deltaTime * 0.06f;
            }

            if (MagnetTime > 0.02f)
            {
                MagnetImag.gameObject.SetActive(true);
                MagnetImag.fillAmount = MagnetTime;
                StartMagnetEffect = true;
            }

            if (MagnetTime < 0.01)
            {
                MagnetImag.gameObject.SetActive(false);
                StartMagnetEffect = false;
            }

            BostFillImage.fillAmount = (float) DiamondCount / 10;
            if (DiamondCount > 0.9f && StartSlowMoEffect == false)
            {
                BostBtn.interactable = true;
            }
            else
            {
                BostBtn.interactable = false;
            }

            if (SlowMotionAbility && BostStart == false)
            {
                SlowMoBtn.interactable = true;
            }
            else
            {
                SlowMoBtn.interactable = false;
            }


            if (BostStart == true && isCarRunning)
            {
                DiamondCount -= Time.deltaTime * 0.5f;
            }

            if (BostStart && DiamondCount <= 0.1f)
            {
                DiamondCount = 0;
                BostStart = false;
                VehicleSimpleControl.OneTime = true;
                Debug.Log("tttt");
            }

            if (LowFuelInidication)
            {
                FuelSlider.GetComponent<Animator>().enabled = true;
                LowFuelAlertText.SetActive(true);
            }
            else
            {
                FuelSlider.GetComponent<Animator>().enabled = false;
                FuelSlider.transform.localScale = new Vector3(1, 1, 1);
                LowFuelAlertText.SetActive(false);
            }

            if (VehicleSimpleControl.CarInsideWater)
            {
                CarInWaterSound.SetActive(true);
            }
            else
            {
                CarInWaterSound.SetActive(false);
            }

            if (CoinCollectSound)
            {
                CoinCollectSound = false;
                if (!CoinCollectAudioSource.isPlaying && PlayerPrefs.GetInt("sound") == 0)
                {
                    CoinCollectAudioSource.PlayOneShot(CoinCollect);
                }
            }

            //********************************   Level Handling     **************************
            GamePlayScoreText.text = Coin_Score.ToString();
            FuelSlider.value = VehicleSimpleControl.Instance.FuelLevel;
            SpeedText.text = Mathf.FloorToInt(CurrrentCar.GetComponent<Rigidbody2D>().velocity.magnitude * 1.5f)
                .ToString();
            // ***************************   InAir Code   **************************************
            CameraMaxValue = CameraSlider.value;
            if (DetectCollision.FrontTyreOnGround == true && DetectCollision.BackTyreOnGround == true &&
                VehicleSimpleControl.Instance.BodyColide == false && isCarRunning == true)
            {
                InAir = true;
            }
            else
            {
                InAir = false;
                AddInAirScore = false;
                InAirAdder = 0;
                Air_Score = 0;
                elapsed = 0;
                transition = true;
                InAirText.gameObject.SetActive(false);
            }


            //**************************************  Flip Code   ***********************************
            if (restvalue == false)
            {
                restvalue = true;
                backFlip = 0;
                frontFlip = 0;
            }

            
        }
    }

    public void ClickOnBostBtn()
    {
        if (b == 0)
        {
            b = 1;
            if (BostStart == false)
            {

                VehicleSimpleControl.OneTime = true;

                BostStart = true;
                if (PlayerPrefs.GetInt("sound") == 0)
                {
                    this.GetComponent<AudioSource>().PlayOneShot(BostSound);
                }
            }


        }
        else
        {
            b = 0;
            if (BostStart == true)
            {

                VehicleSimpleControl.OneTime = true;
                BostStart = false;
                if (PlayerPrefs.GetInt("sound") == 0)
                {
                    this.GetComponent<AudioSource>().PlayOneShot(BostSound);
                }
            }

        }
    }

    public void ClickOnSlowMoBtn()
    {
        if (SlowMoStart == false)
        {
            VehicleSimpleControl.only = true;
            SlowMoBtn.interactable = false;
            SlowMotionAbility = false;
            SlowMoStart = true;
            if (PlayerPrefs.GetInt("sound") == 0)
            {
                this.GetComponent<AudioSource>().PlayOneShot(BostSound);
            }

        }
    }

    public void SoundCheck()
    {
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            SoundOffBtn.SetActive(true);
            SoundOnBtn.SetActive(false);

        }
        else
        {
            SoundOffBtn.SetActive(false);
            SoundOnBtn.SetActive(true);

        }
    }

    public void MusicCheck()
    {
        if (PlayerPrefs.GetInt("music") == 0)
        {
            MusicOffBtn.SetActive(true);
            MusicOnBtn.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(true);
        }
        else
        {
            MusicOffBtn.SetActive(false);
            MusicOnBtn.SetActive(true);
            transform.GetChild(2).gameObject.SetActive(false);

        }
    }

    public void VibrationCheck()
    {
        if (PlayerPrefs.GetInt("vibration") == 0)
        {
    //        VibrationOffBtn.SetActive(true);
            VibrationOnBtn.SetActive(false);

        }
        else
        {
            VibrationOffBtn.SetActive(false);
            //VibrationOnBtn.SetActive(true);

        }
    }

    public void ShowRevivePanel()
    {
        Finish.Instance.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        AudioListener.pause = true;
        LevelFailText.gameObject.SetActive(false);
        RevivePanel.SetActive(true);
        Vibration.Cancel();
    }
    public void ShowCoinRewardPanel()
    {
       
        //Finish.Instance.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        AudioListener.pause = true;
        //
      
        RewardPanel.SetActive(true);
        //Vibration.Cancel();
    }

    public void GameStart()
    {
        //VehicleSimpleControl.Instance.t = 0;cu
        //readyButton.SetActive(true);
        PlayerPrefs.SetInt("restart", 0);
        int h = Random.Range(0, 1);
        BackGroundMusic.SetActive(false);
        Camera.main.transform.GetChild(EnvirenmentNo).gameObject.SetActive(true);
        Camera.main.transform.GetChild(EnvirenmentNo).transform.GetChild(h).gameObject.SetActive(true);
        //Drawmanag.gameObject.SetActive(true);
      
        ActiveCar();
        //VehicleSimpleControl._instance.rigidBody.bodyType = RigidbodyType2D.Static;
        TrackGenerator.SetActive(true);


        if (lastLevel)
        {
           // PlayerPrefs.SetInt("startRandom",startRandom?1:0);
            planetText.text = "Level " + currentLevel;
            randomLevels.Clear();
           // PlayerPrefs.GetString("randomLevels", string.Spl(",",GameManager.Instance.randomLevels.ToArray())
            randomLevels.AddRange(PlayerPrefs.GetString("randomLevels").Split(',').Select(s => int.Parse(s)));
        }
        else
        {
            planetText.text = planetName;
        }
       
        /*if (PlayerPrefs.GetInt("tutorial") <= 3)
        {
            //PlayerPrefs.SetInt("tutorial", PlayerPrefs.GetInt("tutorial") + 1);
            //TutorialPanel.SetActive(true);

            Invoke("CloseTutorial", 17);

        }*/

        if (!readyButton.activeInHierarchy)
        {
            
           
               // readyButton.SetActive(false);
                
                //ready = false;
            
            Invoke("StartTheCar", 4);
            
            

        }

        if (BoostAbility)
        {
            BoostAbility = false;
            DiamondCount = 10;
        }

        if (MagnetAbility)
        {
            MagnetAbility = false;
            MagnetStart = true;
        }

        if (ShieldAbility)
        {
            ShieldAbility = false;
            ShieldStart = true;
        }


    }

    public void GameStartStoredLevel()
    {
        MAinMenuPanel.SetActive(false);
        GameStart();
        GamePlayPanel.SetActive(true);
        LoadingPanel.SetActive(true);
    }
/*

    public void GameStart1()
    {
        //VehicleSimpleControl.Instance.t = 0;cu
        //readyButton.SetActive(true);
        PlayerPrefs.SetInt("restart", 0);
        int h = Random.Range(0, 1);
        BackGroundMusic.SetActive(false);
        Camera.main.transform.GetChild(EnvirenmentNo).gameObject.SetActive(true);
        Camera.main.transform.GetChild(EnvirenmentNo).transform.GetChild(h).gameObject.SetActive(true);
        //Drawmanag.gameObject.SetActive(true);
      
        ActiveCar();
        //VehicleSimpleControl._instance.rigidBody.bodyType = RigidbodyType2D.Static;
        TrackGenerator.SetActive(true);


        if (lastLevel)
        {
            // PlayerPrefs.SetInt("startRandom",startRandom?1:0);
            planetText.text = "Level " + currentLevel;
            randomLevels.Clear();
            randomLevels.AddRange(PlayerPrefs.GetString("randomLevels").Split(',').Select(s => int.Parse(s)));
        }
        else
        {
            planetText.text = planetName;
        }
       
        if (PlayerPrefs.GetInt("tutorial") <= 3)
        {
           // PlayerPrefs.SetInt("tutorial", PlayerPrefs.GetInt("tutorial") + 1);
            //TutorialPanel.SetActive(true);

            Invoke("CloseTutorial", 17);

        }

        if (!TutorialPanel.activeInHierarchy)
        {
            
           
            // readyButton.SetActive(false);
                
            //ready = false;
            
            Invoke("StartTheCar", 4);
            
            

        }

   

    }*/

    public void ActiveCar()
    {
        //level 1
        if (EnvirenmentNo == 1)
        {
            
            CurrrentCar = Instantiate(Vehicles[7], new Vector3(45.75f, 248, 0), Quaternion.identity) as GameObject;
           
        }
        //old levels
        /*else if (EnvirenmentNo == 1)
        {
            CurrrentCar = Instantiate(Vehicles[Car_number], new Vector3(154.2663f, 250.6685f, 0), Quaternion.identity) as GameObject;
        }
        else if (EnvirenmentNo == 2)
        {
            CurrrentCar = Instantiate(Vehicles[Car_number], new Vector3(260.6f, 229.6f, 0), Quaternion.identity) as GameObject;
        }
        else if (EnvirenmentNo == 3)
        {
            CurrrentCar = Instantiate(Vehicles[Car_number], new Vector3(46, 273, 0), Quaternion.identity) as GameObject;
        }
        else if (EnvirenmentNo == 4)
        {
            CurrrentCar = Instantiate(Vehicles[Car_number], new Vector3(33, 257, 0), Quaternion.identity) as GameObject;
        }*/
        //level 2
        else if (EnvirenmentNo == 2)
        {
            CurrrentCar = Instantiate(Vehicles[7], new Vector3(95f, 276.2342f, 0), Quaternion.identity) as GameObject;
        }
        //level 3
        else if (EnvirenmentNo == 3)
        {
            CurrrentCar = Instantiate(Vehicles[7], new Vector3(159.75f, 275.8187f, 0), Quaternion.identity) as GameObject;
        }
        //level 4
        else if (EnvirenmentNo == 4)
        {
            CurrrentCar = Instantiate(Vehicles[7], new Vector3(158f, 275.7989f, 0), Quaternion.identity) as GameObject;
        }
        //level 5
        else if (EnvirenmentNo == 5)
        {
            CurrrentCar = Instantiate(Vehicles[7], new Vector3(164f, 277f, 0), Quaternion.identity) as GameObject;
        }
        //level 6
        else if (EnvirenmentNo == 6)
        {
            CurrrentCar = Instantiate(Vehicles[7], new Vector3(172.2f, 275.847f, 0), Quaternion.identity) as GameObject;
        }
        //level 7
        else if (EnvirenmentNo == 7)
        {
            CurrrentCar = Instantiate(Vehicles[7], new Vector3(160.82f, 276.21f, 0), Quaternion.identity) as GameObject;
        }
        //level 8
        else if (EnvirenmentNo == 8)
        {
            CurrrentCar = Instantiate(Vehicles[7], new Vector3(143, 276.1589f, 0), Quaternion.identity) as GameObject;
        }
        //level 9
        else if (EnvirenmentNo == 9)
        {
            CurrrentCar = Instantiate(Vehicles[7], new Vector3(140f, 277f, 0), Quaternion.identity) as GameObject;
        }
        //level 10
        else if (EnvirenmentNo == 10)
        {
            CurrrentCar = Instantiate(Vehicles[7], new Vector3(146f, 276.4354f, 0), Quaternion.identity) as GameObject;
        }
        //level 11
        else if (EnvirenmentNo == 11)
        {
            CurrrentCar = Instantiate(Vehicles[8], new Vector3(291f, 262.6518f, 0), Quaternion.identity) as GameObject;
        } 
        //level 12
        else if (EnvirenmentNo == 12)
        {
            CurrrentCar = Instantiate(Vehicles[8], new Vector3(137.2f, 262.8514f, 0), Quaternion.identity) as GameObject;
        }
        //level 13
        else if (EnvirenmentNo == 13)
        {
            CurrrentCar = Instantiate(Vehicles[8], new Vector3(131.7f, 262.932f, 0), Quaternion.identity) as GameObject;
        }
        //level 14
        else if (EnvirenmentNo == 14)
        {
            CurrrentCar = Instantiate(Vehicles[8], new Vector3(56f, 263.7726f, 0), Quaternion.identity) as GameObject;
        }
        //level 15
        else if (EnvirenmentNo == 15)
        {
            CurrrentCar = Instantiate(Vehicles[8], new Vector3(39f, 264.2f, 0), Quaternion.identity) as GameObject;
        }
        //level 16
        else if (EnvirenmentNo == 16)
        {
            CurrrentCar = Instantiate(Vehicles[8], new Vector3(11.88714f, 263.6916f, 0), Quaternion.identity) as GameObject;
        }
        //level 17
        else if (EnvirenmentNo == 17)
        {
            CurrrentCar = Instantiate(Vehicles[8], new Vector3(11.90349f, 263.7439f, 0), Quaternion.identity) as GameObject;
        }
        //level 18
        else if (EnvirenmentNo == 18)
        {
            CurrrentCar = Instantiate(Vehicles[8], new Vector3(-14.13728f, 263.8149f, 0), Quaternion.identity) as GameObject;
        }
        //level 19
        else if (EnvirenmentNo == 19)
        {
            CurrrentCar = Instantiate(Vehicles[8], new Vector3(-79.87368f, 263.8146f, 0), Quaternion.identity) as GameObject;
        }
        //level 20
        else if (EnvirenmentNo == 20)
        {
            CurrrentCar = Instantiate(Vehicles[8], new Vector3(-55.8f, 265.5f, 0), Quaternion.identity) as GameObject;
        } 
        //level 21
        else if (EnvirenmentNo == 21)
        {
            CurrrentCar = Instantiate(Vehicles[8], new Vector3(200.8f, 200.4f, 0), Quaternion.identity) as GameObject;
        }
        //level 22
        else if (EnvirenmentNo == 22)
        {
            CurrrentCar = Instantiate(Vehicles[11], new Vector3(93.3f, 262.1f, 0), Quaternion.identity) as GameObject;
        }
        //level 23
        else if (EnvirenmentNo == 23)
        {
          
            CurrrentCar = Instantiate(Vehicles[11], new Vector3(78f, 260.8894f, 0), Quaternion.identity) as GameObject;
        }
        //level 24
        else if (EnvirenmentNo == 24)
        {
          
            CurrrentCar = Instantiate(Vehicles[11], new Vector3(109.2f, 260.9f, 0), Quaternion.identity) as GameObject;
        }
        //level 25
        else if (EnvirenmentNo == 25)
        {
          
            CurrrentCar = Instantiate(Vehicles[11], new Vector3(83f, 260.8894f, 0), Quaternion.identity) as GameObject;
        }
        //level 26
        else if (EnvirenmentNo == 26)
        {
          
            CurrrentCar = Instantiate(Vehicles[11], new Vector3(106.6f, 260.8894f, 0), Quaternion.identity) as GameObject;
        }
        //level 27
        else if (EnvirenmentNo == 27)
        {
          
            CurrrentCar = Instantiate(Vehicles[11], new Vector3(101f, 259.9f, 0), Quaternion.identity) as GameObject;
        }
        //level 28
        else if (EnvirenmentNo == 28)
        {
          
            CurrrentCar = Instantiate(Vehicles[11], new Vector3(92.7f, 272.2f, 0), Quaternion.identity) as GameObject;
        }
        //level 29
        else if (EnvirenmentNo == 29)
        {
          
            CurrrentCar = Instantiate(Vehicles[11], new Vector3(73f, 260f, 0), Quaternion.identity) as GameObject;
        }
        //level 30
        else if (EnvirenmentNo == 30)
        {
          
            CurrrentCar = Instantiate(Vehicles[11], new Vector3(66f, 231f, 0), Quaternion.identity) as GameObject;
        }
        //level 31
        else if (EnvirenmentNo == 31)
        {
          
            CurrrentCar = Instantiate(Vehicles[10], new Vector3(156f, 248.1f, 0), Quaternion.identity) as GameObject;
        }
        //level 32
        else if (EnvirenmentNo == 32)
        {
          
            CurrrentCar = Instantiate(Vehicles[10], new Vector3(185.7f, 248.1f, 0), Quaternion.identity) as GameObject;
        }
        //level 33
        else if (EnvirenmentNo == 33)
        {
          
            CurrrentCar = Instantiate(Vehicles[10], new Vector3(244f, 246.0185f, 0), Quaternion.identity) as GameObject;
        }
        //level 34
        else if (EnvirenmentNo == 34)
        {
          
            CurrrentCar = Instantiate(Vehicles[10], new Vector3(568f, 248.6866f, 0), Quaternion.identity) as GameObject;
        }
        //level 35
        else if (EnvirenmentNo == 35)
        {
          
            CurrrentCar = Instantiate(Vehicles[10], new Vector3(548f, 248.6866f, 0), Quaternion.identity) as GameObject;
        }
        //level 36
        else if (EnvirenmentNo == 36)
        {
          
            CurrrentCar = Instantiate(Vehicles[10], new Vector3(554f, 247f, 0), Quaternion.identity) as GameObject;
        }
        //level 37
        else if (EnvirenmentNo == 37)
        {
          
            CurrrentCar = Instantiate(Vehicles[10], new Vector3(232f, 247f, 0), Quaternion.identity) as GameObject;
        }
        //level 38
        else if (EnvirenmentNo == 38)
        {
          
            CurrrentCar = Instantiate(Vehicles[10], new Vector3(265f, 248f, 0), Quaternion.identity) as GameObject;
        }
        //level 39
        else if (EnvirenmentNo == 39)
        {
          
            CurrrentCar = Instantiate(Vehicles[10], new Vector3(279.1f, 186.6f, 0), Quaternion.identity) as GameObject;
        }
        //level 40        
        else if (EnvirenmentNo == 40)
        {
              
                CurrrentCar = Instantiate(Vehicles[10], new Vector3(251f, 188.8f, 0), Quaternion.identity) as GameObject;
        }
        //level 41
        else if (EnvirenmentNo == 41)
        {
          
            CurrrentCar = Instantiate(Vehicles[15], new Vector3(76f, 257f, 0), Quaternion.identity) as GameObject;
        }
        //level 42
        else if (EnvirenmentNo == 42)
        {
          
            CurrrentCar = Instantiate(Vehicles[15], new Vector3(86f, 299f, 0), Quaternion.identity) as GameObject;
        }
        //level 43
        else if (EnvirenmentNo == 43)
        {
          
            CurrrentCar = Instantiate(Vehicles[15], new Vector3(86f, 299f, 0), Quaternion.identity) as GameObject;
        }
        //level 44
        else if (EnvirenmentNo == 44)
        {
          
            CurrrentCar = Instantiate(Vehicles[15], new Vector3(57f, 299f, 0), Quaternion.identity) as GameObject;
        }
        //level 45
        else if (EnvirenmentNo == 45)
        {
          
            CurrrentCar = Instantiate(Vehicles[15], new Vector3(68.8f, 299f, 0), Quaternion.identity) as GameObject;
        }
        //level 46
        else if (EnvirenmentNo == 46)
        {
          
            CurrrentCar = Instantiate(Vehicles[15], new Vector3(118f, 299f, 0), Quaternion.identity) as GameObject;
        }
        //level 47
        else if (EnvirenmentNo == 47)
        {
          
            CurrrentCar = Instantiate(Vehicles[15], new Vector3(119.001f, 299f, 0), Quaternion.identity) as GameObject;
        }
        //level 48
        else if (EnvirenmentNo == 48)
        {
          
            CurrrentCar = Instantiate(Vehicles[15], new Vector3(167f, 299f, 0), Quaternion.identity) as GameObject;
        }
        //level 49
        else if (EnvirenmentNo == 49)
        {
          
            CurrrentCar = Instantiate(Vehicles[15], new Vector3(124f, 296f, 0), Quaternion.identity) as GameObject;
        }
        //level 50
        else if (EnvirenmentNo == 50)
        {
          
            CurrrentCar = Instantiate(Vehicles[15], new Vector3(85f, 318.5f, 0), Quaternion.identity) as GameObject;
        }

        
        CurrrentCar.SetActive(true);
        carpos = CurrrentCar.transform.position;
        VehicleSimpleControl.StartPosition = CurrrentCar.transform.position;
    }

    
    public void StartTheCar()
    {
        CurrrentCar.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        /*if (DrawingManager.Instance.paths.Contains(DrawingManager.Instance.clone)  && DrawingManager.Instance.drawCount > 0)
        {
            
        }
        else
        {
            //CurrrentCar.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        }*/
        isCarRunning = true;
    }


    public void BtnClick(string btn)
    {
        if (btn == "left")
        {
            Car_number--;
            if (Car_number < 0)
            {
                Car_number = Cars.Length - 1;
            }

            for (int i = 0; i < Cars.Length; i++)
            {
                Cars[i].SetActive(false);
            }

            Cars[Car_number].SetActive(true);
            Cars[Car_number].transform.position = new Vector3(Cars[Car_number].transform.position.x, 957,
                Cars[Car_number].transform.position.z);
            CarPrice = Car_number * 100000;
            CurrentEngineValue = PlayerPrefs.GetInt("car" + Car_number + "engine");
            CurrentfarwardValue = PlayerPrefs.GetInt("car" + Car_number + "farward");
            CurrentSuspensionValue = PlayerPrefs.GetInt("car" + Car_number + "suspension");
            CurrentTyreValue = PlayerPrefs.GetInt("car" + Car_number + "tyres");
        }
        else if (btn == "right")
        {
            Car_number++;
            if (Car_number > Cars.Length - 1)
            {
                Car_number = 0;
            }

            for (int i = 0; i < Cars.Length; i++)
            {
                Cars[i].SetActive(false);
            }

            Cars[Car_number].SetActive(true);
            Cars[Car_number].transform.position = new Vector3(Cars[Car_number].transform.position.x, 957,
                Cars[Car_number].transform.position.z);
            CarPrice = Car_number * 100000;
            CurrentEngineValue = PlayerPrefs.GetInt("car" + Car_number + "engine");
            CurrentfarwardValue = PlayerPrefs.GetInt("car" + Car_number + "farward");
            CurrentSuspensionValue = PlayerPrefs.GetInt("car" + Car_number + "suspension");
            CurrentTyreValue = PlayerPrefs.GetInt("car" + Car_number + "tyres");
        }
        else if (btn == "start")
        {

            if (PlayerPrefs.HasKey("ReloadLevel"))
            {
                MAinMenuPanel.transform.GetChild(1).GetComponent<Button>().enabled = false;
                
                EnvirenmentNo = PlayerPrefs.GetInt("ReloadLevel");
               // env = PlayerPrefs.GetInt("ReloadLevel");
               planetName = "Level  " + EnvirenmentNo;
                Invoke(nameof(GameStartStoredLevel),0.5f);
            }
            else if (PlayerPrefs.HasKey("lastLevel"))
            {
                lastLevel = true;
                planetText.text = "Level " + currentLevel;
                randomLevels.Clear();
                // PlayerPrefs.GetString("randomLevels", string.Spl(",",GameManager.Instance.randomLevels.ToArray())
                randomLevels.AddRange(PlayerPrefs.GetString("randomLevels").Split(',').Select(s => int.Parse(s)));
                Invoke(nameof(GameStartStoredLevel),0.5f);
                
            }
            else if (PlayerPrefs.HasKey("randomLevels") && lastLevel)
            {
                lastLevel = true;
                planetText.text = "Level " + currentLevel;
                randomLevels.Clear();
                // PlayerPrefs.GetString("randomLevels", string.Spl(",",GameManager.Instance.randomLevels.ToArray())
                randomLevels.AddRange(PlayerPrefs.GetString("randomLevels").Split(',').Select(s => int.Parse(s)));
                Invoke(nameof(GameStartStoredLevel),0.5f);
                
            }
            else 

            {
                planetName = "Level  " + EnvirenmentNo;
                Invoke(nameof(GameStartStoredLevel),0.5f);
            }
            //  if(PlayerPrefs.GetInt("EnvironmentNo")>=1)
            //{
              //  PlayerPrefs.GetInt("EnvironmentNo",EnvirenmentNo);
              
                

            //}
            /*MAinMenuPanel.SetActive(false);
                GameStart();
                GamePlayPanel.SetActive(true);
                LoadingPanel.SetActive(true);*/
            
        }
        //test envirenments
       
        else if (btn == "setEnv")
        {

            testButton.Play();
            EnvirenmentNo = 0;
            
        }
        
        else if (btn == "setEnv1")
        {
            testButton1.Play();
            EnvirenmentNo = 1;
        }
        
        else if (btn == "setEnv2")
        {
            testButton2.Play();
            EnvirenmentNo = 2;
        }
        
        else if (btn == "setEnv3")
        {
            testButton3.Play();
            EnvirenmentNo = 3;
        }
        
        else if (btn == "setEnv4")
        {
            testButton4.Play();
            EnvirenmentNo = 4;
        }
        
        else if (btn == "setEnv5")
        {
            testButton5.Play();
            EnvirenmentNo = 5;
        }
        
        else if (btn == "setEnv6")
        {
            testButton6.Play();
            EnvirenmentNo = 6;
        }
        
        else if (btn == "setEnv7")
        {
            testButton7.Play();
            EnvirenmentNo = 7;
        }
        
        else if (btn == "setEnv8")
        {
            testButton8.Play();
            EnvirenmentNo = 8;
        }
        
        else if (btn == "setEnv9")
        {
            testButton9.Play();
            EnvirenmentNo = 9;
        }
        
        else if (btn == "setEnv10")
        {
            testButton10.Play();
            EnvirenmentNo = 10;
        }
        
        else if (btn == "setEnv11")
        {
            testButton11.Play();
            EnvirenmentNo = 11;
        } 
        else if (btn == "setEnv12")
        {
            testButton12.Play();
            EnvirenmentNo = 12;
        }
        else if (btn == "setEnv13")
        {
            testButton13.Play();
            EnvirenmentNo = 13;
        }
        else if (btn == "setEnv14")
        {
            testButton14.Play();
            EnvirenmentNo = 14;
        }
        else if (btn == "setEnv15")
        {
            testButton15.Play();
            EnvirenmentNo = 15;
        }
        else if (btn == "setEnv16")
        {
            testButton16.Play();
            EnvirenmentNo = 16;
        }
        else if (btn == "setEnv17")
        {
            testButton17.Play();
            EnvirenmentNo = 17;
        }
        else if (btn == "setEnv18")
        {
            testButton18.Play();
            EnvirenmentNo = 18;
        }
        else if (btn == "setEnv19")
        {
            testButton19.Play();
            EnvirenmentNo = 19;
        }
        else if (btn == "setEnv20")
        {
            testButton20.Play();
            EnvirenmentNo = 20;
        }
        else if (btn == "setEnv21")
        {
            testButton21.Play();
            EnvirenmentNo = 21;
        }
        else if (btn == "setEnv22")
        {
            testButton22.Play();
            EnvirenmentNo = 22;
        }
        else if (btn == "setEnv23")
        {
            testButton23.Play();
            EnvirenmentNo = 23;
        }
        else if (btn == "setEnv24")
        {
            testButton24.Play();
            EnvirenmentNo = 24;
        }
        else if (btn == "setEnv25")
        {
            testButton25.Play();
            EnvirenmentNo = 25;
        }
        else if (btn == "setEnv26")
        {
            testButton26.Play();
            EnvirenmentNo = 26;
        }
        else if (btn == "setEnv27")
        {
            testButton27.Play();
            EnvirenmentNo = 27;
        }
        else if (btn == "setEnv28")
        {
            testButton28.Play();
            EnvirenmentNo = 28;
        }
        else if (btn == "setEnv29")
        {
            testButton29.Play();
            EnvirenmentNo = 29;
        }
        else if (btn == "setEnv30")
        {
            testButton30.Play();
            EnvirenmentNo = 30;
        }
        else if (btn == "setEnv31")
        {
            testButton31.Play();
            EnvirenmentNo = 31;
        }
        else if (btn == "setEnv32")
        {
            testButton32.Play();
            EnvirenmentNo = 32;
        }
        else if (btn == "setEnv33")
        {
            testButton33.Play();
            EnvirenmentNo = 33;
        }
        else if (btn == "setEnv34")
        {
            testButton34.Play();
            EnvirenmentNo = 34;
        }
        else if (btn == "setEnv35")
        {
            testButton35.Play();
            EnvirenmentNo = 35;
        }
        else if (btn == "setEnv36")
        {
            testButton36.Play();
            EnvirenmentNo = 36;
        }
        else if (btn == "setEnv37")
        {
            testButton37.Play();
            EnvirenmentNo = 37;
        }
        else if (btn == "setEnv38")
        {
            testButton38.Play();
            EnvirenmentNo = 38;
        }
        else if (btn == "setEnv39")
        {
            testButton39.Play();
            EnvirenmentNo = 39;
        }
        else if (btn == "setEnv40")
        {
            testButton40.Play();
            EnvirenmentNo = 40;
        }
        else if (btn == "setEnv41")
        {
            testButton41.Play();
            EnvirenmentNo = 41;
        }
        else if (btn == "setEnv42")
        {
            testButton42.Play();
            EnvirenmentNo = 42;
        }
        else if (btn == "setEnv43")
        {
            testButton43.Play();
            EnvirenmentNo = 43;
        }
        else if (btn == "setEnv44")
        {
            testButton44.Play();
            EnvirenmentNo = 44;
        }
        else if (btn == "setEnv45")
        {
            testButton45.Play();
            EnvirenmentNo = 45;
        }
        else if (btn == "setEnv46")
        {
            testButton46.Play();
            EnvirenmentNo = 46;
        }
        else if (btn == "setEnv47")
        {
            testButton47.Play();
            EnvirenmentNo = 47;
        }
        else if (btn == "setEnv48")
        {
            testButton48.Play();
            EnvirenmentNo = 48;
        }
        else if (btn == "setEnv49")
        {
            testButton49.Play();
            EnvirenmentNo = 49;
        }
        /*else if (btn == "leftEnv")
        {
            EnvirenmentNo--;
            if (EnvirenmentNo < 0)
            {
                EnvirenmentNo = Envs.Length - 1;
            }

            for (int i = 0; i < Envs.Length; i++)
            {
                Envs[i].SetActive(false);
            }

            Envs[EnvirenmentNo].SetActive(true);
            EnvPrice = EnvirenmentNo * 100000;
        }
        else if (btn == "rightEnv")
        {
            EnvirenmentNo++;
            if (EnvirenmentNo > Envs.Length - 1)
            {
                EnvirenmentNo = 0;
            }

            for (int i = 0; i < Envs.Length; i++)
            {
                Envs[i].SetActive(false);
            }

            Envs[EnvirenmentNo].SetActive(true);
            EnvPrice = EnvirenmentNo * 100000;
        }*/
        //closes the ready panel 
        else if (btn == "closetut")
        {/*
            bDeug.Log("Levelll" + GameManager.EnvirenmentNo);
            Debug.Log("Levellllll"+GameManager.Instance.env);
            PlayerPrefs.SetInt("ReloadLevel",GameManager.Instance.env);*/
            CloseTutorial();
            ready = true;
            VehicleSimpleControl.Instance.rigidBody.bodyType = RigidbodyType2D.Dynamic;
            VehicleSimpleControl.Instance.aceleration = 0f;
            VehicleSimpleControl.Instance.maxSpeed = 0f;
            VehicleSimpleControl.Instance.breakForce = 0f;
            VehicleSimpleControl.Instance.reverseMaxSpeed = 0f;
            VehicleSimpleControl.Instance.reverse = false;
           
            readyButton.SetActive(false);
            StartTimer.gameObject.SetActive(true);
            VehicleSimpleControl.Instance.rigidBody.bodyType = RigidbodyType2D.Dynamic;
            Invoke("HideTimer", 4);
        }
        else if (btn == "closeability")
        {
            Time.timeScale = 1;
            AudioListener.pause = false;
        }
        else if (btn == "addability")
        {
            Time.timeScale = 0;
            CurrrentCar.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            AudioListener.pause = true;
        }
        else if (btn == "magnetability")
        {
            if (PlayerPrefs.GetInt("score") >= 5000)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 5000);
                MagnetAbilityBtn.transform.GetChild(0).GetComponent<Image>().color = new Color32(73, 73, 73, 255);
                MagnetAbilityBtn.interactable = false;
                MagnetAbility = true;
            }
            else
            {
                LowCashText.gameObject.SetActive(true);
            }
        }
        else if (btn == "shieldability")
        {
            if (PlayerPrefs.GetInt("score") >= 3500)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 3500);
                ShieldAbilityBtn.transform.GetChild(0).GetComponent<Image>().color = new Color32(73, 73, 73, 255);
                ShieldAbilityBtn.interactable = false;
                ShieldAbility = true;
                PlayerPrefs.SetInt("shieldcount", PlayerPrefs.GetInt("shieldcount") + 1);
            }
            else
            {
                LowCashText.gameObject.SetActive(true);
            }
        }
        else if (btn == "slowmoability")
        {
            if (PlayerPrefs.GetInt("score") >= 3000)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 3000);
                SlowMoAbilityBtn.transform.GetChild(0).GetComponent<Image>().color = new Color32(73, 73, 73, 255);
                SlowMoAbilityBtn.interactable = false;
                SlowMotionAbility = true;
                PlayerPrefs.SetInt("slowmocount", PlayerPrefs.GetInt("slowmocount") + 1);
            }
            else
            {
                LowCashText.gameObject.SetActive(true);
            }
        }
        else if (btn == "boostability")
        {
            if (PlayerPrefs.GetInt("score") >= 2500)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 2500);
                BoostAbilityBtn.transform.GetChild(0).GetComponent<Image>().color = new Color32(73, 73, 73, 255);
                BoostAbilityBtn.interactable = false;
                BoostAbility = true;
                PlayerPrefs.SetInt("bostcount", PlayerPrefs.GetInt("bostcount") + 1);
            }
            else
            {
                LowCashText.gameObject.SetActive(true);
            }
        }

        else if (btn == "addmagnetability")
        {
            if (PlayerPrefs.GetInt("score") >= 5000)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 5000);
                GameAddMagnetAbilityBtn.transform.GetChild(0).GetComponent<Image>().color =
                    new Color32(73, 73, 73, 255);
                GameAddMagnetAbilityBtn.interactable = false;
                MagnetStart = true;
            }
            else
            {
                LowCashTextGamePlay.gameObject.SetActive(true);
            }
        }


        else if (btn == "addslowmoability")
        {
            if (PlayerPrefs.GetInt("score") >= 3000)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 3000);
                GameAddSlowMoAbilityBtn.transform.GetChild(0).GetComponent<Image>().color =
                    new Color32(73, 73, 73, 255);
                GameAddSlowMoAbilityBtn.interactable = false;
                SlowMotionAbility = true;
                PlayerPrefs.SetInt("slowmocount", PlayerPrefs.GetInt("slowmocount") + 1);
            }
            else
            {
                LowCashTextGamePlay.gameObject.SetActive(true);
            }
        }
        else if (btn == "addshieldability")
        {
            if (PlayerPrefs.GetInt("score") >= 3500)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 3500);
                GameAddShieldAbilityBtn.transform.GetChild(0).GetComponent<Image>().color =
                    new Color32(73, 73, 73, 255);
                GameAddShieldAbilityBtn.interactable = false;
                ShieldStart = true;
                PlayerPrefs.SetInt("shieldcount", PlayerPrefs.GetInt("shieldcount") + 1);
            }
            else
            {
                LowCashTextGamePlay.gameObject.SetActive(true);
            }
        }



        else if (btn == "addboostability")
        {
            if (PlayerPrefs.GetInt("score") >= 2500)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 2500);
                GameAddBoostAbilityBtn.transform.GetChild(0).GetComponent<Image>().color = new Color32(73, 73, 73, 255);
                GameAddBoostAbilityBtn.interactable = false;
                DiamondCount = 10;
                PlayerPrefs.SetInt("bostcount", PlayerPrefs.GetInt("bostcount") + 1);
            }
            else
            {
                LowCashTextGamePlay.gameObject.SetActive(true);
            }
        }
        else if (btn == "addfuel")
        {
            if (PlayerPrefs.GetInt("score") >= 4000)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - 4000);
                GameAddFuelBtn.transform.GetChild(0).GetComponent<Image>().color = new Color32(73, 73, 73, 255);
                GameAddFuelBtn.interactable = false;
                VehicleSimpleControl.Instance.FuelLevel = 100;
            }
            else
            {
                LowCashTextGamePlay.gameObject.SetActive(true);
            }
        }

        else if (btn == "soundoff")
        {
            SoundOffBtn.SetActive(false);
            SoundOnBtn.SetActive(true);
            PlayerPrefs.SetInt("sound", 1);
            SoundCheck();
        }
        else if (btn == "soundon")
        {
            SoundOffBtn.SetActive(true);
            SoundOnBtn.SetActive(false);
            PlayerPrefs.SetInt("sound", 0);
            SoundCheck();
        }
        else if (btn == "musicoff")
        {
            MusicOffBtn.SetActive(false);
            MusicOnBtn.SetActive(true);
            PlayerPrefs.SetInt("music", 1);
            MusicCheck();
        }
        else if (btn == "musicon")
        {
            MusicOffBtn.SetActive(true);
            MusicOnBtn.SetActive(false);
            PlayerPrefs.SetInt("music", 0);
            MusicCheck();
        }
        else if (btn == "vibrationff")
        {
           // VibrationOffBtn.SetActive(false);
           // VibrationOnBtn.SetActive(true);
            PlayerPrefs.SetInt("vibration", 1);
            VibrationCheck();
        }
        else if (btn == "vibrationon")
        {
           // VibrationOffBtn.SetActive(true);
           // VibrationOnBtn.SetActive(false);
            PlayerPrefs.SetInt("vibration", 0);
            VibrationCheck();
        }
        else if (btn == "pause")
        {
            Time.timeScale = 0;
            AudioListener.pause = true;
        }
        else if (btn == "resume")
        {
            Time.timeScale = 1;
            if (PlayerPrefs.GetInt("sound") == 0)
            {
                AudioListener.pause = false;
            }
            else
            {
                AudioListener.pause = true;
            }
        }
        //restart button for restarting a level upon failing or from the pause menu
        else if (btn == "restart")
        {
            //VehicleSimpleControl._instance.rigidBody.bodyType = RigidbodyType2D.Static;
            LoadingPanel.SetActive(true);
            PlayerPrefs.SetInt("restart", 1);
            Application.LoadLevel(Application.loadedLevel);
        }
        //start button for starting the vehicle
        else if (btn == "startVehicle")
        {
           
        }
        //next button for continuing to the next level
        else if (btn == "next")
        {
            coinUpdate = true;
            //plays coin animation before instantiating to the next level
            //coinAnimation.Play("coinAnimation");
            //coinsAudio.GetComponent<AudioSource>().PlayOneShot(coinncollect);
            //invokes next level in 3 seconds after the next button is pressed
            LoadingPanel.SetActive(true);
            LevelCompletePanel.transform.GetChild(1).GetChild(1).GetChild(1).GetComponent<Button>().enabled = false;
            Invoke(nameof(Next), 0f);
        }
        //home button for going back to the main menu/ or home 
        else if (btn == "home")
        {
            
            LoadingPanel.SetActive(true);
            Application.LoadLevel(Application.loadedLevel);
            closeLoading = false;
        }
        
        else if (btn == "revive")
        {

            // AdsManager.Instance.Unity_AdmobRewardedVideoAd();
            revivevideo = true;
        } 
        else if (btn == "reviveclose")
        {
            RevivePanel.SetActive(false);
            LevelFail();
        }
        else if (btn == "coinreward")
        {

            // AdsManager.Instance.Unity_AdmobRewardedVideoAd();
            coinRewardVideo = true;
        }
        else if (btn == "rewardclose")
        {
            GrandTotalText.text = PlayerPrefs.GetInt("score").ToString();
            RewardPanel.SetActive(false);
            //levelReward = false;
            //currentLevel++;
            if (VehicleSimpleControl.Instance.FuelLevel >= 50)
            {
                Total_Coin_Score = 10000;
                Debug.Log( Total_Coin_Score);
            }
            else if (VehicleSimpleControl.Instance.FuelLevel >= 30)
            {
                Total_Coin_Score
                 = 5000;
            }
            else if (VehicleSimpleControl.Instance.FuelLevel >= 5)
            {
                Total_Coin_Score = 1000;
            }
            else if (VehicleSimpleControl.Instance.FuelLevel <= 0 || VehicleSimpleControl.Instance.FuelLevel < 5)
            {
                Total_Coin_Score = 0;
            }
           
        }
        else if (btn == "more")
        {
            Application.OpenURL("https://play.google.com/store/apps/developer?id=UltronLightsStudio");
        }
        else if (btn == "share")
        {
            SocialNetworks.ShareURL("2D Path ",
                "https://play.google.com/store/apps/details?id=com.ultron.roaddraw.drawrider.drawclimber");
        }
        else if (btn == "rateus")
        {
            Application.OpenURL(
                "https://play.google.com/store/apps/details?id=com.ultron.roaddraw.drawrider.drawclimber");
        }
        else if (btn == "watchvideoad")
        {
            // AdsManager.Instance.Unity_AdmobRewardedVideoAd();
            VideoReward = true;
        }
        else if (btn == "yes")
        {
            Application.Quit();
        }
        else if (btn == "destroypath")
        {
            DestroyPath.IntantDestroy = true;
        }
    }

    //next function loads the next level
    public void Next()
    {
        //checks if the user has played last level/or level 50 and then starts randomizing the levels from 1 to 50
        if (lastLevel)
        {
            // gets  a random number from the list and assigns it to nextlevelindex
            int nextLevelIndex = Random.Range(1,51);
            //assigns the number from random levels list to next level
            int nextLevel = randomLevels[nextLevelIndex];
            //assigns the number stored in nextlevel to environmentno
            EnvirenmentNo = nextLevel;
            //increases the count of currentlevel by 1
            currentLevel++;
            /*//removes the number/level from the list which was loaded, this prevents the repetition of levels
            randomLevels.RemoveAt(nextLevelIndex);
            //stores the random level list in playerprefs
            PlayerPrefs.SetString("randomLevels", string.Join(",",randomLevels.ToArray()));*/
            lastLevel = true;
            startRandom = true;
            //EnvirenmentNo = Random.Range(0, 50);
            //currentLevel++;
            //activates the loading panel
           // LoadingPanel.SetActive(true);
            //turns off the collider on finish (flag and pole)
            Finish.Instance.collider2D.enabled = false;
            //turns off the level complete panel
            LevelCompletePanel.SetActive(false);
            PlayerPrefs.SetInt("restart", 1);
            //loads the level
            Application.LoadLevel(Application.loadedLevel);
            //VehicleSimpleControl._instance.rigidBody.bodyType = RigidbodyType2D.Static;
        }
        else
        {
                
            //DrawingManager.Instance.posCount = 0;
            EnvirenmentNo ++;
            //currentLevel++currentLevel++;
           // LoadingPanel.SetActive(true);
            Finish.Instance.collider2D.enabled = false;
            LevelCompletePanel.SetActive(false);
            PlayerPrefs.SetInt("restart", 1);
            //loads the level
            Application.LoadLevel(Application.loadedLevel);
            //VehicleSimpleControl._instance.rigidBody.bodyType = RigidbodyType2D.Static;
        }

    }
  
    public void HideInstructionText()
    {
        InstructionText.gameObject.SetActive(false);
    }

    

    public void StartMoving()
    {
        
       //allows the vehicle to move once the start button is pressed, sets the racepress bool of vehicle to true which allows it to move, also turns off the drawing manager so the user cannot draw any path once the vehicle starts moving
        DrawingManager.Instance.startMoving = true;
        Debug.Log("startmoving true");
        if (DrawingManager.Instance.paths.Contains(DrawingManager.Instance.clone))
        {
            VehicleSimpleControl._instance.RacePress = true;
            //VehicleSimpleControl.Instance.aceleration = 3.2f;
            resetButton.SetActive(false);
            Debug.Log("racepress true");
        }
        
        DrawingManager.Instance.Particle.SetActive(false);
        Drawmanag.SetActive(false);
        buttonAnim.Stop("buttonAnim");
       
    }

    public void HideTimer()
    {   //hides the timer once it has finished and removes fixed positions from certain levels
        VehicleSimpleControl.Instance.aceleration = 3f;
        VehicleSimpleControl.Instance.maxSpeed = 30f;
        VehicleSimpleControl.Instance.breakForce = 30f;
        VehicleSimpleControl.Instance.reverseMaxSpeed = 20f;
        VehicleSimpleControl.Instance.reverse = true;
        StartTimer.SetActive(false);
        Drawmanag.SetActive(true);
        drawmanag = true;
        if (DrawingManager.Instance.gameObject.activeSelf)
        {
            /*DrawingManager.Instance.newVerticies2.Clear();
            DrawingManager.Instance.newVerticies.Clear();                                   // Clear Lists before adding new points for the new drawing
            DrawingManager.Instance.newVerticies_.Clear();
            DrawingManager.Instance.paths.Clear();*/
            DrawingManager.Instance.startMoving = false;
            //DrawingManager.Instance.StartCar.SetActive(false);
           // DrawingManager.Instance.Start();
        }

        //level49
        if (EnvirenmentNo == 49)
        {
            DrawingManager.Instance.fixedPosition = false;
        }
        //level50
        if (EnvirenmentNo == 50)
        {
            DrawingManager.Instance.fixedPosition = false;
        }
        /*//level32
        if (EnvirenmentNo == 31)
        {
            DrawingManager.Instance.fixedPosition = false;
        }
        //level33
        if (EnvirenmentNo == 32)
        {
            DrawingManager.Instance.fixedPosition = false;
        }
        //level34
        if (EnvirenmentNo == 33)
        {
            DrawingManager.Instance.fixedPosition = false;
        }
        //level35
        if (EnvirenmentNo == 34)
        {
            DrawingManager.Instance.fixedPosition = false;
        }*/
     

    }

    IEnumerator HideFlipText(int t)
    {
        yield return new WaitForSeconds(t);
        if (restvalue == false)
        {
            BackFlipText.gameObject.SetActive(false);
            FrontFlipText.gameObject.SetActive(false);
        }
    }
    //turn off the loading panel
    public void CloseLoading()
    {
        LoadingPanel.SetActive(false);
        closeLoading = true;
        /*HideBannerBottom();
        HideBannerTop();*/
    }

    public void Ready()
    {
        readyButton.SetActive(true);
        closeLoading = false;
    }
    //stores names of all the levels from level 1 to level 50

    public void GetEnvirementInfo(int number)
    {
        EnvirenmentNo = number;
        if (EnvirenmentNo == 1)
        {
            planetName = "Level " + 1;
        }
        /*else if (EnvirenmentNo == 1)
        {

            planetName = "Desert";
        }
        else if (EnvirenmentNo == 2)
        {

            planetName = "Snow";
        }
        else if (EnvirenmentNo == 3)
        {

            planetName = "Jungle";
        }
        else if (EnvirenmentNo == 4)
        {


            planetName = "SciFi";
        }*/
        else if (EnvirenmentNo == 2)
        {


            planetName = "Level " + 2;
        }
        else if (EnvirenmentNo == 3)
        {


            planetName = "Level " + 3;
        }
        else if (EnvirenmentNo == 4)
        {


            planetName = "Level " + 4;
        }
        else if (EnvirenmentNo == 5)
        {


            planetName = "Level  " + 5;
        }
        else if (EnvirenmentNo == 6)
        {


            planetName = "Level  " + 6;
        }
        else if (EnvirenmentNo == 7)
        {


            planetName = "Level " + 7;
        }
        else if (EnvirenmentNo == 8)
        {


            planetName = "Level  " + 8;
        }
        else if (EnvirenmentNo == 9)
        {


            planetName = "Level  " + 9;
        }
        else if (EnvirenmentNo == 10)
        {


            planetName = "Level  " + 10;
        }
        else if (EnvirenmentNo == 11)
        {

            planetName = "Level  " + 11;
        }
        else if (EnvirenmentNo == 12)
        {

            planetName = "Level  " + 12;
        }
        else if (EnvirenmentNo == 13)
        {

            planetName = "Level  " + 13;
        }
        else if (EnvirenmentNo == 14)
        {

            planetName = "Level  " + 14;
        }
        else if (EnvirenmentNo == 15)
        {

            planetName = "Level  " + 15;
        }
        else if (EnvirenmentNo == 16)
        {

            planetName = "Level  " + 16;
        }
        else if (EnvirenmentNo == 17)
        {

            planetName = "Level  " + 17;
        }else if (EnvirenmentNo == 18)
        {

            planetName = "Level  " + 18;
        }else if (EnvirenmentNo == 19)
        {

            planetName = "Level  " + 19;
        }else if (EnvirenmentNo == 20)
        {

            planetName = "Level  " + 20;
        }else if (EnvirenmentNo == 21)
        {

            planetName = "Level  " + 21;
        }else if (EnvirenmentNo == 22)
        {

            planetName = "Level  " + 22;
        }
        else if (EnvirenmentNo == 23)
        {

            planetName = "Level  " + 23;
        }
         else if (EnvirenmentNo == 24)
        {

            planetName = "Level  " + 24;
        }
         else if (EnvirenmentNo == 25)
        {

            planetName = "Level  " + 25;
        }
        else if (EnvirenmentNo == 26)
        {

            planetName = "Level  " + 26;
        }else if (EnvirenmentNo == 27)
        {

            planetName = "Level  " + 27;
        }else if (EnvirenmentNo == 28)
        {

            planetName = "Level   " + 28;
        }else if (EnvirenmentNo == 29)
        {

            planetName = "Level   " + 29;
        }
        else if (EnvirenmentNo == 30)
        {

            planetName = "Level  " + 30;
        }else if (EnvirenmentNo == 31)
        {

            planetName = "Level  " + 31;
        }else if (EnvirenmentNo == 32)
        {

            planetName = "Level  " + 32;
        }else if (EnvirenmentNo == 33)
        {

            planetName = "Level  " + 33;
        }else if (EnvirenmentNo == 34)
        {

            planetName = "Level  " + 34;
        }
        else if (EnvirenmentNo == 35)
        {

            planetName = "Level  " + 35;
        }else if (EnvirenmentNo == 36)
        {

            planetName = "Level  " + 36;
        }else if (EnvirenmentNo == 37)
        {

            planetName = "Level  " + 37;
        }else if (EnvirenmentNo == 38)
        {

            planetName = "Level   " + 38;
        }else if (EnvirenmentNo == 39)
        {

            planetName = "Level  " + 39;
        }else if (EnvirenmentNo == 40)
        {

            planetName = "Level  " + 40;
        }else if (EnvirenmentNo == 41)
        {

            planetName = "Level  " + 41;
        }else if (EnvirenmentNo == 42)
        {

            planetName = "Level  " + 42;
        }else if (EnvirenmentNo == 43)
        {

            planetName = "Level   " + 43;
        }
        else if (EnvirenmentNo == 44)
        {

            planetName = "Level  " + 44;
        }
        else if (EnvirenmentNo == 45)
        {

            planetName = "Level  " + 45;
        } else if (EnvirenmentNo == 46)
        {

            planetName = "Level  " + 46;
        }else if (EnvirenmentNo == 47)
        {

            planetName = "Level   " + 47;
        }else if (EnvirenmentNo == 48)
        {

            planetName = "Level  " + 48;
        }else if (EnvirenmentNo == 49)
        {

            planetName = "Level  " + 49;
        }else if (EnvirenmentNo == 50)
        {

            planetName = "Level   " + 50;
        }
        


    }

    public void UnlockEnvCoins()
    {
        if (EnvirenmentNo == 1)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
        else if (EnvirenmentNo == 2)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
        else if (EnvirenmentNo == 3)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
        else if (EnvirenmentNo == 4)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
        else if (EnvirenmentNo == 5)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }

        else if (EnvirenmentNo == 6)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }

        else if (EnvirenmentNo == 7)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }

        else if (EnvirenmentNo == 8)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }

        else if (EnvirenmentNo == 9)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }

        else if (EnvirenmentNo == 10)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }

        else if (EnvirenmentNo == 11)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }

        else if (EnvirenmentNo == 12)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }

        else if (EnvirenmentNo == 13)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
        else if (EnvirenmentNo == 14)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
        else if (EnvirenmentNo == 15)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
        else if (EnvirenmentNo == 16)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
        else if (EnvirenmentNo == 17)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
        else if (EnvirenmentNo == 18)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
        else if (EnvirenmentNo == 19)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
        else if (EnvirenmentNo == 20)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 21)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 22)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 23)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 24)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 25)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
        else if (EnvirenmentNo == 26)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 27)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 28)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 29)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
else if (EnvirenmentNo == 30)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 31)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 32)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 33)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
else if (EnvirenmentNo == 34)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 35)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 36)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 37)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 38)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 39)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
else if (EnvirenmentNo == 40)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 41)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 42)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 43)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 44)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 45)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 46)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 47)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 48)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 49)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }/*else if (EnvirenmentNo == 50)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 51)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }
else if (EnvirenmentNo == 52)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }else if (EnvirenmentNo == 53)
        {
            if (PlayerPrefs.GetInt("score") >= EnvPrice)
            {
                PlayerPrefs.SetInt("env" + EnvirenmentNo, 2);
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - EnvPrice);
            }
        }*/


    }

    public void UnlockVehicle()
    {
        if (Car_number == 1)
        {
            //CarPrice = 100000;
            CarPrice = 0;
            if (PlayerPrefs.GetInt("score") >= CarPrice)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - CarPrice);
                PlayerPrefs.SetInt("car" + Car_number, 2);
            }
        }
        else if (Car_number == 2)
        {
            CarPrice = 0;
            //CarPrice = 200000;
            if (PlayerPrefs.GetInt("score") >= CarPrice)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - CarPrice);
                PlayerPrefs.SetInt("car" + Car_number, 2);
            }
        }
        else if (Car_number == 3)
        {
            CarPrice = 0;
            //CarPrice = 300000;
            if (PlayerPrefs.GetInt("score") >= CarPrice)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - CarPrice);
                PlayerPrefs.SetInt("car" + Car_number, 2);
            }
        }
        else if (Car_number == 4)
        {
            CarPrice = 0;
            //CarPrice = 400000;
            if (PlayerPrefs.GetInt("score") >= CarPrice)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - CarPrice);
                PlayerPrefs.SetInt("car" + Car_number, 2);
            }
        }
        else if (Car_number == 5)
        {
            CarPrice = 0;
            //CarPrice = 500000;
            if (PlayerPrefs.GetInt("score") >= CarPrice)
            {
                PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - CarPrice);
                PlayerPrefs.SetInt("car" + Car_number, 2);
            }
        }
        else if (Car_number == 6)
        {
            CarPrice = 0;
            /*CarPrice = 600000;
            if (PlayerPrefs.GetInt("score") >= CarPrice)
            {*/
               // PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - CarPrice);
                PlayerPrefs.SetInt("car" + Car_number, 2);
            //}
        }
        else if (Car_number == 7)
        {
            CarPrice = 0;
            //CarPrice = 700000;
           // if (PlayerPrefs.GetInt("score") >= CarPrice)
           // {
             //   PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - CarPrice);
                PlayerPrefs.SetInt("car" + Car_number, 2);
           // }
        }
        else if (Car_number == 8)
        {
            CarPrice = 0;
           // CarPrice = 800000;
           // if (PlayerPrefs.GetInt("score") >= CarPrice)
            //{
           //     PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - CarPrice);
                PlayerPrefs.SetInt("car" + Car_number, 2);
           // }
        }
        else if (Car_number == 9)
        {
            CarPrice = 0;
            // CarPrice = 800000;
            // if (PlayerPrefs.GetInt("score") >= CarPrice)
            //{
            //     PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - CarPrice);
            PlayerPrefs.SetInt("car" + Car_number, 2);
            // }
        }
        else if (Car_number == 10)
        {
            CarPrice = 0;
            // CarPrice = 800000;
            // if (PlayerPrefs.GetInt("score") >= CarPrice)
            //{
            //     PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - CarPrice);
            PlayerPrefs.SetInt("car" + Car_number, 2);
            // }
        }
        else if (Car_number == 11)
        {
            CarPrice = 0;
            // CarPrice = 800000;
            // if (PlayerPrefs.GetInt("score") >= CarPrice)
            //{
            //     PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - CarPrice);
            PlayerPrefs.SetInt("car" + Car_number, 2);
            // }
        }
        else if (Car_number == 12)
        {
            CarPrice = 0;
            // CarPrice = 800000;
            // if (PlayerPrefs.GetInt("score") >= CarPrice)
            //{
            //     PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - CarPrice);
            PlayerPrefs.SetInt("car" + Car_number, 2);
            // }
        }
        else if (Car_number == 13)
        {
            CarPrice = 0;
            // CarPrice = 800000;
            // if (PlayerPrefs.GetInt("score") >= CarPrice)
            //{
            //     PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - CarPrice);
            PlayerPrefs.SetInt("car" + Car_number, 2);
            // }
        }
        else if (Car_number == 14)
        {
            CarPrice = 0;
            // CarPrice = 800000;
            // if (PlayerPrefs.GetInt("score") >= CarPrice)
            //{
            //     PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - CarPrice);
            PlayerPrefs.SetInt("car" + Car_number, 2);
            // }
        }
        else if (Car_number == 15)
        {
            CarPrice = 0;
            // CarPrice = 800000;
            // if (PlayerPrefs.GetInt("score") >= CarPrice)
            //{
            //     PlayerPrefs.SetInt("score", PlayerPrefs.GetInt("score") - CarPrice);
            PlayerPrefs.SetInt("car" + Car_number, 2);
            // }
        }
    }

    public void EngineUpdateBtn()
    {
        if (PlayerPrefs.GetInt("car" + Car_number + "engine") <= CurrentEngineValue)
        {
            if (PlayerPrefs.GetInt("score") >= (PlayerPrefs.GetInt("car" + Car_number + "engine") * 4000))
            {
                PlayerPrefs.SetInt("score",
                    PlayerPrefs.GetInt("score") - (PlayerPrefs.GetInt("car" + Car_number + "engine") * 4000));
                PlayerPrefs.SetInt("car" + Car_number + "engine",
                    PlayerPrefs.GetInt("car" + Car_number + "engine") + 1);
                CurrentEngineValue++;
            }
            else
            {
                Debug.Log("lowCash");
            }
        }
        else
        {
            CurrentEngineValue++;
        }
    }

    public void EngineDegradeBtn()
    {
        CurrentEngineValue--;
    }

    public void SuspensionDegradeBtn()
    {
        CurrentSuspensionValue--;
    }

    public void TyreDegradeBtn()
    {
        CurrentTyreValue--;
    }

    public void FarwardDegradeBtn()
    {
        CurrentfarwardValue--;

    }

    public void SuspensionUpdateBtn()
    {

        if (PlayerPrefs.GetInt("car" + Car_number + "suspension") <= CurrentSuspensionValue)
        {
            if (PlayerPrefs.GetInt("score") >= (PlayerPrefs.GetInt("car" + Car_number + "suspension") * 4000))
            {
                PlayerPrefs.SetInt("score",
                    PlayerPrefs.GetInt("score") - (PlayerPrefs.GetInt("car" + Car_number + "suspension") * 4000));
                PlayerPrefs.SetInt("car" + Car_number + "suspension",
                    PlayerPrefs.GetInt("car" + Car_number + "suspension") + 1);
                CurrentSuspensionValue++;
            }
            else
            {
                Debug.Log("lowCash");
            }

        }
        else
        {
            CurrentSuspensionValue++;
        }
    }

    public void TyreUpdateBtn()
    {
        if (PlayerPrefs.GetInt("car" + Car_number + "tyres") <= CurrentTyreValue)
        {
            if (PlayerPrefs.GetInt("score") >= (PlayerPrefs.GetInt("car" + Car_number + "tyres") * 4000))
            {
                PlayerPrefs.SetInt("score",
                    PlayerPrefs.GetInt("score") - (PlayerPrefs.GetInt("car" + Car_number + "tyres") * 4000));
                PlayerPrefs.SetInt("car" + Car_number + "tyres", PlayerPrefs.GetInt("car" + Car_number + "tyres") + 1);
                CurrentTyreValue++;
            }
            else
            {
                Debug.Log("lowCash");
            }

        }
        else
        {
            CurrentTyreValue++;
        }
    }

    public void FarwardUpdateBtn()
    {

        if (PlayerPrefs.GetInt("car" + Car_number + "farward") <= CurrentfarwardValue)
        {
            if (PlayerPrefs.GetInt("score") >= (PlayerPrefs.GetInt("car" + Car_number + "farward") * 4000))
            {
                PlayerPrefs.SetInt("score",
                    PlayerPrefs.GetInt("score") - (PlayerPrefs.GetInt("car" + Car_number + "farward") * 4000));
                PlayerPrefs.SetInt("car" + Car_number + "farward",
                    PlayerPrefs.GetInt("car" + Car_number + "farward") + 1);
                CurrentfarwardValue++;
            }
            else
            {
                Debug.Log("lowCash");
            }
        }
        else
        {
            CurrentfarwardValue++;
        }
    }

    public void BottonSound()
    {
        if (PlayerPrefs.GetInt("sound") == 0)
        {
            this.GetComponent<AudioSource>().PlayOneShot(BtnSound);
        }

    }

    public void ShowBannerTop()
    {
        if (PlayerPrefs.GetInt("removeads") < 2)
        {
/*#if !UNITY_EDITOR
        AdsManager.Instance.showBannerbottomcentre();
#endif
        }
    }
    public void ShowBannerBottom()
    {
        if (PlayerPrefs.GetInt("removeads") < 2)
        {
#if !UNITY_EDITOR
             AdsManager.Instance.showBannerbottomcentre();
#endif
        }
    }
    public void HideBannerTop()
    {
        if (PlayerPrefs.GetInt("removeads") < 2)
        {
#if !UNITY_EDITOR
             AdsManager.Instance.hideBannerbottomcentre();
#endif
        }
    }
    public void HideBannerBottom()
    {
        if (PlayerPrefs.GetInt("removeads") < 2)
        {
#if !UNITY_EDITOR
            AdsManager.Instance.hideBannerbottomcentre();
#endif
        }
    }
    public void ShowInterstial()
    {
        if (PlayerPrefs.GetInt("removeads") < 2)
        {
#if !UNITY_EDITOR
             AdsManager.Instance.ShowInterstitail();
#endif
        }
    }
    public void ShowUnityAds()
    {
        if (PlayerPrefs.GetInt("removeads") < 2)
        {
#if !UNITY_EDITOR
        AdsManager.Instance.showUnityAdmob();
#endif
        }
    }*/

            void bannerad(string id)
            {
                if (id == "badminton")
                {
                    Application.OpenURL(
                        "https://play.google.com/store/apps/details?id=com.ultron.badminton3D.tennis3D");
                }
                else if (id == "duck")
                {
                    Application.OpenURL("https://play.google.com/store/apps/details?id=com.uls.duck.hunting");
                }
                else if (id == "sniperops")
                {
                    Application.OpenURL(
                        "https://play.google.com/store/apps/details?id=com.ultron.sniper3dshooting.elitesniperShooter");
                }
                else if (id == "3dhorse")
                {
                    Application.OpenURL("https://play.google.com/store/apps/details?id=com.uls.horseriding");
                }
                else if (id == "bmx")
                {
                    Application.OpenURL("https://play.google.com/store/apps/details?id=com.uls.cycleriding");
                }
                else if (id == "chainhorse")
                {
                    Application.OpenURL(
                        "https://play.google.com/store/apps/details?id=com.ultron.chainedcarchainedbikechainedhorseracing");
                }
                else if (id == "wheelrush")
                {
                    Application.OpenURL(
                        "https://play.google.com/store/apps/details?id=com.ultron.wheeldash.endlessrun");
                }
                else if (id == "rivalcar")
                {
                    Application.OpenURL("https://play.google.com/store/apps/details?id=com.ultron.warrobots.galaxywar");
                }
                else if (id == "fruitshooter")
                {
                    Application.OpenURL("https://play.google.com/store/apps/details?id=com.uls.arcade.bubbles");
                }
                else if (id == "rescuepet")
                {
                    Application.OpenURL(
                        "https://play.google.com/store/apps/details?id=com.ultron.petrescue.match3saga");
                }
                else if (id == "crazycarstunt")
                {
                    Application.OpenURL(
                        "https://play.google.com/store/apps/details?id=com.ultron.stuntcar.bikestuntdrive");
                }
                else if (id == "bottleshooter")
                {
                    Application.OpenURL(
                        "https://play.google.com/store/apps/details?id=com.ultron.bottlesshooting.gunshooting");
                }
                else if (id == "4x4jeep")
                {
                    Application.OpenURL(
                        "https://play.google.com/store/apps/details?id=com.ultron.offroadproject.suvoffroaddrive");
                }
            }
        }
}
}
    
    
