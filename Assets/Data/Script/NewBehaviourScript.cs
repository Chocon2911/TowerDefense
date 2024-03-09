using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StatType
{
    AttackDamage,
    AttackSpeed,
    Health,
    Mana,
}

public interface IStat
{
    public StatType Type { get; }
    public float Value { get; }
}

public class AttackDamageStat : IStat
{
    public StatType Type => StatType.AttackDamage;

    private float _value;
    public float Value => _value;
}

public enum StatModifierType
{
    IncreaseFlat,
    DecreasePercentage,
}

public interface IStatModifier
{
    public StatModifierType Type { get; }
    public abstract float Apply(float input);
}

public class IncreaseFlatModifier : IStatModifier
{
    public StatModifierType Type => StatModifierType.IncreaseFlat;

    private float _value;

    public IncreaseFlatModifier(float value)
    {
        _value = value;
    }

    public float Apply(float input)
    {
        return input += _value;
    }
}

/// <summary>
/// Cái này Mono hay gì cũng được, miễn là có lifecycle tương tự như mono là đc
/// </summary>
public class EntityStatController : MonoBehaviour
{
    public Dictionary<StatType, IStat> Stats = new();
    public Dictionary<StatType, List<IStatModifier>> StatModifiers = new();

    private void Update()
    {
        // Xử lý logic xóa statmodifier sau bao nhiêu giây hay gì đấy
    }


    public void InitStats(List<IStat> stats)
    {
        foreach (var stat in stats)
        {
            Stats.Add(stat.Type, stat);
        }
    }

    public void AddModifier(StatType type, IStatModifier modifier)
    {
        StatModifiers[type].Add(modifier);
    }

    public float GetStatBaseValue(StatType type)
    {
        return Stats[type].Value;
    }
    
    public float GetStatFinalValue(StatType type)
    {
        return GetFinalValue(type);
    }

    private float GetFinalValue(StatType type)
    {
        var finalValue = Stats[type].Value;
        if (StatModifiers.TryGetValue(type, out var modifiers))
        {
            foreach (var modifier in modifiers)
            {
                finalValue = modifier.Apply(finalValue);
            }
        }
        return finalValue;
    }
}
