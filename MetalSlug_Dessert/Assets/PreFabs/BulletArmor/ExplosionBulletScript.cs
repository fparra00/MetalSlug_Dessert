using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionBulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyExplosionBullet", 1.4f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void destroyExplosionBullet()
    {
        Destroy(gameObject);
    }
}
