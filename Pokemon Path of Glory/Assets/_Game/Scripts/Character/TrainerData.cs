using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillRank { Untrained, Novice, Adept, Apprentice, Expert, Master }

[CreateAssetMenu(fileName = "newTrainer", menuName = "Trainer/Create New Trainer")]
public class TrainerData : ScriptableObject
{
    [Header("Trainer Info")]
    public string trainerName;
    public int level = 1;
    public bool isFemale = true;

    [Header("Health Stats")]
    public int maxHp = 10;
    public int currentHp;

    [Header("Base Stats")]
    public int attack = 5;
    public int defense = 5;
    public int spAttack = 5;
    public int spDefense = 5;
    public int speed = 5;

    [Header("Skills")]
    public SkillRank acrobatics = SkillRank.Novice;
    public SkillRank athletics = SkillRank.Novice;
    public SkillRank combat = SkillRank.Novice;
    public SkillRank intimidate = SkillRank.Novice;
    public SkillRank stealth = SkillRank.Novice;
    public SkillRank survival = SkillRank.Novice;
    public SkillRank command = SkillRank.Novice;
    public SkillRank charm = SkillRank.Novice;
    public SkillRank focus = SkillRank.Novice;
    public SkillRank intuition = SkillRank.Novice;
    public SkillRank generalEducation = SkillRank.Novice;
    public SkillRank medicineEducation = SkillRank.Novice;
    public SkillRank occultEducation = SkillRank.Novice;
    public SkillRank pokemonEducation = SkillRank.Novice;
    public SkillRank technologyEducation = SkillRank.Novice;
    public SkillRank guile = SkillRank.Novice;
    public SkillRank perception = SkillRank.Novice;

    [Header("Trainer’s Pokémon Team")]
    public List<PokemonData> pokemonTeam;

    public void Init()
    {
        currentHp = maxHp;
    }

}
