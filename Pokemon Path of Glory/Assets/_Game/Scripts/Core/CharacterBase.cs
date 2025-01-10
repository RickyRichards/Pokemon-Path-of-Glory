using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName ="Pokemon/Create Character")]
public class CharacterBase: ScriptableObject
{
    //gender
    [SerializeField]
    private bool male, female;
    
    //name
    [SerializeField]
    private string name;
    
    //model
    [SerializeField] GameObject model;

    //stats
    [SerializeField] int maxHp;
    [SerializeField] int attack;
    [SerializeField] int defense;
    [SerializeField] int spAttack;
    [SerializeField] int spDefense;
    [SerializeField] int speed;

    public string Name => name;
    public GameObject Model => model;

    public int MaxHp => maxHp;
    public int Attack => attack;
    public int Defense => defense;
    public int SpAttack => spAttack;
    public int SpDefense => spDefense;
    public int Speed => speed;
}

