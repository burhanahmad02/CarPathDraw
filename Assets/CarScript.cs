using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarScript : MonoBehaviour
{
    public Wheel_Options wheelOptions;
    public GameObject[] wheels;
    // Start is called before the first frame update
    void Start()
    {
        for (int wheelPosition = 0; wheelPosition < this.wheels.Length; ++wheelPosition)
        {
            if (wheels[wheelPosition] == null)
            {
                wheels = new GameObject[0];
                Debug.Log("Wheel not assigned.");
                return;
            }
            else if (wheels[wheelPosition].GetComponent<CircleCollider2D>() == null)
            {
                wheels = new GameObject[0];
                Debug.Log("Circle collider no assigned to the wheel.");
                return;
            }
            else
                this.addWheelJoint2D(wheelPosition);
        }
    }
    public void addWheelJoint2D(int wheelPosition)
    {
        WheelJoint2D wheelJoint2D = gameObject.AddComponent<WheelJoint2D>() as WheelJoint2D;
        if (!wheels[wheelPosition].GetComponent<Rigidbody2D>())
            wheels[wheelPosition].AddComponent<Rigidbody2D>();
        wheelJoint2D.connectedBody = wheels[wheelPosition].GetComponent<Rigidbody2D>();
        JointSuspension2D jointSuspension2D = new JointSuspension2D();
        // ISSUE: explicit reference operation
        jointSuspension2D.angle = 90f;
        jointSuspension2D.dampingRatio = wheelOptions.dampingRatio;
        jointSuspension2D.frequency = wheelOptions.frequency;
        wheelJoint2D.suspension = jointSuspension2D;
        wheelJoint2D.anchor = wheels[wheelPosition].transform.localPosition;
        wheels[wheelPosition].GetComponent<Rigidbody2D>().mass = wheelOptions.mass;
        wheels[wheelPosition].GetComponent<Rigidbody2D>().gravityScale = wheelOptions.gravityScale;
        wheels[wheelPosition].GetComponent<Rigidbody2D>().collisionDetectionMode = CollisionDetectionMode2D.Continuous;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
