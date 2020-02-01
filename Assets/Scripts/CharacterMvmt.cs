using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMvmt : MonoBehaviour
{

    public float speed = 3.5f;
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
            rb.AddForce(new Vector3(-1, 0, 0) * speed);
        }
        else if (Input.GetKey("d"))
        {
            rb.AddForce(new Vector3(1, 0, 0) * speed);
        }

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(new Vector3(0, 1, 0) * speed, ForceMode.Impulse);
        }
    }
}
