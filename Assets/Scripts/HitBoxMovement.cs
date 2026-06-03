using UnityEngine;

public class HitBoxMovement : MonoBehaviour
{
    private PlayerAndCameraMovement _playerAndCameraMovement;

    private void Update()
    {
        Quaternion targetRotation = Quaternion.Euler(_playerAndCameraMovement.pitch, _playerAndCameraMovement.yaw, 0f);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 10f);
    }
    
}
