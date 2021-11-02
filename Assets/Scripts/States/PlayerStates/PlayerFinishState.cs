using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinishState : PlayerBaseState
{
    public PlayerFinishState(PlayerController controller) : base(controller)
    {
        controller.PlayJumpAnimation();
        controller.OnFinishEvent();
    }

    public override void Update(PlayerController controller)
    {
        controller.movement.JumpToTheChopper();
    }

    public override void FixedUpdate(PlayerController controller)
    {
    }

    public override void OnTriggerEnter(PlayerController controller, Collider other)
    {
    }

    public override void OnCollisionEnter(PlayerController controller, Collision other)
    {
        if (other.gameObject.CompareTag("Chopper"))
        {
            controller.OnChopperEvent(other.transform);
        }
    }
}
