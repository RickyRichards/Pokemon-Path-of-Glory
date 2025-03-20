using UnityEngine;

[CreateAssetMenu(menuName = "Pokemon/Create New Move")]
public class MoveBase : ScriptableObject
{
    [Header("Basic Info")]
    [SerializeField] private string moveName;
    [TextArea] [SerializeField] private string description;
    [SerializeField] private EnergyTypes type;
    [SerializeField] private MoveCategory category; // Physical, Special, Status
    [SerializeField] private string frequency; // At-Will, EOT, Scene

    [Header("Move Mechanics")]
    [SerializeField] private int accuracyCheck;
    [SerializeField] private int damageBase;
    [SerializeField] private int flatDamage;
    [SerializeField] private bool alwaysHits; // Moves like Swift

    [Header("Rollable Damage")]
    [SerializeField] private int diceRollValue;
    [SerializeField] private int numberOfDice;

    [Header("Move Effects")]
    [SerializeField] private MoveEffect effect; // Burn, Sleep, Paralyze, etc.
    [SerializeField] private int effectChance; // Chance of status effect activation (e.g., Ember burns on 18+)
    [SerializeField] private string specialEffect; // Any unique effects (e.g., "Hits multiple times")

    [Header("Move Range")]
    [SerializeField] private string range; // E.g., "Melee", "Line 4", "Blast 3"

    [Header("Contest Info")]
    [SerializeField] private string contestType;
    [SerializeField] private string contestEffect;

    // Public Getters
    public string MoveName => moveName;
    public string Description => description;
    public EnergyTypes Type => type;
    public MoveCategory Category => category;
    public string Frequency => frequency;
    public int AccuracyCheck => accuracyCheck;
    public int DamageBase => damageBase;
    public int FlatDamage => flatDamage;
    public bool AlwaysHits => alwaysHits;
    public int DiceRollValue => diceRollValue;
    public int NumberOfDice => numberOfDice;
    public MoveEffect Effect => effect;
    public int EffectChance => effectChance;
    public string SpecialEffect => specialEffect;
    public string Range => range;
    public string ContestType => contestType;
    public string ContestEffect => contestEffect;

    // Damage Calculation (Based on PTU Damage Charts)
    public int CalculateDamage()
    {
        if (flatDamage > 0)
        {
            return flatDamage;
        }
        return (numberOfDice * Random.Range(1, diceRollValue + 1)); // Roll dice
    }

    // Accuracy Check Roll
    public bool RollAccuracy(int evasion)
    {
        if (alwaysHits) return true; // Moves like Swift auto-hit

        int roll = Random.Range(1, 21); // Simulate d20 roll
        return roll + AccuracyCheck >= evasion; // Compare with opponent's evasion
    }
}

// Move Categories (Physical, Special, or Status)
public enum MoveCategory
{
    Physical,
    Special,
    Status
}

// Move Effects (Possible Status Conditions or Special Effects)
public enum MoveEffect
{
    None,
    Burn,
    Freeze,
    Paralysis,
    Poison,
    Sleep,
    Confusion,
    Flinch
}
