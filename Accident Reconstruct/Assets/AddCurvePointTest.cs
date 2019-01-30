using System.Collections;
using System.Collections.Generic;
using BansheeGz.BGSpline.Curve;
using UnityEngine;
using UnityEngine.Events;

public class AddCurvePointTest : MonoBehaviour
{
    public BGCurve curve;
    public GameObject pointPrefab;

    public UnityEvent Event;

    private void Update()
    {
        RaycastHit hit;
        Ray ray;
        if (Camera.main != null && Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                curve.AddPoint(new BGCurvePoint(curve, hit.point));
            }
        }
        
        
    }

    public void InvokeEvent()
    {
        Event.Invoke();
    }

    public void OnMouseDown()
    {
        InvokeEvent();
    }

    public void CreatePoint(Transform location)
    {
        GameObject newPoint = Instantiate(pointPrefab, location);
        newPoint.AddComponent<BGCurvePointGO>();
    }
    
    public void AddPoint(Transform position)
    {
        curve.AddPoint(new BGCurvePoint(curve, position.position));
    }
}
