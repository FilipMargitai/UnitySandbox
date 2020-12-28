using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundCheckDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;

    private float x;
    private float z;
    private CharacterController controller;
    private Vector3 move;
    private Vector3 velocity;
    private bool isGrounded;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        KeyboardInput();
        BodyMovement();
    }
    private void KeyboardInput()
    {
        x = Input.GetAxis("Horizontal");
        z = Input.GetAxis("Vertical");
    }
    private void BodyMovement()
    {
        //GroundCheck and velocity check
        isGrounded = Physics.CheckSphere(groundCheck.position, groundCheckDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f; //Should be zero but Brackeys recomends some small negative number
        }

        //Jump
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        //movement
        move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        //gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
