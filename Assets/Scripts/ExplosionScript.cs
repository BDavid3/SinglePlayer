using System;
using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ExplosionScript : MonoBehaviour
{
    [SerializeField] private Transform telephoneTransform;
    [SerializeField] private PlayerMovement playerMovementScript;
    [SerializeField] private Rigidbody playerRigidbody;
    [SerializeField] private float explosionForce = 100f;
    [SerializeField] private float explosionRadius = 100f;
    [SerializeField] private ParticleSystem explosionEffect;
    [SerializeField] private Image image;
    [SerializeField] private GameObject endCanvas;
    
    
    private AudioSource _audioSource;
    private Outline _outline;
    private TextMeshProUGUI _text;

    void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
        _outline = telephoneTransform.gameObject.GetComponent<Outline>();
        _text = endCanvas.GetComponentInChildren<TextMeshProUGUI>();
    }

    public void Explode()
    {
        playerMovementScript.enabled = false;
        playerRigidbody.constraints = RigidbodyConstraints.None;
        
        _outline.enabled = false;
        
        playerRigidbody.AddExplosionForce(explosionForce,telephoneTransform.position,explosionRadius);
        
        _audioSource.Play();
        explosionEffect.Play();
        
        StartCoroutine(Fade());
        StartCoroutine(EndScene());

    }
    
    IEnumerator Fade()
    {
        Color color  = image.color;
        color.a = 0f;
        while (color.a <= 1f)
        {
            color.a += 0.001f;
            image.color = color;
            yield return null;
        }
    }

    IEnumerator EndScene()
    {
        Color textColor = _text.color;
        
        yield return new WaitForSeconds(5f);
        endCanvas.SetActive(true);
        
        while (textColor.a >= 0f)
        {
            textColor.a -= 0.001f;
            _text.color = textColor;
            yield return null;
        }
        SceneManager.LoadScene("MainMenuScene");

    }
}


