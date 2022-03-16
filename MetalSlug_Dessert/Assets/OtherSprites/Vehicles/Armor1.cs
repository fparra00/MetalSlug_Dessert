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


    private bool isIdleUp, isShooting, isFlying, exitVehicle;
    private float x;


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
        MarcoMovement.transform.position = spotMarco.transform.position;

        //Checks
        isIdleUp = (x == 0.0f) ? true : false;
        if (isShooting) shoot();
        if (isFlying) fly();
        if (isFlying && !isIdleUp) isIdleUp = true;
        if (exitVehicle) exitArmor();

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
        Destroy(Collider);
        this.enabled = false;
        LogicalMarco.renderer.enabled = true;
        LogicalMarco.isInVehicle = false;
        Vector3 e = new Vector3(-5f, 1f, -0.47f);
        Destroy(Rigidbody2D);
        MarcoMovement.transform.position = e;
 
    }

    private void fly()
    {
        Rigidbody2D.AddForce(Vector2.up * 1.5f);
    }
}
