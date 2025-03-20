using System;
using System.Collections.Generic;
using UnityEngine;

// 🟢 Defines all status effects
public enum StatusEffectType
{
    None, Burn, Frozen, Paralysis, Poisoned, BadlyPoisoned, Sleep,
    Confused, Flinch, Rage, Infatuation, Cursed, Disabled, Suppressed,
    Stuck, Trapped, Vulnerable, Tripped, Slowed, Blindness, TotalBlindness
}

// 🟢 Handles applying & removing status effects
[System.Serializable]
public class StatusEffect
{
    public StatusEffectType EffectType;
    public int Duration; // -1 means persistent, otherwise # of turns
    public bool CanBeCuredBySwitching; // Volatile vs Persistent
    
    public StatusEffect(StatusEffectType type, int duration = -1, bool canBeCuredBySwitching = false)
    {
        EffectType = type;
        Duration = duration;
        CanBeCuredBySwitching = canBeCuredBySwitching;
    }
}
