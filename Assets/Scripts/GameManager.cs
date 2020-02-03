using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private int numberOfTurtlesSaved;
    private int trashCollected;
    private int numberOfTurtlesAlive;
    private int maxNumberOfTurtles;
    private int maxTrash;
    public bool victory {
        get
        {
            return GetSaved() + GetDied() == babyTutrleStatus.Length;
        }
    }
    public int[] babyTutrleStatus = new int[6]; //0 uncollected, 1 colledted, 2 dead
    public static GameManager instance;

    int saved = 0;
    int died = 0;

    private void Awake() {
        if (instance == null)
            instance = this;
        else
            Destroy(this);
    }


    // Start is called before the first frame update
    void Start()
    {
        maxNumberOfTurtles = GameObject.FindGameObjectsWithTag("babyTurtle").Length;
        maxTrash = GameObject.FindGameObjectsWithTag("trash").Length;
    }

    // Update is called once per frame
    void Update()
    { 
        //gameOver();
    }
    public void collectTrash() {
        trashCollected += 1;
    }
    public void collectTurtle() {
        GetComponent<FMODUnity.StudioEventEmitter>().Play();
        numberOfTurtlesSaved += 1;
    }
    void gameOver() {
        //Failure
        if (numberOfTurtlesSaved == 0 && numberOfTurtlesAlive == 0 && numberOfTurtlesLeft() == 0)
        {
            SceneManager.LoadScene("Game Over");
        }
        //Success
        else if (numberOfTurtlesSaved > 0 && numberOfTurtlesAlive > 0 && numberOfTurtlesLeft() == 0) {
            //victory = true;
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

    public int GetSaved()
    {
        return saved;
    }

    public int GetDied()
    {
        return died;
    }

    public void turtleDied(int ID)
    {
        died++;

        if (died == 6)
        {
            SceneManager.LoadScene("GameOver");
        }
        babyTutrleStatus[ID] = 2;
    }

    public void turtleFound(int ID)
    {
        saved++;

        babyTutrleStatus[ID] = 1;
    }

}
