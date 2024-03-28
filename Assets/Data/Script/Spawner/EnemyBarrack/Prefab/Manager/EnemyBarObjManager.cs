using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyBarObjManager : HuyMonoBehaviour
{
    [SerializeField] protected EnemyBarObjSpawnEnemy spawnEnemy;
    public EnemyBarObjSpawnEnemy SpawnEnemy => spawnEnemy;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadSpawnEnemy();
    }

    //=======================================Load Component=======================================
    protected virtual void LoadSpawnEnemy()
    {
        if (this.spawnEnemy != null) return;
        this.spawnEnemy = transform.Find("SpawnEnemy").GetComponent<EnemyBarObjSpawnEnemy>();
        Debug.Log(transform.name + ": LoadSpawnEnemy", transform.gameObject);
    }
}
