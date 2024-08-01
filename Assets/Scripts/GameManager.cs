using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] enemy;
    public float spawnWait;
    public float startWait;
    private int availableEnemy;

    public TextMeshProUGUI scoreText;
    private float score;

    public RawImage playerLifeImage;
    private RawImage[] playerLifes;
    public Canvas canvas;
    private int oldLife;
    public int playerLife;

    public TextMeshProUGUI timeText;
    private float time;

    public GameObject player;

    public GameObject gameoverText;
    public GameObject restartButton;

    public GameObject item;
    public GameObject itemEffect;
    public GameObject playerAppearEffect;

    public GameObject boss;
    public GameObject bossText;
    public GameObject gameclearText;

     public GameObject bossAppearEffect;

    // Start is called before the first frame update
    void Start()
    {
        playerLifes = new RawImage[playerLife];
        for(int i = 0; i < playerLife; i++)
        {
            playerLifes[i] = Instantiate(playerLifeImage);
            playerLifes[i].transform.SetParent(canvas.transform);
            playerLifes[i].rectTransform.localPosition = new Vector3(-140 + 30 * i, -270, 0);
        }
        oldLife = playerLife;
        Instantiate(playerAppearEffect);
        StartCoroutine(SpawnEnemies());
        StartCoroutine(SpawnItems());
    }

    private void Update() 
    {
        if(oldLife > playerLife) 
        {
            oldLife = playerLife; 
            if (oldLife < 0) 
                oldLife = 0;

            for (int i = oldLife; i < playerLifes.Length; i++) 
            { 
                playerLifes[i].enabled = false;
            } 
        }    
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(2f);
        GameObject.Find("StartText").SetActive(false);
        Instantiate(player, new Vector3(0, -3.5f, 0), Quaternion.identity);

        yield return new WaitForSeconds(startWait);
        
        while(true)
        {
            if(time > 120)
            {
                yield return new WaitForSeconds(3f);
                bossText.SetActive(true);
                Instantiate(bossAppearEffect, new Vector3(0, 3.0f, 0), Quaternion.identity);
                yield return new WaitForSeconds(3f);
                bossText.SetActive(false);
                GameObject b = Instantiate(boss, new Vector3(0, 3f, 0), Quaternion.identity);
                yield return new WaitForSeconds(2f);
                b.GetComponent<Boss>().shooting = 1;
                break;
            }
            if(time < 20)
                availableEnemy = 2;
            else if(time < 60)
                availableEnemy = 3;
            else
                availableEnemy = 4;
            GameObject instanEnemy = enemy[Random.Range(0, availableEnemy+1)];
            Vector3 spawnPosition = new Vector3(Random.Range(-2.3f, 2.3f), 6.0f);   
            Instantiate(instanEnemy, spawnPosition, Quaternion.identity);
            yield return new WaitForSeconds(spawnWait);
        }
    }

    IEnumerator SpawnItems()
    {   
        while(true)
        {
            int itemSpawnTime = Random.Range(45, 60);
            yield return new WaitForSeconds(itemSpawnTime);       
            if(time > 120)
                break;    
            Vector3 spawnPosition = new Vector3(Random.Range(-2.3f, 2.3f), 6.0f);
            Instantiate(item, spawnPosition, Quaternion.identity);
        }
    }

    private void FixedUpdate() 
    {
        if(GameObject.Find("Player(Clone)") != null)
        {
            time += 1 * Time.deltaTime;
            timeText.text = ((int)time).ToString();
        }
        
    }

    void UpdateScore()
    {
        scoreText.text = score.ToString();
    }

    public void AddScore(int newScoreValue)
    {
        score += newScoreValue;
        UpdateScore();
    }

    public void GameOver()
    {
        gameoverText.SetActive(true);
        restartButton.SetActive(true);
    }

    public void GameClear()
    {
        GameObject player = GameObject.Find("Player(Clone)");
        player.tag = "Untagged";
        gameclearText.SetActive(true);
        restartButton.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene("Stage1");
    }

    public void RespawnPlayer()
    {   
        StartCoroutine(NonAttack(3f));
    }

    IEnumerator NonAttack(float duration)
    {
        yield return new WaitForSeconds(1f);
        GameObject respawn = Instantiate(player, new Vector3(0, -3.5f, 0), Quaternion.identity);
        Debug.Log("player respawned");

        Debug.Log("NonAttackMode started");
        respawn.tag = "Untagged";
        respawn.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(duration);

        Debug.Log("NonAttackMode finished");
        respawn.tag = "Player";
        respawn.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1.0f);
    }

    public void ItemPlayer()
    {
        StartCoroutine(FeverTime(7f));
    }

    IEnumerator FeverTime(float duration)
    {
        GameObject player = GameObject.Find("Player(Clone)");
        Debug.Log("player fevertime");

        player.tag = "Untagged";
        player.GetComponent<Player>().speed += 5;
        player.GetComponent<Player>().bulletPattern = 3;
        float oldSpawnWait = spawnWait;
        spawnWait = 0.1f;
        GameObject effect = Instantiate(itemEffect.gameObject);
        yield return new WaitForSeconds(duration);

        spawnWait = oldSpawnWait;
        yield return new WaitForSeconds(4f);

        Debug.Log("fevertime finished");
        Destroy(effect);
        player.tag = "Player";
        player.GetComponent<Player>().speed -= 5;
        player.GetComponent<Player>().bulletPattern = 0;
    }
}
