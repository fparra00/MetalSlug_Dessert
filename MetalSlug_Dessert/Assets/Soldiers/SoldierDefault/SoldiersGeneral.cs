using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldiersGeneral : MonoBehaviour
{
    [SerializeField] private float visionRange;
    public static bool seeEnemy = false;

    void Start()
    {
    }

    void FixedUpdate()
    {
        //Checks
        seeEnemy = (this.transform.position.x + -(visionRange) > LogicalMarco.directionAbs.x) ? false : true;

    }

   
}
