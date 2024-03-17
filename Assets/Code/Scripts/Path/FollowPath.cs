using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class FollowPath : MonoBehaviour
{

    public Path path;
    public float speed = 0.5f;
    [Range(0f, 1f)]
    public float t = 0;
    public bool destroyAtEnd = false;
    public bool loop = false;
    public bool rotate = true;

    Vector3 after;
    Vector3 vect;

    private void Start()
    {

    }


    // Update is called once per frame
    void Update()
    {
        if (path == null)
            return;

        if (t < 1.0f)
        {
            after = path.GetPositionAt(t + (.03f));
            
            transform.position = path.GetPositionAt(t);
            if (rotate)
            {
                vect = after - transform.position;
                vect.Normalize();
                transform.GetChild(0).rotation = Quaternion.LookRotation(Vector3.forward, vect);
            }

        }
        else
        {
            if (destroyAtEnd)
                Destroy(gameObject);
            if (loop)
                t = t % 1;

        }

        t += Time.deltaTime * speed;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + vect);

    }
}
