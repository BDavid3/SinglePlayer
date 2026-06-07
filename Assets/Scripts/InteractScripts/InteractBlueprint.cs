using System;
using UnityEngine;

public abstract class InteractBlueprint : MonoBehaviour
{
    [SerializeField] private Outline outlineScript;
    [SerializeField] protected GameObject canvas;
    [SerializeField] private PlayerMovement playerMovementScript;
    protected bool IsInteract;
    protected bool isLocked;
    private bool _isInRange;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Collider"))
        {
            outlineScript.enabled = true;
            _isInRange = true;
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Collider"))
        {
            outlineScript.enabled = false;   
            _isInRange = false;
        }
    }

    void Update()
    {
        if (_isInRange && Input.GetKeyDown(KeyCode.E) && !isLocked)
        {
            IsInteract = !IsInteract;
            // Set True
         
            playerMovementScript.enabled = !IsInteract;
            Cursor.visible = IsInteract;
            Cursor.lockState =  IsInteract ? CursorLockMode.None : CursorLockMode.Locked;
            canvas.SetActive(IsInteract);
            
            OnInteract();
        }
    }
    protected abstract void OnInteract();
}
