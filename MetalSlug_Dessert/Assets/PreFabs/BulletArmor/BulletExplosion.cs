using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletExplosion : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private float explosionRadio;
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

    private void explosion()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(this.transform.position, explosionRadio);
        foreach (Collider2D collision in collisions)
        {
            if (collision.CompareTag("Soldier"))
            {
                collision.gameObject.GetComponent<SoldiersGeneral>().hit(2);
            }
        }

        Vector3 floorExpl = new Vector3(transform.position.x, transform.position.y + 0.1f, -1f);
        Instantiate(prExplosion, floorExpl, Quaternion.identity);
        destroyBullet();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            explosion();
        }
    }

   

    private void destroyBullet()
    {
        Destroy(gameObject);
    }
}
