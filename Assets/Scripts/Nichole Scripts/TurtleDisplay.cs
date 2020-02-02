using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurtleDisplay : MonoBehaviour
{
    [SerializeField] private  GameObject GM;
    [SerializeField] private Image[] turtles = new Image[6];

    private void Update()
    {
        updateTurtles();
    }

    private void updateTurtles()
    {
        for (int i = 0; i < GM.GetComponent<GameManager>().babyTutrleStatus.Length; i++)
        {
            /*int j = GM.GetComponent<GameManager>().babyTutrleStatus[i];
            if (j == 0)
            {
                turtles[i].GetComponent<Image>().color = new Color(.5f, .5f, .5f, 1f);
            }
            else if (j == 1)
            {
                turtles[i].GetComponent<Image>().color = new Color(255f, 255f, 255f, 255f);
            }
            else
            {
                turtles[i].GetComponent<Image>().color = new Color(0f, 0f, 0f, 255f);
            }*/
            switch (GM.GetComponent<GameManager>().babyTutrleStatus[i])
            {
                case 0:
                    turtles[i].GetComponent<Image>().color = new Color(.5f, .5f, .5f, 0f);
                    break;
                case 1:
                    turtles[i].GetComponent<Image>().color = new Color(255, 255, 255, 255);
                    break;
                case 2:
                    turtles[i].GetComponent<Image>().color = new Color(0, 0, 0, 255);
                    break;
                default:
                    break;
            }
        }
    }


}
