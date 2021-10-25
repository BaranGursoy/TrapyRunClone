using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelicopterAnimation : MonoBehaviour
{
   public Transform upperPart;
   public Transform backPart;

   private void Update()
   {
      upperPart.Rotate(Vector3.forward, 180f*Time.deltaTime, Space.Self);
      backPart.Rotate(Vector3.right, 180f*Time.deltaTime, Space.Self);
   }
}
