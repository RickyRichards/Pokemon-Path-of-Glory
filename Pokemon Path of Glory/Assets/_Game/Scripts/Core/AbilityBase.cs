using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Pokemon/Create New Ability")]
public class AbilityBase : ScriptableObject
{
    [Header("Ability Info")]
    [SerializeField] private string abilityName;
    [TextArea] [SerializeField] private string description;

    public string AbilityName => abilityName;
    public string Description => description;

    // Virtual methods that can be overridden for specific abilities
    public virtual void OnBattleStart(PokemonData pokemon) { } // Abilities like Intimidate
    public virtual void OnHit(PokemonData pokemon, PokemonData attacker) { } // Abilities like Static
    public virtual void OnTurnEnd(PokemonData pokemon) { } // Abilities like Rain Dish
}
