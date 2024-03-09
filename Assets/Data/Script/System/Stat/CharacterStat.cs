using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stat
{
    Health,
    Damage,
    MoveSpeed,
    AttackCooldown,
}

public interface StatIF
{
    public Stat Type { get; }
    public Stat Stat { get; }
}

public enum StatModifier
{
    Increase,
    IncreaseMultipler,
}

public interface StatModifierIF
{
    public StatModifier Type { get; }
    public abstract void Add(float value);
}

public class CharacterStat : MonoBehaviour
{

}
