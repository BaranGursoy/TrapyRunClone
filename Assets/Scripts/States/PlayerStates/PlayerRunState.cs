using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunState : PlayerBaseState
{
    public PlayerRunState(PlayerController controller) : base(controller)
    {
        controller.PlayRunAnimation();
    }

    public override void Update(PlayerController controller)
    {
        controller.movement.TouchMovement();
    }

    public override void FixedUpdate(PlayerController controller)
    {
        controller.movement.Move();
    }

    public override void OnTriggerEnter(PlayerController controller, Collider other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            controller.currentState = new PlayerFinishState(controller);
        }

        else if (other.gameObject.CompareTag("Checkpoint"))
        {
            other.gameObject.transform.GetChild(0).gameObject.SetActive(true);   // taking the hidden enemies and activating them when player
            // passes the checkpoint
        }

        else if (other.gameObject.CompareTag("Fall"))
        {
            controller.currentState = new PlayerFallState(controller);
        }
    }

    public override void OnCollisionEnter(PlayerController controller, Collision other)
    {
    }
}
