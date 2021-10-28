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

    public LevelManager levelManager;
    private bool oogieBoogiesCanStartToRun = false;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        oogieBoogiesCanStartToRun = levelManager.hasPlayerTouchedTheScreen;
    }

    private void FixedUpdate()
    {
        if (!shouldStop && oogieBoogiesCanStartToRun)
        {
            movement = (transform.forward * speed);
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

            animator.SetBool("Jump", true);
            StartCoroutine(StoppingTimer());
        }

        if (other.gameObject.CompareTag("RotationTrigger"))
        {
            if (transform.parent.gameObject.CompareTag("SideEnemies"))
            {
                StartCoroutine(RotateTimer());
            }
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

    IEnumerator RotateTimer()
    {
        yield return new WaitForSeconds(0.5f);
        transform.rotation = Quaternion.Euler((Vector3.forward));
    }
}
