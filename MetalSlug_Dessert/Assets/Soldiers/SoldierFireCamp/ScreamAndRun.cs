using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamAndRun : MonoBehaviour
{
    //Components
    private Animator Animator;
    private Rigidbody2D Rigidbody2D;
    //Auxiliar Variables
    private bool screamAndRun, seeEnemy;
    private float visionRange;

    void Start()
    {
        //Initialize Components
        Animator = GetComponent<Animator>();   
        Rigidbody2D = GetComponent<Rigidbody2D>();  
        //Initialize Variables
        seeEnemy = false;
        screamAndRun = false;
        visionRange = 2f;
    }

    void Update()
    {
        //Recalculate
        checkEnemy();
        //Checks
        if(seeEnemy) screamAndRun = true;
        if (screamAndRun) run();
    }

    //Function to Run if See Marco
    private void run()
    {
        if(this.transform.position.x <0.0f) transform.localScale = new Vector3(1.2f, 1.2f, 1f);
        Rigidbody2D.velocity = new Vector2(1.7f, Rigidbody2D.velocity.y);
        Animator.SetBool("seeEnemy", true);
        Invoke("destroySoldier", 2f);
    }

    private void destroySoldier()
    {
        Destroy(gameObject);
    }

    void checkEnemy()
    {
        seeEnemy = (this.transform.position.x + -(visionRange) > LogicalMarco.directionAbs.x) ? false : true;
    }

}
