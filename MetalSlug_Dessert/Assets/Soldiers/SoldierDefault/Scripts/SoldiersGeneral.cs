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
    public bool hitWithKnife;


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
        Animator.SetBool("isAlive", isAlive);


        if (hitWithKnife)
        {
            health = 0;
            Animator.SetBool("dieKnife", true);
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


    public void jeje()
    {

    }
}
