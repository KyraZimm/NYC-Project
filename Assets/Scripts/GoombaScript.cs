using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class GoombaScript : MonoBehaviour
{
    public GameObject Player;
    private float yPos;

    public float leftBound;
    public float rightBound;

    public float offset;

    public GameObject barrel;

    private float timer;
    private float timerStart = 3f;
    
    // Start is called before the first frame update
    void Start()
    {
        yPos = gameObject.transform.position.y;
        timer = offset + timerStart;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Player.transform.position.x >= leftBound && Player.transform.position.x <= rightBound)
        {
            gameObject.transform.position = new Vector3(Player.transform.position.x, yPos, 0);
        }

        if (timer <= 0)
        {
            GameObject newBarrel = Instantiate(barrel, gameObject.transform.position, Quaternion.identity);
            timer = timerStart;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
