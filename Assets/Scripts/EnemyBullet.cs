using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    public GameObject enemyBullet;
    public GameObject bulletSpawn;
    public float fireRate;
    private float nextFire;

    public int bulletPattern;

    void Attack()
    {
        switch(bulletPattern)
        {
            case 0:
                Instantiate(enemyBullet, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                break;
            case 1:
                Instantiate(enemyBullet, bulletSpawn.transform.position + Vector3.left * 0.2f, bulletSpawn.transform.rotation);
                Instantiate(enemyBullet, bulletSpawn.transform.position + Vector3.right * 0.2f, bulletSpawn.transform.rotation);
                break;
        }
    }

    void FixedUpdate() 
    {

        if (Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Attack();
        }
    }
}
