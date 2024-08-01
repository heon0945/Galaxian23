using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Boss : MonoBehaviour
{

    public GameObject[] bossBullet;
    public GameObject bulletSpawn;
    private float fireRate;
    private float nextFire;

    private int bulletPattern;
    private float speed;
    private int originHP;
    public int totalHP;
    public Slider sliderHP;
    public GameObject bossbody;

    private bool moving;
    private Vector3 movePosition;
    private int movingTime;
    public int shooting;

    public GameObject bossDieEffect;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 2f;
        originHP = 70;
        moving = false;
        speed = 2;
        movingTime = 10;
        sliderHP.value = originHP;
        totalHP = originHP;
        bulletPattern = 0;
        shooting = 0;

        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        if(gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }    

        StartCoroutine(BossMoving());
    }

    IEnumerator BossMoving()
    {
       while(true)
        {
            int moveTime = Random.Range(movingTime-3, movingTime);
            yield return new WaitForSeconds(moveTime);           
            movePosition = new Vector3(Random.Range(-1.7f, 1.7f), 3.0f);
            moving = true;
            yield return new WaitForSeconds(2f);
            moving = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        sliderHP.value = totalHP;
        sliderHP.transform.position = Camera.main.WorldToScreenPoint(transform.position + new Vector3(0, 0.8f, 0));

        if(totalHP <= 0)
        {
            Instantiate(bossDieEffect, transform.position, Quaternion.identity);
            gameManager.GetComponent<GameManager>().GameClear();
            Destroy(gameObject);
        }
        else if(totalHP <= 30)
        {
            bossbody.GetComponent<BossbodyDestroy>().SetCollisionStart();
            bulletPattern = 1;
            movingTime = 4;
        }
        else if(totalHP < 40)
        {
            Debug.Log("rapid shooting");
            fireRate = 1;
        }
        else if(totalHP < 50)
        {
            Debug.Log("more moving");
            movingTime = 8;
        }
    }

    void FixedUpdate() 
    {
        if(moving == true)
        {
            transform.position = Vector3.Lerp(transform.position, movePosition, speed * Time.deltaTime);
        }
        if(shooting == 1)
        {
            if (Time.time > nextFire)
            {
                nextFire = Time.time + fireRate;
                Attack();
            }
        }
    }

    void Attack()
    {
        switch(bulletPattern)
        {
            case 0:
                Instantiate(bossBullet[0], bulletSpawn.transform.position + Vector3.left * 0.2f, bulletSpawn.transform.rotation);
                Instantiate(bossBullet[0], bulletSpawn.transform.position + Vector3.right * 0.2f, bulletSpawn.transform.rotation);
                break;
            case 1:
                float bulletNum = 20;
                float angle = 2*Mathf.PI/bulletNum; 
                for(int i = 0; i < bulletNum; i++)
                {
                    GameObject bullet = Instantiate(bossBullet[1], bulletSpawn.transform.position, Quaternion.identity);
                    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(100 * Mathf.Cos(angle*i), 
                    100 * Mathf.Sin(angle*i)));
                    bullet.transform.Rotate(new Vector3(0f, 0f, 360/bulletNum * i - 90));
                }
                fireRate = Random.Range(0.5f, 1.5f);
                break;
        }
    }
}
