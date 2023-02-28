using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateobject : MonoBehaviour
{
    public float speed = 60;
    bool check;
    // Start is called before the first frame update
    private void Start()
    {
        if (VehicleSimpleControl.DistanceCovered > 1500)
        {
            check = true;
        }
        else
        {
            check = false;
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (check)
        {
            this.transform.Rotate(0, 0, -speed * Time.deltaTime);
        }
        
    }
}
