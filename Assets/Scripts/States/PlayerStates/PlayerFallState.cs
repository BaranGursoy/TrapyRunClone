using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerBaseState
{
    public PlayerFallState(PlayerController controller) : base(controller)
    {
        controller.PlayFallAnimation();
        controller.OnFallEvent();
    }

    public override void Update(PlayerController controller)
    {
        
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
