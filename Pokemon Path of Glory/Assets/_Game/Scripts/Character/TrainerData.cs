using System.Collections.Generic;
using UnityEngine;

public enum SkillRank { Untrained, Novice, Adept, Apprentice, Expert, Master, Legendary, Virtuoso }

public enum StatType{ HP, Attack, Defense, SpAttack, SpDefense, Speed}

[CreateAssetMenu(fileName = "NewTrainer", menuName = "Trainer/Create New Trainer")]
public class TrainerData : ScriptableObject
{
    [Header("Trainer Info")]
    public string trainerName;
    public int level = 1;
    public bool isFemale = true;

    [Header("Health Stats")]
    public int currentHp;

    [Header("Stat Allocation")]
    public int availableStatPoints = 10; // default points to distribute

    [Header("Base Stats")]
    public int maxHp = 10;
    public int attack = 5;
    public int defense = 5;
    public int spAttack = 5;
    public int spDefense = 5;
    public int speed = 5;

    [Header("Skills")]
    public SkillRank acrobatics = SkillRank.Novice;
    public SkillRank athletics = SkillRank.Novice;
    public SkillRank charm = SkillRank.Novice;
    public SkillRank combat = SkillRank.Novice;
    public SkillRank command = SkillRank.Novice;
    public SkillRank generalEducation = SkillRank.Novice;
    public SkillRank medicineEducation = SkillRank.Novice;
    public SkillRank occultEducation = SkillRank.Novice;
    public SkillRank pokemonEducation = SkillRank.Novice;
    public SkillRank technologyEducation = SkillRank.Novice;
    public SkillRank focus = SkillRank.Novice;
    public SkillRank guile = SkillRank.Novice;
    public SkillRank intimidate = SkillRank.Novice;
    public SkillRank intuition = SkillRank.Novice;
    public SkillRank perception = SkillRank.Novice;
    public SkillRank stealth = SkillRank.Novice;
    public SkillRank survival = SkillRank.Novice;

    [Header("Selected Skills")] 
    public List<string> selectedSkills = new List<string>(); // Keeps track of selected skills

        public void AllocateStat(StatType stat)
    {
        if (availableStatPoints <= 0) return;

        switch (stat)
        {
            case StatType.HP:
                if (maxHp < 15) { maxHp++; availableStatPoints--; }
                break;
            case StatType.Attack:
                if (attack < 10) { attack++; availableStatPoints--; }
                break;
            case StatType.Defense:
                if (defense < 10) { defense++; availableStatPoints--; }
                break;
            case StatType.SpAttack:
                if (spAttack < 10) { spAttack++; availableStatPoints--; }
                break;
            case StatType.SpDefense:
                if (spDefense < 10) { spDefense++; availableStatPoints--; }
                break;
            case StatType.Speed:
                if (speed < 10) { speed++; availableStatPoints--; }
                break;
        }
    }

    public void RemoveStat(StatType stat)
    {
        switch (stat)
        {
            case StatType.HP:
                if (maxHp > 10) { maxHp--; availableStatPoints++; }
                break;
            case StatType.Attack:
                if (attack > 5) { attack--; availableStatPoints++; }
                break;
            case StatType.Defense:
                if (defense > 5) { defense--; availableStatPoints++; }
                break;
            case StatType.SpAttack:
                if (spAttack > 5) { spAttack--; availableStatPoints++; }
                break;
            case StatType.SpDefense:
                if (spDefense > 5) { spDefense--; availableStatPoints++; }
                break;
            case StatType.Speed:
                if (speed > 5) { speed--; availableStatPoints++; }
                break;
        }
    }



    public void ResetSkills()
    {
        acrobatics = SkillRank.Novice;
        athletics = SkillRank.Novice;
        combat = SkillRank.Novice;
        intimidate = SkillRank.Novice;
        stealth = SkillRank.Novice;
        survival = SkillRank.Novice;
        command = SkillRank.Novice;
        charm = SkillRank.Novice;
        focus = SkillRank.Novice;
        intuition = SkillRank.Novice;
        generalEducation = SkillRank.Novice;
        medicineEducation = SkillRank.Novice;
        occultEducation = SkillRank.Novice;
        pokemonEducation = SkillRank.Novice;
        technologyEducation = SkillRank.Novice;
        guile = SkillRank.Novice;
        perception = SkillRank.Novice;

        selectedSkills.Clear();
    }

    public void SetSkill(string skillName, SkillRank rank)
    {
        switch (skillName)
        {
            case "Acrobatics": acrobatics = rank; break;
            case "Athletics": athletics = rank; break;
            case "Combat": combat = rank; break;
            case "Intimidate": intimidate = rank; break;
            case "Stealth": stealth = rank; break;
            case "Survival": survival = rank; break;
            case "Command": command = rank; break;
            case "Charm": charm = rank; break;
            case "Focus": focus = rank; break;
            case "Intuition": intuition = rank; break;
            case "General Ed": generalEducation = rank; break;
            case "Medicine Ed": medicineEducation = rank; break;
            case "Occult Ed": occultEducation = rank; break;
            case "Pokemon Ed": pokemonEducation = rank; break;
            case "Technology Ed": technologyEducation = rank; break;
            case "Guile": guile = rank; break;
            case "Perception": perception = rank; break;
            default: Debug.LogWarning($"Skill '{skillName}' not found!"); break;
        }

        if (!selectedSkills.Contains(skillName))
        {
            selectedSkills.Add(skillName);
        }
    }

    public void DebugTrainerData()
    {
        Debug.Log($"Trainer Name: {trainerName}");
        Debug.Log($"Level: {level}");
        Debug.Log($"Max HP: {maxHp}");
        Debug.Log($"Current HP: {currentHp}");
        Debug.Log($"Skills: Acrobatics ({acrobatics}), Athletics ({athletics}), Combat ({combat})");
    }

    public void TestLevelUp()
    {
        level += 1;
        maxHp += 5;
        attack += 2;
        Debug.Log($"Trainer Leveled Up! New Level: {level}, HP: {maxHp}, Attack: {attack}");
    }
    public bool HasSkill(string skillName, out SkillRank rank)
    {
        Dictionary<string, SkillRank> skillLookup = new Dictionary<string, SkillRank>
        {
            { "Acrobatics", acrobatics },
            { "Athletics", athletics },
            { "Combat", combat },
            { "Intimidate", intimidate },
            { "Stealth", stealth },
            { "Survival", survival },
            { "Command", command },
            { "Charm", charm },
            { "Focus", focus },
            { "Intuition", intuition },
            { "General Ed", generalEducation },
            { "Medicine Ed", medicineEducation },
            { "Occult Ed", occultEducation },
            { "Pokemon Ed", pokemonEducation },
            { "Technology Ed", technologyEducation },
            { "Guile", guile },
            { "Perception", perception }
        };

        if (skillLookup.TryGetValue(skillName, out rank))
        {
            return true;
        }

        rank = SkillRank.Untrained; // Default if not found
        return false;
    }

    public string GetAssignedSkills()
    {
        return $"Acrobatics: {acrobatics}, Athletics: {athletics}, Combat: {combat}, " +
            $"Intimidate: {intimidate}, Stealth: {stealth}, Survival: {survival}, " +
            $"Command: {command}, Charm: {charm}, Focus: {focus}, Intuition: {intuition}, " +
            $"General Ed: {generalEducation}, Medicine Ed: {medicineEducation}, " +
            $"Occult Ed: {occultEducation}, Pokemon Ed: {pokemonEducation}, " +
            $"Technology Ed: {technologyEducation}, Guile: {guile}, Perception: {perception}";
    }



}
