using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMvmt : MonoBehaviour
{

    public float speed = 30f;
    Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            rb.AddForce(Vector3.left * speed);
        }
        else if (Input.GetKey("d"))
        {
            rb.AddForce(Vector3.right * speed);
        }

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(Vector3.up * speed, ForceMode.Impulse);
        }
    }
}
