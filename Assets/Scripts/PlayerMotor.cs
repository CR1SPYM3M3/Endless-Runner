using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotor : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 moveVector;
    private float gravity = 25.0f;
    private float jumpForce = 10.0f;

    private float speed = 7.5f;
    private float verticalVelocity = 0.0f;
	void Start () {
        controller = GetComponent<CharacterController>();
	}
	
	
	void Update () {
        moveVector = Vector3.zero;

        if (controller.isGrounded)
        {
            verticalVelocity = -gravity * Time.deltaTime;
            if(Input.GetKeyDown(KeyCode.Space))
            {
                verticalVelocity = jumpForce;
            }
        }
        else
        {
            verticalVelocity -= gravity * Time.deltaTime;
        }
       
        //X - L R
        moveVector.x = Input.GetAxisRaw("Horizontal") * speed;
        //Y - U D
        moveVector.y = verticalVelocity;
        //Z - F B
        moveVector.z = speed;
        controller.Move (moveVector * Time.deltaTime);
	}
}
