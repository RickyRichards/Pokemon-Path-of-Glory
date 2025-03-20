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

    [Header("Tutor Points")]
    [SerializeField] private int tutorPoints = 1; // Pokémon starts with 1 Tutor Point

    public PokemonSpecies Species => species;
    public string Nickname => nickname;
    public int Level => level;
    public int Experience => experience;
    public List<MoveBase> Moves => moves;
    public List<AbilityBase> Abilities => abilities;
    public Nature Nature => nature;

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

    // 🛠 Initialize Pokémon (Set Abilities and Nature Effects)
    public void Initialize()
    {
        ApplyNature();
        abilities.Add(species.BasicAbilities[Random.Range(0, species.BasicAbilities.Count)]);
    }
}
