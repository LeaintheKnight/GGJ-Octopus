using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    [SerializeField] private GameObject screen;
    bool isRunning = true;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isRunning)
            {
                pauseGame();
            }
            else
            {
                resumeGame();
            }
        }
    }
    public void pauseGame()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        screen.SetActive(true);
        Time.timeScale = 0f;
        isRunning = false;
        
    }

    public void resumeGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        screen.SetActive(false);
        Cursor.visible = false;
        Time.timeScale = 1f;
        isRunning = true;
        
    }

    public void goToMainMenu()
    {
        Time.timeScale = 1f;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        screen.SetActive(false);
        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
