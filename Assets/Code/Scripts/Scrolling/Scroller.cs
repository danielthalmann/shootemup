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

    public bool animate = true;

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

        width = CameraUtils.GetScreenToWorld().x;

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

        if (animate)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).transform.position = new Vector3(0, start + (height * i));
            }
        }

    }

    public void StartScroller()
    {
        animate = true;
    }

    public void StopScroller()
    {
        animate = false;
    }

}
