using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamAndRun : MonoBehaviour
{
    private Animator Animator;
    private Rigidbody2D Rigidbody2D;
    private bool screamAndRun;

    void Start()
    {
        Animator = GetComponent<Animator>();   
        Rigidbody2D = GetComponent<Rigidbody2D>();  
    }

    void Update()
    {
        //Checks
        if(SoldiersGeneral.seeEnemy) screamAndRun = true;
        if (screamAndRun) run();
    }

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
}
