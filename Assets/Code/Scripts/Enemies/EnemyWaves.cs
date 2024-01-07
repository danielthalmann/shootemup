using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyWaves : ScriptableObject
{
    public float startAfter = 1.0f;

    public Path path;

    public GameObject enemy;

    public float interval = 1.0f;

    [Range(1, 100)]
    public int count = 1;

}
