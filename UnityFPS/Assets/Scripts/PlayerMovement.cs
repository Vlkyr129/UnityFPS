using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    CharacterController controller;
    Vector3 velocity;
    bool isGrounded;

    [Header("Character Characteristics")]
    [SerializeField]
    float moveSpeed = 5f;
    [SerializeField]
    float gravity = -9.18f;
    [SerializeField]
    float jumpForce = 3f;

    [Header("Ground Check")]
    [SerializeField]
    Transform groundCheck;
    [SerializeField]
    float groundDistance = 0.4f;
    [SerializeField]
    LayerMask groundMask;


    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    private void FixedUpdate()
    {
        //Checks contact with ground force yo face into it
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        //Player Movement along X and Z axis
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * moveSpeed * Time.deltaTime);

        //Player Movement along the Y axis
        //Going Up
        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity);
        }
        //Going Down
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
    }
}
