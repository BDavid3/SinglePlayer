using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class StarterScript : MonoBehaviour
{
    [SerializeField] private GameObject canvas;
    [SerializeField] private ExplosionScript explosionScript;
    private Image _image;

    void Awake()
    {
        Outline[] outlines = FindObjectsByType<Outline>(FindObjectsSortMode.None);
        
        foreach (Outline outline in outlines)
        {
            outline.enabled = false;
        }
        
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        
        canvas.SetActive(true);
        _image = canvas.GetComponentInChildren<Image>();
        
        explosionScript.enabled = false;
    }

    private void Start()
    {
        StartCoroutine(Fade());
    }

    IEnumerator Fade()
    {
        Color color = _image.color;
        
        while (color.a > 0f)
        {
            color.a -= 0.001f;
            _image.color = color;
            yield return null;
        }
    }
}
