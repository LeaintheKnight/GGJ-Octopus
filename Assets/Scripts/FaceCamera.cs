using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] string objectStateName = "None";
    [SerializeField] bool isAnimated = true;
    [SerializeField] bool randomizeZRotation = false;
    private Animator objectAnimator;

    Quaternion zRot = Quaternion.identity;

    void Awake()
    {
        enabled = false;
    }

    // Start is called before the first frame update
    void Start()
    {
        if (isAnimated)
        {
            objectAnimator = this.gameObject.GetComponent<Animator>();
            if (objectAnimator != null)
            {
                objectAnimator.Play(objectStateName, -1, Random.Range(0.0f, 1.0f));
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation * zRot;
    }

    void OnBecameVisible()
    {
        enabled = true;

        if (randomizeZRotation)
        {
            zRot = Quaternion.Euler(0, 0, Random.Range(0, 360f));
        }
        else
        {
            zRot = Quaternion.identity;
        }
    }

    void OnBecameInvisible()
    {
        enabled = false;
    }
}
