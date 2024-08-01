using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossbodyDestroy : MonoBehaviour
{
    //each part of hp

    public int scoreValue;
    public int HP;
    private bool collisionStart;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        if(gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }    

        collisionStart = false;
    }

    public void SetCollisionStart()
    {
        collisionStart = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBullet"))
        {
            Destroy(collision.gameObject);
            if(collisionStart == true)
            {
                HP--;
                transform.parent.gameObject.GetComponent<Boss>().totalHP--;
                if(HP == 0)
                {
                    gameManager.AddScore(scoreValue);
                    Destroy(gameObject);
                }
            }
        }   
    }
}
