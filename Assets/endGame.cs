using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class endGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log(GameManager.instance.victory);
            if (GameManager.instance.victory)
            {
                Debug.Log("Touch");
                SceneManager.LoadScene("Victory");

            }
            else
            {
                //GUI.Label(new Rect(50,50,100,25), "You cant leave yet you need to save all your babies!");
            }
        }
    }
}
