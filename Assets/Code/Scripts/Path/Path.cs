using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    public List<Vector> vectors = new List<Vector>();

    public bool helper = true;

    public bool loopPath = false;

    [Range(0f, 1.0f)]
    public float position = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    
    void OnDrawGizmos()
    {
        Vector3 p;
        float t;

        if (vectors.Count < 2)
            return;

        float steps = 1.0f / 30;

        Vector3 last = vectors[0].getPoint(transform);

        int max = vectors.Count - 1;

        if (loopPath) {
            max = vectors.Count;
        }

        for (int i = 0; i < max; i++)
        {
/*
            if (helper)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(vectors[i % vectors.Count].getPoint(transform), vectors[i % vectors.Count].getCurveRight(transform));
                Gizmos.DrawLine(vectors[(i + 1) % vectors.Count].getPoint(transform), vectors[(i + 1) % vectors.Count].getCurveLeft(transform));
            }
*/
            for (t = steps; t < 1.0f; t += steps)
            {
                p = Bezier(vectors[i % vectors.Count].getPoint(transform), 
                           vectors[i % vectors.Count].getCurveRight(transform), 
                           vectors[(i + 1) % vectors.Count].getCurveLeft(transform), 
                           vectors[(i + 1) % vectors.Count].getPoint(transform)
                           , t);

                Gizmos.color = Color.red;
                Gizmos.DrawLine(last, p);

                last = p;
                // Gizmos.DrawSphere(p, 0.5f);
            }

        }
        if (loopPath)
        {
            Gizmos.DrawLine(last, vectors[0].getPoint(transform));
        }
        else
        {
            Gizmos.DrawLine(last, vectors[vectors.Count - 1].getPoint(transform));
        }

        p = GetPositionAt(position)
;
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(p, 0.2f); 

    }

    public Vector3 GetPositionAt(float pos)
    {
        if (pos >= 1.0f) {
            if (loopPath)
                return vectors[0].getPoint(transform);
            else
                return vectors[vectors.Count - 1].getPoint(transform);
        }
        int segment;
        float t;
        if (loopPath)
        {
            segment = (int)(pos * vectors.Count);
            t = ((pos * (vectors.Count)) - segment);
        }
        else
        {
            segment = (int)(pos * (vectors.Count - 1));
            t = ((pos * (vectors.Count - 1)) - segment);
        }

        return Bezier(vectors[segment].getPoint(transform), vectors[segment].getCurveRight(transform), vectors[(segment + 1) % vectors.Count].getCurveLeft(transform), vectors[(segment + 1) % vectors.Count].getPoint(transform), t);
    }



    public Vector3 Bezier(Vector3 a, Vector3 b, Vector3 c, Vector3 d, float t)
    {
        float ap = Mathf.Pow((1.0f - t), 3.0f);
        float bp = 3.0f * t * Mathf.Pow((1.0f - t), 2.0f);
        float cp = 3.0f * (1.0f - t) * Mathf.Pow(t, 2.0f);
        float dp = Mathf.Pow(t, 3.0f);

        return new Vector3(
            a.x * ap + b.x * bp + c.x * cp + d.x * dp,
            a.y * ap + b.y * bp + c.y * cp + d.y * dp,
            a.z * ap + b.z * bp + c.z * cp + d.z * dp
        );

    }
}
