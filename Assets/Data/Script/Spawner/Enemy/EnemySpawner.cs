using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : Spawner
{
    private static EnemySpawner instance;
    public static EnemySpawner Instance;

    public List<Transform> Prefabs => prefabs;

    protected override void Awake()
    {
        if (instance != null)
        {
            Debug.LogError(transform.name + ": EnemySpawner is already existed", transform.gameObject);
            return;
        }
        instance = this;

        base.Awake();
    }
}
