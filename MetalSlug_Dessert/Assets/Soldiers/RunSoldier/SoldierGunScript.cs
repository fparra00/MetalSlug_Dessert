using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierGunScript : MonoBehaviour
{
    [Header("Internal Variables")]
    [Tooltip("Velocity of Marco, enter a number between 0 to 10")]
    [SerializeField] private Transform gunPosition;
    [SerializeField] private GameObject bullet;
    [SerializeField] private float cooldownShot;

    private float nextShoot;
    private Animator Animator;
    private bool isShooting;

    private void Start()
    {
        Animator = GetComponent<Animator>();    
    }
    void Update()
    {
        // Checks
        if (RunSoldier.seeMarco && Time.time >= nextShoot)
        {
            shoot();
            isShooting = true;
        } else
        {
            isShooting = false;
        }
    }


    //Function to Instantiate a Bullet in the position of the gun
    private void shoot()
    {
        Animator.SetBool("shoot", isShooting);
        Instantiate(bullet, gunPosition.position, gunPosition.rotation);
        nextShoot = Time.time + cooldownShot;
    }
}
