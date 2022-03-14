using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalMarco : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;

    [Header("Internal Variables")]
    [Tooltip("Velocity of Marco, enter a number between 0 to 10")]
    [SerializeField] private float velocity;
    [Tooltip("Jump Force of Marco, enter a number between 0 to 50")]
    [SerializeField] private float jumpForce;
    [Tooltip("Health of Marco, enter a number between 0 to 10")]
    [SerializeField] private float health;


    private float x, y;

    [Header("Animations")]
    private bool isRunning, isJumping, isGrounded;



    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }
    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(x * velocity, Rigidbody2D.velocity.y);
    }

    void Update()
    {
        //Variables that need recalculation
        recalculateOrientation();
        isInGround();

        //Checks
        isRunning = x != 0.0f && isGrounded;
        isJumping = Input.GetKeyDown(KeyCode.W) && isGrounded ? true : false;

        //Animator
        Animator.SetBool("isJumping",isJumping);

        //Actions
        if (isJumping) jump();

    }

    //Function to recalculate the orientation of Marco in function of his movement
    private void recalculateOrientation()
    {
        x = Input.GetAxisRaw("Horizontal");
        if(x <0.0f) transform.localScale = new Vector3(-1f, 1f, 1f);
        if (x > 0.0f) transform.localScale = new Vector3(1f, 1f, 1f);
    }

    //Function to check if Marco is in the ground
    private void isInGround()
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.5f, Color.red);
        isGrounded = Physics2D.Raycast(transform.position, Vector3.down, 0.5f) ? true : false;
    }

    //Function to Jump
    private void jump()
    {
        Rigidbody2D.AddForce(Vector2.up * jumpForce);
    }
}
