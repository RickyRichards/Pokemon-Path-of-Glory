using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SkillDropdownManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown[] skillDropdowns;

    private List<string> allSkills = new List<string>
    {
        "None", "Acrobatics", "Athletics", "Combat", "Intimidate", "Stealth",
        "Survival", "Command", "Charm", "Focus", "Intuition", "General Ed",
        "Medicine Ed", "Occult Ed", "Pokemon Ed", "Technology Ed", "Guile", "Perception"
    };

    private TrainerData trainer;

    private void Start()
    {
        trainer = GM.Instance.PlayerTrainer;
        PopulateDropdowns();
    }

    private void PopulateDropdowns()
    {
        for (int i = 0; i < skillDropdowns.Length; i++)
        {
            skillDropdowns[i].ClearOptions();
            skillDropdowns[i].AddOptions(new List<string>(allSkills));
            skillDropdowns[i].value = allSkills.IndexOf(trainer.selectedSkills[i]); // Set saved selection
            int index = i;
            skillDropdowns[i].onValueChanged.AddListener(delegate { UpdateSkill(index); });
        }
    }

    private void UpdateSkill(int index)
    {
        trainer.SetSkill(index, skillDropdowns[index].options[skillDropdowns[index].value].text);
        RefreshDropdowns();
    }

    private void RefreshDropdowns()
    {
        List<string> selectedSkills = new List<string>(trainer.selectedSkills);

        for (int i = 0; i < skillDropdowns.Length; i++)
        {
            string currentSelection = trainer.selectedSkills[i];
            skillDropdowns[i].ClearOptions();

            List<string> availableOptions = new List<string>(allSkills);
            availableOptions.RemoveAll(skill => selectedSkills.Contains(skill) && skill != currentSelection);

            skillDropdowns[i].AddOptions(availableOptions);
            skillDropdowns[i].value = availableOptions.IndexOf(currentSelection);
        }
    }
}
