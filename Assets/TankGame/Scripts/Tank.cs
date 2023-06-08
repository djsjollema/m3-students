using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0, 1, 0);
    public float speed = 1.0f;
    Vector2 minView;
    Vector2 maxView;

    void Start()
    {
        minView = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxView = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        BorderControl();
        transform.position += velocity * speed * Time.deltaTime;
        
    }

    public void BorderControl()
    {
        if(transform.position.y > maxView.y)
        {
            transform.position = new Vector3(transform.position.x, minView.y, 0);
        }

        if(transform.position.y < minView.y)
        {
            transform.position = new Vector3(transform.position.x,maxView.y, 0);
        }

    }
}
