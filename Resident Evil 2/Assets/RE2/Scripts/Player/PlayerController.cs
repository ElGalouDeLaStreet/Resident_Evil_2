using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float movementSpeed;
    public float turningSpeed = 3;
    float x;
    float y;

    public bool run;

    void Update()
    {
        x = Input.GetAxis("Horizontal") * turningSpeed;
        transform.Rotate(0, x, 0);

        y = Input.GetAxis("Vertical") * movementSpeed * Time.deltaTime;
        transform.Translate(0, 0, y);

        run = Input.GetButton("Run");
        if (run)
        {
            movementSpeed = 10f;
        } else
        {
            movementSpeed = 8f;
        }
    }
}
