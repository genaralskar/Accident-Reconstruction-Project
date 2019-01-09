using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private float horizontalInput;
    private float verticalInput;
    private float wheelAngle;
    
    public WheelCollider frWheel;
    public WheelCollider flWheel;
    public WheelCollider brWheel;
    public WheelCollider blWheel;

    public Transform frTransform;
    public Transform flTransform;
    public Transform brTransform;
    public Transform blTransform;

    public float maxWheelAngle = 30f;
    public float torquePower = 50f;
    public float breakPower = 50f;

    public void FixedUpdate()
    {
        GetInput();
        Steer();
        Accelerate();
        UpdateWheelPoses();
    }

    private void GetInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }

    private void Steer()
    {
        wheelAngle = maxWheelAngle * horizontalInput;
        frWheel.steerAngle = wheelAngle;
        flWheel.steerAngle = wheelAngle;
    }

    private void Accelerate()
    {
        if (Input.GetButton("Brake"))
        {
          print("Braking!");
          brWheel.brakeTorque = breakPower;
          blWheel.brakeTorque = breakPower;
          frWheel.brakeTorque = breakPower;
          flWheel.brakeTorque = breakPower;
        }
        else
        {
            brWheel.brakeTorque = 0;
            blWheel.brakeTorque = 0;
            frWheel.brakeTorque = 0;
            flWheel.brakeTorque = 0;
        }
        
        brWheel.motorTorque = verticalInput * torquePower;
        blWheel.motorTorque = verticalInput * torquePower;
        
    }

    private void UpdateWheelPoses()
    {
        UpdateWheelPose(frWheel, frTransform);
        UpdateWheelPose(flWheel, flTransform);
        UpdateWheelPose(brWheel, brTransform);
        UpdateWheelPose(blWheel, blTransform);
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
