using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBulletArmor : MonoBehaviour
{
    void Start()
    {
        Invoke("destroyExplosion", 1f);
    }

    void Update()
    {
        
    }

    private void destroyExplosion()
    {
        Destroy(gameObject);    
    }
}
