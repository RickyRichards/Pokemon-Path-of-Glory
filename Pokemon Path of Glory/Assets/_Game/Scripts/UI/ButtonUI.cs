using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    [Header("Navigation Buttons")]
    [SerializeField] private Button next, back;
    [SerializeField] private GameObject pages;

    [Header("Background Selection")]
    [SerializeField] private TMP_InputField bgname;
    [SerializeField] private TMP_InputField bgdesc;
    [SerializeField] private TextMeshProUGUI text;

    [Header("Player References")]
    [SerializeField] private GameObject player;
    [SerializeField] private RawImage playerimg;
    private bool Female = true;

    [Header("Skill Selection")]
    [SerializeField] private TextMeshProUGUI apprentice, adept, untrained1, untrained2, untrained3;
    [SerializeField] private TMP_Dropdown field1, field2, field3, field4, field5;

    [Header("UI Elements")]
    [SerializeField] private Image img;
    [SerializeField] private string newGameScene = "Level"; // Scene to load for new game

    private TrainerData trainerData; // Reference to TrainerData
    private int num = 0;
    private bool isMain;

    // ✅ Dictionary to Track Selected Skills & Corresponding Dropdowns
    private Dictionary<TMP_Dropdown, string> selectedSkills = new Dictionary<TMP_Dropdown, string>();

    private readonly List<string> skillNames = new List<string>
    {
        "Acrobatics", "Athletics", "Combat", "Intimidate", "Stealth", "Survival",
        "Command", "Charm", "Focus", "Intuition", "General Ed", "Medicine Ed",
        "Occult Ed", "Pokemon Ed", "Technology Ed", "Guile", "Perception"
    };

    private bool isUpdatingDropdowns = false; // Prevents infinite loop


    private void Awake()
    {
        trainerData = GM.Instance?.trainerData;
        if (trainerData == null)
        {
            Debug.LogError("TrainerData is NULL! Make sure it's assigned in the GameManager.");
            return;
        }

        if (player != null && SceneManager.GetActiveScene().name != "MainMenu")
        {
            isMain = false;
            next.interactable = false;
            if (img != null) img.color = new Color(1f, 1f, 1f, 0f);
            pages.transform.GetChild(num).gameObject.SetActive(true);
            player = GameObject.Find("Player");

            // ✅ Determine Gender from Player Model
            Female = player.transform.GetChild(0).gameObject.activeInHierarchy;
        }
    }

    private void Start()
    {
        next.interactable = false;
        InitializeDropdowns();
        RefreshDropdownOptions();
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            // Disable Next button if race isn't selected or +1 modifier isn't set
            if (pages.transform.GetChild(num).name == "RaceSelection")
            {
                next.interactable = FindObjectOfType<RaceSelectionUI>()?.isRaceSelected == true && !string.IsNullOrEmpty(FindObjectOfType<RaceSelectionUI>()?.selectedSkillForPlusOne);
            }
            else
            {
              //  next.interactable = true;  // Enable Next for all other pages
            }
        }
    }

    private void InitializeDropdowns()
    {
        field1.onValueChanged.AddListener(delegate { UpdateSelections(field1); });
        field2.onValueChanged.AddListener(delegate { UpdateSelections(field2); });
        field3.onValueChanged.AddListener(delegate { UpdateSelections(field3); });
        field4.onValueChanged.AddListener(delegate { UpdateSelections(field4); });
        field5.onValueChanged.AddListener(delegate { UpdateSelections(field5); });

        // Initialize Selected Skills Dictionary
        selectedSkills[field1] = "None";
        selectedSkills[field2] = "None";
        selectedSkills[field3] = "None";
        selectedSkills[field4] = "None";
        selectedSkills[field5] = "None";
    }

    private void UpdateSelections(TMP_Dropdown changedDropdown)
    {
        if (isUpdatingDropdowns) return; // Prevent infinite loop


        string newSelection = changedDropdown.options[changedDropdown.value].text;

        // Prevent selecting the same skill twice
        foreach (var entry in selectedSkills)
        {
            if (entry.Key != changedDropdown && entry.Value == newSelection && newSelection != "None")
            {
                Debug.LogWarning($"Duplicate skill selection detected! Resetting {changedDropdown.name}");
                changedDropdown.value = 0; // Reset to "None"
                return;
            }
        }

        // Update Dictionary with new selection
        selectedSkills[changedDropdown] = newSelection;

        // Refresh dropdown options for all dropdowns
        RefreshDropdownOptions();
        AssignSkills();
    }

    private void RefreshDropdownOptions()
    {
        isUpdatingDropdowns = true; // Prevent recursive updates

        HashSet<string> usedSkills = new HashSet<string>(selectedSkills.Values);
        usedSkills.Remove("None"); // Keep "None" always available

        foreach (var dropdown in selectedSkills.Keys)
        {
            List<string> availableOptions = new List<string> { "None" };
            availableOptions.AddRange(skillNames.FindAll(skill => !usedSkills.Contains(skill) || selectedSkills[dropdown] == skill));

            dropdown.ClearOptions();
            dropdown.AddOptions(availableOptions);

            // Keep previous selection if still valid
            string previousSelection = selectedSkills[dropdown];
            int newIndex = availableOptions.IndexOf(previousSelection);
            dropdown.value = (newIndex >= 0) ? newIndex : 0;
        }
    }

    private void AssignSkills()
    {
        if (trainerData == null)
        {
            Debug.LogError("TrainerData is NULL! Skills cannot be assigned.");
            return;
        }
        trainerData.ResetSkills();

        if (field1.value != 0) SetSkill(field1.options[field1.value].text, SkillRank.Apprentice);
        if (field2.value != 0) SetSkill(field2.options[field2.value].text, SkillRank.Adept);
        if (field3.value != 0) SetSkill(field3.options[field3.value].text, SkillRank.Untrained);
        if (field4.value != 0) SetSkill(field4.options[field4.value].text, SkillRank.Untrained);
        if (field5.value != 0) SetSkill(field5.options[field5.value].text, SkillRank.Untrained);
        
        Debug.Log($"Assigned Skills: {trainerData.GetAssignedSkills()}"); // Add this

        FindObjectOfType<SkillSummaryUI>()?.UpdateSkillUI();

    }

    // ✅ Dictionary-Based Approach to Set Skills
    private void SetSkill(string skillName, SkillRank rank)
    {
        if (trainerData == null) return;

        Dictionary<string, Action> skillSetters = new Dictionary<string, Action>
        {
            { "Acrobatics", () => trainerData.acrobatics = rank },
            { "Athletics", () => trainerData.athletics = rank },
            { "Combat", () => trainerData.combat = rank },
            { "Intimidate", () => trainerData.intimidate = rank },
            { "Stealth", () => trainerData.stealth = rank },
            { "Survival", () => trainerData.survival = rank },
            { "Command", () => trainerData.command = rank },
            { "Charm", () => trainerData.charm = rank },
            { "Focus", () => trainerData.focus = rank },
            { "Intuition", () => trainerData.intuition = rank },
            { "General Ed", () => trainerData.generalEducation = rank },
            { "Medicine Ed", () => trainerData.medicineEducation = rank },
            { "Occult Ed", () => trainerData.occultEducation = rank },
            { "Pokemon Ed", () => trainerData.pokemonEducation = rank },
            { "Technology Ed", () => trainerData.technologyEducation = rank },
            { "Guile", () => trainerData.guile = rank },
            { "Perception", () => trainerData.perception = rank }
        };
        if (skillSetters.ContainsKey(skillName))
            skillSetters[skillName]();
        else
            Debug.LogWarning($"Skill '{skillName}' not found!");
    }

    public void Next()
    {
        if (pages.transform.GetChild(num).name == "Background") // If moving to the summary page
        {
            // Check if the name and description fields are filled
            if (string.IsNullOrWhiteSpace(bgname.text) || string.IsNullOrWhiteSpace(bgdesc.text))
            {
                Debug.LogWarning("You must enter a Background Name and Description before proceeding!");
                return; // Stop execution
            }
            FindObjectOfType<SkillSummaryUI>()?.UpdateSkillUI(); // Refresh UI
            AssignSkills(); // Ensure skills are saved before loading summary
            
            // Check if all dropdowns are set to something other than "None"
            if (field1.value == 0 || field2.value == 0 || field3.value == 0 || field4.value == 0 || field5.value == 0)
            {
                Debug.LogWarning("All skill selections must be chosen before proceeding!");
                return; // Stop execution
            }
        }

        // If the player is on the Race Selection page
        if (pages.transform.GetChild(num).name == "Race")
        {
            Debug.Log("Calling ConfirmRaceSelection from Next()");
            FindObjectOfType<RaceSelectionUI>()?.ConfirmRaceSelection();
            if(FindObjectOfType<RaceSelectionUI>().isRaceSelected == false) return;

        }
        pages.transform.GetChild(num).gameObject.SetActive(false);
        num++;
        pages.transform.GetChild(num).gameObject.SetActive(true);
    }

    public void Back()
    {
        pages.transform.GetChild(num).gameObject.SetActive(false);
        num--;
        pages.transform.GetChild(num).gameObject.SetActive(true);
    }

    // ✅ **Gender Selection**
    public void GenderSelect()
    {
        string tag = EventSystem.current.currentSelectedGameObject.tag;

        if (tag == "FemaleB")
        {
            if (!player.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                player.transform.GetChild(1).gameObject.SetActive(false);
                player.transform.GetChild(0).gameObject.SetActive(true);
                Female = true;
            }
        }
        else if (tag == "MaleB")
        {
            if (!player.transform.GetChild(1).gameObject.activeInHierarchy)
            {
                player.transform.GetChild(0).gameObject.SetActive(false);
                player.transform.GetChild(1).gameObject.SetActive(true);
                Female = false;
            }
        }
    }

    public void MainStory()
    {
        isMain = true;
        next.interactable = true;
        img.color = Color.white;
        text.text = "Create your own journey filled with quests and adventure. Defeat gym leaders, solve mysteries, battle evil teams, and discover what awaits you at the end.";
    }

    public void NewGameButton()
    {
        SceneManager.LoadScene(newGameScene);
    }
}
