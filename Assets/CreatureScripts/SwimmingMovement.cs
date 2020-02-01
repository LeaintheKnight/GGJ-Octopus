using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimmingMovement : MonoBehaviour
{
    [SerializeField] Transform goToPosition;
    [SerializeField] Transform startPosition;
    [SerializeField] float moveSpeed;
    private SpriteRenderer whaleSprite;
    private bool movingFoward = true;
    Vector3 previousPosition;

    private void Awake()
    {
        whaleSprite = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingFoward)
        {
            if (this.gameObject.transform.position == goToPosition.transform.position)
            {
                movingFoward = false;
            }
            else
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, goToPosition.transform.position, moveSpeed);
        }
        else
        {
            if(this.gameObject.transform.position == startPosition.transform.position)
            {
                movingFoward = true;
            }
            this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, startPosition.transform.position, moveSpeed);
        }

        if (whaleSprite != null && transform.position != previousPosition)
        {
            whaleSprite.flipX = Vector3.Cross(Camera.main.transform.rotation * Vector3.forward, transform.position - previousPosition).y < 0;
            previousPosition = transform.position;
        }
    }
}
