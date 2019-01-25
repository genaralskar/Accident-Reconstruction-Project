using System.Collections;
using System.Collections.Generic;
using BansheeGz.BGSpline.Components;
using UnityEngine;

public class MoveCarWaypoint : MonoBehaviour
{

    public BGCcTrs curveMove;
    public BGCcCursor cursor;
    public float moveAmount = 1;

    private void Awake()
    {
        if (curveMove != null)
        {
            curveMove.Speed = 0.01f;
            curveMove.Speed = 0;
        }
    }

    private void Update()
    {
        if (cursor != null)
        {
            if (cursor.DistanceRatio == 1)
            {
                cursor.DistanceRatio = 0;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (curveMove != null)
        {
            curveMove.Speed = moveAmount;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (curveMove != null)
        {
            curveMove.Speed = 0;    
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (cursor != null)
        {
            cursor.Distance += moveAmount * Time.deltaTime;
        }
    }
}
