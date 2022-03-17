using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor1 : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private CapsuleCollider2D Collider;

    [SerializeField] private float velocity;
    [SerializeField] private GameObject prBullet;
    [SerializeField] private GameObject MarcoMovement;
    [SerializeField] private GameObject shootExplosion;
    [SerializeField] private Transform spotMarco;
    [SerializeField] private Transform gunPosition;


    private bool isIdleUp, isShooting, isFlying, exitVehicle, isGrounded;
    private float x,y;

    void Start()
    {
        Animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Collider = GetComponent<CapsuleCollider2D>(); 
        Animator.SetBool("enterToArmor", true);
        LogicalMarco.isInVehicle = true;    
    }

    void Update()
    {
        //Recalculate
        Invoke("rotateArmorAndMovement", 2f);

        //Checks
        isIdleUp = (x == 0.0f) ? true : false;
        if (isShooting) shoot();
        if (isFlying) fly();
        if (isFlying && !isIdleUp) isIdleUp = true;
        if (exitVehicle && isGrounded) exitArmor();
        if(!LogicalMarco.isInVehicle) MarcoMovement.transform.position = spotMarco.transform.position;


        //Inputs
        isShooting = Input.GetKeyDown(KeyCode.Space);
        exitVehicle = Input.GetKeyDown(KeyCode.E);
        isFlying = Input.GetKey(KeyCode.W);

        //Animator
        Animator.SetBool("isIdle", isIdleUp);
        Animator.SetBool("isFlying", isFlying);
        }



    private void rotateArmorAndMovement()
    {
        if(LogicalMarco.direction==Vector2.right) transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        if (LogicalMarco.direction == Vector2.left) transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);

        x = Input.GetAxisRaw("Horizontal");
        if (Rigidbody2D != null) Rigidbody2D.velocity = new Vector2(x * velocity, Rigidbody2D.velocity.y);
    }

    private void shoot()
    {
        Instantiate(shootExplosion, gunPosition.position,Quaternion.identity);
        Instantiate(prBullet, gunPosition.position, gunPosition.rotation);
    }

    private void exitArmor()
    {
        Animator.SetBool("exitVehicle", exitVehicle);
        LogicalMarco.isInVehicle = false;
        Destroy(Rigidbody2D);
        MarcoMovement.transform.position = this.transform.position;
        spotMarco.transform.position = new Vector3(spotMarco.transform.position.x+1f, spotMarco.transform.position.y + 0.30f, spotMarco.transform.position.z);

        Invoke("destroyArmor", 2f);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = (collision.gameObject.CompareTag("Floor")) ? true : false;
    }


    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = (collision.gameObject.CompareTag("Floor")) ? false : true;
    }


    private void destroyArmor()
    {
        LogicalMarco.renderer.enabled = true;
        Destroy(gameObject);
    }



    private void fly()
    {
        Rigidbody2D.AddForce(Vector2.up * 1.1f);
    }
}
