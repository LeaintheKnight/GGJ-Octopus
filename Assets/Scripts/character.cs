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
    babies.Add(new Vector3(0, -0.25f, -1).normalized);
    babies.Add(new Vector3(0.2f, -0.25f, -1f).normalized);
    babies.Add(new Vector3(-0.2f, -0.25f, -1f).normalized); 

    babies.Add(new Vector3(0,-0.4f, -1f).normalized);    
    babies.Add(new Vector3(0.2f, -0.4f, -1f).normalized);   
    babies.Add(new Vector3(-0.2f, -0.4f, -1f).normalized);   

    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "trash"){
            Destroy(other.gameObject);
            GameManager.instance.collectTrash();
        }
        if(other.gameObject.tag == "babyTurtle"){
            Destroy(other.gameObject);
            Instantiate (prefab, transform);
            gameObject.transform.GetChild(GameManager.instance.getTurtles()+1).transform.localPosition = babies[GameManager.instance.getTurtles()];
            GameManager.instance.collectTurtle();
        }       
    }
}
