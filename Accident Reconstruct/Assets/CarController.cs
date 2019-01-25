using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class CarController : NetworkBehaviour
{
    [HideInInspector]
    public float horizontalInput;
    [HideInInspector]
    public float verticalInput;
    [HideInInspector]
    public float wheelAngle;

    public ControlInputs input;

    public List<Axel> axels;

    public Rigidbody rb;
    public float startForce = 100;

    public float maxWheelAngle = 30f;
    public float forwardTorquePower = 2000f;
    public float reverseTorquePower = 1500;
    public float breakPower = 3000f;
    public bool breaking;

    public Transform carWaypoint;

    public bool AI;

    private void Awake()
    {
//        if (!isLocalPlayer)
//        {
//            input = null;
//        }
        
    }

    public void FixedUpdate()
    {
        if (!isLocalPlayer && !AI)
        {
            return;
        }
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }

    private void GetInput()
    {
//        horizontalInput = Input.GetAxis("Horizontal");
//        verticalInput = Input.GetAxis("Vertical");
//        breaking = Input.GetButton("Brake");
        if (input != null)
        {
            input.GetInputs(this);
        }
    }

    private void Steer()
    {
        wheelAngle = maxWheelAngle * horizontalInput;
        foreach(var axel in axels)
        {
            if (axel.steering)
            {
                axel.SetSteering(wheelAngle);
            }
        }
    }

    private void Accelerate()
    {
        //====Breaking Stuff====
        if (breaking)
        {
            print("Braking!");
        }
        //Set braking force on wheels if breaking
        foreach (var axel in axels)
        {
            if (breaking && axel.breaks)
            {
                axel.SetBrakeTorque(breakPower);
            }
            else
            {
                axel.SetBrakeTorque(0);
            }
        }

        //====Takeoff force for faster start, arcadey====
        if (rb.velocity.magnitude < 20 && Input.GetAxis("Vertical") > 0)
        {
            rb.AddForce(transform.forward * startForce);
        }

        //====Motor Force Stuff====
        float torquePower = 0;
        
        //Different torque amount if reversing
        if (verticalInput > 0)
        {
            torquePower = forwardTorquePower;
        }
        else if (verticalInput < 0)
        {
            torquePower = reverseTorquePower;
        }
        
        //multiply input by proper torque amount
        torquePower *= verticalInput;
        
        //set motor force for wheels
        foreach (var axel in axels)
        {
            if (axel.motor)
            {
                axel.SetMotorTorque(torquePower);
            }
        }        
    }

    private void UpdateWheelPoses()
    {
        foreach (var axel in axels)
        {
            axel.UpdateWheelPoses();
        }
    }   
}

[System.Serializable]
public class Axel
{
    public WheelCollider RWheelCollider;
    public WheelCollider LWheelCollider;
    public Transform RWheelTransform;
    public Transform LWheelTransform;
    public bool motor = false;
    public bool steering = false;
    public bool breaks = true;

    public void SetSteering(float newSteerAngle)
    {
        RWheelCollider.steerAngle = newSteerAngle;
        LWheelCollider.steerAngle = newSteerAngle;
    }

    public void SetBrakeTorque(float newBrakeTorque)
    {
        RWheelCollider.brakeTorque = newBrakeTorque;
        LWheelCollider.brakeTorque = newBrakeTorque;
    }

    public void SetMotorTorque(float newMotorTorque)
    {
        RWheelCollider.motorTorque = newMotorTorque;
        LWheelCollider.motorTorque = newMotorTorque;
    }

    public void UpdateWheelPoses()
    {
        UpdateWheelPose(RWheelCollider, RWheelTransform);
        UpdateWheelPose(LWheelCollider, LWheelTransform);
    }

    private void UpdateWheelPose(WheelCollider col, Transform trans)
    {
        Vector3 pos;
        Quaternion rot;
        
        col.GetWorldPose(out pos, out rot);

        trans.position = pos;
        trans.rotation = rot;
    }
}
