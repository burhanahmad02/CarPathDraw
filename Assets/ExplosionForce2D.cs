// Developed by Ananda Gupta
// info@onemaninteractive.com
// http://onemaninteractive.com

using UnityEngine;
using System.Collections;

public class ExplosionForce2D : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float thrust = 50.0f;

    private void Start()
    {
        transform.rotation = Quaternion.identity;
        if (GetComponent<Rigidbody2D>() == null)
        {
            gameObject.AddComponent<Rigidbody2D>();
        }

        rb2D = GetComponent<Rigidbody2D>();
        rb2D.mass = 1;
        rb2D.gravityScale = 1;
        rb2D.constraints = RigidbodyConstraints2D.None;
        // transform.position = new Vector3(0.0f, -2.0f, 0.0f);
        if (this.gameObject.tag == "animal" || this.gameObject.tag == "bird")
        {
            rb2D.AddForce(transform.right * thrust, ForceMode2D.Impulse);
        }
        else
        {
            rb2D.AddForce(transform.up * thrust, ForceMode2D.Impulse);
        }
       
    }

  
}
