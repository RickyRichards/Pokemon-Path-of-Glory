using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pokemon/Create New Species")]
public class PokemonSpecies : ScriptableObject
{
    [Header("Basic Info")]
    [SerializeField] private string speciesName;
    [SerializeField] private string pokedexEntry;
    [SerializeField] private EnergyTypes type1;
    [SerializeField] private EnergyTypes type2;
    [SerializeField] private int evolutionLevel;
    [SerializeField] private PokemonSpecies evolvesInto;

    [Header("Base Stats")]
    [SerializeField] private int baseHP;
    [SerializeField] private int baseATK;
    [SerializeField] private int baseSATK;
    [SerializeField] private int baseDEF;
    [SerializeField] private int baseSDEF;
    [SerializeField] private int baseSPD;

    [Header("Size & Biology")]
    [SerializeField] private float heightMeters;
    [SerializeField] private float weightKg;
    [SerializeField] private string diet;
    [SerializeField] private string habitat;

    [Header("Abilities")]
    [SerializeField] private List<AbilityBase> basicAbilities;
    [SerializeField] private List<AbilityBase> advancedAbilities;
    [SerializeField] private List<AbilityBase> highAbilities;

    [Header("Capabilities - Physical Power")]
    [SerializeField] private int power;

    [Header("Capabilities - Jumping & Movement")]
    [SerializeField] private int overland;
    [SerializeField] private int swim;
    [SerializeField] private int burrow;
    [SerializeField] private int sky;
    [SerializeField] private int levitate;
    [SerializeField] private int teleporter;
    [SerializeField] private JumpCapability jump;

    [Header("Special Capabilities")]
    [SerializeField] private List<string> specialCapabilities;
    [SerializeField] private List<string> naturewalkTypes;

    [Header("Pokémon Skills")]
    [SerializeField] private SkillData athletics = new SkillData(2, 0);
    [SerializeField] private SkillData acrobatics = new SkillData(2, 0);
    [SerializeField] private SkillData combat = new SkillData(2, 0);
    [SerializeField] private SkillData stealth = new SkillData(2, 0);
    [SerializeField] private SkillData perception = new SkillData(2, 0);
    [SerializeField] private SkillData focus = new SkillData(2, 0);

    [Header("Move Set")]
    [SerializeField] private List<LearnableMove> learnableMoves;

    // Public Getters
    public string Name => speciesName;
    public string PokedexEntry => pokedexEntry;
    public EnergyTypes Type1 => type1;
    public EnergyTypes Type2 => type2;
    public int EvolvesAtLevel => evolutionLevel;
    public PokemonSpecies EvolvesInto => evolvesInto;

    public int BaseHP => baseHP;
    public int BaseATK => baseATK;
    public int BaseSATK => baseSATK;
    public int BaseDEF => baseDEF;
    public int BaseSDEF => baseSDEF;
    public int BaseSPD => baseSPD;

    public string Diet => diet;
    public string Habitat => habitat;

    public List<AbilityBase> BasicAbilities => basicAbilities;
    public List<AbilityBase> AdvancedAbilities => advancedAbilities;
    public List<AbilityBase> HighAbilities => highAbilities;

    // Strength & Physical Power
    public int Power => power;
    // Movement Capabilities
    public int Overland => overland;
    public int Swim => swim;
    public int Burrow => burrow;
    public int Sky => sky;
    public int Levitate => levitate;
    public int Teleporter => teleporter;
    public JumpCapability Jump => jump;

    // Special Capabilities
    public List<string> SpecialCapabilities => specialCapabilities;
    public List<string> NaturewalkTypes => naturewalkTypes;

    public List<LearnableMove> LearnableMoves => learnableMoves;
}
// 🟢 Struct for Skill Dice & Modifier
[System.Serializable]
public struct SkillData
{
    [SerializeField] private int diceCount; 
    [SerializeField] private int modifier;  
    [SerializeField] private bool isSet;    

    public SkillData(int dice, int mod)
    {
        diceCount = dice;
        modifier = mod;
        isSet = true;
    }

    public int DiceCount => diceCount;
    public int Modifier => modifier;
    public bool IsSet => isSet;

    public string Display() => $"{diceCount}d6{(modifier >= 0 ? "+" : "")}{modifier}";
}

// 🟢 Struct for Jump Capability
[System.Serializable]
public struct JumpCapability
{
    public int horizontal;
    public int vertical;

    public JumpCapability(int horiz, int vert)
    {
        horizontal = horiz;
        vertical = vert;
    }

    public string Display() => $"{horizontal}/{vertical}";
}


// Represents a move and the level at which it is learned
[System.Serializable]
public class LearnableMove
{
    [SerializeField] private MoveBase moveBase; // The move itself
    [SerializeField] private int level; // Level at which Pokémon learns this move

    public MoveBase MoveBase => moveBase;
    public int Level => level;
}
