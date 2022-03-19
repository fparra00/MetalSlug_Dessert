using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSoldier : MonoBehaviour
{
    //Internal Variables
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    //Components
    private Rigidbody2D rb;
    private Vector2 dirBullet;
    

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        Invoke("destroyBullet", 1f);
    }

    private void FixedUpdate()
    {
        //Recalculate the Direction and Speed of the Bullet
        if (LogicalMarco.directionAbs.x > this.transform.position.x) dirBullet = Vector2.right; else dirBullet = Vector2.left;
        rb.velocity = dirBullet * speed;
    }

    //Function to Destroy the Bullet
    private void destroyBullet()
    {
        Destroy(gameObject);
    }


    //onTriggerEnter
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If Collision with Marco
        if (collision.CompareTag("Player"))
        {
            destroyBullet();
        }
        //If Collision with Armor type1
        if (collision.CompareTag("Armor"))
        {
            Armor1.health--;
        }
    }
}
