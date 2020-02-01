using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    [SerializeField] string objectStateName = "None";
    [SerializeField] bool isAnimated = true;
    private Animator objectAnimator;

    // Start is called before the first frame update
    void Start()
    {
        if(isAnimated)
        {
            objectAnimator = this.gameObject.GetComponent<Animator>();
            objectAnimator.Play(objectStateName, -1, Random.Range(0.0f, 1.0f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
