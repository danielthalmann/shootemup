using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VectorFollow : MonoBehaviour
{
    public Vector2 direction;
    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 orientation = new Vector3(direction.x, direction.y, 0).normalized;

        Vector3 position = orientation * (speed * Time.deltaTime);

        transform.rotation = Quaternion.LookRotation(Vector3.forward, orientation);
        transform.position = transform.position + position;
        
    }
}
