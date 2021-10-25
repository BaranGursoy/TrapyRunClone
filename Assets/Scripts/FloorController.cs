using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorController : MonoBehaviour
{
    private Color lerpedColor = Color.white;

    private MeshRenderer mr;
    private Rigidbody rb;

    private bool lerpColor = false;

    [SerializeField]
    private float duration = 0.5f;

    private float t = 0f;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        mr = GetComponentInChildren<MeshRenderer>();
        mr.materials[0].color = Color.white;
    }

    private void Update()
    {
        if (lerpColor)
        {
            t += Time.deltaTime / duration;
            
            mr.materials[0].color = lerpedColor;
            lerpedColor = Color.Lerp(Color.white, Color.red, t);
            StartCoroutine(StartFloorFall());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            lerpColor = true;
        }
    }

    IEnumerator StartFloorFall()
    {
        yield return new WaitForSeconds(0.5f);
        rb.isKinematic = false;
        rb.useGravity = true;
    }
}
