using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor1 : MonoBehaviour
{
    //Components
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private CapsuleCollider2D Collider;

    //Internal
    [SerializeField] private float velocity;
    [SerializeField] private GameObject prBullet;
    [SerializeField] private GameObject MarcoMovement;
    [SerializeField] private GameObject shootExplosion;
    [SerializeField] private Transform spotMarco;
    [SerializeField] private Transform gunPosition;

    //Auxiliar Variables
    private bool isIdleUp, isShooting, isFlying, exitVehicle, isGrounded, isAlive;
    private float x,y;
    public static int health;

    void Start()
    {
        //Initialize Variables
        Animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Collider = GetComponent<CapsuleCollider2D>();
        health = 3;
        Animator.SetBool("enterToArmor", true);
        LogicalMarco.isInVehicle = true;    
    }

    void Update()
    {
        //Recalculate
        Invoke("rotateArmorAndMovement", 2f);
        MarcoMovement.transform.position = spotMarco.transform.position;

        //Checks
        isIdleUp = (x == 0.0f) ? true : false;
        isAlive = (health > 0) ? true : false;
        if (isShooting) shoot();
        if (isFlying) fly();
        if (isFlying && !isIdleUp) isIdleUp = true;
        if (isFlying && !isIdleUp) isFlying=true;
        if (exitVehicle && isGrounded) exitArmor();

        //Inputs
        isShooting = Input.GetKeyDown(KeyCode.Space);
        exitVehicle = Input.GetKeyDown(KeyCode.E);
        isFlying = Input.GetKey(KeyCode.W);

        //Animator
        Animator.SetBool("isIdle", isIdleUp);
        Animator.SetBool("isFlying", isFlying);
        }


    //Function to Recalculate the Movement and the Orientation of the Armor
    private void rotateArmorAndMovement()
    {
        if(LogicalMarco.direction==Vector2.right) transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        if (LogicalMarco.direction == Vector2.left) transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);

        x = Input.GetAxisRaw("Horizontal");
        if (Rigidbody2D != null) Rigidbody2D.velocity = new Vector2(x * velocity, Rigidbody2D.velocity.y);
    }

    //Function to Shoot projectiles
    private void shoot()
    {
        Instantiate(shootExplosion, gunPosition.position,Quaternion.identity);
        Instantiate(prBullet, gunPosition.position, gunPosition.rotation);
    }

    //Function to Exit the Armor
    private void exitArmor()
    {

        Animator.SetBool("exitVehicle", exitVehicle);
        LogicalMarco.isInVehicle = false;
        Destroy(Rigidbody2D);
        MarcoMovement.transform.position = this.transform.position;
        spotMarco.transform.position = new Vector3(spotMarco.transform.position.x+1f, spotMarco.transform.position.y + 0.30f, spotMarco.transform.position.z);
        MarcoMovement.transform.position = spotMarco.transform.position;

        Invoke("destroyArmor", 2f);
    }

    //onCollisionEnter
    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = (collision.gameObject.CompareTag("Floor")) ? true : false;
    }

    //onExitEnter
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = (collision.gameObject.CompareTag("Floor")) ? false : true;
    }

    //Function to Destroy the Armor
    private void destroyArmor()
    {
        LogicalMarco.renderer.enabled = true;
        Destroy(gameObject);

    }

    //Function to Fly
    private void fly()
    {
        Rigidbody2D.AddForce(Vector2.up * 1.1f);
    }
}
