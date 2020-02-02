using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WavyMovement : MonoBehaviour
{
    [SerializeField] float amplitude = 0.1f;
    [SerializeField] float frequency = 0.2f;

    float time = 0;
    float initY = 0;
    // Start is called before the first frame update
    void Start()
    {
        initY = transform.position.y;
        time = Random.Range(0, 360f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 position = transform.position;
        position.y = initY + Mathf.Sin(time * Mathf.Deg2Rad) * amplitude;
        transform.position = position;
        time += Time.deltaTime * frequency * 360;
    }
}
