using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turtleTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag == "Player"){
            GameObject []turtles =  GameObject.FindGameObjectsWithTag("babyTurtle");
        }
    }
}
