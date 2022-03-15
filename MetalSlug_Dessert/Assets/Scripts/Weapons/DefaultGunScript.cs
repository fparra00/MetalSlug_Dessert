using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultGunScript : MonoBehaviour
{

    [SerializeField] private Transform gunPosition;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float cooldownShot;

    private float nextShoot;


    void Update()
    {


        // Checks
        if (LogicalMarco.isShooting && Time.time >= nextShoot)
        {
            shoot();
            nextShoot = Time.time + cooldownShot;
        }

    }


    //Function to Instantiate a Bullet in the position of the gun
    private void shoot()
    {
        Instantiate(bullet, gunPosition.position, gunPosition.rotation);
    }
}
