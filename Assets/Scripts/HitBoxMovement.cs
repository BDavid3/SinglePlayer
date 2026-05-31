using UnityEngine;

public class HitBoxMovement : MonoBehaviour
{
    public RotateCamera rotateCamera;

    private void Update()
    {
        Quaternion targetRotation = Quaternion.Euler(rotateCamera.pitch, rotateCamera.yaw, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
    }
    
}
