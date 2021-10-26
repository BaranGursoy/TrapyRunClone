using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // follow object
    public Transform target;
   
    //camera transform
    public Transform camTransform;
   
    // offset between camera and target
    public Vector3 offset;

    // This value will change at the runtime depending on target movement. Initialize with zero vector.
    private Vector3 velocity = Vector3.zero;

    public PlayerController playerController;
    
    private void Start()
    {
        offset = camTransform.position - target.position;
    }
    

    private void LateUpdate()
    {
        // update position
        if (!playerController.finished)
        {
            Vector3 targetPosition = target.position + offset;
            camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0f);
            
            float cameraY = Mathf.Clamp(transform.position.y, -12f, 4.4f); // camera height restrictions in case of we're falling
            camTransform.position = new Vector3(camTransform.position.x, cameraY, camTransform.position.z);
        }
        else
        {
            //transform.rotation = Quaternion.Lerp(Quaternion.identity, Quaternion.Euler(0f, 0f,0f), 1f);
            transform.LookAt(playerController.gameObject.transform);
        }
    }
}