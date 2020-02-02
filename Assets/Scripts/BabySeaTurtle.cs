using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabySeaTurtle : MonoBehaviour
{
    public int speed = 5;
    private void Update() {
        
    } 

    void Move(){
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "trash"){
            GameManager.instance.turtleDied();
            Destroy(this);
        }
    }
}
