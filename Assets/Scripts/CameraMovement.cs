using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    private float mouseX;
    private float mouseY;

    public float mouseSenseX;
    public float mouseSenseY;

    private Transform pers;

    private float camRot = 0;

    private void Start()
    {
        pers = transform.parent;
        Cursor.lockState = CursorLockMode.Locked;
    }



    private void Update()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSenseX * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSenseY * Time.deltaTime;

        camRot -= mouseY;

        camRot = Mathf.Clamp(camRot, -90, 90);

        transform.localRotation = Quaternion.Euler(camRot, 0, 0);

        pers.Rotate(Vector3.up * mouseX);
    }
}
