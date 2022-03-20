using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HomelessScript : MonoBehaviour
{

    private Animator animator;
    private AudioSource aud;
    private bool isReleased, goToRun;
    public AudioClip sound;


    void Start()
    {
        aud = GetComponent<AudioSource>();  
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetBool("isReleased",isReleased);
        if (goToRun) run();
    }


    public void run()
    {
        transform.localScale = new Vector3(-1.2f, 1.2f, 1.2f);
        transform.Translate(Vector2.right * (Time.deltaTime * 1f));
    }

    private void setGoToRun() => goToRun = true;
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isReleased = (collision.CompareTag("regularBullet")) ? true : false;
    }
}
