using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashWavyMovement : MonoBehaviour
{
    [SerializeField] float amplitude = 0.15f;
    [SerializeField] float frequency = 0.3f;

    float time = 0;
    float initY = 0;

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
        time = Random.Range(0, 360f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 position = rb.position;
        position.y = initY + Mathf.Sin(time * Mathf.Deg2Rad) * amplitude;
        rb.position = position;
        time += Time.fixedDeltaTime * frequency * 360;
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
