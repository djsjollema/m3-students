using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0, 1, 0);
    public float speed = 1.0f;
    Vector2 minView;
    Vector2 maxView;
    public KeyCode forward, left, right, backward;
    public Bullet bullet;
    public AudioSource shot;

    void Start()
    {
        minView = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxView = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
    }

    void Update()
    {
        BorderControl();
        transform.position += velocity * speed * Time.deltaTime;

        if (Input.GetKeyDown(KeyCode.RightArrow)){
            transform.localEulerAngles += new Vector3(0, 0, -10);
            velocity = Quaternion.Euler(0, 0, -10) * velocity;
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.localEulerAngles += new Vector3(0, 0, 10);
            velocity = Quaternion.Euler(0, 0, 10) * velocity;
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            speed++;
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            speed--;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Bullet newBullet = Instantiate(bullet, transform.position, Quaternion.identity);
            newBullet.velocity = velocity;
            newBullet.speed = 10.0f;
            shot.Play();
        }

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

        if(transform.position.x > maxView.x)
        {
            transform.position = new Vector3(minView.x, transform.position.y, 0);
        }

        if(transform.position.x < minView.x )
        {
            transform.position = new Vector3(maxView.x, transform.position.y, 0);
        }

    }
}
