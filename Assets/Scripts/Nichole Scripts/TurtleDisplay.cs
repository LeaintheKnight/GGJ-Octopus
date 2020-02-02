using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtleDisplay : MonoBehaviour
{
    [SerializeField] private  GameObject GM;
    [SerializeField] private Image[] turtles = new Image[6];
    [SerializeField] private Sprite babyTurtle;

    private void Update()
    {
        updateTurtles();
    }

    private void updateTurtles()
    {
        for (int i = 0; i < GM.GetComponent<GameManager>().babyTutrleStatus.Length; i++)
        {
            turtles[i].GetComponent<Image>().sprite = babyTurtle;
            turtles[i].transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            switch (GM.GetComponent<GameManager>().babyTutrleStatus[i])
            {
                case 0:
                    turtles[i].GetComponent<Image>().color = new Color(.5f, .5f, .5f, 0f);
                    break;
                case 1:
                    turtles[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    break;
                case 2:
                    turtles[i].GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    turtles[i].transform.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
                    break;
                default:
                    break;
            }
        }
    }


}
