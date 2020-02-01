using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMvmt : MonoBehaviour
{

    public float speed = 3.5f;
    Rigidbody rb;

    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Input.GetMouseButtonDown(0)){
            if(Physics.Raycast(ray, out hit, 100)){
                targetPosition = hit.point;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }
}
