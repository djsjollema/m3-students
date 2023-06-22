using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShooterManager : MonoBehaviour
{
    public Smiley smiley;
    private Vector2 maxView;
    private Vector2 minView;

    // Start is called before the first frame update
    void Start()
    {


        minView = Camera.main.ScreenToWorldPoint(Vector2.zero);
        maxView = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width,Screen.height));


    }

    void Update()
    {
        if(Random.Range(0,10000) < 10)
        {
            float x = Random.Range(minView.x, maxView.x);
            float y = maxView.y + smiley.transform.localScale.y;

            Smiley newSmiley = Instantiate(smiley, new Vector3(x, y, 0), Quaternion.identity);
            newSmiley.yMin = minView.y - smiley.transform.localScale.y;
        }


    }
}
