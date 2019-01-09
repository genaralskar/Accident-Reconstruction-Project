using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCenterOfMass : MonoBehaviour
{
    public Rigidbody rb;
    
    private void Awake()
    {
        rb.centerOfMass = transform.localPosition;
    }
}
