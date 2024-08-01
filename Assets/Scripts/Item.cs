using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    private GameObject gameManager;

    private void Start() 
    {
        gameManager = GameObject.FindGameObjectWithTag("GameManager"); 
    }

    //when contact player, destroy itself and player
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            gameManager.GetComponent<GameManager>().ItemPlayer();
            Destroy(gameObject);
        }
          
    }
}
