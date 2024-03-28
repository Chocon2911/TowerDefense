using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyObjMove : HuyMonoBehaviour
{
    [SerializeField] protected EnemyObjManager enemyObjManager;
    public EnemyObjManager EnemyObjManager => enemyObjManager;

    //Stat
    protected float moveSpeed => enemyObjManager.EnemyObjStat.Stats[CharacterStatType.MoveSpeed];

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadEnemyObjManager();
    }

    //=============================================Move===========================================
    protected virtual void Move()
    {
        
    }

    //========================================Load Component======================================
    protected virtual void LoadEnemyObjManager()
    {
        if (this.enemyObjManager != null) return;
        this.enemyObjManager = transform.parent.GetComponent<EnemyObjManager>();
        Debug.Log(transform.name + ": LoadEnemyObjManager", transform.gameObject);
    }
}
