using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class SpinningObstacle : MonoBehaviour
{
    public bool reverse = false;

    private float multiplier = 1f;

    private void Update()
    {
        if (reverse)
        {
            multiplier = -1f;
        }
        transform.Rotate(0f, -360f*multiplier*Time.deltaTime, 0f);

    }
    
}
