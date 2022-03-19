using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPGScript : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float damage;
    [SerializeField] private GameObject prExplosion;


    private Rigidbody2D rb;
    private Vector2 dirBullet;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke("destroyBullet", 2f);
        if(LogicalMarco.directionAbs.x > this.transform.position.x) {
            dirBullet = Vector2.right;
            this.transform.localScale = new Vector3(1f,1f,1f);
        } else
        {
            dirBullet = Vector2.left;
        }
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
        if (!other.name.Equals("BulletSoldier(Clone)") && !other.name.Equals("DefaultBullet(Clone)") && !other.CompareTag("Soldier"))
        {
            explosion();
            destroyBullet();
        }
    }



    private void explosion()
    {
        Vector3 floorExpl = new Vector3(transform.position.x, transform.position.y + 0.1f, -1f);
        Instantiate(prExplosion, floorExpl, Quaternion.identity);
        destroyBullet();
    }
   

    


}
