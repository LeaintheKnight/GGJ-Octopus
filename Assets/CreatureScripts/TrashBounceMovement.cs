using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashBounceMovement : MonoBehaviour
{
    [SerializeField] float initialSpeed = 1.25f;
    [SerializeField] float deceleration = 0.01f;
    [SerializeField] float descentSpeed = 0.15f;

    float yVel = 0;
    float initY;

    Rigidbody rb;

    void Awake()
    {
        enabled = false;
        rb = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        initY = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y < initY)
        {
            yVel = initialSpeed * Random.Range(0.9f, 1.1f);
        }

        rb.position += Vector3.up * yVel * Time.fixedDeltaTime;
        yVel = Mathf.Max(yVel - deceleration, -descentSpeed);
    }

    void OnBecameVisible()
    {
        enabled = true;
    }

    void OnBecameInvisible()
    {
        enabled = false;
    }
}
