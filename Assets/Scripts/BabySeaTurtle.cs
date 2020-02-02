using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySeaTurtle : MonoBehaviour
{
    public int speed = 5;
    [SerializeField] private int ID; // Keep number between 0 - 5

    private void Update() {
        //Move();
    }

    void Move(){
       gameObject.GetComponent<Rigidbody>().position -= Vector3.forward * speed * Time.deltaTime;
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
