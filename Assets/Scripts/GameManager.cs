using UnityEngine;

public class GameManager : MonoBehaviour
{
    int numberOfTurtlesSaved;
    int trashCollected;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void collectTrash(){

    }
    void gameOver(){

    }

    void numberOfTurtlesLeft(){

    }

    //
    // The following functions are required for the UI script to display
    // the amount of trash and number of turtles correctly.
    //

    public int getTrash() // Returns the amount of trash collected
    {
        return 0;
    }

    public int getTrashMax() // Returns the max amount of trash in the game
    {
        return 0;
    }

    public int getTurtles() // Returns the number of turtles collected
    {
        return 0;
    }

    public int getTurtlesMax() // Returns the max number of turtles in the game
    {
        return 0;
    }
}
