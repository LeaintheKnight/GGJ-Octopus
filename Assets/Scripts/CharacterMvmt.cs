using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMvmt : MonoBehaviour
{
    [SerializeField] int distance = 5;
    [SerializeField] float upSpeed;
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
            transform.position += Camera.main.transform.forward * distance * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.A)){
            transform.position -= Camera.main.transform.right * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.S)){
            transform.position -= Camera.main.transform.forward * distance * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.D)){
            transform.position += Camera.main.transform.right * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.Space)){
            transform.position += Vector3.up.normalized * Time.deltaTime;
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            transform.position -= Vector3.up.normalized * Time.deltaTime;
        }
    }
}
