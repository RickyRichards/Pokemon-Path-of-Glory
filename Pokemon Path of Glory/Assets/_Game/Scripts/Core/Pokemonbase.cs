using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="Pokemon/Crete New Pokemon")]
public class Pokemonbase : ScriptableObject
{
    [SerializeField] string name;
    [TextArea]
    [SerializeField] string description;
    
    [SerializeField] GameObject model;

    //tpyes
    [SerializeField] EnergyTypes type1;
    [SerializeField] EnergyTypes type2;

    //stats
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;

    [SerializeField] List<LearnableMove> learnableMoves;
    
    public string Name => name;
    public string Description => description;
    public GameObject Model => model;

    public int MaxHp => maxHp;
    public int Attack => attack;
    public int Defense => defense;
    public int SpAttack => spAttack;
    public int SpDefense => spDefense;
    public int Speed => speed;
    public List<LearnableMove> LearnableMoves => learnableMoves;
}

[System.Serializable]
public class LearnableMove{
    [SerializeField] Movebase movebase;
    [SerializeField] int level;

    public Movebase Movebase => movebase;
    public int Level => level;
}
