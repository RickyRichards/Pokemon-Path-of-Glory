using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "Pokemon/Create New Ability")]
public class AbilityBase : ScriptableObject
{
    [Header("Ability Info")]
    [SerializeField] private string abilityName;

    [TextArea]
    [SerializeField] private string description;

    [SerializeField] private AbilityFrequency frequency;  // At-Will, Scene, Daily, Static
    [SerializeField] private List<AbilityActionType> actionTypes; // Shift, Interrupt, etc.
    
    [TextArea]
    [SerializeField] private string trigger;  // Conditions for activation (if any)

    [SerializeField] private List<AbilityKeyword> keywords;  // Connection, Immune, etc.

    public string AbilityName => abilityName;
    public string Description => description;
    public AbilityFrequency Frequency => frequency;
    public List<AbilityActionType> ActionTypes => actionTypes;
    public string Trigger => trigger;
    public List<AbilityKeyword> Keywords => keywords;
}

// 🟢 Enum for Ability Frequency
public enum AbilityFrequency
{
    Static,    // Always active
    AtWill,    // Can be used any time
    Scene,     // Once per battle scene
    Scene2,    // Twice per battle scene
    Scene3,    // Three times per battle scene
    Daily1,    // Once per day
    Daily2,    // Twice per day
    Daily3     // Three times per day
}

// 🟢 Enum for Ability Action Types
public enum AbilityActionType
{
    None,
    Free,
    Standard,
    Swift,      // Takes a Swift Action
    Shift,      // Takes a Shift Action
    Interrupt,  // Used as a Reaction
    Extended    // Requires extra time
}

// 🟢 Enum for Ability Keywords
public enum AbilityKeyword
{
    None,
    Connection,  // Pokémon learns a move permanently
    Immune,      // Cannot be affected by a status effect
    LastChance,  // +5 Damage Rolls (or +10 when below 1/3 HP)
    Pickup       // Finds random items
}
