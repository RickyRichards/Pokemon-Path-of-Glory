using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillRank { Untrained, Novice, Adept, Apprentice, Expert, Master}

public class Character : MonoBehaviour
{
    [field: Header("Base Info")]
    [field: SerializeField] private int Level { get; set; } = 1;
    [field: SerializeField] private int AvailablePoints { get; set; } = 10;
    [field: SerializeField] private int CurrentHp { get; set; }
    [field: SerializeField] private bool IsFemale { get; set; } = true;


    [field: Header("Base Stats")]
    [field: SerializeField] private int maxHp { get; set; } = 10;
    [field: SerializeField] private int attack { get; set; } = 5;
    [field: SerializeField] private int defense { get; set; } = 5;
    [field: SerializeField] private int spAttack { get; set; } = 5;
    [field: SerializeField] private int spDefense { get; set; } = 5;
    [field: SerializeField] private int speed { get; set; } = 5;

    [field: Header("Skill Stats")]
    [field: SerializeField] public SkillRank acrobatics { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank athletics { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank combat { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank intimidate { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank stealth { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank survival { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank command { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank charm { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank focus { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank intuition { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank generalEducation { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank medicineEducatoin { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank occultEducation { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank pokemonEducation { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank technologyEducation { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank guile { get; set; } = SkillRank.Novice;
    [field: SerializeField] public SkillRank perception { get; set; } = SkillRank.Novice;

    // Stat methods
    public int Attack => ( attack * 10 );
    public int Defense => ( defense * 10 );
    public int SpAttack => ( spAttack * 10 );
    public int SpDefense => ( spDefense * 10 );
    public int Speed => ( speed * 10 );
    public int MaxHp => ( maxHp * 10 ) + 10;

    // Skill methods
    public int Acrobatics => ( (int) acrobatics ) + 1;
    public int Athletics => ( (int) athletics ) + 1;
    public int Combat => ( (int) combat ) + 1;
    public int Intimidate => ( (int) intimidate ) + 1;
    public int Stealth => ( (int) stealth ) + 1;
    public int Survival => ( (int) survival ) + 1;
    public int Command => ( (int) command ) + 1;
    public int Charm => ( (int) charm ) + 1;
    public int Focus => ( (int) focus ) + 1;
    public int Intuition => ( (int) intuition ) + 1;
    public int GeneralEducation => ( (int) generalEducation ) + 1;
    public int MedicineEducatoin => ( (int) medicineEducatoin ) + 1;
    public int OccultEducation => ( (int) occultEducation ) + 1;
    public int PokemonEducation => ( (int) pokemonEducation ) + 1;
    public int TechnologyEducation => ( (int) technologyEducation ) + 1;
    public int Guile => ( (int) guile ) + 1;
    public int Perception => ( (int) perception ) + 1;



    public void Init() {
        CurrentHp = maxHp;
    }

    public void Reset(){
        
    }

    /* if using two chracters, make a character party/ hard code */

}
