using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMvmt : MonoBehaviour
{
    public Camera cam;
    int distance = 5;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        if (Input.GetKey(KeyCode.W)){
            transform.position = transform.position + Camera.main.transform.forward * distance * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.A)){
            transform.position = transform.position - Camera.main.transform.right * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.S)){
            transform.position = transform.position - Camera.main.transform.forward * distance * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.D)){
            transform.position = transform.position + Camera.main.transform.right * Time.deltaTime;
        }
        else if(Input.GetKey(KeyCode.Space)){
            transform.position = transform.position + new Vector3(0,1,0).normalized;
        }
    }
}
