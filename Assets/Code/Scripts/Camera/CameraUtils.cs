using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUtils
{

    public static Vector2 GetScreenToWorld()
    {
        Vector2 edgeVector = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        return edgeVector * 2;
    }

    public static Rect GetRectScreenWorld()
    {
        Vector2 world = CameraUtils.GetScreenToWorld();

        return new Rect(-world.x, world.y / 2, world.x, world.y);

    }


}
