using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntirollBar : MonoBehaviour
{

    public WheelCollider wheelL;
    public WheelCollider wheelR;
    public float antiRoll = 5000;
    public Rigidbody rb;
    
    
    void FixedUpdate()
    {
        WheelHit hit;
        float travelL = 1;
        float travelR = 1;
        bool groundedL = wheelL.GetGroundHit(out hit);
        if (groundedL)
        {
            travelL = (-wheelL.transform.InverseTransformPoint(hit.point).y -wheelL.radius) / wheelL.suspensionDistance;
        }
        
        bool groundedR = wheelR.GetGroundHit(out hit);
        if (groundedR)
        {
            travelL = (-wheelR.transform.InverseTransformPoint(hit.point).y -wheelR.radius) / wheelR.suspensionDistance;
        }

        float antiRollForce = (travelL - travelR) * antiRoll;

        if (groundedL)
        {
            rb.AddForceAtPosition(wheelL.transform.up * -antiRollForce, wheelL.transform.position);
        }
        
        if (groundedR)
        {
            rb.AddForceAtPosition(wheelR.transform.up * -antiRollForce, wheelR.transform.position);
        }
    }
}
