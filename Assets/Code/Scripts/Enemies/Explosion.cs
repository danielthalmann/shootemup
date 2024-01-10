using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public GameObject ExplosionPrefab;
    public string exploseOnTriggerTag = "";

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Explose()
    {
        GameObject g = Instantiate(ExplosionPrefab, transform.position, transform.rotation);
        Destroy(g, 1);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (exploseOnTriggerTag != "")
        {

            if (other.gameObject.CompareTag(exploseOnTriggerTag))
            {
            Debug.Log(other.gameObject.tag);
                Destroy(other.gameObject);
                Explose();
            }
        }
    }  

}
