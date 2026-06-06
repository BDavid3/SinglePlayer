using UnityEngine;

public class PlayerAndCameraMovement : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Transform cam;
    private Vector3 _movement;
    
    [SerializeField] private float sens;
    [SerializeField] private float distance = 3f;
    [SerializeField] private LayerMask collisionMask;
    public float yaw;
    public float pitch;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float  horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical"); 
        
        Vector3 camForward = cam.forward; 
        Vector3 camRight = cam.right; 
        
        camForward.y = 0f;
        camRight.y = 0f;
        
        _movement = (camForward * vertical + camRight * horizontal).normalized;
        
    }
    
    void LateUpdate()
    {
        yaw += Input.GetAxis("Mouse X") * sens;
        pitch -= Input.GetAxis("Mouse Y") * sens;
        pitch = Mathf.Clamp(pitch, -20f, 60f);

        Quaternion rotation = Quaternion.Euler(pitch, yaw, 0f);
        Vector3 desiredOffset = rotation * new Vector3(0f, 0f, -distance);
        Vector3 desiredPosition = transform.position + desiredOffset;
        
        RaycastHit hit;
        if (Physics.Raycast(transform.position, desiredOffset.normalized, out hit, distance, collisionMask))
        {
            cam.position = hit.point + hit.normal * 0.3f;
        }
        else
        {
            cam.position = desiredPosition;
        }
        
        cam.LookAt(transform);
    }
    
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movement * (speed * Time.fixedDeltaTime));
    }
    
    // Update is frame dependent, FixedUpdate is not. 
    
}
