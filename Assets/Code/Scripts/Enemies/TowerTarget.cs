using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerTarget : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        PlayerTarget target = FindFirstObjectByType<PlayerTarget>();
        if (target != null)
        {
            Vector2 direction = target.gameObject.transform.position - transform.position;
            direction.Normalize();

            Vector3 orientation = new Vector3(direction.x, direction.y, 0).normalized;
            transform.rotation = Quaternion.LookRotation(Vector3.forward, orientation);
        }
        
    }
}
