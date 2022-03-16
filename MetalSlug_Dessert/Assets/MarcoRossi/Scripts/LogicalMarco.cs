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
    public static Vector2 direction;
    public static Vector2 directionAbs;
    public static Renderer renderer;


    [Header("Static bools to control actions of Marco in Another Scripts")]
    public static bool isRunning, isJumping, isGrounded, isDucking, isWalkWhileDuck, isShootingWhileDuck, isShooting, isRazing, isInVehicle;



    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
        renderer = GetComponent<Renderer>();
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = new Vector2(x * velocity, Rigidbody2D.velocity.y);
        if (isWalkWhileDuck) Rigidbody2D.velocity = new Vector2(x * velocity/2, Rigidbody2D.velocity.y);

    }

    void Update()
    {
        //Variables that need recalculation
        recalculateOrientation();
        directionAbs = new Vector2(transform.position.x, transform.position.y);


        //Checks
        isRunning = x != 0.0f && isGrounded && !isJumping && !isDucking;
        isWalkWhileDuck = isDucking && x != 0.0f;
        isShootingWhileDuck = isDucking && isShooting;

        //Inputs
        isJumping = Input.GetKeyDown(KeyCode.W) && isGrounded && !isDucking ? true : false;
        isDucking = Input.GetKey(KeyCode.S);
        isShooting = Input.GetKeyDown(KeyCode.Space) && !isInVehicle;
        isRazing = Input.GetKeyDown(KeyCode.F); 

        //Animator
        Animator.SetBool("isJumping",isJumping);
        Animator.SetBool("isRunning",isRunning);
        Animator.SetBool("isDucking", isDucking);
        Animator.SetBool("isWalkWhileDuck", isWalkWhileDuck);
        Animator.SetBool("isShooting", isShooting);
        Animator.SetBool("isShootingWhileDuck", isShootingWhileDuck);
        Animator.SetBool("isRazing", isRazing);

        //Actions
        if (isJumping) jump();
    }

    //Function to recalculate the orientation of Marco in function of his movement
    private void recalculateOrientation()
    {
        x = Input.GetAxisRaw("Horizontal");
        if (x < 0.0f) {
            transform.localScale = new Vector3(-1.2f, 1.2f, 1f);
            direction = Vector2.left;
        }
        if (x > 0.0f)
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1f);
            direction = Vector2.right;
        }
    }


    //Function to Jump
    private void jump()
    {
        Rigidbody2D.AddForce(Vector2.up * jumpForce);
    }

   
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = (collision.gameObject.CompareTag("Floor")) ? true : false;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = (collision.gameObject.CompareTag("Floor")) ? false : true;
    }
}
