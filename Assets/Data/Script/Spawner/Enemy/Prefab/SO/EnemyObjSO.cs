using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Enemy_", menuName = "SO/Enemy/Obj/Stat")]
public class EnemyObjSO : ScriptableObject
{
    //============================================Stat============================================
    [Header("Stat")]
    [SerializeField] protected float health = 3;
    public float Health => health;

    //===========================================Attack===========================================
    [Header("Attack")]
    [SerializeField] protected float damage;
    public float Damage => damage;

    [SerializeField] protected float attackSpeed;
    public float AttackSpeed => attackSpeed;

    //============================================Move============================================
    [Header("Move")]
    [SerializeField] protected float moveSpeed = 5;
    public float MoveSpeed => moveSpeed;
}
