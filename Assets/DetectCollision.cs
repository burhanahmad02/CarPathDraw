using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectCollision : MonoBehaviour

{
    public bool FrontTyre;
    public bool BackTyre;
    public static bool FrontTyreOnGround;
    public static bool BackTyreOnGround;
    public  bool FrontIsGrounded;
    public  bool BackIsGrounded;
    public static bool FrontWheelMud;
    public static bool BackWheelMud;

    public LayerMask whatIsGround;


    // Start is called before the first frame update
    void Start()
    {
        FrontTyreOnGround = false;
        BackTyreOnGround = false;
        FrontWheelMud = false;
        BackWheelMud = false;
    }

    // Update is called once per frame
    void Update()
    {
        FrontIsGrounded = FrontTyreOnGround;
        BackIsGrounded = BackTyreOnGround;
       
        if (FrontTyre)
        {
            RaycastHit2D hitFront = Physics2D.Raycast(this.transform.position, Vector2.down,Mathf.Infinity,whatIsGround);
            // && hitFront.distance == this.GetComponent<CircleCollider2D>().radius
            //Debug.Log(hitFront.distance);
            if (hitFront.collider != null)
            {
                
               // Debug.Log("d "+hitFront.distance);
               if (hitFront.collider.gameObject.layer == 8 && hitFront.distance >= this.GetComponent<CircleCollider2D>().radius + 1.5f )
                {
                    FrontTyreOnGround = true;
                  //  Debug.Log("not touch");
                }
                else
                {
                    FrontTyreOnGround = false;
                   // Debug.Log("touch");
                }
                if (hitFront.collider.gameObject.tag == "Ground" && hitFront.distance <= this.GetComponent<CircleCollider2D>().radius + 0.5f)
                {
                    FrontWheelMud = true;
                }
                else
                {

                    FrontWheelMud = false;
                }
            }
        }

        if (BackTyre)
        {
            RaycastHit2D hitback = Physics2D.Raycast(this.transform.position, Vector2.down, Mathf.Infinity, whatIsGround);
            // && hitFront.distance == this.GetComponent<CircleCollider2D>().radius
            //Debug.Log(hitFront.distance);
            if (hitback.collider != null)
            {
                if ( hitback.collider.gameObject.layer == 8 && hitback.distance >= this.GetComponent<CircleCollider2D>().radius + 1.5f)
                {
                    BackTyreOnGround = true;
                  //  Debug.Log("touch");
                }
                else
                {
                    BackTyreOnGround = false;
                  //  Debug.Log("not touch");
                }

                if (hitback .collider.gameObject.tag == "Ground" && hitback.distance <= this.GetComponent<CircleCollider2D>().radius + 0.5f)
                {
                    BackWheelMud = true;
                }
                else
                {

                    BackWheelMud = false;
                }
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if ( collision.gameObject.CompareTag("line"))
        {
            VehicleSimpleControl.Instance.BodyColide = false;
        }
        if (collision.gameObject.tag == "rope2D")
        {
            this.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Discrete;
        }
        else
        {
            this.GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        }
    }

}
