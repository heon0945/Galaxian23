using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyPlayer : MonoBehaviour
{
    private GameObject gameManager;
    public GameObject playerDieEffect;

    private void Start() 
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager"); 
    }

    //when contact player, destroy itself and player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
           
            gameManager.GetComponent<GameManager>().playerLife--;
            int life = gameManager.GetComponent<GameManager>().playerLife;

            if(life <= 0)
            {
                Instantiate(playerDieEffect, 
                new Vector3(collision.transform.position.x, collision.transform.position.y, -1), Quaternion.identity);
                gameManager.GetComponent<GameManager>().GameOver();
            }
            else
            {
                gameManager.GetComponent<GameManager>().RespawnPlayer();
            }
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }   
    }
}
