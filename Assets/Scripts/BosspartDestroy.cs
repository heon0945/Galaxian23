using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BosspartDestroy : MonoBehaviour
{
    //each part of hp

    public int scoreValue;
    public int HP;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        GameObject gameManagerObject = GameObject.FindGameObjectWithTag("GameManager");
        if(gameManagerObject != null)
        {
            gameManager = gameManagerObject.GetComponent<GameManager>();
        }    
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("PlayerBullet"))
        {
            HP--;
            transform.parent.gameObject.GetComponent<Boss>().totalHP--;
            Destroy(collision.gameObject);
            if(HP == 0)
            {
                gameManager.AddScore(scoreValue);
                Destroy(gameObject);
            }
           
        }   
    }
}
