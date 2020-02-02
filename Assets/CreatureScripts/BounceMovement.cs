using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceMovement : MonoBehaviour
{
    [SerializeField] float initialSpeed = 0.025f;
    [SerializeField] float deceleration = 0.0002f;
    [SerializeField] float descentSpeed = 0.003f;

    int delay;

    float yVel = 0;
    float initY;
    // Start is called before the first frame update
    void Start()
    {
        delay = Random.Range(0, 600);
        initY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (delay-- <= 0)
        {
            if (transform.position.y < initY)
            {
                yVel = initialSpeed * Random.Range(0.9f, 1.1f);
            }

            transform.Translate(0, yVel, 0, Space.World);
            yVel = Mathf.Max(yVel - deceleration, -descentSpeed);
        }
    }
}
