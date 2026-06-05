using UnityEngine;

public class StarterScript : MonoBehaviour
{
    private TypeEffect _telephoneScript;

    void Awake()
    {
        Outline[] outlines = FindObjectsByType<Outline>(FindObjectsSortMode.None);
        
        foreach (Outline outline in outlines)
        {
            outline.enabled = false;
        }

        _telephoneScript = FindAnyObjectByType<TypeEffect>(FindObjectsInactive.Include);
        _telephoneScript.enabled = false;
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        
    }
}
