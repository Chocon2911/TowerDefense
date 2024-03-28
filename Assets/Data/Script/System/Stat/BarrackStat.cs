using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BarrackStatType
{
    //Spawn
    SpawnCooldown,

    //Stat
    Level,
}

public enum BarrackStatListType
{
    SpawnCooldownLevels,
}

public abstract class BarrackStat : HuyMonoBehaviour
{
    protected Dictionary<BarrackStatType, float> stats = new();
    public Dictionary<BarrackStatType, float> Stats => stats;

    protected Dictionary<BarrackStatListType, List<float>> statsList;

    public Dictionary<BarrackStatType, float> StatsCurr;
    public Dictionary<BarrackStatType, Dictionary<Modifier, float>> StatsFixed;

    //=======================================Modify Curr==========================================
    public virtual void IncreaseCurr(BarrackStatType type, float value)
    {
        this.StatsCurr[type] += value;
    }

    //=======================================Modify Fixed=========================================
    public virtual void IncreaseFlatFixed(BarrackStatType type, float value)
    {
        Modifier modifier = Modifier.Flat;
        this.StatsFixed[type][modifier] += value; 
    }

    public virtual void IncreasePercentFixed(BarrackStatType type, float value)
    {
        Modifier modifier = Modifier.Percent;
        this.StatsFixed[type][modifier] += value;
    }

    //=======================================Modify Stats=========================================
    protected virtual void GetFinalValue(BarrackStatType type)
    {
        this.stats[type] = this.StatsFixed[type][Modifier.Flat];
        this.stats[type] += this.stats[type] * this.StatsFixed[type][Modifier.Percent] / 100;
        this.stats[type] += this.StatsCurr[type];
    }

    protected virtual void GetAllFinalValue()
    {
        foreach(BarrackStatType type in this.StatsFixed.Keys)
        {
            this.GetFinalValue(type);
        }
    }

    //==============================================Other=========================================
    protected abstract void DefaultStat();
}
