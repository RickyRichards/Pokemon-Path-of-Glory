using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SkillSummaryUI : MonoBehaviour
{
    [SerializeField] private GameObject ranksObject; // Drag the "Ranks" GameObject in Unity
    private TrainerData trainerData;

    private Dictionary<string, TextMeshProUGUI> rankTexts = new Dictionary<string, TextMeshProUGUI>();

    private readonly List<string> skillNames = new List<string>
    {
        "Acrobatics", "Athletics", "Combat", "Intimidate", "Stealth", "Survival",
        "Command", "Charm", "Focus", "Intuition",
        "General Ed", "Medicine Ed", "Occult Ed", "Pokemon Ed", "Technology Ed", "Guile", "Perception"
    };

    private void Start()
    {
        trainerData = GM.Instance?.trainerData;
        if (trainerData == null)
        {
            Debug.LogError("TrainerData is NULL! Cannot update skill UI.");
            return;
        }

        GameObject categories = transform.Find("Categories")?.gameObject;
        if (categories == null)
        {
            Debug.LogError("Categories object not found! Ensure it's named correctly.");
            return;
        }

        ranksObject = categories.transform.Find("Ranks")?.gameObject;
        if (ranksObject == null)
        {
            Debug.LogError("Ranks object not found! Ensure it's inside Categories.");
            return;
        }

        StoreRankTexts();
        UpdateSkillUI();
    }

    private void StoreRankTexts()
    {
        foreach (TextMeshProUGUI text in ranksObject.GetComponentsInChildren<TextMeshProUGUI>())
        {
            rankTexts[text.name] = text; // Store rank text using GameObject name
            Debug.Log($"Stored Rank Text: {text.name}"); // ✅ Debug
        }
    }

    public void UpdateSkillUI()
    {
        if (trainerData == null)
        {
            Debug.LogError("TrainerData is NULL! Cannot update skill UI.");
            return;
        }

        foreach (string skill in skillNames)
        {
            string resultTextName = skill + "Res"; // Example: "AcrobaticsRes", "AthleticsRes", etc.

            if (rankTexts.TryGetValue(resultTextName, out TextMeshProUGUI rankText))
            {
                if (trainerData.HasSkill(skill, out SkillRank rank))
                {
                    rankText.text = rank.ToString(); // Update rank text to match trainer data
                    Debug.Log($"Updated {resultTextName}: {rank}");
                }
                else
                {
                    rankText.text = "Untrained"; // Default if no skill is found
                    Debug.LogWarning($"Skill '{skill}' not found in TrainerData! Setting to Untrained.");
                }
            }
            else
            {
                Debug.LogError($"Rank UI for {resultTextName} not found! Ensure it exists in the Ranks object.");
            }
        }
    }
}
