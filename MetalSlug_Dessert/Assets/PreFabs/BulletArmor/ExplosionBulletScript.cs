using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyExplosionBullet", 1.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void explosion()
    {
        Collider2D[] collisions = Physics2D.OverlapCircleAll(this.transform.position, 0.5f);
        foreach (Collider2D collision in collisions)
        {
            if (collision.CompareTag("Soldier"))
            {
                collision.gameObject.GetComponent<SoldiersGeneral>().hit(2);
            }
        }

      
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other != null)
        {
            explosion();
        }
    }

    void OnDrawGizmos()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, 0.5f);
    }

    private void destroyExplosionBullet()
    {
        Destroy(gameObject);
    }
}
