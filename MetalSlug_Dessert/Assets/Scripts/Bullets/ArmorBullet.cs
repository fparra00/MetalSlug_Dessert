using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmorBullet : MonoBehaviour
{

    [SerializeField] private float speed;
    [SerializeField] private float damage;

    private Rigidbody2D rb;
    private Vector2 dirBullet;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("destroyBullet", 1f);
        dirBullet = LogicalMarco.direction;
    }

    private void FixedUpdate()
    {
        rb.velocity = dirBullet * speed;
    }

    private void destroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Soldier"))
        {
            destroyBullet();
        }
    }
}