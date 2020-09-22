using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarBehaviour : MonoBehaviour
{
    private Transform bar;
    
    void Start()
    {
        bar = transform.Find("Bar");
    }

    public void UpdateSize(float value)
    {
        bar.localScale = new Vector3(value, bar.localScale.y);
    }
}