/* This script shows how realtime generation works. Read the comments in code to understand the process */
using System.Collections.Generic;
using UnityEngine;
using System.Collections;
public class MyTerrain2DGenerator : MonoBehaviour
{
    public static MyTerrain2DGenerator _instance;
    public static bool check;
    Transform Player;
    // public GameObject[] TerrainTemplate;
    public GameObject Level1;
    public GameObject Level2;
    public GameObject Level3;
    public GameObject Level4;
    public GameObject Level5;
    public GameObject Level6;
    public GameObject Level7;
    public GameObject Level8;
    public GameObject Level9;
    public GameObject Level10;
    public GameObject Level11;
    public GameObject Level12;
    public GameObject Level13;
    public GameObject Level14;
    public GameObject Level15;
    public GameObject Level16;
    public GameObject Level17;
    public GameObject Level18;
    public GameObject Level19;
    public GameObject Level20;
    public GameObject Level21;
    public GameObject Level22;
    public GameObject Level23;
    public GameObject Level24;
    public GameObject Level25;
    public GameObject Level26;
    public GameObject Level27;
    public GameObject Level28;
    public GameObject Level29;
    public GameObject Level30;
    public GameObject Level31;
    public GameObject Level32;
    public GameObject Level33;
    public GameObject Level34;
    public GameObject Level35;
    public GameObject Level36;
    public GameObject Level37;
    public GameObject Level38;
    public GameObject Level39;
    public GameObject Level40;
    public GameObject Level41;
    public GameObject Level42;
    public GameObject Level43;
    public GameObject Level44;
    public GameObject Level45;
    public GameObject Level46;
    public GameObject Level47;
    public GameObject Level48;
    public GameObject Level49;
    public GameObject Level50;
    public GameObject[] DesertTiles;
    public GameObject[] MountainTile;
    public GameObject[] MoonTiles;
    public GameObject[] SiFiTiles;
    public Material[] TerrainMat;
    public Material[] CapMat;
    private Vector3 _nextTerrainPos;
    GameObject newTerrainObj;
    public static bool GenerateFuel;
    int a;
    public List<GameObject> _createdTerrains = new List<GameObject>();
    int RandomNumber;
    public GameObject[] Vehicles;
    int counter;
    bool first_tile;
    public bool changemat_tele;
    public static MyTerrain2DGenerator Instance { get { return _instance; } }
    private void Awake()
    {
        _instance = this;
    }
    void Start () 
    {
        GenerateNextTerrain2D(Vector2.zero);
        VehicleSimpleControl.Instance.FuelLevel = 100;
        GenerateFuel = false;
        counter = 0;
        first_tile = false;
        changemat_tele = false;
    }
    void LateUpdate()
    {
        // Debug.Log(GenerateFuel);
        if (GameManager.Instance.CurrrentCar.transform != null)
        {
            Player = GameManager.Instance.CurrrentCar.transform;
        }
       
        /*if (Player.position.x > _nextTerrainPos.x) 
        {
            _nextTerrainPos.x += 1000;
            a= Random.Range(0, 10);
            _nextTerrainPos.y = 0;
            GenerateNextTerrain2D(new Vector2(_nextTerrainPos.x, _nextTerrainPos.y));
        }*/
        if (_createdTerrains.Count > 3)
        {
            Destroy(_createdTerrains[0]);
            _createdTerrains.RemoveAt(0);
        }
        if (changemat_tele)
        {
            changemat_tele = false;
            for (int i = 0; i < _createdTerrains.Count; i++)
            {
                _createdTerrains[i].GetComponent<MeshRenderer>().material = TerrainMat[GameManager.EnvirenmentNo];
              //  _createdTerrains[i].transform.GetChild(1).GetComponent<MeshRenderer>().material = CapMat[GameManager.EnvirenmentNo - 1];
                if (_createdTerrains[i].transform.GetChild(2).gameObject.activeInHierarchy)
                {
                    _createdTerrains[i].transform.GetChild(2).gameObject.GetComponent<MeshRenderer>().material = TerrainMat[GameManager.EnvirenmentNo];
                }
            }
        }
    }
    void GenerateNextTerrain2D(Vector2 terrainPos)
    {
        counter++;
        if (_createdTerrains.Count == 0)
        {
            RandomNumber = 0;
        }
        else
        {
            RandomNumber = Random.RandomRange(0, 3);
        }
        if (GameManager.EnvirenmentNo == 1)
        {
            
            newTerrainObj = Instantiate(Level1, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(117.4f,252.1f);
            Camera.main.orthographicSize = 46f;
            DistanceHandler(newTerrainObj);
        }
        /*else if (GameManager.EnvirenmentNo == 1)
        {
            newTerrainObj = Instantiate(DesertTiles[RandomNumber], _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            DistanceHandler(newTerrainObj);
        }
        else if (GameManager.EnvirenmentNo == 2)
        {
            newTerrainObj = Instantiate(MountainTile[RandomNumber], _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            DistanceHandler(newTerrainObj);
        }
        else if (GameManager.EnvirenmentNo == 3)
        {
            newTerrainObj = Instantiate(MoonTiles[RandomNumber], _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            DistanceHandler(newTerrainObj);
        }
        else if (GameManager.EnvirenmentNo == 4)
        {
            newTerrainObj = Instantiate(SiFiTiles[RandomNumber], _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            DistanceHandler(newTerrainObj);
        }*/
        //level 2
        else if (GameManager.EnvirenmentNo == 2)
        {
            newTerrainObj = Instantiate(Level2, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(166f,284f);
            Camera.main.orthographicSize = 46f;
            DistanceHandler(newTerrainObj);
        }
        //level 3
        else if (GameManager.EnvirenmentNo == 3)
        {
            newTerrainObj = Instantiate(Level3, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(228.75f,283f);
            Camera.main.orthographicSize = 46f;
            DistanceHandler(newTerrainObj);
        } 
        //level4
        else if (GameManager.EnvirenmentNo == 4)
        {
            newTerrainObj = Instantiate(Level4, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(228.75f,290f);
            Camera.main.orthographicSize = 46f;
            DistanceHandler(newTerrainObj);
        }
        //level 5
        else if (GameManager.EnvirenmentNo == 5)
        {
            newTerrainObj = Instantiate(Level5, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(234.1f,275f);
            Camera.main.orthographicSize = 46f;
            DistanceHandler(newTerrainObj);
        }
        //level 6
        else if (GameManager.EnvirenmentNo == 6)
        {
            newTerrainObj = Instantiate(Level6, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(243f,290f);
            Camera.main.orthographicSize = 46f;
            DistanceHandler(newTerrainObj);
        } 
        // level 7
        else if (GameManager.EnvirenmentNo == 7)
        {
            newTerrainObj = Instantiate(Level7, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(232.8f,290f);
            Camera.main.orthographicSize = 48f;
            DistanceHandler(newTerrainObj);
        }
        //level 8
        else if (GameManager.EnvirenmentNo == 8)
        {
            newTerrainObj = Instantiate(Level8, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(216.09f,286.26f);
            Camera.main.orthographicSize = 48f;
            DistanceHandler(newTerrainObj);
        }
        //level 9 
        else if (GameManager.EnvirenmentNo == 9)
        {
            newTerrainObj = Instantiate(Level9, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(216.09f,286.26f);
            Camera.main.orthographicSize = 48f;
            DistanceHandler(newTerrainObj);
        }
        //level 10
        else if (GameManager.EnvirenmentNo == 10)
        {
            newTerrainObj = Instantiate(Level10, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(217.9f,290f);
            Camera.main.orthographicSize = 48f;
            DistanceHandler(newTerrainObj);
        }
        //level 11
        else if (GameManager.EnvirenmentNo == 11)
        {
            newTerrainObj = Instantiate(Level11, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(381.95f,271.2f);
            Camera.main.orthographicSize = 60f;
            DistanceHandler(newTerrainObj);
        }
        //level 12
        else if (GameManager.EnvirenmentNo == 12)
        {
            newTerrainObj = Instantiate(Level12, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(217.9f,274.1f);
            Camera.main.orthographicSize = 55f;
            DistanceHandler(newTerrainObj);
        }
        //level 13
        else if (GameManager.EnvirenmentNo == 13)
        {
            newTerrainObj = Instantiate(Level13, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(205.1f,269.6f);
            Camera.main.orthographicSize = 50f;
            DistanceHandler(newTerrainObj);
        }
        //level 14
        else if (GameManager.EnvirenmentNo == 14)
        {
            newTerrainObj = Instantiate(Level14, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(117f,267.2f);
            Camera.main.orthographicSize = 45f;
            DistanceHandler(newTerrainObj);
        }
        //level 15
        else if (GameManager.EnvirenmentNo == 15)
        {
            newTerrainObj = Instantiate(Level15, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(99.13f,267.2f);
            Camera.main.orthographicSize = 43f;
            DistanceHandler(newTerrainObj);
        }
        //level 16
        else if (GameManager.EnvirenmentNo == 16)
        {
            newTerrainObj = Instantiate(Level16, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(64.25f,267.2f);
            Camera.main.orthographicSize = 44f;
            DistanceHandler(newTerrainObj);
        }
        //level 17
        else if (GameManager.EnvirenmentNo == 17)
        {
            newTerrainObj = Instantiate(Level17, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(65.18f,267.2f);
            Camera.main.orthographicSize = 44f;
            DistanceHandler(newTerrainObj);
        }
        //level 18
        else if (GameManager.EnvirenmentNo == 18)
        {
            newTerrainObj = Instantiate(Level18, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(49f,267.2f);
            Camera.main.orthographicSize = 48f;
            DistanceHandler(newTerrainObj);
        }
        //level 19
       else if (GameManager.EnvirenmentNo == 19)
        {
            newTerrainObj = Instantiate(Level19, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(-8.9f,267.2f);
            Camera.main.orthographicSize = 55f;
            DistanceHandler(newTerrainObj);
        }
        //level 20
        else if (GameManager.EnvirenmentNo == 20)
        {
            newTerrainObj = Instantiate(Level20, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(8f,276.8f);
            Camera.main.orthographicSize = 60f;
            DistanceHandler(newTerrainObj);
        }
        //level 21
        else if (GameManager.EnvirenmentNo == 21)
        {
            newTerrainObj = Instantiate(Level21, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(257f,219f);
            Camera.main.orthographicSize = 60f;
            DistanceHandler(newTerrainObj);
        }
        //level 22
       else if (GameManager.EnvirenmentNo == 22)
        {
            newTerrainObj = Instantiate(Level22, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(171f,267.2f);
            Camera.main.orthographicSize = 50f;
            DistanceHandler(newTerrainObj);
        }
        //level 23
        else if (GameManager.EnvirenmentNo == 23)
        {
            newTerrainObj = Instantiate(Level23, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(189.5f,267.2f);
            Camera.main.orthographicSize = 70f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 24
        else if (GameManager.EnvirenmentNo == 24)
        {
            newTerrainObj = Instantiate(Level24, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(205f,267.2f);
            Camera.main.orthographicSize = 65f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 25
        else if (GameManager.EnvirenmentNo == 25)
        {
            newTerrainObj = Instantiate(Level25, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(176.42f,267.2f);
            Camera.main.orthographicSize = 60f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 26
        else if (GameManager.EnvirenmentNo == 26)
        {
            newTerrainObj = Instantiate(Level26, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(183f,267.2f);
            Camera.main.orthographicSize = 55f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 27
        else if (GameManager.EnvirenmentNo == 27)
        {
            newTerrainObj = Instantiate(Level27, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(190.77f,267.2f);
            Camera.main.orthographicSize = 60f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 28
        else if (GameManager.EnvirenmentNo == 28)
        {
            newTerrainObj = Instantiate(Level28, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(186.9f,267.2f);
            Camera.main.orthographicSize = 60f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 29
       else if (GameManager.EnvirenmentNo == 29)
        {
            newTerrainObj = Instantiate(Level29, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(167.12f,267.2f);
            Camera.main.orthographicSize = 60f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 30
        else if (GameManager.EnvirenmentNo == 30)
        {
            newTerrainObj = Instantiate(Level30, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(170.95f,250.92f);
            Camera.main.orthographicSize = 70f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 31
        else if (GameManager.EnvirenmentNo == 31)
        {
            newTerrainObj = Instantiate(Level31, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(251f,267.2f);
            Camera.main.orthographicSize = 60f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 32
        else if (GameManager.EnvirenmentNo == 32)
        {
            newTerrainObj = Instantiate(Level32, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(278.4f,265.2f);
            Camera.main.orthographicSize = 60f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 33
        else if (GameManager.EnvirenmentNo == 33)
        {
            newTerrainObj = Instantiate(Level33, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(327.3f,247.2f);
            Camera.main.orthographicSize = 55f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 34
        else if (GameManager.EnvirenmentNo == 34)
        {
            newTerrainObj = Instantiate(Level34, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(632.6f,265.2f);
            Camera.main.orthographicSize = 45f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 35
        else if (GameManager.EnvirenmentNo == 35)
        {
            newTerrainObj = Instantiate(Level35, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(622.2f,258.8f);
            Camera.main.orthographicSize = 50f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 36
        else if (GameManager.EnvirenmentNo == 36)
        {
            newTerrainObj = Instantiate(Level36, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(622.2f,258.8f);
            Camera.main.orthographicSize = 50f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 37
        else if (GameManager.EnvirenmentNo == 37)
        {
            newTerrainObj = Instantiate(Level37, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(342f,258.8f);
            Camera.main.orthographicSize = 75f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 38
        else if (GameManager.EnvirenmentNo == 38)
        {
            newTerrainObj = Instantiate(Level38, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(366f,248f);
            Camera.main.orthographicSize = 65f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 39
        else if (GameManager.EnvirenmentNo == 39)
        {
            newTerrainObj = Instantiate(Level39, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(378.7f,210f);
            Camera.main.orthographicSize = 65f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 40
        else if (GameManager.EnvirenmentNo == 40)
        {
            newTerrainObj = Instantiate(Level40, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(351f,207f);
            Camera.main.orthographicSize = 65f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 41
        else if (GameManager.EnvirenmentNo == 41)
        {
            newTerrainObj = Instantiate(Level41, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(187f,262f);
            Camera.main.orthographicSize = 70f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 42
        else if (GameManager.EnvirenmentNo == 42)
        {
            newTerrainObj = Instantiate(Level42, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(190.5f,306.2f);
            Camera.main.orthographicSize = 70f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 43
        else if (GameManager.EnvirenmentNo == 43)
        {
            newTerrainObj = Instantiate(Level43, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(187f,316.6f);
            Camera.main.orthographicSize = 70f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 44
        else if (GameManager.EnvirenmentNo == 44)
        {
            newTerrainObj = Instantiate(Level44, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(174.11f,321f);
            Camera.main.orthographicSize = 75f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 45
        else if (GameManager.EnvirenmentNo == 45)
        {
            newTerrainObj = Instantiate(Level45, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(166f,312.5f);
            Camera.main.orthographicSize = 65f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 46
        else if (GameManager.EnvirenmentNo == 46)
        {
            newTerrainObj = Instantiate(Level46, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(187f,321f);
            Camera.main.orthographicSize = 65f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 47
        else if (GameManager.EnvirenmentNo == 47)
        {
            newTerrainObj = Instantiate(Level47, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(207.07f,332.29f);
            Camera.main.orthographicSize = 65f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 48
        else if (GameManager.EnvirenmentNo == 48)
        {
            newTerrainObj = Instantiate(Level48, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(231f,321f);
            Camera.main.orthographicSize = 50f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 49
        else if (GameManager.EnvirenmentNo == 49)
        {
            newTerrainObj = Instantiate(Level49, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(187f,321f);
            Camera.main.orthographicSize = 45f;
            DistanceHandler(newTerrainObj);
            
        }
        //level 50
        else if (GameManager.EnvirenmentNo == 50)
        {
            newTerrainObj = Instantiate(Level50, _nextTerrainPos, Quaternion.identity) as GameObject;
            newTerrainObj.SetActive(true);
            Camera.main.transform.position = new Vector3(128.4f,317.1f);
            Camera.main.orthographicSize = 35f;
            DistanceHandler(newTerrainObj);
            
        }
       
        _createdTerrains.Add(newTerrainObj);
        if (VehicleSimpleControl.Instance.FuelLevel < 50 && _createdTerrains.Count>1 && GenerateFuel == false)
        {
            GenerateFuel = true;
            int r = Random.Range(1, 3);
            Debug.Log("abc");
        }
      
    }
    public void DistanceHandler(GameObject tileset)
    {
        if (VehicleSimpleControl.DistanceCovered >= 500)
        {
            tileset.transform.GetChild(0).gameObject.SetActive(true);
            
        }
        if (VehicleSimpleControl.DistanceCovered >= 700)
        {
            tileset.transform.GetChild(1).gameObject.SetActive(true);

        }
        if (VehicleSimpleControl.DistanceCovered >= 900)
        {
            tileset.transform.GetChild(2).gameObject.SetActive(true);

        }
        if (VehicleSimpleControl.DistanceCovered >= 1100)
        {
            tileset.transform.GetChild(3).gameObject.SetActive(true);

        }
    }
}
