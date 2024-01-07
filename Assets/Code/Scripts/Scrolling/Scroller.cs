using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.UIElements;

public class Scroller : MonoBehaviour
{

    public float speed = 1.0f;

    private float width;
    private float height;
    private float start;

        public static float GetScreenToWorldHeight
    {
        get
        {
            Vector2 topRightCorner = new Vector2(1, 1);
            Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner); 
            float height = edgeVector.y * 2;
            return height;
        }
    }

    public static float GetScreenToWorldWidth
    {
        get
        {
            Vector2 topRightCorner = new Vector2(1, 1);
            Vector2 edgeVector = Camera.main.ViewportToWorldPoint(topRightCorner); 
            float width = edgeVector.x * 2;
            return width;
        }
    }


    // Start is called before the first frame update
    void Start()
    {

        GameObject istc;

        if (transform.childCount < 1)
            return;

        istc = transform.GetChild(0).gameObject;
        // float ratio = istc.transform.localScale.y / istc.transform.localScale.x;

        SpriteRenderer s = istc.GetComponent<SpriteRenderer>();
        float ratio = s.size.y / s.size.x;

        width = GetScreenToWorldWidth;
        height = (width * ratio);
        start = (-2 * height);

        for (int i = 0; i < transform.childCount; i++)
        {
            istc = transform.GetChild(i).gameObject;
            istc.transform.localScale = new Vector3(width, width);
            istc.transform.position = new Vector3(0, start + (height * i));
        }


    }

    // Update is called once per frame
    void Update()
    {
        start -= (Time.deltaTime * speed);

        if (start < (-2 * height))
            start += height;
        
        
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).transform.position = new Vector3(0, start + (height * i));
        }

    }

}
