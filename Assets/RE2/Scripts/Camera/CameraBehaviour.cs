using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    public Transform player, target;
    public float rotateSpeed = 3f;
    float x, y;

    private float addFOV = 15f;
    private float sensitivity = 10f;
    float initFOV;
    float FOV;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        initFOV = Camera.main.fieldOfView;
        FOV = Camera.main.fieldOfView;
    }

    void LateUpdate()
    {
        //Rotation horizontale
        x += Input.GetAxis("Mouse X") * rotateSpeed;

        //Rotation verticale
        y -= Input.GetAxis("Mouse Y") * rotateSpeed;
        y = Mathf.Clamp(y, -35, 60);

        transform.LookAt(target);
        target.rotation = Quaternion.Euler(y, x, 0);

        if (Input.GetButtonDown("Escape"))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

        if(Input.GetButton("Aim"))
        {
            FOV += addFOV * sensitivity;
            Camera.main.fieldOfView = FOV;
        }

        if (Input.GetButtonUp("Aim"))
        {
            Camera.main.fieldOfView = initFOV;
            FOV = initFOV;
        }
    }
}
