using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandbagScript : MonoBehaviour
{

    private Animator Animator;

    private float health;

    void Start()
    {
        Animator = GetComponent<Animator>();    
        health = 5;
    }

    void Update()
    {
        if (health == 0) Animator.SetBool("explosion", true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("regularBulelet"))
        {
            health--;
        }
    }
}
