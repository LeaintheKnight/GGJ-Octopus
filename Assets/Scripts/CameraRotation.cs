using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    [SerializeField] Transform attachTo = null;
    [SerializeField] float distanceBehind = 2;
    [SerializeField] float verticalRotationLimit = 80;

    [SerializeField] float horizontalRotation = 0;
    [SerializeField] float verticalRotation = 0;

    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        transform.SetParent(attachTo);
        transform.localPosition = transform.rotation * Vector3.back * distanceBehind;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float chgX = Input.GetAxis("Mouse X");
        float chgY = Input.GetAxis("Mouse Y");

        if (chgX != 0 || chgY != 0)
        {
            horizontalRotation += chgX;
            verticalRotation -= chgY;

            verticalRotation = Mathf.Clamp(verticalRotation, -verticalRotationLimit, verticalRotationLimit);

            attachTo.eulerAngles = new Vector3(verticalRotation, horizontalRotation);
        }
    }
}
