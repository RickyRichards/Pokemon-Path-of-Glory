using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RaceSelectionUI : MonoBehaviour
{
    [Header("UI Elements")]
    [SerializeField] private TMP_Text raceDescriptionText;
    [SerializeField] private Button raceButtonTemplate;
    [SerializeField] private Transform raceButtonContainer;
    [SerializeField] private TMP_Text selectedRaceText;
    [SerializeField] private TextMeshProUGUI skillOption1Text; // Text for first +1 skill option
    [SerializeField] private TextMeshProUGUI skillOption2Text; // Text for second +1 skill option
    [SerializeField] private Button removeSkill1Button;
    [SerializeField] private Button removeSkill2Button;
    [SerializeField] private Button plusOneButton1; // First +1 option
    [SerializeField] private Button plusOneButton2; // Second +1 option
    [SerializeField] private TextMeshProUGUI skillOption1ModifierText;
    [SerializeField] private TextMeshProUGUI skillOption2ModifierText;

    public bool isRaceSelected = false;  // Track if race is selected and modifier is set

    [Header("Race Data")]
    public RaceData[] availableRaces;
    private RaceData selectedRace;
    public string selectedSkillForPlusOne;
    private Dictionary<string, int> skillModifiers = new Dictionary<string, int>();

    private void Start()
    {
        PopulateRaceList();
        removeSkill1Button.interactable = false;
        removeSkill2Button.interactable = false;
    }

    // Populating the list of available races
    public void PopulateRaceList()
    {
        foreach (Transform child in raceButtonContainer)
        {
            Destroy(child.gameObject); // Clear existing buttons
        }

        foreach (RaceData race in availableRaces)
        {
            Button newButton = Instantiate(raceButtonTemplate, raceButtonContainer);
            newButton.gameObject.SetActive(true);
            TMP_Text buttonText = newButton.GetComponentInChildren<TextMeshProUGUI>();
            buttonText.text = race.raceName;
            newButton.onClick.AddListener(() => SelectRace(race));
        }
    }

    // When a race is selected, update the UI accordingly
    private void SelectRace(RaceData race)
    {
        selectedRace = race;
        selectedRaceText.text = "Selected Race: " + race.raceName;
        raceDescriptionText.text = race.description;

        // Set the skill names for possible +1 bonuses
        skillOption1Text.text = race.skillForPlusOneOption1; // First skill name
        skillOption2Text.text = race.skillForPlusOneOption2; // Second skill name

        skillModifiers[race.skillForPlusOneOption1] = 0;
        skillModifiers[race.skillForPlusOneOption2] = 0;

        skillOption1ModifierText.text = "0";
        skillOption2ModifierText.text = "0";

        // Enable buttons and set listeners
        plusOneButton1.onClick.RemoveAllListeners();
        plusOneButton2.onClick.RemoveAllListeners();
        removeSkill1Button.onClick.RemoveAllListeners();
        removeSkill2Button.onClick.RemoveAllListeners();

        // Set up buttons for the +1 options
        plusOneButton1.onClick.AddListener(() => AssignSkillBonus(race.skillForPlusOneOption1, skillOption1ModifierText, removeSkill1Button, removeSkill2Button));
        plusOneButton2.onClick.AddListener(() => AssignSkillBonus(race.skillForPlusOneOption2, skillOption2ModifierText, removeSkill2Button, removeSkill1Button));
        removeSkill1Button.onClick.AddListener(() => RemoveSkillBonus(race.skillForPlusOneOption1, skillOption1ModifierText, plusOneButton1, removeSkill1Button));
        removeSkill2Button.onClick.AddListener(() => RemoveSkillBonus(race.skillForPlusOneOption2, skillOption2ModifierText, plusOneButton2, removeSkill2Button));

        plusOneButton1.interactable = true;
        plusOneButton2.interactable = true;
        removeSkill1Button.interactable = false;
        removeSkill2Button.interactable = false;
    }

    // Choose the skill to apply +1 modifier
    private void AssignSkillBonus(string skillName, TextMeshProUGUI modifierText, Button minusButton, Button otherRemoveButton)
    {
        // Prevent double assignment of +1

        selectedSkillForPlusOne = skillName;
        skillModifiers[skillName] = 1;
        modifierText.text = "1";

        // Disable `+` buttons after selection
        plusOneButton1.interactable = false;
        plusOneButton2.interactable = false;

        // Enable the `-` button only for the selected skill
        minusButton.interactable = true;
    }

    // Remove the +1 modifier
    private void RemoveSkillBonus(string skillName, TextMeshProUGUI modifierText, Button plusButton, Button minusButton)
    {
        // Prevent removal of unassigned skill
        if (selectedSkillForPlusOne != skillName) return;

        skillModifiers[skillName] = 0;
        modifierText.text = "0";
        selectedSkillForPlusOne = null;

        // Re-enable `+` buttons when the skill bonus is removed
        plusOneButton1.interactable = true;
        plusOneButton2.interactable = true;

        // Disable the `-` button since no skill has +1 anymore
        minusButton.interactable = false;
    }

    // Apply the selected skill modifier to the TrainerData
    public void ConfirmRaceSelection()
    {
        if (!string.IsNullOrEmpty(selectedRace.raceName))
        {
            if(!string.IsNullOrEmpty(selectedSkillForPlusOne)){
                Debug.Log($"ConfirmRaceSelection called - selectedRace: {selectedRace?.raceName}, selectedSkillForPlusOne: {selectedSkillForPlusOne}");
                selectedRace.ApplyRaceModifiers(GM.Instance.trainerData, selectedSkillForPlusOne);
                isRaceSelected = true;  // Set the race selection as complete
            }
            else{
                return;
            }
        }
        else
        {
            Debug.LogWarning("Race not selected or +1 modifier not set!");
        }
    }
}
