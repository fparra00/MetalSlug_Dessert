using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneSoldier : MonoBehaviour
{



    void Start()
    {
    }

    void Update()
    {
        //Actions
        if (SoldiersGeneral.seeEnemy) attack();

        Debug.Log(SoldiersGeneral.seeEnemy);
    }

    private void attack()
    {
    }

}
