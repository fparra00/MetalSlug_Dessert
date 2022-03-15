using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletArmor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("destroyBullet", 1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void destroyBullet()
    {
Destroy(gameObject);
    }
}
