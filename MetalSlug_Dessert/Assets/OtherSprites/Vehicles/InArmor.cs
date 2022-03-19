using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InArmor : MonoBehaviour
{

    void Update()
    {
        if (LogicalMarco.isInVehicle) Invoke("destroyThis", 2f);
    }

    private void destroyThis()
    {
        Destroy(gameObject);
    }
}
