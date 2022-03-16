using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiersGeneral : MonoBehaviour
{
    [SerializeField] private float visionRange;
    [SerializeField] private float health;
    [SerializeField] private GameObject bloodPrefab;
    [SerializeField] private Transform bloodSpot;

    private Animator Animator;

    public static bool seeEnemy, isAlive, hitWithKnife;


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
        if (!isAlive) Invoke("destroySoldier", 2f);


        if (hitWithKnife)
        {
            health = 0;
            Die(2);
        }
    }


    void checkEnemy()
    {
        seeEnemy = (this.transform.position.x + -(visionRange) > LogicalMarco.directionAbs.x) ? false : true;
    }

    void Die(int opc)
    {
        switch (opc)
        {
            //Opc1: Die with normal Bullet
            case 1:
                Debug.Log("Muerte por disparo");
                Animator.SetBool("dieRegularBullet", true);
                break;
            //Opc2: Die with a Knife
            case 2:
                Debug.Log("Muerte por cuchillo");
                break;
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("regularBullet")){
            health--;
            bleeding();
            if (health==0) Die(1);
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
