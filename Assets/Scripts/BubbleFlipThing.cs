using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleFlipThing : MonoBehaviour
{
    SpriteRenderer whale;
    SpriteRenderer thisOne;
    float x;

    // Start is called before the first frame update
    void Start()
    {
        whale = transform.parent.GetComponent<SpriteRenderer>();
        thisOne = GetComponent<SpriteRenderer>();
        x = transform.localPosition.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 localPosition = transform.localPosition;
        localPosition.x = whale.flipX ? -x : x;
        thisOne.flipX = whale.flipX;
        transform.localPosition = localPosition;
    }
}
