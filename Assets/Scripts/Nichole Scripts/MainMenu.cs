using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void playGame()
    {
        Debug.Log("Play");
        //SceneManager.LoadScene();
    }

    public void goToCredits()
    {
        SceneManager.LoadScene("Credits");
    }
    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
