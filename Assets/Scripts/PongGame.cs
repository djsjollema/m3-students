using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PongGame : MonoBehaviour
{
    public GameObject pongBall;
    public Vector3 velocity = new Vector3(-1,2,0);
    public Vector2 viewMax;
    public Vector2 viewMin; 

    void Start()
    {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);

        viewMax = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        viewMin = Camera.main.ScreenToWorldPoint(Vector2.zero);

        Debug.Log(viewMax);
        Debug.Log(viewMin);
        
    }

    // Update is called once per frame
    void Update()
    {
        pongBall.transform.position += velocity * Time.deltaTime;

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
        }

        if(pongBall.transform.position.x < viewMin.x - pongBall.transform.lossyScale.x / 2)
        {
            pongBall.transform.position = Vector3.zero;
        }
        
    }
}
