using UnityEngine;
using Cursor = UnityEngine.Cursor;

public class PlayerMovementScript : MonoBehaviour
{
    public float speed = 3f;
    public Rigidbody rb;
    public Transform cam;
    public Vector3 movement;
    
    void Start()
    {
        // Set cursor settings
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    
    void Update()
    {
        // h, v  contains x,y
        
        float  h = Input.GetAxis("Horizontal"); // x
        float v = Input.GetAxis("Vertical"); // y

        // vector 3 = x,y,z 
        // forward is a static property: 0,0,forward  -> back is 0,0,-forward
        // left is -right,0,0 -> right is +  
        
        Vector3 camForward = cam.forward; // blue axis perhaps forward?
        Vector3 camRight = cam.right; // red axis perhaps right? 
        
        camForward.y = 0f;
        camRight.y = 0f;
        
        // normalize magnitude of the current vector 1
        
        camForward.Normalize();
        camRight.Normalize();
        
        movement = (camForward * v + camRight * h);
        
        
    }
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * (speed * Time.fixedDeltaTime));
    }
    
}
