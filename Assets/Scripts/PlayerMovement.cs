using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 3f;
    [SerializeField] private float rotationSpeed = 2f;
    [SerializeField] private float finishSpeed = 5f;

    private PlayerController _controller;
    private bool right;
    private bool left;
    
    private Vector3 movement = Vector3.zero;

    private void Awake()
    {
        InitComponents();
    }

    private void InitComponents()
    {
        _controller = GetComponent<PlayerController>();
    }
    
    public void TouchMovement()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Touch finger = Input.GetTouch(0);

            // RIGHT-LEFT MOVEMENT STARTED

            if (finger.deltaPosition.x > 1.0f)
            {
                right = true;
                left = false;
            }

            if (finger.deltaPosition.x < -1.0f)
            {
                right = false;
                left = true;
            }

            transform.Rotate(finger.deltaPosition.x * Vector3.up * Time.deltaTime * rotationSpeed);

            // RIGHT-LEFT MOVEMENT ENDED
        }
    }

    public void Move()
    {
        movement = (transform.forward * movementSpeed);
            
        // For playing with keyboard on play mode
        float rotateY = Input.GetAxis("Horizontal"); 
        transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * rotationSpeed);
        // Keyboard movement control is ended
            
        movement.y = _controller.rb.velocity.y; // For not to break gravity rules
        _controller.rb.velocity = movement;
    }
    
    public void JumpToTheChopper()
    {
        transform.position = Vector3.MoveTowards(transform.position, _controller.finishTarget.position, finishSpeed
            *Time.deltaTime);
    }
}
