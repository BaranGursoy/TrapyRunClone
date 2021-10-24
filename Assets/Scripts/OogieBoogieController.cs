using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OogieBoogieController : MonoBehaviour
{
    private Rigidbody rb;

    private Animator animator;

    private bool shouldStop = false;

    private Vector3 movement = Vector3.zero;

    public PlayerController playerController;
    
    [SerializeField]
    private float speed = 3f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        if (!shouldStop)
        {
            movement = (Vector3.forward * speed);
        }
        else
        {
            movement = Vector3.zero;
        }
        movement.y = rb.velocity.y;
        rb.velocity = movement;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.LookAt(other.gameObject.transform);
            rb.AddForce(transform.forward * 100f);
            
            //transform.LookAt(other.gameObject.transform);
            //transform.position = Vector3.MoveTowards(transform.position, other.gameObject.transform.position, speed * Time.deltaTime);
            
            animator.SetBool("Jump", true);
            StartCoroutine(StoppingTimer());
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            playerController.gameOver = true;
        }
    }

    IEnumerator StoppingTimer()
    {
        yield return new WaitForSeconds(0.6f);
        shouldStop = true;
    }
}
