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
        screen.SetActive(true);
        Time.timeScale = 0f;
        isRunning = false;
    }

    public void resumeGame()
    {
        screen.SetActive(false);
        Time.timeScale = 1f;
        isRunning = true;
    }

    public void goToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
