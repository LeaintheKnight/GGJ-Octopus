using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySeaTurtle : MonoBehaviour
{
    public int speed = 5;
    [SerializeField] private int ID; // Keep number between 0 - 5

    void Move(){
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "trash"){
            GameManager.instance.turtleDied(ID);
            Destroy(this);
        }
    }
    int getID(){
        return ID;
    }
}
