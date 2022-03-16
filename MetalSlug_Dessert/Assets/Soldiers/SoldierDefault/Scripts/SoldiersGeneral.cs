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

    public static bool seeEnemy, isAlive;


    void Start()
    {
        Animator = GetComponent<Animator>();
        seeEnemy = false;
        isAlive = true;
    }

    void FixedUpdate()
    {
        Invoke("checkEnemy", 0.5f);
        isAlive = (health > 0) ? true : false;
        Animator.SetBool("isAlive", isAlive);

        if (!isAlive) Invoke("destroySoldier", 3f);

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

    void checkEnemy()
    {
        seeEnemy = (this.transform.position.x + -(visionRange) > LogicalMarco.directionAbs.x) ? false : true;
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
