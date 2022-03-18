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

    void Start()
    {
        //Initialize Variables
        Rigidbody2D = GetComponent<Rigidbody2D>();  
        distanceToShoot = 2.5f;
        velocity = 0.2f;
    }

    void Update()
    {
        //Recalculate
        seeEnemy();
        rotate();

        //Checks
        if (!seeMarco) lookForMarco(); 
 
    }

    //Function to Recalculate the orientation of the Enemy
    private void rotate()
    {
        Vector3 lookLeft = new Vector3(1.2f, 1.2f, 1.2f);
        Vector3 lookRight = new Vector3(-1.2f, 1.2f, 1.2f);

        if (LogicalMarco.directionAbs.x > this.transform.position.x) transform.localScale = lookRight; else transform.localScale = lookLeft;    
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

