using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandbagScript : MonoBehaviour
{
    //Components
    private Animator Animator;
    private BoxCollider2D BoxCollider2D;

    //Internal Variables
    private float health;

    void Start()
    {
        Animator = GetComponent<Animator>();    
        BoxCollider2D = GetComponent<BoxCollider2D>();  
        health = 5;
    }

    void Update()
    {
        if (health == 0) destroySandbag();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("regularBullet"))
        {
            health--;
        }
    }

    private void destroySandbag()
    {
        Animator.SetBool("explosion", true);
        Destroy(BoxCollider2D);
    }
}
