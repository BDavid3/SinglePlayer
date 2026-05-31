using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    
    public GameObject player;
    public GameObject cam;
    
    private PlayerMovementScript _movementScript;
    private RotateCamera _cameraScript;
    
    void Start()
    { 
        _movementScript = player.GetComponent<PlayerMovementScript>();
        _cameraScript = cam.GetComponent<RotateCamera>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !pauseMenu.activeInHierarchy)
        {
            pauseMenu.SetActive(true);
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            
            _movementScript.enabled = false;
            _cameraScript.enabled = false;
        }
    }
    
    public void Resume()
    {
        pauseMenu.SetActive(false);
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
            
        _movementScript.enabled = true;
        _cameraScript.enabled = true;
    }

    public void MainMenu()
    {
        pauseMenu.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        SceneManager.LoadScene("MainMenuScene");
    }
}
