using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Armor1 : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private BoxCollider2D Collider;

    [SerializeField] private float velocity;
    [SerializeField] private GameObject prBullet;
    [SerializeField] private GameObject MarcoMovement;
    [SerializeField] private Transform spotMarco;



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
        Invoke("rotateArmorAndMovement", 2f);
        MarcoMovement.transform.position = spotMarco.transform.position;
    }

    private void FixedUpdate()
    {

    }

    private void rotateArmorAndMovement()
    {
        if(LogicalMarco.direction==Vector2.right) transform.localScale = new Vector3(1.5f, 1.5f, 1.5f);
        if (LogicalMarco.direction == Vector2.left) transform.localScale = new Vector3(-1.5f, 1.5f, 1.5f);
        x = Input.GetAxisRaw("Horizontal");
        if (Rigidbody2D != null) Rigidbody2D.velocity = new Vector2(x * velocity, Rigidbody2D.velocity.y);



    }
}
