using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollBackground : MonoBehaviour
{
    private float backGroundSpeed = 2.0f; //screen move speed
    float moveCheck; //check time for background replacing

    // Start is called before the first frame update
    void Start()
    {
        moveCheck = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        moveCheck = backGroundSpeed * Time.deltaTime;
        transform.Translate(Vector3.down * moveCheck);
        if(transform.position.y < -10.0f)
        {
            transform.position = new Vector2(0.0f, 10.0f);
        }
    }
}
