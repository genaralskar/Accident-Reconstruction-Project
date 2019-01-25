using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Speedometer : MonoBehaviour
{
    public Text text;
    public WheelCollider wc1;
    public WheelCollider wc2;
    public Rigidbody rb;


    void Update()
    {
        float mph1 = (wc1.rpm * 60) * (2 * wc1.radius * Mathf.PI) / (12*5280);
        float mph2 = (wc2.rpm * 60) * (2 * wc2.radius * Mathf.PI) / (12*5280);

        float speed = Mathf.Round(rb.velocity.magnitude * 2.2369362912f);

        text.text = "MPH: " + speed;
    }
}
