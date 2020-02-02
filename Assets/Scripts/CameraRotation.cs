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
        transform.localPosition = Vector3.back * distanceBehind;
        transform.localRotation = Quaternion.identity;
        horizontalRotation = transform.eulerAngles.y;
        verticalRotation = transform.eulerAngles.x;
    }

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.fog = true;
        RenderSettings.fogMode = FogMode.Exponential;
        RenderSettings.fogDensity = 0.1f;
        RenderSettings.fogColor = new Color(0.1f, 0.3f, 0.4f, 1.0f);
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

            RaycastHit hit;

            if (Physics.Raycast(attachTo.position, attachTo.rotation * Vector3.back, out hit, distanceBehind, 1 << 8, QueryTriggerInteraction.UseGlobal))
            {
                transform.localPosition = Vector3.back * hit.distance;
            }
            else
            {
                transform.localPosition = Vector3.back * distanceBehind;
            }
        }
    }
}
