using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneSoldier : MonoBehaviour
{
    private bool atackMode;


    void Start()
    {
    }

    void Update()
    {
        //Actions
        if (SoldiersGeneral.seeEnemy) atackMode=true;

    }

    private void atack()
    {
    }

}
