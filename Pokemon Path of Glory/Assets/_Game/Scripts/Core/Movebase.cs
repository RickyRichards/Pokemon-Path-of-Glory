using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pokemon/Create New Move")]
public class MoveBase : ScriptableObject
{
    [Header("Move Info")]
    [SerializeField] private string moveName;
    [TextArea]
    [SerializeField] private string description;
    [SerializeField] private EnergyTypes type;
    [SerializeField] private MoveCategory category;
    [SerializeField] private MoveFrequency frequency; // Frequency restored
    [SerializeField] private int accuracyCheck;
    [SerializeField] private int damageBase; // Determines roll & flat damage
    [SerializeField] private int flatDamage; // Alternative static damage
    [SerializeField] private string moveRange; // Range description
    [TextArea]
    [SerializeField] private string effect; // Additional effects (e.g., burns target on 18+)
    [SerializeField] private string contestType; // Beauty, Cool, etc.
    [SerializeField] private string contestEffect; // Contest battle effect
    [SerializeField] private List<string> keywords; // Keywords like "Firestarter", "Sonic"

    public string MoveName => moveName;
    public string Description => description;
    public EnergyTypes Type => type;
    public MoveCategory Category => category;
    public MoveFrequency Frequency => frequency;
    public int AccuracyCheck => accuracyCheck;
    public int DamageBase => damageBase;
    public int FlatDamage => flatDamage;
    public string MoveRange => moveRange;
    public string Effect => effect;
    public string ContestType => contestType;
    public string ContestEffect => contestEffect;
    public List<string> Keywords => keywords;

    // 🟢 Function to get the rolled damage formula based on Damage Base
    public string GetRolledDamage()
    {
        return DamageBaseToDice(damageBase);
    }

    // 🟢 Full Damage Base to Dice Formula Table (DB 1 - DB 28)
    private string DamageBaseToDice(int db)
    {
        Dictionary<int, string> damageTable = new Dictionary<int, string>
        {
            { 1, "1d6+1" }, { 2, "1d6+3" }, { 3, "1d6+5" },
            { 4, "1d8+6" }, { 5, "1d8+8" }, { 6, "2d6+8" },
            { 7, "2d6+10" }, { 8, "2d8+10" }, { 9, "2d10+10" },
            { 10, "3d8+10" }, { 11, "3d10+10" }, { 12, "3d12+10" },
            { 13, "4d10+10" }, { 14, "4d10+15" }, { 15, "4d10+20" },
            { 16, "5d10+20" }, { 17, "5d12+25" }, { 18, "6d12+25" },
            { 19, "6d12+30" }, { 20, "6d12+35" }, { 21, "6d12+40" },
            { 22, "6d12+45" }, { 23, "6d12+50" }, { 24, "6d12+55" },
            { 25, "6d12+60" }, { 26, "7d12+65" }, { 27, "8d12+70" },
            { 28, "8d12+80" }
        };

        return damageTable.ContainsKey(db) ? damageTable[db] : "Unknown";
    }
}

// 🟢 Enum for Move Categories
public enum MoveCategory
{
    Physical,
    Special,
    Status
}

// 🟢 Enum for Move Frequency
public enum MoveFrequency
{
    AtWill,  // Can be used every turn
    EOT,     // Every other turn
    Scene1,  // Once per scene
    Scene2,  // Twice per scene
    Scene3,  // Three times per scene
    Daily1,  // Once per day
    Daily2,  // Twice per day
    Daily3   // Three times per day
}
