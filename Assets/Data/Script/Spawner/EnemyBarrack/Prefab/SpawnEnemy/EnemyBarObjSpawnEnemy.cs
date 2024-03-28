using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarObjSpawnEnemy : HuyMonoBehaviour
{
    [SerializeField] protected EnemyBarObjManager enemyBarObjManager;
    public EnemyBarObjManager EnemyBarObjManager => enemyBarObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyBarObjManager();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadEnemyBarObjManager()
    {
        if (this.enemyBarObjManager != null) return;
        this.enemyBarObjManager = transform.parent.GetComponent<EnemyBarObjManager>();
        Debug.Log(transform.name + ": LoadEnemyBarObjManager", transform.gameObject);
    }

    //========================================Spawn Enemy=========================================
    protected virtual void SpawnEnemy(string name)
    {
        Vector2 spawnPos = transform.parent.position;
        Quaternion spawnRot = Quaternion.Euler(0, 0, 0);
        EnemySpawner.Instance.Spawn(name, spawnPos, spawnRot);
    }
}
