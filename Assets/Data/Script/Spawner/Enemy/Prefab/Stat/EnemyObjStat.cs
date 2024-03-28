using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjStat : CharacterStat
{
    protected EnemyObjManager enemyObjManager;
    public EnemyObjManager EnemyObjManager => enemyObjManager;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyObjManager();
    }

    //===========================================Load Component===================================
    protected virtual void LoadEnemyObjManager()
    {
        if (this.enemyObjManager != null) return;
        this.enemyObjManager = transform.parent.GetComponent<EnemyObjManager>();
        Debug.Log(transform.name + ": LoadEnemyObjManager", transform.gameObject);
    }

    //===============================================Other========================================
    protected override void DefaultStat()
    {
        if (this.enemyObjManager.EnemyObjSO == null) Debug.LogError(transform.name + ": No SO", transform.gameObject);

        //Stat
        this.StatsFixed[CharacterStatType.MaxHealth][Modifier.Flat] = this.enemyObjManager.EnemyObjSO.Health;
        this.StatsCurr[CharacterStatType.MaxHealth] = 0;

        //Attack
        this.StatsFixed[CharacterStatType.Damage][Modifier.Flat] = this.enemyObjManager.EnemyObjSO.Damage;
        this.StatsFixed[CharacterStatType.AttackSpeed][Modifier.Flat] = this.enemyObjManager.EnemyObjSO.AttackSpeed;

        this.StatsCurr[CharacterStatType.Damage] = 0;
        this.StatsCurr[CharacterStatType.AttackSpeed] = 0;

        //Move
        this.StatsFixed[CharacterStatType.MoveSpeed][Modifier.Flat] = this.enemyObjManager.EnemyObjSO.MoveSpeed;

        this.StatsCurr[CharacterStatType.MoveSpeed] = 0;
    }
}
