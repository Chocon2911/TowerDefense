using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterStatType
{
    //Stat
    MaxHealth,

    //Move
    MoveSpeed,

    //Attack
    Damage,
    AttackSpeed,
}

public abstract class CharacterStat : HuyMonoBehaviour
{
    protected Dictionary<CharacterStatType, float> stats = new();
    public Dictionary<CharacterStatType, float> Stats => stats;

    public Dictionary<CharacterStatType, float> StatsCurr = new();
    public Dictionary<CharacterStatType, Dictionary<Modifier, float>> StatsFixed = new();

    protected override void Awake()
    {
        base.Awake();
        this.DefaultStat();
    }

    //===========================================Modify Stat======================================
    protected virtual void IncreaseFlatFixed(CharacterStatType type, float value)
    {
        this.StatsFixed[type][Modifier.Flat] += value;
        this.GetFinalValue(type);
    }

    protected virtual void IncreasePercentFixed(CharacterStatType type, float value)
    {
        this.StatsFixed[type][Modifier.Percent] += value;
        this.GetFinalValue(type);
    }

    protected virtual void IncresaeCurr(CharacterStatType type, float value)
    {
        this.StatsCurr[type] += value;
    }

    protected virtual void GetFinalValue(CharacterStatType type)
    {
        this.stats[type] = this.StatsFixed[type][Modifier.Flat];
        this.stats[type] += this.stats[type] * this.StatsFixed[type][Modifier.Percent] / 100;
        this.stats[type] += this.StatsCurr[type];
    }

    protected virtual void GetAllFinalValue()
    {
        foreach(CharacterStatType type in this.StatsFixed.Keys)
        {
            GetFinalValue(type);
        }
    }

    //==============================================Other=========================================
    protected abstract void DefaultStat();
}