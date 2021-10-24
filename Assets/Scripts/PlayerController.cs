using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField]
    private float speed = 5f;
    [SerializeField]
    private float turnSpeed = 10f;

    public bool gameOver = false;

    private Animator animator;

    private Vector3 movement = Vector3.zero;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }
    

    private void FixedUpdate()
    {
        if (!gameOver)
        {
            movement = (transform.forward * speed);
            float rotateY = Input.GetAxis("Horizontal");
            transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * turnSpeed);
        }

        else
        {
            animator.SetBool("Fall", true);
            movement = Vector3.zero;
        }
        movement.y = rb.velocity.y;
        rb.velocity = movement;
        
    }
}
