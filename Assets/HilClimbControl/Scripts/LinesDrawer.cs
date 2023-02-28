using System;
using UnityEngine;
 
public class LinesDrawer : MonoBehaviour
{
    private static LinesDrawer _instance;
    public static LinesDrawer Instance { get { return _instance; } }
    //public static bool canDraw;
    public  Transform transformObj;
    public GameObject linePrefab;
    public LayerMask cantDrawOverLayer;
    int cantDrawOverLayerIndex;
    //public static Transform Ts;
    [Space ( 30f )]
    public Gradient lineColor;
    public float linePointsMinDistance;
    public float lineWidth;
   
 
    [Space ( 30f )]
    public int maxDrawnLines = 1000000;
    
    public static int drawnLines = 1;
 
    Line currentLine;
 
    Camera cam;
 
    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
            
        }
        else
        {
            _instance = this;
        }
    }

    public void OnEnable()
    {
        if(transformObj.transform.childCount>0)
        {
            DestroyImmediate(transformObj.GetChild(0).gameObject);
            
            //break;
        }
    }
    void Start ( )
    {
        
            
        

        //canDraw = false;
        cam = Camera.main;
        cantDrawOverLayerIndex = LayerMask.NameToLayer ( "CantDrawOver" );
        
    }
    //Can also use this to delete lines whenever the level ends
    /*public void  DeleteLines (){
        foreach (Transform child in transform)
            GameObject.Destroy(child.gameObject);
        drawnLines = 0;
    }*/
    /*private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Car")
        {
            VehicleSimpleControl.Instance.gameObject.SetActive(false);
        }
    }*/

    void Update ( ) {
        if(transformObj.transform.childCount>0 )
        {
            //Invoke(nameof(SetToFalse),1.5f);
            //break;
        }
       
        /*if (canDraw == false)
        {
            if(drawnLines == 1)
            {
                Debug.Log("Destroy the drawn object");
                
         
                drawnLines = 0;
                Debug.Log("turn drawnlines back to zero"+LinesDrawer.drawnLines);

            }
        }*/
        
        
        if (drawnLines < maxDrawnLines){
            if ( Input.GetMouseButtonDown ( 0 ) )
                
                BeginDraw ( );
 
            if ( currentLine != null )
                Draw ( );
 
            if ( Input.GetMouseButtonUp ( 0 ) )
                EndDraw ( );
            
        }
        else{
            
            Debug.Log("You can't draw lines anymore");
           // GameManager.Instance.retry = false;
            //finish.stopCar = false;
        }
        
    }
 
    // Begin Draw ----------------------------------------------
    void BeginDraw ( )
    {
        //finish.stopCar = true;
        currentLine = Instantiate ( linePrefab, this.transform ).GetComponent <Line> ( );
 
        //Set line properties
        currentLine.UsePhysics ( false );
        currentLine.SetLineColor ( lineColor );
        currentLine.SetPointsMinDistance ( linePointsMinDistance );
        currentLine.SetLineWidth ( lineWidth );
 
    }
    // Draw ----------------------------------------------------
    void Draw ( )
    {
        //finish.stopCar = true;
        Vector2 mousePosition = cam.ScreenToWorldPoint ( Input.mousePosition );
 
        //Check if mousePos hits any collider with layer "CantDrawOver", if true cut the line by calling EndDraw( )
        RaycastHit2D hit = Physics2D.CircleCast ( mousePosition, lineWidth / 3f, Vector2.zero, 1f, cantDrawOverLayer );
 
        if ( hit )
            EndDraw ( );
        else
            currentLine.AddPoint ( mousePosition );
    }
    // End Draw ------------------------------------------------
    void EndDraw ( )
    {
        
        if ( currentLine != null ) {
            if ( currentLine.pointsCount < 2 ) {
                //If line has one point
                Destroy ( currentLine.gameObject );
            } else {
                //Add the line to "CantDrawOver" layer
                currentLine.gameObject.layer = cantDrawOverLayerIndex;
 
                //Activate Physics on the line
                currentLine.UsePhysics ( true );
 
                currentLine = null;
 
                drawnLines++;
            }
        }
        
        
    }

    /*public void SetToFalse()
    {
        //finish.stopCar = false;
    }*/
    
}