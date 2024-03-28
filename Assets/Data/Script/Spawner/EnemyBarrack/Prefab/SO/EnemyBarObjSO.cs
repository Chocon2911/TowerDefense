using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EnemyBarrack", menuName = "SO/EnemyBar/Obj/Stat")]
public class EnemyBarObjSO : ScriptableObject
{
    [Header("Spawn")]
    [SerializeField] protected float spawnCooldown = 1f;
    public float SpawnCooldown => spawnCooldown;

    [Header("Level")]
    [SerializeField] protected float level;
    public float Level => level;

    [SerializeField] protected List<float> spawnCooldownlevels;
    public List<float> SpawnCooldownlevels => spawnCooldownlevels;
}
