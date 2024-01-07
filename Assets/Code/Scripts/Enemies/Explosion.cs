using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject ExplosionPrefab;

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("FireAllied"))
        {
            GameObject g = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
            Destroy(g, 1);
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }  

}
