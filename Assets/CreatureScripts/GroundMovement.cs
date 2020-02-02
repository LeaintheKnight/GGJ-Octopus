using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    [SerializeField] Transform goTo;
    private Vector3 startPosition;
    private Vector3 goToPosition;
    [SerializeField] float moveSpeed;

    [SerializeField] float yOffset;

    private SpriteRenderer whaleSprite;
    private bool movingFoward = true;
    Vector3 previousPosition;

    Vector3 referencePoint;

    private void Awake()
    {
        whaleSprite = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    void Start()
    {
        startPosition = previousPosition = referencePoint = transform.position;
        goToPosition = goTo.position;
        Destroy(goTo);
    }

    // Update is called once per frame
    void Update()
    {
        if (movingFoward)
        {
            if (referencePoint == goToPosition)
            {
                movingFoward = false;
            }
            else
                referencePoint = Vector3.MoveTowards(referencePoint, goToPosition, moveSpeed);
        }
        else
        {
            if (referencePoint == startPosition)
            {
                movingFoward = true;
            }
            referencePoint = Vector3.MoveTowards(referencePoint, startPosition, moveSpeed);
        }

        if (whaleSprite != null && referencePoint != previousPosition)
        {
            whaleSprite.flipX = Vector3.Cross(Camera.main.transform.rotation * Vector3.forward, referencePoint - previousPosition).y < 0;
            previousPosition = referencePoint;
        }

        RaycastHit hit;

        if (Physics.Raycast(referencePoint, Vector3.down, out hit, Mathf.Infinity, 1 << 8, QueryTriggerInteraction.UseGlobal))
        {
            transform.position = hit.point + Vector3.up * yOffset;
        }
    }
}
