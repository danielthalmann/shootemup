using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Path : MonoBehaviour
{

    public List<Vector> vectors = new List<Vector>();

    public bool helper = true;

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

        float steps = 1.0f / 40;

        Vector3 last = vectors[0].getPoint(transform);

        for (int i = 0; i < vectors.Count - 1; i++)
        {

            if (helper)
            {
                Gizmos.color = Color.yellow;
                Gizmos.DrawLine(vectors[i].getPoint(transform), vectors[i].getCurveRight(transform));
                Gizmos.DrawLine(vectors[i + 1].getPoint(transform), vectors[i + 1].getCurveLeft(transform));
            }

            for (t = steps; t < 1.0f; t += steps)
            {
                p = Bezier(vectors[i].getPoint(transform), vectors[i].getCurveRight(transform), vectors[i + 1].getCurveLeft(transform), vectors[i + 1].getPoint(transform), t);
                

                Gizmos.color = Color.red;
                Gizmos.DrawLine(last, p);

                last = p;
                // Gizmos.DrawSphere(p, 0.5f);
            }

        }
        Gizmos.DrawLine(last, vectors[vectors.Count - 1].getPoint(transform));

        p = GetPositionAt(position);
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(p, 0.2f); 

    }

    public Vector3 GetPositionAt(float pos)
    {
        if (pos >= 1.0f) {
            return vectors[vectors.Count - 1].getPoint(transform);
        }
        int segment = (int)(pos * (vectors.Count - 1));
        float t = ((pos * (vectors.Count - 1)) - segment);
        return Bezier(vectors[segment].getPoint(transform), vectors[segment].getCurveRight(transform), vectors[segment + 1].getCurveLeft(transform), vectors[segment + 1].getPoint(transform), t);
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
