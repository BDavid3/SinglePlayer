using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float sens = 20f;
    public Transform target;
    public float height = 2f;
    public float distance = 3f;
    public LayerMask collisionMask;

    public float yaw;
    public float pitch;

    private void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * sens;
        pitch -= Input.GetAxis("Mouse Y") * sens;
        pitch = Mathf.Clamp(pitch, -30f, 60f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 desiredOffset = rotation * new Vector3(0f, 0f, -distance);
        Vector3 desiredPosition = target.position + desiredOffset;
        
        RaycastHit hit;
        if (Physics.Raycast(target.position, desiredOffset.normalized, out hit, distance, collisionMask))
        {
            // Wall detected, place camera just in front of the hit point
            transform.position = hit.point + hit.normal * 0.2f;
        }
        else
        {
            transform.position = desiredPosition;
        }
        
        transform.LookAt(target);
    }
}