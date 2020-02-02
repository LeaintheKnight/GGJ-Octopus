using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    List<Vector3> babies = new List<Vector3>();
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
    babies.Add(new Vector3(0, -0.25f, -1));   
    babies.Add(new Vector3(0.2f, -0.25f, -1f));   
    babies.Add(new Vector3(-0.2f, -0.25f, -1f));   
    babies.Add(new Vector3(0.15f, -0.4f, -1f));   
    babies.Add(new Vector3(-0.15f, 0.4f, -1f));   

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "trash"){
            GameManager.instance.collectTrash();
        }
        if(other.gameObject.tag == "babyTurtle"){
            Destroy(other.gameObject);
            GameManager.instance.collectTurtle();
            Instantiate (prefab, transform);
            gameObject.transform.GetChild(GameManager.instance.getTurtles()).transform.localPosition = babies[GameManager.instance.getTurtles()];
            //childObject.transform.parent.position = gameObject.transform.position - new Vector3(0,0,1);
        }       
    }
}
