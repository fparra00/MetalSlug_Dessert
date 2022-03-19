using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiersGeneral : MonoBehaviour
{
    [SerializeField] private float visionRange;
    [SerializeField] private  float health;
    [SerializeField] private GameObject bloodPrefab;
    [SerializeField] private Transform bloodSpot;

    private Animator Animator;
    private Rigidbody2D Rigidbody2D;
    private CapsuleCollider2D capsuleCollider;

    public static bool seeEnemy, isAlive;


    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        capsuleCollider = GetComponent<CapsuleCollider2D>();    
        Animator = GetComponent<Animator>();
        seeEnemy = false;
        isAlive = true;
    }

    void FixedUpdate()
    {
        //Recalculate
        rotate();
        checkEnemy();

        //Checks
        isAlive = (health > 0) ? true : false;
        if (!isAlive) die();

        //Animations
        Animator.SetBool("isAlive", isAlive);

    }


    public void hit(int opc)
    {
        switch (opc)
        {
            //Case 1: Hit with Knife
            case 1:
                health = 0;
                Animator.SetBool("dieKnife", true);
                break;
            //Case 2: Hit with Armor Bullet
            case 2:
                health = 0;
                Animator.SetBool("dieArmorBullet", true);
                break;
        }
    }

    private void die()
    {
       Destroy(Rigidbody2D);
       Invoke("destroySoldier", 3f);
       Destroy(capsuleCollider);
    }

    void checkEnemy()
    {
        seeEnemy = (this.transform.position.x + -(visionRange) > LogicalMarco.directionAbs.x) ? false : true;
    }

    //Function to Recalculate the orientation of the Enemy
    private void rotate()
    {
        if (LogicalMarco.directionAbs.x > this.transform.position.x)
        {
            transform.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
        }
        else
        {
            transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("regularBullet")){
            health--;
            bleeding();
            if (health==0) Animator.SetBool("dieRegularBullet", true);
        }
    }

    private void bleeding()
    {
        Instantiate(bloodPrefab, bloodSpot.position, bloodSpot.rotation);
    }

   private void destroySoldier()
    {
        Destroy(gameObject);
    }
}
