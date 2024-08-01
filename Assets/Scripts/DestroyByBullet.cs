using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByBullet : MonoBehaviour
{
    public int scoreValue;
    private GameManager gameManager;

    public GameObject enemyEffect;

    private void Start() 
    {
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        if(gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }    
    }
    //when contact player bullet, destroy itself and the bullet
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBullet"))
        {
            gameManager.AddScore(scoreValue);
            Destroy(collision.gameObject);
            Instantiate(enemyEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }   
    }
}
