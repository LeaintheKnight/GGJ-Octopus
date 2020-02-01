using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIDisplay : MonoBehaviour
{
    [SerializeField] private GameObject GM;
    [SerializeField] private TextMeshProUGUI trashDisplay;
    [SerializeField] private TextMeshProUGUI turtleDisplay;

    private static int maxTurtles;
    private static int maxTrash;

    /*
     * Game Manager Requirements:
     * 
     * public int getTrash() -> Returns the amount of trash collected
     * public int getTrashMax() -> Returns the max amount of trash in the game
     * public int getTurtles() -> Returns the number of turtles collected
     * public int getTurtlesMax() -> Returns the max number of turtles in the game
     * 
     * */

    private void Awake()
    {
        maxTurtles = GM.GetComponent<GameManager>().getTurtlesMax();
        maxTrash = GM.GetComponent<GameManager>().getTrashMax();
    }

    private void Update()
    {
        trashDisplay.text = GM.GetComponent<GameManager>().getTrash() + " / " + maxTrash;
        turtleDisplay.text = GM.GetComponent<GameManager>().getTurtles() + " / " + maxTurtles;
    }

}

