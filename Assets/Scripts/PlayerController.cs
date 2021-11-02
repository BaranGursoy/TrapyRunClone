using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [HideInInspector] public PlayerBaseState currentState;

    [HideInInspector] public static Action PlayerFallEvent;
    [HideInInspector] public static Action PlayerChopperEvent;
    [HideInInspector] public static Action PlayerFinishEvent;
    
    [HideInInspector] public Rigidbody rb;
    [HideInInspector] public Animator animator;
    [HideInInspector] public PlayerMovement movement;
    
    [SerializeField] public Transform finishTarget;

    private static readonly int Fall = Animator.StringToHash("Fall");
    private static readonly int Run = Animator.StringToHash("Run");
    private static readonly int Idle = Animator.StringToHash("Idle");
    private static readonly int Jump = Animator.StringToHash("Jump");
    private static readonly int Dance = Animator.StringToHash("Dance");

    private void Awake()
    {
        InitComponents();
    }

    private void Start()
    {
        currentState = new PlayerIdleState(this);
    }

    private void Update()
    {
       currentState.Update(this);
    }

    private void FixedUpdate()
    {
        currentState.FixedUpdate(this);
    }

    private void OnDestroy()
    {
        PlayerChopperEvent = null;
        PlayerFallEvent = null;
        PlayerFinishEvent = null;
    }

    private void OnTriggerEnter(Collider other)
    {
        currentState.OnTriggerEnter(this, other);
    }

    private void OnCollisionEnter(Collision other)
    {
        currentState.OnCollisionEnter(this, other);
    }

    public void OnChopperEvent(Transform other)
    {
        transform.Rotate(0f, 180f, 0f);
        animator.Play(Dance);
        transform.SetParent(other.gameObject.transform); // For player to move with helicopter with the ending dance animation
        PlayerChopperEvent?.Invoke();
    }

    public void OnFinishEvent()
    {
        PlayerFinishEvent?.Invoke();
    }

    public void OnFallEvent()
    {
        PlayerFallEvent?.Invoke();
    }
    
    private void InitComponents()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        movement = GetComponent<PlayerMovement>();
    }

    public void PlayIdleAnimation()
    {
        animator.Play(Idle);
    }
    
    public void PlayRunAnimation()
    {
        animator.Play(Run);
    }
    
    public void PlayFallAnimation()
    {
        animator.Play(Fall);
    }
    
    public void PlayJumpAnimation()
    {
        animator.Play(Jump);
    }
    
    public void PlayDanceAnimation()
    {
        animator.Play(Dance);
    }
    
}
