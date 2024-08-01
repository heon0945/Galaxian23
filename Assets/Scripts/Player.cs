using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed; //move speed

    public float xMin, xMax; //screen width

    public GameObject[] playerBullet;
    public GameObject bulletSpawn;
    public float fireRate;
    private float nextFire;

    public int bulletPattern; // decide bullet pattern

    // Start is called before the first frame update
    void Start()
    {
        bulletPattern = 0; 
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            bulletPattern ++;
            if(bulletPattern > 3)
                bulletPattern = 0;
        }
    }

    void Attack()
    {
        switch(bulletPattern)
        {
            case 0:
                Instantiate(playerBullet[0], bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                break;
            case 1:
                Instantiate(playerBullet[0], bulletSpawn.transform.position + Vector3.left * 0.2f, bulletSpawn.transform.rotation);
                Instantiate(playerBullet[0], bulletSpawn.transform.position + Vector3.right * 0.2f, bulletSpawn.transform.rotation);
                break;
            case 2:
                Instantiate(playerBullet[1], bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                break;
            case 3:
                Instantiate(playerBullet[1], bulletSpawn.transform.position, bulletSpawn.transform.rotation);
                GameObject leftBullet = Instantiate(playerBullet[1], bulletSpawn.transform.position + Vector3.left * 0.2f, bulletSpawn.transform.rotation);
                leftBullet.transform.Rotate(Vector3.forward * 3);
                GameObject rightBullet = Instantiate(playerBullet[1], bulletSpawn.transform.position + Vector3.right * 0.2f, bulletSpawn.transform.rotation);
                rightBullet.transform.Rotate(Vector3.forward * -3);
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


        if(Input.GetKey(KeyCode.LeftArrow)) //move left
        {
            transform.Translate(new Vector2(-speed*Time.deltaTime, 0.0f));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), -3.5f, 0.0f); ////make player stay in screen
        }
        else if(Input.GetKey(KeyCode.RightArrow)) //move right
        {
            transform.Translate(new Vector2(speed*Time.deltaTime, 0.0f));
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, xMin, xMax), -3.5f, 0.0f); //make player stay in screen
        }    
    }
}
