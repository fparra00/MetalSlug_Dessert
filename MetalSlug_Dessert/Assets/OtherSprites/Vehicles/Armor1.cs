using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor1 : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private BoxCollider2D Collider;

    [SerializeField] private float velocity;
    [SerializeField] private float jumpForce;
    [SerializeField] private GameObject prBullet;
    [SerializeField] private GameObject MarcoMovement;
    [SerializeField] private GameObject shootExplosion;
    [SerializeField] private Transform spotMarco;
    [SerializeField] private Transform gunPosition;


    private bool isIdleUp, isShooting, isFlying;
    private float x;


    void Start()
    {
        Animator = GetComponent<Animator>();
        Rigidbody2D = GetComponent<Rigidbody2D>();
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
        if (isShooting) shoot();
        if (isFlying) fly();
        if (isFlying && !isIdleUp) isIdleUp = true;

        //Inputs
        isShooting = Input.GetKeyDown(KeyCode.Space);
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

    private void fly()
    {
        Rigidbody2D.AddForce(Vector2.up * jumpForce);
    }
}
