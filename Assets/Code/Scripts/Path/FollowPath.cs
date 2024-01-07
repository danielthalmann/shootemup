using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{

    public Path path;
    public float speed = 0.5f;
    [Range(0f, 1f)]
    public float t = 0;
    public bool destroyAtEnd = false;

    
    // Update is called once per frame
    void Update()
    {
        if (path == null)
            return;

        if ( t < 1.0f )
        {
            transform.position = path.GetPositionAt(t);

        } else
        {
            if (destroyAtEnd)
                Destroy(gameObject);

        }
        
        t += Time.deltaTime * speed;
    }
}
