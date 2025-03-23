using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillDropdownManager : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown field1, field2, field3, field4, field5;
    private TrainerData trainerData;

    private bool isUpdatingDropdowns = false; // Prevents infinite loop

    private List<string> skillNames = new List<string>
    {
        "Acrobatics", "Athletics", "Combat", "Intimidate", "Stealth", "Survival",
        "Command", "Charm", "Focus", "Intuition", "General Ed", "Medicine Ed",
        "Occult Ed", "Pokemon Ed", "Technology Ed", "Guile", "Perception"
    };

    private Dictionary<TMP_Dropdown, string> selectedSkills = new Dictionary<TMP_Dropdown, string>();

    private void Start()
    {
        trainerData = GM.Instance?.trainerData;
        if (trainerData == null)
        {
            Debug.LogError("TrainerData is null!");
            return;
        }

        InitializeDropdown(field1);
        InitializeDropdown(field2);
        InitializeDropdown(field3);
        InitializeDropdown(field4);
        InitializeDropdown(field5);

        field1.onValueChanged.AddListener(delegate { UpdateSelections(field1); });
        field2.onValueChanged.AddListener(delegate { UpdateSelections(field2); });
        field3.onValueChanged.AddListener(delegate { UpdateSelections(field3); });
        field4.onValueChanged.AddListener(delegate { UpdateSelections(field4); });
        field5.onValueChanged.AddListener(delegate { UpdateSelections(field5); });
    }

    private void InitializeDropdown(TMP_Dropdown dropdown)
    {
        dropdown.ClearOptions();
        List<string> options = new List<string> { "None" };
        options.AddRange(skillNames);

        dropdown.AddOptions(options);
        dropdown.value = 0;
        selectedSkills[dropdown] = "None";
    }

    private void UpdateSelections(TMP_Dropdown changedDropdown)
    {
        if (isUpdatingDropdowns) return; // Prevent recursion

        string newSelection = changedDropdown.options[changedDropdown.value].text;

        // Prevent duplicate selection
        foreach (var entry in selectedSkills)
        {
            if (entry.Key != changedDropdown && entry.Value == newSelection && newSelection != "None")
            {
                Debug.LogWarning($"Duplicate selection detected! Resetting {changedDropdown.name}");
                changedDropdown.value = 0; // Reset to "None"
                return;
            }
        }

        // Update selection
        selectedSkills[changedDropdown] = newSelection;

        RefreshDropdownOptions();
        AssignSkills();
    }

    private void RefreshDropdownOptions()
    {
        isUpdatingDropdowns = true; // Temporarily disable event listeners

        HashSet<string> usedSkills = new HashSet<string>(selectedSkills.Values);
        usedSkills.Remove("None");

        foreach (var dropdown in selectedSkills.Keys)
        {
            string previousSelection = selectedSkills[dropdown];

            List<string> availableOptions = new List<string> { "None" };
            availableOptions.AddRange(skillNames.FindAll(skill => !usedSkills.Contains(skill) || selectedSkills[dropdown] == skill));

            dropdown.ClearOptions();
            dropdown.AddOptions(availableOptions);

            // Restore previous selection
            int newIndex = availableOptions.IndexOf(previousSelection);
            dropdown.value = (newIndex >= 0) ? newIndex : 0;
        }

        isUpdatingDropdowns = false; // Re-enable event listeners
    }

    private void AssignSkills()
    {
        trainerData.ResetSkills();

        if (field1.value != 0) trainerData.SetSkill(field1.options[field1.value].text, SkillRank.Apprentice);
        if (field2.value != 0) trainerData.SetSkill(field2.options[field2.value].text, SkillRank.Adept);
        if (field3.value != 0) trainerData.SetSkill(field3.options[field3.value].text, SkillRank.Untrained);
        if (field4.value != 0) trainerData.SetSkill(field4.options[field4.value].text, SkillRank.Untrained);
        if (field5.value != 0) trainerData.SetSkill(field5.options[field5.value].text, SkillRank.Untrained);
    }
}
