using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodController : MonoBehaviour
{
    [SerializeField]
    private BoxCollider wall;

    private void OnCollisionEnter(Collision other)
    {
        wall.enabled = false;
    }

    private void OnCollisionExit(Collision other)
    {
        wall.enabled = true;
    }
}
