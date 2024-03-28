using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBarObjStat : BarrackStat
{
    [SerializeField] protected EnemyBarObjManager enemyBarObjManager;
    public EnemyBarObjManager EnemyBarObjManager => enemyBarObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
    }

    //========================================Load Component======================================
    protected virtual void LoadEnemyBarObjManager()
    {
        if (this.enemyBarObjManager != null) return;
        this.enemyBarObjManager = transform.parent.GetComponent<EnemyBarObjManager>();
        Debug.Log(transform.name + ": LoadEnemyBarObjManager", transform.gameObject);
    }

    //============================================Other===========================================
    protected override void DefaultStat()
    {

        //Spawn
        this.StatsFixed[BarrackStatType.SpawnCooldown][Modifier.Flat] = 0; //SO

        this.StatsCurr[BarrackStatType.SpawnCooldown] = 0;

        //Stat
        this.StatsFixed[BarrackStatType.Level][Modifier.Flat] = 1; //SO

        this.StatsCurr[BarrackStatType.Level] = 0;
    }
}
