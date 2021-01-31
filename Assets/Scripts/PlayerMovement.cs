using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public CharacterController characterController;
    public float speed = 12f;
    public float jumpHeight = 3f;

    public float gravity = -9.81f;
    private Vector3 gravitationalVelocity;

    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    private bool isGrounded;
    
    // Update is called once per frame
    void Update() {

        // check whether it has landed on an object
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && gravitationalVelocity.y < 0)
            gravitationalVelocity.y = -2f; // reset the velocity (not 0 as sometimes it bugs out)
        

        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");

        // take the relative player transforms and multiply them with the input to move relative to the players rotation
        Vector3 move = transform.right * x + transform.forward * y;
        
        // multiply speed by delta time to enure frame rate does not affect speed
        characterController.Move(move * (speed * Time.deltaTime));

        if (Input.GetButtonDown("Jump") && isGrounded)
            gravitationalVelocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        
        // 
        gravitationalVelocity.y += gravity * Time.deltaTime;
        characterController.Move(gravitationalVelocity * Time.deltaTime);
    }
}