using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PlayerBaseState
{
   protected PlayerBaseState(PlayerController controller) {}

   public abstract void Update(PlayerController controller);
   
   public abstract void FixedUpdate(PlayerController controller);
   
   public abstract void OnTriggerEnter(PlayerController controller, Collider other);
   
   public abstract void OnCollisionEnter(PlayerController controller, Collision other);
}
