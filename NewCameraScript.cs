using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCameraScript : MonoBehaviour
{


    public float minX = -90f;
    public float maxX = 90f;
    public float minY = -360f;
    public float maxY = 360f;
    public float sensivity;
    public float xRotation = 0;
    public float yRotation = 0;

    public Camera mainCam;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }

    // Update is called once per frame
    void Update()
    {
        yRotation += Input.GetAxis("Mouse X") * sensivity;
        xRotation -= Input.GetAxis("Mouse Y") * sensivity;

        xRotation = Mathf.Clamp(xRotation, minX, maxX);

        transform.eulerAngles = new Vector3(0, yRotation, 0);
        mainCam.transform.eulerAngles = new Vector3(xRotation, yRotation, 0);


    }
}
