using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class character : MonoBehaviour
{
    List<GameObject> babies = new List<GameObject>();
    public GameObject prefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "trash"){
            GameManager.instance.collectTrash();
        }
        if(other.gameObject.tag == "babyTurtle"){
            GameManager.instance.collectTurtle();
            babies.Add(gameObject);
            Instantiate (prefab, transform);
            //childObject.transform.parent.position = gameObject.transform.position - new Vector3(0,0,1);
        }    
    }
}
