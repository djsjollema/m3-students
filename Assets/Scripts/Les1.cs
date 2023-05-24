using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Les1 : MonoBehaviour
{
    public GameObject A;
    public GameObject B;
    public Vector3 v;

    public GameObject P;
    float t = 0;
    public float tmax = 0;
    public float speed = 2.0f;

    void Start()
    {
        P.transform.position = A.transform.position;
    }

    void Update()
    {
        v = B.transform.position - A.transform.position;
        v = v.normalized;
        P.transform.position += v*speed * Time.deltaTime;

        float distance = (B.transform .position - P.transform.position).magnitude;
        if(distance < (v * speed * Time.deltaTime).magnitude)
        {
            P.transform.position = A.transform.position;
            t = 0;
        }
        t += Time.deltaTime;
        tmax = Mathf.Max(t, tmax);
        
    }
}
