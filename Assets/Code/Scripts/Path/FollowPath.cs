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

    private Quaternion origin_rotation;

    Vector3 after;
    Vector3 vect;

    private void Start()
    {
        origin_rotation = transform.rotation;

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
            vect = after - transform.position;
            vect.Normalize();
            //transform.GetChild(0).rotation = Quaternion.Euler(0, 0, Mathf.Sin(vect.x) * 90);
            transform.GetChild(0).rotation = Quaternion.LookRotation(Vector3.forward, vect);
            //transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(vect.x) * 90);

        }
        else
        {
            if (destroyAtEnd)
                Destroy(gameObject);

        }

        t += Time.deltaTime * speed;
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + vect);

    }
}
