using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMvmt : MonoBehaviour
{

    public float speed = 3.5f;
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("a"))
        {
            rb.AddForce(new Vector2(-1, 0) * speed);
        }
        else if (Input.GetKey("d"))
        {
            rb.AddForce(new Vector3(1, 0) * speed);
        }

        if (Input.GetKeyDown("space"))
        {
            rb.AddForce(new Vector3(0, 1) * speed, ForceMode2D.Impulse);
        }
    }
}
