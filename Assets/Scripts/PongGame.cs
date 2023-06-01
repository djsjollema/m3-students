using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class PongGame : MonoBehaviour
{
    public GameObject pongBall;
    public Vector3 velocity = new Vector3(-1,2,0);
    public Vector2 viewMax;
    public Vector2 viewMin;
    public GameObject playerB;
    public GameObject playerA;
    public float speed = 5.0f;

    public TMP_Text scoreA_text;
    public TMP_Text scoreB_text;

    int scoreA = 0;
    int scoreB = 0;


    RaycastHit2D hit;

    void Start()
    {
        scoreA_text.text = scoreA.ToString();
        scoreB_text.text = scoreB.ToString();

        viewMax = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        viewMin = Camera.main.ScreenToWorldPoint(Vector2.zero);
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreA_text.text = scoreA.ToString();
        scoreB_text.text = scoreB.ToString();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerB.transform.position += new Vector3(0, 1, 0);
        }

        if(Input.GetKeyDown(KeyCode.DownArrow)) {
            playerB.transform.position += new Vector3(0, -1, 0);
         }

        if (Input.GetKeyDown(KeyCode.W)){
            playerA.transform.position += new Vector3(0, 1, 0);
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            playerA.transform.position += new Vector3(0, -1, 0);
        }

        pongBall.transform.position += velocity * speed * Time.deltaTime;

        hit = Physics2D.Raycast(pongBall.transform.position, new Vector3(velocity.x, 0, 0),0.5f);
        Debug.DrawRay(pongBall.transform.position, new Vector3(velocity.x, 0, 0),Color.white);
        if(hit.collider != null)
        {
            velocity = new Vector3(-velocity.x, velocity.y, 0);
        }
        if(pongBall.transform.position.y > viewMax.y - pongBall.transform.localScale.x/2)
        {
            velocity = new Vector3(velocity.x, -velocity.y, 0);
        }

        if(pongBall.transform.position.y < viewMin.y + pongBall.transform.localScale.x / 2)
        {
            velocity = new Vector3(velocity.x, -velocity.y, 0);
        }
        if(pongBall.transform.position.x > viewMax.x + pongBall.transform.localScale.x /2)
        {
            pongBall.transform.position = Vector3.zero;
            scoreA++;
        }

        if(pongBall.transform.position.x < viewMin.x - pongBall.transform.lossyScale.x / 2)
        {
            pongBall.transform.position = Vector3.zero;
            scoreB++;
        }
        
    }
}
