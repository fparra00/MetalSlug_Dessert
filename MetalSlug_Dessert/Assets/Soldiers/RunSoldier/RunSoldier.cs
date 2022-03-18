using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunSoldier : MonoBehaviour
{
    private bool seeMarco;
    private float distanceToShoot, velocity;
   

    private Rigidbody2D Rigidbody2D;

    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();  
        distanceToShoot = 2.5f;
        velocity = 0.2f;
    }

    void Update()
    {
        //Recalculate
        seeEnemy();

        //Checks
        if (!seeMarco) lookForMarco();

        
    }

    private void seeEnemy()
    {
        seeMarco = (this.transform.position.x + -(distanceToShoot) > LogicalMarco.directionAbs.x) ? false : true;
    }

    private void lookForMarco()
    {
        Rigidbody2D.velocity = new Vector2(LogicalMarco.directionAbs.x * velocity, Rigidbody2D.velocity.y);

    }
}

