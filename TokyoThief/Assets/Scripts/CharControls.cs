﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControls : MonoBehaviour
{

    [SerializeField]
    float moveSpeed = 4f;
    float runSpeed = 4f;
    float crouchSpeed = 2f;

    public float gravity = -20.0f;
    public float jumpHeight = 3f;

    float groundSlopeLimit = 45f;
    float jumpSlopeLimit = 90f;

    public LayerMask groundMask;

    bool isCrouched = false;

    Vector3 velocity;
    Vector3 forward, right;
    Vector3 currDir;

    bool isGrounded = true;

    CharacterController controller;
    
    // Start is called before the first frame update
    void Start()
    {
        Reorient();
    }

    // Update is called once per frame
    void Update()
    {

        // How much to offset my raycasts from center of controller
        Vector3 capsuleOffset = new Vector3(controller.radius, 0, 0);

        Ray centerRay = new Ray(transform.position, -Vector3.up); // Ray down the center of controller
        Ray frontRay = new Ray(transform.position + capsuleOffset, -Vector3.up); // Ray down the outside front of controller
        Ray backRay = new Ray(transform.position - capsuleOffset, -Vector3.up); // Ray down the outside back of controller

        float rayLength = (controller.height / 2) + 0.1f; // Ray starts at middle of controller, so half the height + some extra for the skin, etc

        // Check center, front, and back to see if they are all grounded before applying gravity
        if (!Physics.Raycast(centerRay, rayLength, groundMask))
        {
            if (!Physics.Raycast(frontRay, rayLength, groundMask))
            {
                if (!Physics.Raycast(backRay, rayLength, groundMask))
                {
                    isGrounded = false;
                }
                else
                {
                    isGrounded = true;
                }
            }
            else
            {
                isGrounded = true;
            }
        }
        else
        {
            isGrounded = true;
        }



        // Debug draw my raycasts
        Debug.DrawRay(transform.position, -transform.up * rayLength, Color.white);
        Debug.DrawRay(transform.position + capsuleOffset, -transform.up * rayLength, Color.white);
        Debug.DrawRay(transform.position - capsuleOffset, -transform.up * rayLength, Color.white);

        // reset velocity if we hit the ground or ceiling
        if ((isGrounded && velocity.y <= 0) || ((controller.collisionFlags & CollisionFlags.Above) != 0))
        {
            controller.slopeLimit = groundSlopeLimit;
            velocity.y = 0f;
        }
        else if (!isGrounded)
        {
            // apply gravity
            velocity.y += gravity * Time.deltaTime;
            
        }

        controller.Move(velocity * Time.deltaTime);

        if (Input.anyKey)
        {        
            Move();
        }		
    }
	
	void Move()
	{
		Vector3 direction = new Vector3(Input.GetAxis("HorizontalKey"), 0, Input.GetAxis("VerticalKey"));
		Vector3 rightMovement = right * moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey");
		Vector3 upMovement = forward * moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey");
	
		Vector3 heading = Vector3.Normalize(rightMovement + upMovement);

        if (heading != Vector3.zero)
        {
            transform.forward = heading;
        }

        Reorient();

        //crouch
        if (Input.GetKeyDown(KeyCode.LeftControl) && isGrounded == true)
        {
            if (isCrouched == false)
            {
                transform.localScale -= new Vector3(0, 0.5F, 0);
                isCrouched = true;
                moveSpeed = crouchSpeed;
                controller.center = new Vector3(0, 0.8f, 0);
            }
            else
            {
                transform.localScale -= new Vector3(0, -0.5F, 0);
                isCrouched = false;
                moveSpeed = runSpeed;
                controller.center = new Vector3(0, 0.15f, 0);
            }
        }

        //jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            controller.slopeLimit = jumpSlopeLimit;
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // horizontal movement
        heading *= moveSpeed;
        controller.Move(heading * Time.deltaTime);
	}

    void Reorient()
    {
        if (currDir != Camera.main.transform.forward)
        {
            forward = Camera.main.transform.forward;
            currDir = Camera.main.transform.forward;
            forward.y = 0;
            forward = Vector3.Normalize(forward);
            right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
            controller = GetComponent<CharacterController>();
        }
    }

}
