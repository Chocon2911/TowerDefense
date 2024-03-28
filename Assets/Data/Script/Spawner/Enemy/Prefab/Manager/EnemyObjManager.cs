using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class EnemyObjManager : HuyMonoBehaviour
{
    [SerializeField] protected Rigidbody2D rb;
    public Rigidbody2D Rb => rb;

    [SerializeField] protected BoxCollider2D bodyCol;
    public BoxCollider2D BodyCol => bodyCol;

    [SerializeField] protected EnemyObjSO enemyObjSO;
    public EnemyObjSO EnemyObjSO => enemyObjSO;

    [SerializeField] protected EnemyObjStat enemyObjStat;
    public EnemyObjStat EnemyObjStat => enemyObjStat;

    [SerializeField] protected EnemyObjMove enemyObjMove;
    public EnemyObjMove EnemyObjMove => enemyObjMove;

    protected override void LoadComponent()
    {
        base.LoadComponent();
        this.LoadRigidbody();
        this.DefaultRigidbody();
        this.DefaultBodyCollider();
        this.LoadBodyCollider();
        this.LoadEnemyObjStat();
        this.LoadEnemyObjMove();
    }

    //=========================================Load Component======================================
    protected virtual void LoadRigidbody()
    {
        if (this.rb != null) return;
        this.rb = transform.GetComponent<Rigidbody2D>();
        Debug.Log(transform.name + ": LoadRigidbody", transform.gameObject);
    }

    protected virtual void LoadBodyCollider()
    {
        if (this.bodyCol != null) return;
        this.bodyCol = transform.GetComponent<BoxCollider2D>();
        this.bodyCol.isTrigger = false;
        Debug.Log(transform.name + ": LoadBodyCollider", transform.gameObject);
    }

    protected virtual void LoadEnemyObjStat()
    {
        if (this.enemyObjStat != null) return;
        this.enemyObjStat = transform.Find("Stat").GetComponent<EnemyObjStat>();
        Debug.Log(transform.name + ": LoadEnemyObjStat", transform.gameObject);
    }

    protected virtual void LoadEnemyObjMove()
    {
        if (this.enemyObjMove != null) return;
        this.enemyObjMove = transform.Find("Move").GetComponent<EnemyObjMove>();
        Debug.Log(transform.name + ": LoadEnemyObjMove", transform.gameObject);
    }

    //=============================================Other===========================================
    protected virtual void DefaultRigidbody()
    {
        if (this.rb == null) return;
        this.rb.isKinematic = false;
        this.rb.collisionDetectionMode = CollisionDetectionMode2D.Continuous;
        this.rb.gravityScale = 0;
        this.rb.freezeRotation = true;
        this.rb.interpolation = RigidbodyInterpolation2D.Interpolate;
    }

    protected virtual void DefaultBodyCollider()
    {
        if (this.bodyCol == null) return;
        this.bodyCol.isTrigger = false;
    }
}