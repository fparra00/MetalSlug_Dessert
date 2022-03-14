using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogicalMarco : MonoBehaviour
{
    [Header("Components")]
    private Rigidbody2D rb;
    private Animator anim;

    [Header("Internal Variables")]
    [SerializeField] private float velocity, jumpForce, health;
    private float x, y;

    [Header("Animations")]
    private bool isRunning, isJumping;



    void Start()
    {
        
    }

    void Update()
    {
        recalculateOrientation();
        
    }

    private void recalculateOrientation()
    {
        x = Input.GetAxisRaw("Horizontal");
        if(x <0.0f) transform.localScale = new Vector3(-1f, 1f, 1f);
        if (x > 0.0f) transform.localScale = new Vector3(1f, 1f, 1f);
    }
}
