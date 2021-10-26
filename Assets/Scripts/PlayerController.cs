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
    
    private float jumpTpChopperSpeed = 5f;

    private Animator animator;

    private Vector3 movement = Vector3.zero;

    [NonSerialized]
    public bool gameOver = false;
    [NonSerialized]
    public bool finished = false;
    [NonSerialized]
    public bool isPlayerOnTheChopper = false;

    public LevelManager levelManager;
    private bool playerCanStartTheGame = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (finished && !gameOver)
        {
            transform.position = Vector3.MoveTowards(transform.position, chopper.position, jumpTpChopperSpeed*Time.deltaTime);
        }

        playerCanStartTheGame = levelManager.hasPlayerTouchedTheScreen;
    }

    private void FixedUpdate()
    {
        if (!gameOver && !finished && playerCanStartTheGame)
        {
            movement = (transform.forward * speed);
            float rotateY = Input.GetAxis("Horizontal");
            transform.Rotate(Input.GetAxis("Horizontal") * Vector3.up * turnSpeed);
        }

        else if(gameOver)
        {
            animator.SetBool("Fall", true);
            movement = Vector3.zero;
        }

        movement.y = rb.velocity.y;
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
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Chopper"))
        {
            transform.Rotate(0f, 180f, 0f);
            animator.SetBool("Dance", true);
            transform.SetParent(other.gameObject.transform);
            isPlayerOnTheChopper = true;
        }
    }
}
