using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicidalTurtles : MonoBehaviour
{
    [SerializeField] float waitTimeMin = 2.5f;
    [SerializeField] float waitTimeMax = 7.5f;
    [SerializeField] float minSpeed = 5;
    [SerializeField] float maxSpeed = 10;

    Rigidbody rb;
    [SerializeField] float wait;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        wait = Random.Range(waitTimeMin, waitTimeMax);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        wait -= Time.fixedDeltaTime;

        if (wait <= 0)
        {
            rb.velocity = Random.onUnitSphere * Random.Range(minSpeed, maxSpeed);
            wait += Random.Range(waitTimeMin, waitTimeMax);
        }
    }
}
