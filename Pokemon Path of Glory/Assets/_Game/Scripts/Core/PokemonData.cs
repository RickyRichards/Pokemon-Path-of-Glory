using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PokemonData
{
    [Header("Basic Pokémon Info")]
    [SerializeField] private PokemonSpecies species;
    [SerializeField] private string nickname;
    [SerializeField] private int level = 1;
    [SerializeField] private int experience = 0;

    [Header("Nature")]
    [SerializeField] private Nature nature;

    [Header("Current Battle Stats")]
    [SerializeField] private int currentHp;
    [SerializeField] private List<MoveBase> moves = new List<MoveBase>();

    [Header("Stat Allocation (PTU)")]
    [SerializeField] private int attackPoints;
    [SerializeField] private int defPoints;
    [SerializeField] private int satkPoints;
    [SerializeField] private int sdefPoints;
    [SerializeField] private int spdPoints;

    [Header("PTU Combat Stages")]
    [SerializeField] private int attackStage = 0;
    [SerializeField] private int defenseStage = 0;
    [SerializeField] private int specialAttackStage = 0;
    [SerializeField] private int specialDefenseStage = 0;
    [SerializeField] private int speedStage = 0;

    [Header("Evasion Stats")]
    [SerializeField] private int physicalEvasion;
    [SerializeField] private int specialEvasion;
    [SerializeField] private int speedEvasion;

    [Header("Abilities")]
    [SerializeField] private List<AbilityBase> abilities = new List<AbilityBase>();

    [Header("Tutor Points & TM Moves")]
    [SerializeField] private int tutorPoints = 1; // Pokémon starts with 1 Tutor Point
    [SerializeField] private List<MoveBase> tmMoves = new List<MoveBase>(); // Holds TM moves

    [Header("Status Effects")]
    [SerializeField] private List<StatusEffect> statusEffects = new List<StatusEffect>();


    public PokemonSpecies Species => species;
    public string Nickname => nickname;
    public int Level => level;
    public int Experience => experience;
    public List<StatusEffect> StatusEffects => statusEffects;
    public List<MoveBase> Moves => moves;
    public List<MoveBase> TmMoves => tmMoves;
    public List<AbilityBase> Abilities => abilities;
    public Nature Nature => nature;

     // ✅ EXP Chart (Based on PTU 1.05)
    private static readonly Dictionary<int, int> ExpChart = new Dictionary<int, int>
    {
        {1, 0}, {2, 10}, {3, 20}, {4, 30}, {5, 40}, {6, 50}, {7, 60}, {8, 70}, {9, 80}, {10, 90},
        {11, 110}, {12, 135}, {13, 160}, {14, 190}, {15, 220}, {16, 250}, {17, 285}, {18, 320}, {19, 360}, {20, 400},
        {21, 460}, {22, 530}, {23, 600}, {24, 670}, {25, 745}, {26, 820}, {27, 900}, {28, 990}, {29, 1075}, {30, 1165},
        {31, 1260}, {32, 1355}, {33, 1455}, {34, 1555}, {35, 1660}, {36, 1770}, {37, 1880}, {38, 1995}, {39, 2110}, {40, 2230},
        {41, 2355}, {42, 2480}, {43, 2610}, {44, 2740}, {45, 2875}, {46, 3015}, {47, 3155}, {48, 3300}, {49, 3445}, {50, 3645},
        {51, 3850}, {52, 4060}, {53, 4270}, {54, 4485}, {55, 4705}, {56, 4930}, {57, 5160}, {58, 5390}, {59, 5625}, {60, 5865},
        {61, 6110}, {62, 6360}, {63, 6610}, {64, 6865}, {65, 7125}, {66, 7390}, {67, 7660}, {68, 7925}, {69, 8205}, {70, 8485},
        {71, 8770}, {72, 9060}, {73, 9350}, {74, 9645}, {75, 9945}, {76, 10250}, {77, 10560}, {78, 10870}, {79, 11185}, {80, 11505},
        {81, 11910}, {82, 12320}, {83, 12735}, {84, 13155}, {85, 13580}, {86, 14010}, {87, 14445}, {88, 14885}, {89, 15330}, {90, 15780},
        {91, 16235}, {92, 16695}, {93, 17160}, {94, 17630}, {95, 18105}, {96, 18585}, {97, 19070}, {98, 19560}, {99, 20055}, {100, 20555}
    };

    
    // ✅ Gain EXP
    public void GainExp(int amount)
    {
        experience += amount;
        Debug.Log($"{Species.Name} gained {amount} EXP!");

        while (level < 100 && experience >= GetExpForNextLevel(level))
        {
            LevelUp();
        }
    }

    // ✅ Get EXP required for next level
    private int GetExpForNextLevel(int currentLevel)
    {
        return ExpChart.ContainsKey(currentLevel + 1) ? ExpChart[currentLevel + 1] : int.MaxValue;
    }

    // ✅ Level Up!
    private void LevelUp()
    {
        level++;
        Debug.Log($"{Species.Name} leveled up to {level}!");

        LearnMovesAtLevel(level);
        CheckForEvolution();
    }

    private void CheckForEvolution(){
        if(species.EvolvesAtLevel >0 && level >= species.EvolvesAtLevel){
            Evolve();
        }
    }
    // ✅ Evolve the Pokémon
    private void Evolve()
    {
        if (species.EvolvesInto == null)
        {
            Debug.Log($"{Species.Name} does not have an evolution.");
            return;
        }

        Debug.Log($"{Species.Name} is evolving into {species.EvolvesInto.Name}!");

        species = species.EvolvesInto; // Change species
        level = species.EvolvesAtLevel; // Set new level requirement
        RecalculateStats(); // Update stats

        Debug.Log($"{Species.Name} has evolved!");
    }

    // ✅ Recalculate Stats (Called after Evolution)
    private void RecalculateStats()
    {
        currentHp = MaxHp;
        }
    // 🛠 Derived Stat Calculations
    public int MaxHp => level + (species.BaseHP * 3) + 10;
    public int Attack => ApplyCombatStage(species.BaseATK + attackPoints, attackStage);
    public int Defense => ApplyCombatStage(species.BaseDEF + defPoints, defenseStage);
    public int SpAttack => ApplyCombatStage(species.BaseSATK + satkPoints, specialAttackStage);
    public int SpDefense => ApplyCombatStage(species.BaseSDEF + sdefPoints, specialDefenseStage);
    public int Speed => ApplyCombatStage(species.BaseSPD + spdPoints, speedStage);

    // 🛠 Apply Combat Stage Multipliers
    private int ApplyCombatStage(int baseStat, int stage)
    {
        float[] stageMultipliers = { 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f, 1.2f, 1.4f, 1.6f, 1.8f, 2.0f, 2.2f };
        return Mathf.FloorToInt(baseStat * stageMultipliers[stage + 6]);
    }

    // 🛠 Evasion Calculation (Capped at +6)
    public int PhysicalEvasion => Mathf.Min(Defense / 5, 6);
    public int SpecialEvasion => Mathf.Min(SpDefense / 5, 6);
    public int SpeedEvasion => Mathf.Min(Speed / 5, 6);

    // 🛠 Modify Combat Stages
    public void ModifyCombatStage(string stat, int amount)
    {
        switch (stat.ToLower())
        {
            case "attack": attackStage = Mathf.Clamp(attackStage + amount, -6, 6); break;
            case "defense": defenseStage = Mathf.Clamp(defenseStage + amount, -6, 6); break;
            case "special attack": specialAttackStage = Mathf.Clamp(specialAttackStage + amount, -6, 6); break;
            case "special defense": specialDefenseStage = Mathf.Clamp(specialDefenseStage + amount, -6, 6); break;
            case "speed": speedStage = Mathf.Clamp(speedStage + amount, -6, 6); break;
        }
    }

    // 🛠 Apply Nature Effects
    public void ApplyNature()
    {
        Dictionary<Nature, (string raise, string lower)> natureEffects = new Dictionary<Nature, (string, string)>
        {
            { Nature.Cuddly, ("HP", "Attack") },
            { Nature.Distracted, ("HP", "Defense") },
            { Nature.Proud, ("HP", "Special Attack") },
            { Nature.Decisive, ("HP", "Special Defense") },
            { Nature.Patient, ("HP", "Speed") },
            { Nature.Desperate, ("Attack", "HP") },
            { Nature.Lonely, ("Attack", "Defense") },
            { Nature.Adamant, ("Attack", "Special Attack") },
            { Nature.Naughty, ("Attack", "Special Defense") },
            { Nature.Brave, ("Attack", "Speed") },
            { Nature.Stark, ("Defense", "HP") },
            { Nature.Bold, ("Defense", "Attack") },
            { Nature.Impish, ("Defense", "Special Attack") },
            { Nature.Lax, ("Defense", "Special Defense") },
            { Nature.Relaxed, ("Defense", "Speed") },
            { Nature.Curious, ("Special Attack", "HP") },
            { Nature.Modest, ("Special Attack", "Attack") },
            { Nature.Mild, ("Special Attack", "Defense") },
            { Nature.Rash, ("Special Attack", "Special Defense") },
            { Nature.Quiet, ("Special Attack", "Speed") },
            { Nature.Dreamy, ("Special Defense", "HP") },
            { Nature.Calm, ("Special Defense", "Attack") },
            { Nature.Gentle, ("Special Defense", "Defense") },
            { Nature.Careful, ("Special Defense", "Special Attack") },
            { Nature.Sassy, ("Special Defense", "Speed") },
            { Nature.Skittish, ("Speed", "HP") },
            { Nature.Timid, ("Speed", "Attack") },
            { Nature.Hasty, ("Speed", "Defense") },
            { Nature.Jolly, ("Speed", "Special Attack") },
            { Nature.Naive, ("Speed", "Special Defense") },
        };

        if (natureEffects.ContainsKey(nature))
        {
            string raiseStat = natureEffects[nature].raise;
            string lowerStat = natureEffects[nature].lower;

            if (raiseStat == "HP") attackPoints++;
            else if (raiseStat == "Attack") attackPoints++;
            else if (raiseStat == "Defense") defPoints++;
            else if (raiseStat == "Special Attack") satkPoints++;
            else if (raiseStat == "Special Defense") sdefPoints++;
            else if (raiseStat == "Speed") spdPoints++;

            if (lowerStat == "HP") attackPoints--;
            else if (lowerStat == "Attack") attackPoints--;
            else if (lowerStat == "Defense") defPoints--;
            else if (lowerStat == "Special Attack") satkPoints--;
            else if (lowerStat == "Special Defense") sdefPoints--;
            else if (lowerStat == "Speed") spdPoints--;
        }
    }

     // 🟢 Learn Moves at Level Up
    public void LearnMovesAtLevel(int newLevel, Action<MoveBase> onMoveLearnPrompt = null)
    {
        foreach (var learnableMove in species.LearnableMoves)
        {
            if (learnableMove.Level == newLevel)
            {
                TryLearnMove(learnableMove.MoveBase, onMoveLearnPrompt);
            }
        }
    }

    // 🟢 Attempt to Learn a Move with Player Choice
    public void TryLearnMove(MoveBase newMove, Action<MoveBase> onMoveLearnPrompt)
    {
        if (moves.Count < 6)
        {
            moves.Add(newMove);
            Debug.Log($"{Species.Name} learned {newMove.MoveName}!");
        }
        else
        {
            Debug.Log($"{Species.Name} wants to learn {newMove.MoveName}, but it already knows 6 moves!");
            onMoveLearnPrompt?.Invoke(newMove); // 🔥 Calls a UI prompt for player choice
        }
    }
        // 🟢 Initialize Pokémon
    public void Initialize()
    {
        if (species.BasicAbilities.Count > 0)
        {
            int randomIndex = UnityEngine.Random.Range(0, species.BasicAbilities.Count);
            abilities.Add(species.BasicAbilities[randomIndex]);
        }

        LearnMovesAtLevel(level); // ✅ No more missing argument error!
    }

    // 🟢 Forget a Move and Learn a New One (Player Choice)
    public void ReplaceMove(MoveBase moveToForget, MoveBase newMove)
    {
        if (moves.Contains(moveToForget))
        {
            moves.Remove(moveToForget);
            moves.Add(newMove);
            Debug.Log($"{Species.Name} forgot {moveToForget.MoveName} and learned {newMove.MoveName}!");
        }
    }

    // 🟢 Learn a Move (Handles Move Limit)
    public void LearnMove(MoveBase newMove)
    {
        if (moves.Count >= 6)
        {
            Debug.Log($"Move limit reached! {Species.Name} must forget a move to learn {newMove.MoveName}.");
            // You can add a system here where the player chooses which move to forget
            return;
        }
        moves.Add(newMove);
        Debug.Log($"{Species.Name} learned {newMove.MoveName}!");
    }

    // 🟢 Forget a Move
    public void ForgetMove(MoveBase moveToForget)
    {
        if (moves.Contains(moveToForget))
        {
            moves.Remove(moveToForget);
            Debug.Log($"{Species.Name} forgot {moveToForget.MoveName}.");
        }
    }

    // 🟢 Learn TM Moves (No Move Limit, Separate List)
    public void LearnTMMove(MoveBase tmMove)
    {
        if (!tmMoves.Contains(tmMove))
        {
            tmMoves.Add(tmMove);
            Debug.Log($"{Species.Name} learned {tmMove.MoveName} via TM!");
        }
    }

    // 🟢 Forget TM Moves
    public void ForgetTMMove(MoveBase tmMove)
    {
        if (tmMoves.Contains(tmMove))
        {
            tmMoves.Remove(tmMove);
            Debug.Log($"{Species.Name} forgot {tmMove.MoveName} (TM).");
        }
    }

// ✅ Modify ApplyStatusEffect() to check type immunities
    public void ApplyStatusEffect(StatusEffectType effectType)
    {
        if (IsImmuneToStatus(effectType))
        {
            Debug.Log($"{Species.Name} is immune to {effectType}!");
            return;
        }

        if (HasStatusEffect(effectType))
        {
            Debug.Log($"{Species.Name} is already affected by {effectType}!");
            return;
        }

        int duration = GetDefaultDuration(effectType);
        bool canBeCuredBySwitching = IsVolatileEffect(effectType);
        statusEffects.Add(new StatusEffect(effectType, duration, canBeCuredBySwitching));

        Debug.Log($"{Species.Name} is now {effectType}!");
    }

    // ✅ Check if Pokémon is immune to the status effect
    private bool IsImmuneToStatus(StatusEffectType effectType)
    {
        EnergyTypes primaryType = Species.Type1;
        EnergyTypes secondaryType = Species.Type2;

        return effectType switch
        {
            StatusEffectType.Burn => primaryType == EnergyTypes.Fire || secondaryType == EnergyTypes.Fire,
            StatusEffectType.Paralysis => primaryType == EnergyTypes.Electric || secondaryType == EnergyTypes.Electric,
            StatusEffectType.Poisoned => primaryType == EnergyTypes.Poison || secondaryType == EnergyTypes.Poison ||
            primaryType == EnergyTypes.Steel || secondaryType == EnergyTypes.Steel,
            StatusEffectType.Frozen => primaryType == EnergyTypes.Ice || secondaryType == EnergyTypes.Ice,
            StatusEffectType.Stuck => primaryType == EnergyTypes.Ghost || secondaryType == EnergyTypes.Ghost,
            StatusEffectType.Trapped => primaryType == EnergyTypes.Ghost || secondaryType == EnergyTypes.Ghost,
            _ => false
        };
    }

    // 🟢 Check if Pokémon already has a status effect
    public bool HasStatusEffect(StatusEffectType effectType)
    {
        return statusEffects.Exists(effect => effect.EffectType == effectType);
    }

    // 🟢 Remove a Status Effect
    public void RemoveStatusEffect(StatusEffectType effectType)
    {
        statusEffects.RemoveAll(effect => effect.EffectType == effectType);
        Debug.Log($"{Species.Name} is no longer {effectType}.");
    }

    // 🟢 Auto-remove volatile effects when switching out
    public void OnSwitchOut()
    {
        statusEffects.RemoveAll(effect => effect.CanBeCuredBySwitching);
        Debug.Log($"{Species.Name} is switched out and cured of volatile effects.");
    }

    // 🟢 Clear all effects when fainting
    public void OnFaint()
    {
        statusEffects.Clear();
        Debug.Log($"{Species.Name} fainted! All status effects are removed.");
    }

    // 🟢 Handle end-of-turn status effects
    public void EndOfTurnStatusEffects()
    {
        foreach (var effect in statusEffects)
        {
            if (effect.EffectType == StatusEffectType.Burn || effect.EffectType == StatusEffectType.Poisoned)
            {
                int tickDamage = MaxHp / 10; // Tick of HP = 10% of Max HP
                currentHp = Mathf.Max(currentHp - tickDamage, 1);
                Debug.Log($"{Species.Name} took {tickDamage} damage from {effect.EffectType}!");
            }
            
            // Reduce duration for volatile effects
            if (effect.Duration > 0)
            {
                effect.Duration--;
                if (effect.Duration <= 0)
                {
                    RemoveStatusEffect(effect.EffectType);
                }
            }
        }
    }

    // 🟢 Returns default duration of volatile effects
    private int GetDefaultDuration(StatusEffectType effectType)
    {
        return effectType switch
        {
            StatusEffectType.Confused => 3,
            StatusEffectType.Sleep => UnityEngine.Random.Range(1, 3),
            StatusEffectType.Rage => 2,
            _ => -1, // Persistent effects (Burn, Paralysis) last indefinitely
        };
    }

    // 🟢 Check if an effect is volatile
    private bool IsVolatileEffect(StatusEffectType effectType)
    {
        return effectType switch
        {
            StatusEffectType.Confused => true,
            StatusEffectType.Sleep => true,
            StatusEffectType.Flinch => true,
            StatusEffectType.Rage => true,
            _ => false, // Persistent effects cannot be cured by switching
        };
    }
}
