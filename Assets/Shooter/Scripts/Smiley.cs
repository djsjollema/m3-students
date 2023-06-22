using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Smiley : MonoBehaviour
{
    public Vector3 velocity = new Vector3(0, -1, 0);
    public float speed = 1;
    public float yMin = 0;


    void Start()
    {
        
    }

    void Update()
    {
        transform.position += velocity * speed * Time.deltaTime;
        if(transform.position.y < yMin)
        {
            Destroy(gameObject);
        }
    }
}
