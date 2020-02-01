using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwimMovement : MonoBehaviour
{
    [SerializeField] Transform goToPosition;
    [SerializeField] Transform startPosition;
    [SerializeField] float moveSpeed;
    private SpriteRenderer whaleSprite;
    private bool movingFoward = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(movingFoward)
        {
            if(this.gameObject.transform.position == goToPosition.transform.position)
            {
                movingFoward = false;
                whaleSprite.flipX = true;
            }
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
    }
}
