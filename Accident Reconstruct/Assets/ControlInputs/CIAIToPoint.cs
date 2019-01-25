using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

[CreateAssetMenu(menuName = "ControlInputs/AI To Point")]
public class CIAIToPoint : ControlInputs
{
    public override void GetInputs(CarController cc)
    {
        //get direction
        Vector3 direction = cc.transform.InverseTransformPoint(cc.carWaypoint.position);

        //do something to find proper steer angle
        float input = Mathf.Clamp(direction.x, -1, 1);
        cc.horizontalInput = input;
        cc.verticalInput = 1;
    }
}
