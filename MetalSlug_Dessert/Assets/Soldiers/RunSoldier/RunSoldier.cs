using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSoldier : MonoBehaviour
{
    //Internal Variables
    public static bool seeMarco;
    private float distanceToShoot, velocity;
    //Components
    private Rigidbody2D Rigidbody2D;
    private Animator animator;  
    //Static Variables
    private SoldierGunScript SoldierGunScript;

    void Start()
    {
        //Initialize Variables
        Rigidbody2D = GetComponent<Rigidbody2D>();
        SoldierGunScript = gameObject.GetComponent<SoldierGunScript>();
        animator = GetComponent<Animator>();    
        distanceToShoot = 2f;
        velocity = 0.2f;
    }

    void Update()
    {
        //Recalculate
        seeEnemy();

        //Checks
        if (!seeMarco) lookForMarco(); 
        if(!SoldiersGeneral.isAlive) SoldierGunScript.enabled = false;
        //Animator
        animator.SetBool("shoot", seeMarco);
    }



    //Function that detect if Marco is close
    private void seeEnemy()
    {
        seeMarco = (this.transform.position.x + -(distanceToShoot) > LogicalMarco.directionAbs.x) ? false : true;
    }

    //Function to pursue Marco
    private void lookForMarco()
    {
        Rigidbody2D.velocity = new Vector2(LogicalMarco.directionAbs.x * velocity, Rigidbody2D.velocity.y);
    }

}

