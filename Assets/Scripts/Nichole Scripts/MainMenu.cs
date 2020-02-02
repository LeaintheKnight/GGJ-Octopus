using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    public void playGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
        SceneManager.LoadScene("working Project");
    }

    public void goToCredits()
    {
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
        SceneManager.LoadScene("Credits");
    }
    public void quitGame()
    {
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
        Debug.Log("Quit");
        Application.Quit();
    }
}
