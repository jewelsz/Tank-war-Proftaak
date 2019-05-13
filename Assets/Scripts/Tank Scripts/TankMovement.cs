using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankMovement : MonoBehaviour
{
    private  float movementSpeed;
    private float rotationSpeed;
    private bool goingForward;

    private void Start()
    {
        movementSpeed = 5f;
        rotationSpeed = 50f;
    }

    private void Update()
    {
        //Moving forward and backward
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            goingForward = true;
            transform.position += transform.forward * Time.deltaTime * movementSpeed;
        }
        else if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position -= transform.forward * Time.deltaTime * movementSpeed;
            goingForward = false;
        }
       
        if(goingForward)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            }
        }
        if(!goingForward)
        {
            if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
            }
            else if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
            {
                transform.Rotate(-Vector3.up * rotationSpeed * Time.deltaTime);
            }
        }
        
    }
}
