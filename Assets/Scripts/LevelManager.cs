using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [NonSerialized]
    public bool hasPlayerTouchedTheScreen = false;

    [SerializeField]
    private Canvas canvas;

    private void Update()
    {
        if (Input.anyKey)
        {
            canvas.enabled = false;
            hasPlayerTouchedTheScreen = true;
        }
    }
}
