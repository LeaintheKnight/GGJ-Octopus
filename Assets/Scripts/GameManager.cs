using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int numberOfTurtlesSaved;
    private int trashCollected;
    private int numberOfTurtlesAlive;
    private int maxNumberOfTurtles;
    private int maxTrash;
    public int[] babyTutrleStatus = new int[6]; //0 uncollected, 1 colledted, 2 dead
    public static GameManager instance;

    private void Awake() {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
//        maxNumberOfTurtles = GameObject.FindGameObjectsWithTag("babyTurtle").Length;
  //      maxTrash = GameObject.FindGameObjectsWithTag("trash").Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            turtleDied(0);
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            babyTutrleStatus[0] = 1;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            babyTutrleStatus[0] = 0;
        }
        foreach (int i in babyTutrleStatus)
        {
            Debug.Log(i);
        }

    }
    public void collectTrash() {
        trashCollected += 1;
    }
    public void collectTurtle() {
        numberOfTurtlesSaved += 1;
    }
    void gameOver() {
        //Failure
        if (numberOfTurtlesSaved == 0 && numberOfTurtlesAlive == 0 && numberOfTurtlesLeft() == 0) {

        }
        //Success
        else if (numberOfTurtlesSaved > 0 && numberOfTurtlesAlive > 0 && numberOfTurtlesLeft() == 0) {

        }
    }

    int numberOfTurtlesLeft() {
        return GameObject.FindGameObjectsWithTag("babyTurtle").Length;
    }

    //
    // The following functions are required for the UI script to display
    // the amount of trash and number of turtles correctly.
    //

    public int getTrash() // Returns the amount of trash collected
    {
        return trashCollected;
    }

    public int getTrashMax() // Returns the max amount of trash in the game
    {
        return maxTrash;
    }

    public int getTurtles() // Returns the number of turtles collected
    {
        return numberOfTurtlesSaved;
    }

    public int getTurtlesMax() // Returns the max number of turtles in the game
    {
        return maxNumberOfTurtles;
    }

    public void turtleDied(int ID) {
        babyTutrleStatus[ID] = 2;
    }

}
