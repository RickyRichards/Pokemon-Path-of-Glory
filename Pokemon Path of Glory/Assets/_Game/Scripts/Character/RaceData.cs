using UnityEngine;

[CreateAssetMenu(fileName = "NewRace", menuName = "Trainer/Race")]
public class RaceData : ScriptableObject
{
    public string raceName;
    [TextArea]public string description;

    [Header("Modifiers")]
    public int acrobaticsModifier;
    public int athleticsModifier;
    public int charmModifier;
    public int combatModifier;
    public int commandModifier;
    public int generalEdModifier;
    public int medicineEdModifier;
    public int occultEdModifier;
    public int pokemonEdModifier;
    public int techEdModifier;
    public int focusModifier;
    public int guileModifier;
    public int intimidateModifier;
    public int intuitionModifier;
    public int perceptionModifier;
    public int stealthModifier;
    public int survivalModifier;
    
    // These are the skills that can get the +1 modifier
    public string skillForPlusOneOption1;
    public string skillForPlusOneOption2;


    // Apply Race Modifiers to TrainerData
    public void ApplyRaceModifiers(TrainerData trainer, string selectedSkill)
    {

        trainer.acrobaticsBonus = acrobaticsModifier;
        trainer.athleticsBonus += athleticsModifier;
        trainer.charmBonus += charmModifier;
        trainer.combatBonus += combatModifier;
        trainer.commandBonus += commandModifier;
        trainer.generalEdBonus += generalEdModifier;
        trainer.medicineEdBonus += medicineEdModifier;
        trainer.occultEdBonus += occultEdModifier;
        trainer.pokemonEdBonus += pokemonEdModifier;
        trainer.techEdBonus += techEdModifier;
        trainer.focusBonus += focusModifier;
        trainer.guileBonus += guileModifier;
        trainer.intimidateBonus += intimidateModifier;
        trainer.intuitionBonus += intuitionModifier;
        trainer.perceptionBonus += perceptionModifier;
        trainer.stealthBonus += stealthModifier;
        trainer.survivalBonus += survivalModifier;
        
        switch (selectedSkill)
        {
            case "Acrobatics": trainer.acrobaticsBonus += 1; break;
            case "Athletics": trainer.athleticsBonus += 1; break;
            case "Charm": trainer.charmBonus += 1; break;
            case "Combat": trainer.combatBonus += 1; break;
            case "Command": trainer.commandBonus += 1; break;
            case "General Ed": trainer.generalEdBonus += 1; break;
            case "Medicine Ed": trainer.medicineEdBonus += 1; break;
            case "Occult Ed": trainer.occultEdBonus += 1; break;
            case "Pokemon Ed": trainer.pokemonEdBonus += 1; break;
            case "Tech Ed": trainer.techEdBonus += 1; break;
            case "Focus": trainer.focusBonus += 1; break;
            case "Guile": trainer.guileBonus += 1; break;
            case "Intimidate": trainer.intimidateBonus += 1; break;
            case "Intuition": trainer.intuitionBonus += 1; break;
            case "Perception": trainer.perceptionBonus += 1; break;
            case "Stealth": trainer.stealthBonus += 1; break;
            case "Survival": trainer.survivalBonus += 1; break;
            default: Debug.LogWarning($"Skill '{selectedSkill}' not found for +1 bonus!"); break;
        }
    }
     // Method to add the +1 modifier to a specific skill
    private void AddModifierToSkill(TrainerData trainer, string skill, int modifier)
    {
        if (skill == "Acrobatics") trainer.acrobaticsBonus += modifier;
        else if (skill == "Athletics") trainer.athleticsBonus += modifier;
        else if (skill == "Charm") trainer.charmBonus += modifier;
        else if (skill == "Combat") trainer.combatBonus += modifier;
        else if (skill == "Command") trainer.commandBonus += modifier;
        else if (skill == "General Ed") trainer.generalEdBonus += modifier;
        else if (skill == "Medicine Ed") trainer.medicineEdBonus += modifier;
        else if (skill == "Occult Ed") trainer.occultEdBonus += modifier;
        else if (skill == "Pokemon Ed") trainer.pokemonEdBonus += modifier;
        else if (skill == "Tech Ed") trainer.techEdBonus += modifier;
        else if (skill == "Focus") trainer.focusBonus += modifier;
        else if (skill == "Guile") trainer.guileBonus += modifier;
        else if (skill == "Intimidate") trainer.intimidateBonus += modifier;
        else if (skill == "Intuition") trainer.intuitionBonus += modifier;
        else if (skill == "Perception") trainer.perceptionBonus += modifier;
        else if (skill == "Stealth") trainer.stealthBonus += modifier;
        else if (skill == "Survival") trainer.survivalBonus += modifier;
    }
}
