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

    private void Start()
    {
        offset = camTransform.position - target.position;
    }

    private void LateUpdate()
    {
        // update position
        Vector3 targetPosition = target.position + offset;
        camTransform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, 0f);
        
    }
}