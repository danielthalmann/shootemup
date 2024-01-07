using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class Attack : MonoBehaviour
{
    public GameObject fire;

    public float interval = 1.0f;

    private float time = 0f;


    // Update is called once per frame
    void Update()
    {

        if (fire == null)
            return;


        if (time > interval)
        {
            GameObject obj = Instantiate(fire, transform.position, transform.rotation);
            Destroy(obj, 3);
            time = 0;
        }

        time += Time.deltaTime;
    }
}
