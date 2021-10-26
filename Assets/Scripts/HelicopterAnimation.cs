using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterAnimation : MonoBehaviour
{
   public Transform upperPart;
   public Transform backPart;

   public PlayerController playerController;
   public Transform chopperFinishPoint;

   private float chopperSpeed = 5f;
   
   private void Update()
   {
      upperPart.Rotate(Vector3.forward, 180f*Time.deltaTime, Space.Self);
      backPart.Rotate(Vector3.right, 180f*Time.deltaTime, Space.Self);

      if (playerController.isPlayerOnTheChopper)
      {
         transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-80f, 90f,transform.rotation.z), 1f);
         transform.position = Vector3.MoveTowards(transform.position, chopperFinishPoint.position,
            chopperSpeed * Time.deltaTime);
      }
   }
}
