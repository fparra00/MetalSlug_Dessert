using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private GameObject prExplosion;


    private Rigidbody2D rb;
    private Vector2 dirBullet;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            destroyBullet();
            Vector3 floorExpl = new Vector3(transform.position.x, transform.position.y + 0.1f, -0.47f);
            Instantiate(prExplosion, floorExpl, Quaternion.identity);
        }

        if (other.CompareTag("FloorTrigger"))
        {
           
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision != null)
        {

        }
    }
}
