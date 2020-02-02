using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMvmt : MonoBehaviour
{
    [SerializeField] int distance = 5;
    [SerializeField] float upSpeed;

    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
    }

    void Move(){
        if (Input.GetKey(KeyCode.W)){
            rb.position += Camera.main.transform.forward * distance * Time.fixedDeltaTime;
        }
        if(Input.GetKey(KeyCode.A)){
            rb.position -= Camera.main.transform.right * Time.fixedDeltaTime;
        }
        if(Input.GetKey(KeyCode.S)){
            rb.position -= Camera.main.transform.forward * distance * Time.fixedDeltaTime;
        }
        if(Input.GetKey(KeyCode.D)){
            rb.position += Camera.main.transform.right * Time.fixedDeltaTime;
        }
        if(Input.GetKey(KeyCode.Space)){
            rb.position += Vector3.up.normalized * Time.fixedDeltaTime;
        }
        if(Input.GetKey(KeyCode.LeftShift))
        {
            rb.position -= Vector3.up.normalized * Time.fixedDeltaTime;
        }
    }
}
