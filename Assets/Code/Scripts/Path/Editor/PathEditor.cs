using UnityEditor;
using UnityEngine;
using System.Collections;
using log4net.Util;

// Create a 180 degrees wire arc with a ScaleValueHandle attached to the disc
// that lets you modify the "radius" value in the WireArcExample
[CustomEditor(typeof(Path))]
public class PathEditor : Editor
{
    void OnSceneGUI()
    {
        Handles.color = Color.red;
        Path path = (Path)target;
        if (!path.helper)
            return;
        // Handles.DrawWireArc(myObj.transform.position, Vector3.forward, myObj.transform.right, 180, radius);

        for (int i = 0; i < path.vectors.Count; i++)
        {
            Vector3 last = path.vectors[i].point;
            path.vectors[i].point = Handles.PositionHandle(path.vectors[i].point + path.transform.position, path.transform.rotation) - path.transform.position;

            path.vectors[i].curveLeft += path.vectors[i].point - last;
            path.vectors[i].curveRight += path.vectors[i].point - last;

            if (i > 0) { 
                path.vectors[i].curveLeft = Handles.PositionHandle(path.vectors[i].curveLeft + path.transform.position, path.transform.rotation) - path.transform.position;
            }
            if (i < path.vectors.Count - 1) { 
                path.vectors[i].curveRight = Handles.PositionHandle(path.vectors[i].curveRight + path.transform.position, path.transform.rotation) - path.transform.position;
            }

        }
    }

}