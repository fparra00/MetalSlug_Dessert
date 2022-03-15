using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreamAndRun : MonoBehaviour
{
    private Animator Animator;
    void Start()
    {
        Animator = GetComponent<Animator>();    
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(SoldiersGeneral.seeEnemy);

        Animator.SetBool("seeEnemy", SoldiersGeneral.seeEnemy);
    }
}
