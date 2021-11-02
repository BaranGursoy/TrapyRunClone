using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterAnimation : MonoBehaviour
{
   [SerializeField] private float rotationSpeed = 180f;
   public Transform upperPart;
   public Transform backPart;
   
   public Transform chopperFinishPoint;

   private float chopperSpeed = 5f;

   private void SignUpEvents()
   {
      PlayerController.PlayerChopperEvent += OnPlayerInChopper;
   }

   private void OnPlayerInChopper()
   {
      StartCoroutine(ChopperMovement());
   }

   private IEnumerator ChopperMovement()
   {
      while (true)
      {
         transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(-80f, 90f,transform.rotation.z), 1f);
         transform.position = Vector3.MoveTowards(transform.position, chopperFinishPoint.position,
            chopperSpeed * Time.deltaTime);
         yield return null;
      }
   }

   private void Start()
   {
      SignUpEvents();
   }

   private void Update()
   {
      upperPart.Rotate(Vector3.forward, rotationSpeed*Time.deltaTime, Space.Self);
      backPart.Rotate(Vector3.right, rotationSpeed*Time.deltaTime, Space.Self);
   }
}
