using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerBaseState
{
    public PlayerIdleState(PlayerController controller) : base(controller)
    {
        controller.PlayIdleAnimation();
    }

    public override void Update(PlayerController controller)
    {
        if (Input.anyKey)
        {
            controller.currentState = new PlayerRunState(controller);
        }
    }

    public override void FixedUpdate(PlayerController controller)
    {
       
    }

    public override void OnTriggerEnter(PlayerController controller, Collider other)
    {
        
    }

    public override void OnCollisionEnter(PlayerController controller, Collision other)
    {
    
    }
}
