using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyByHP : MonoBehaviour
{
    public int scoreValue;
    public int HP;
    private GameManager gameManager;
    public GameObject enemyEffect;

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
            Destroy(collision.gameObject);
            if(HP <= 0)
            {
                gameManager.AddScore(scoreValue);
                Instantiate(enemyEffect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
            else
            {
                StartCoroutine(Flicker());
            }
        }   
    }

    public IEnumerator Flicker()
    {
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.1f);
        gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
    }
}
