using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 500f;

    private float mouseX;
    private float mouseY;
    private float xRotation = 0f;
    private Transform playerBody;
    // Start is called before the first frame update
    void Start()
    {
        playerBody = transform.parent.transform;
        Cursor.lockState = CursorLockMode.Locked; //Cursor stays in the middle of the screen
    }

    // Update is called once per frame
    void Update()
    {
        MouseInput();
        BodyRotation();
    }
    private void MouseInput()
    {
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
    }
    private void BodyRotation()
    {
        //Rotation of X
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //You can't rotate around by looking up or down
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);


        //Rotation of Y
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
