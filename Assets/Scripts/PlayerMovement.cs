using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float sens = 5f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private Transform cam; 
    private Rigidbody _rb;
    private float _yaw;
    private float _pitch;
    private Vector3 _movement;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        _yaw += Input.GetAxis("Mouse X") * sens;
        _pitch -=  Input.GetAxis("Mouse Y") * sens;
        _pitch = Mathf.Clamp(_pitch, -90, 90);
        
        transform.rotation = Quaternion.Euler(0f, _yaw, 0f);
        cam.localRotation = Quaternion.Euler(_pitch, 0f, 0f);
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        
        _movement = (transform.forward * vertical + transform.right * horizontal).normalized;
    }
    
    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * (moveSpeed * Time.fixedDeltaTime));
    }
    
}
