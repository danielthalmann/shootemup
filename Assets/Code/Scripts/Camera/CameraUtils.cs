using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtils
{

    public static Vector2 getScreenToWorld()
    {
        Vector2 edgeVector = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        return edgeVector * 2;

    }

}
