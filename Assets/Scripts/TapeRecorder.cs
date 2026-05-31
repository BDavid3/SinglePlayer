using UnityEngine;


public class TapeRecorder : MonoBehaviour
{
    private Outline _outline;
    public GameObject canvas;
    public AudioSource audioSource;
    
    public GameObject player;
    public GameObject cam;
    
    private PlayerMovementScript _movementScript;
    private RotateCamera _cameraScript;

    private bool _isInMenu;

    void Start()
    {
        _outline = GetComponent<Outline>();
        
        _movementScript = player.GetComponent<PlayerMovementScript>();
        _cameraScript = cam.GetComponent<RotateCamera>();
    }

    void Update()
    {
        if (_outline.enabled && Input.GetKeyDown(KeyCode.E))
        {
            _isInMenu = !_isInMenu;

            Cursor.lockState = _isInMenu ? CursorLockMode.None : CursorLockMode.Locked;
            Cursor.visible = _isInMenu;

            canvas.SetActive(_isInMenu);

            _movementScript.enabled = !_isInMenu;
            _cameraScript.enabled = !_isInMenu;
         
            if (!_isInMenu)
            {
                audioSource.Stop();
            }
            
        }
    }

    public void StarterAudio()
    {
        audioSource.Play();
    }
}
