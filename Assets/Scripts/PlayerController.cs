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
    
    public Transform chopper;
    
    private float jumpToChopperSpeed = 5f;

    private Animator animator;

    private Vector3 movement = Vector3.zero;

    // For level states
    [NonSerialized]
    public bool gameOver = false;
    [NonSerialized]
    public bool finished = false;
    [NonSerialized]
    public bool isPlayerOnTheChopper = false;
    // Level states variables ended
    
    public LevelManager levelManager;
    private bool playerCanStartTheGame = false;
    
    // FOR TOUCH CONTROL
    private bool right;
    private bool left;
    // TOUCH CONTROL VARIABLES ENDED
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (finished && !gameOver)
        {
            // Jumping movement to helicopter
            transform.position = Vector3.MoveTowards(transform.position, chopper.position, jumpToChopperSpeed*Time.deltaTime);
        }

        TouchMovement();
        
        playerCanStartTheGame = levelManager.hasPlayerTouchedTheScreen; // Did the user make the first touch?
    }

    private void FixedUpdate()
    {
        if (!gameOver && !finished && playerCanStartTheGame)
        {
            animator.SetBool("StartGame", true);
            movement = (transform.forward * speed);
            
            // For playing with keyboard on play mode
            float rotateY = Input.GetAxis("Horizontal"); 
            transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * turnSpeed);
            // Keyboard movement control is ended
        }

        else if(gameOver)
        {
            animator.SetBool("Fall", true);
            movement = Vector3.zero;
        }

        movement.y = rb.velocity.y; // For not to break gravity rules
        rb.velocity = movement;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            finished = true;
            movement = Vector3.zero;
            animator.SetBool("Jump", true);
        }

        if (other.gameObject.CompareTag("Checkpoint"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);   // taking the hidden enemies and activating them when player
                                                                                // passes the checkpoint
        }

        if (other.gameObject.CompareTag("Fall"))
        {
            gameOver = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Chopper"))
        {
            transform.Rotate(0f, 180f, 0f);
            animator.SetBool("Dance", true);
            transform.SetParent(other.gameObject.transform); // For player to move with helicopter with the ending dance animation
            isPlayerOnTheChopper = true;
        }
    }
    
    private void TouchMovement()
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

            transform.Rotate(finger.deltaPosition.x * Vector3.up * Time.deltaTime * turnSpeed);

            // RIGHT-LEFT MOVEMENT ENDED
        }
    }
}
