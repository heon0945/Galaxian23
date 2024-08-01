using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChasePlayer : MonoBehaviour
{
    private GameObject player;
    private Vector3 playerPos, enemyPos, chasingDir;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            playerPos = player.transform.position;
            enemyPos = transform.position;
            chasingDir = (playerPos - enemyPos).normalized;
            transform.position = new Vector3(enemyPos.x + chasingDir.x * Time.deltaTime, enemyPos.y, enemyPos.z);
        }
    }
}
