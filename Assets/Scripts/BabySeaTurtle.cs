using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySeaTurtle : MonoBehaviour
{
    public int speed = 5;
    [SerializeField] private int ID; // Keep number between 0 - 5
    float timeToChangeDirection;
    Rigidbody rigidbody;
    Transform transform;

    // Update is called once per frame
    private void Start() {
                rigidbody = gameObject.GetComponent<Rigidbody>();
                transform = gameObject.GetComponent<Transform>();

    }
    public void Update () { 
        float movie = Time.deltaTime/ 10;
        transform.position = Vector3.Lerp(transform.position, transform.position + RandomVector(-5, 5), movie);
     }  
     private Vector3 RandomVector(float min, float max) {
         var x = Random.Range(min, max);
         var y = Random.Range(min, max);
         var z = Random.Range(min, max);
         return new Vector3(x, y, z);
     }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "trash"){
            GameManager.instance.turtleDied(ID);
            GetComponent<FMODUnity.StudioEventEmitter>().Play();
            Destroy(this.gameObject);
        }
        else if (other.gameObject.tag == "Player")
        {
            GameManager.instance.turtleFound(ID);
        }
    }
}
