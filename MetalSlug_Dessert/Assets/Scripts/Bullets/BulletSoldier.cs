using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSoldier : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private Rigidbody2D rb;
    private Vector2 dirBullet;
    

    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        Invoke("destroyBullet", 1f);
    }

    private void FixedUpdate()
    {
        if (LogicalMarco.directionAbs.x > this.transform.position.x) dirBullet = Vector2.right; else dirBullet = Vector2.left;
        rb.velocity = dirBullet * speed;
    }

    private void destroyBullet()
    {
        Destroy(gameObject);
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            destroyBullet();
        }
    }
}
