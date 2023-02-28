using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RanDomExplosionForce : MonoBehaviour
{
    private Rigidbody2D rb2D;
    private float thrust;
    int r;
    public static bool instantDestroy;

    private void Start()
    {
        instantDestroy = false;
        r = Random.Range(0,2);
        thrust = Random.Range(50,100);
        transform.rotation = Quaternion.identity;
        if (GetComponent<Rigidbody2D>() == null)
        {
            gameObject.AddComponent<Rigidbody2D>();
        }

        rb2D = GetComponent<Rigidbody2D>();
        rb2D.mass = 1;
        rb2D.gravityScale = 1;

        // transform.position = new Vector3(0.0f, -2.0f, 0.0f);
        if (r == 0)
        {
            rb2D.AddForce(-transform.up * thrust, ForceMode2D.Impulse);
        }
        if (r == 1)
        {
            rb2D.AddForce(-transform.right * thrust, ForceMode2D.Impulse);
        }
        if (r == 2)
        {
            rb2D.AddForce(transform.up * thrust, ForceMode2D.Impulse);

        }


    }
    private void Update()
    {
        if (instantDestroy == true)
        {
            Destroy(gameObject);
        }
    }
}
