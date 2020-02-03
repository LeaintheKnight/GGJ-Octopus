using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endGame : MonoBehaviour
{
    private void OnCollisionEnter(Collision other) {
        if(GameManager.instance.victory == true){
            gameObject.GetComponent<Rigidbody>().detectCollisions = false; 
        }
        else{
            GUI.Label(new Rect(50,50,100,25), "You cant leave yet you need to save all your babies!");
        }
    }
}
