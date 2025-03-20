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
    [SerializeField] private PokemonSpecies evolvedForm;

    [Header("Base Stats")]
    [SerializeField] private int baseHP;
    [SerializeField] private int baseATK;
    [SerializeField] private int baseSATK;
    [SerializeField] private int baseDEF;
    [SerializeField] private int baseSDEF;
    [SerializeField] private int baseSPD;

    [Header("Size & Biology")]
    [SerializeField] private float height; // In meters
    [SerializeField] private float weight; // In kilograms
    [SerializeField] private string diet;
    [SerializeField] private string habitat;

    [Header("Abilities")]
    [SerializeField] private List<AbilityBase> basicAbilities;
    [SerializeField] private List<AbilityBase> advancedAbilities;
    [SerializeField] private List<AbilityBase> highAbilities;

    [Header("Capabilities")]
    [SerializeField] private List<string> capabilities;

    [Header("Skills")]
    [SerializeField] private int athletics;
    [SerializeField] private int acrobatics;
    [SerializeField] private int combat;
    [SerializeField] private int stealth;
    [SerializeField] private int perception;
    [SerializeField] private int focus;

    [Header("Move Set")]
    [SerializeField] private List<LearnableMove> learnableMoves;

    // Properties for external access
    public string SpeciesName => speciesName;
    public string PokedexEntry => pokedexEntry;
    public EnergyTypes Type1 => type1;
    public EnergyTypes Type2 => type2;
    public int EvolutionLevel => evolutionLevel;
    public PokemonSpecies EvolvedForm => evolvedForm;

    public int BaseHP => baseHP;
    public int BaseATK => baseATK;
    public int BaseSATK => baseSATK;
    public int BaseDEF => baseDEF;
    public int BaseSDEF => baseSDEF;
    public int BaseSPD => baseSPD;

    public float Height => height;
    public float Weight => weight;
    public string Diet => diet;
    public string Habitat => habitat;

    public List<AbilityBase> BasicAbilities => basicAbilities;
    public List<AbilityBase> AdvancedAbilities => advancedAbilities;
    public List<AbilityBase> HighAbilities => highAbilities;
    
    public List<string> Capabilities => capabilities;

    public int Athletics => athletics;
    public int Acrobatics => acrobatics;
    public int Combat => combat;
    public int Stealth => stealth;
    public int Perception => perception;
    public int Focus => focus;

    public List<LearnableMove> LearnableMoves => learnableMoves;
}

// Represents a move and the level at which it is learned
[System.Serializable]
public class LearnableMove
{
    public MoveBase moveBase; // The move itself
    public int level; // Level at which Pokémon learns this move
}
