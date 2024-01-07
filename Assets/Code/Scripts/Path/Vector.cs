using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Vector 
{

    public Vector3 point = new Vector3();
    public Vector3 curveLeft = new Vector3();
    public Vector3 curveRight = new Vector3();

    public Vector3 getPoint(Transform transform)
    {
        Vector3 p = point + transform.position;
        p.Scale(transform.localScale);
        return p;

    }

    public Vector3 getCurveLeft(Transform transform)
    {
        Vector3 p = curveLeft + transform.position;
        p.Scale(transform.localScale);
        return p;

    }

    public Vector3 getCurveRight(Transform transform)
    {
        Vector3 p = curveRight + transform.position;
        p.Scale(transform.localScale);
        return p;

    }

}
