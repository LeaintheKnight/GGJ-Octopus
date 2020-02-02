using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingMovementButBetter : MonoBehaviour
{
    [SerializeField] Transform[] goTo;
    private Vector3 startPosition;
    private Vector3[] goToPosition;
    [SerializeField] float moveSpeed;
    
    private SpriteRenderer whaleSprite;
    private int movePoint = 1;
    Vector3 previousPosition;

    [SerializeField] bool flipX;

    private void Awake()
    {
        whaleSprite = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        goToPosition = new Vector3[1 + goTo.Length];
        goToPosition[0] = previousPosition = transform.position;

        for (int i = 0; i < goTo.Length; i++)
        {
            goToPosition[i + 1] = goTo[i].position;
            Destroy(goTo[i]);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position == goToPosition[movePoint])
        {
            movePoint = (movePoint + 1) % goToPosition.Length;
        }
        transform.position = Vector3.MoveTowards(transform.position, goToPosition[movePoint], moveSpeed);

        if (whaleSprite != null && transform.position != previousPosition)
        {
            whaleSprite.flipX = flipX ^ Vector3.Cross(Camera.main.transform.rotation * Vector3.forward, transform.position - previousPosition).y < 0;
            previousPosition = transform.position;
        }
    }
}
