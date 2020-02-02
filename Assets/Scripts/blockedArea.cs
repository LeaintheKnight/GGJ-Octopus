using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class blockedArea : MonoBehaviour
{
    [SerializeField] private int requiredTrash;
    
    private void OnCollisionEnter(Collision other) {
        if(collectedEnoughTrash() == true){
            gameObject.GetComponent<Rigidbody>().detectCollisions = false; 
        }
        else{
            GUI.Label(new Rect(50,50,100,25), string.Format("You need to clean the ocean more before you can enter here. Required trash {0}", requiredTrash));
        }
    }

    bool collectedEnoughTrash(){
        if(GameManager.instance.getTrash() == requiredTrash){
            return true;
        }
        else{
            return false;
        }
    }
}
