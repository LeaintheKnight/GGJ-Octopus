using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicidalTurtles : MonoBehaviour
{
    [SerializeField] float waitTimeMin = 5;
    [SerializeField] float waitTimeMax = 10;
    [SerializeField] float minSpeed = 1;
    [SerializeField] float maxSpeed = 5;

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
