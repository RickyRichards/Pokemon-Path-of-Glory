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
    [SerializeField] private Button next, back;
    [SerializeField] private GameObject pages;
    [SerializeField] private TMP_InputField bgname;
    [SerializeField] private TMP_InputField bgdesc;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string newGame = "Level";
    [SerializeField] GameObject player;
    [SerializeField] RawImage playerimg;
    [SerializeField] TextMeshProUGUI apprentice, adept, untrained1, untrained2, untrained3 ;

    [SerializeField] private TMP_Dropdown field1, field2, field3, field4, field5;

    [SerializeField] private CanvasGroup fadeCanvas;
    public Sprite[] sprites;
    [SerializeField] Image img;
    bool isMain;
    Color a;
    int num = 0;
    [SerializeField] private bool Female;

    private void Awake() {
        if(player != null){
            if(SceneManager.GetActiveScene().name != "MainMenu"){
                isMain = false;
                if(!isMain)
                    next.interactable = false;
                if(img != null)
                    img.color = new Color(255, 255, 255, 0);
                if(pages !=null)
                    pages.transform.GetChild(num).gameObject.SetActive(true);
                player = GameObject.Find("Player");
                if(player.transform.GetChild(0).gameObject.activeInHierarchy){
                    Female = true;
                }
            }
            else{
                return;
            }
        }
    }

    public Character GetCharacter (){
        return player.GetComponent<Character>();
    }
// 🛠️ Set Skill Based on Dropdown Selection
    private void SetSkill(Character c, string skillName, SkillRank rank)
    {
        Dictionary<string, Action> skillSetters = new Dictionary<string, Action>
        {
            { "Acrobatics", () => c.acrobatics = rank },
            { "Athletics", () => c.athletics = rank },
            { "Combat", () => c.combat = rank },
            { "Intimidate", () => c.intimidate = rank },
            { "Stealth", () => c.stealth = rank },
            { "Survival", () => c.survival = rank },
            { "Command", () => c.command = rank },
            { "Charm", () => c.charm = rank },
            { "Focus", () => c.focus = rank },
            { "Intuition", () => c.intuition = rank },
            { "General Ed", () => c.generalEducation = rank },
            { "Medicine Ed", () => c.medicineEducatoin = rank },
            { "Occult Ed", () => c.occultEducation = rank },
            { "Pokemon Ed", () => c.pokemonEducation = rank },
            { "Technology Ed", () => c.technologyEducation = rank },
            { "Guile", () => c.guile = rank },
            { "Perception", () => c.perception = rank }
        };

        if (skillSetters.ContainsKey(skillName))
            skillSetters[skillName]();
    }

    // 🛠️ Assign Skills from Dropdowns
    public void AdjustStat()
    {
        var c = GetCharacter();

        c.Reset();
        SetSkill(c, field1.options[field1.value].text, SkillRank.Apprentice);
        SetSkill(c, field2.options[field2.value].text, SkillRank.Adept);
        SetSkill(c, field3.options[field3.value].text, SkillRank.Untrained);
        SetSkill(c, field4.options[field4.value].text, SkillRank.Untrained);
        SetSkill(c, field5.options[field5.value].text, SkillRank.Untrained);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().name != "MainMenu")
        {
            back.interactable = num > 0;
            next.interactable = num < 17 && isMain;

            // Enable 'Next' only if all required fields are filled
            if (pages.transform.GetChild(num) == pages.transform.GetChild(4))
            {
                next.interactable = !string.IsNullOrWhiteSpace(bgname.text)
                                    && apprentice.text != "None"
                                    && adept.text != "None"
                                    && untrained1.text != "None"
                                    && untrained2.text != "None"
                                    && untrained3.text != "None";
            }
        }
    }
    
    public void OnCharacterChange()
    {
        if (GM.Instance != null)
        {
            GM.Instance.SaveGame();
            Debug.Log("Character Auto-Saved!");
        }
    }


    public void NewGameButton(){
        StartCoroutine(FadeToScene(newGame));
    }
    
    private IEnumerator FadeToScene(string sceneName)
    {
        fadeCanvas.gameObject.SetActive(true); // Enable fade UI
        float fadeDuration = 1.5f;
        for (float t = 0; t < fadeDuration; t += Time.deltaTime)
        {
            fadeCanvas.alpha = t / fadeDuration;
            yield return null;
        }
        SceneManager.LoadScene(sceneName);
    }

    public void MainStory(){
        if(pages.transform.GetChild(num) == pages.transform.GetChild(0)){
            isMain = true;
            if(next.interactable == false)
                next.interactable = true;
            img.color = new Color(255, 255, 255, 255);
            text.text = "create your own journey filled with quests and advednture, defeate gym leaders, solve mysteries, battle evil teams and find what awaits you at the end";
        }
    }

    public void Next(){
        pages.transform.GetChild(num).gameObject.SetActive(false);
        num ++;
        pages.transform.GetChild(num).gameObject.SetActive(true);
        if(pages.transform.GetChild(num) == pages.transform.GetChild(4)){
            if(String.IsNullOrWhiteSpace(bgname.text)){
                bgname.text = "";
            }
        }
        if(playerimg.gameObject.activeInHierarchy == false && num == 8){playerimg.gameObject.SetActive(true);}
        else if(playerimg.gameObject.activeInHierarchy == true && num != 8){playerimg.gameObject.SetActive(false);}
        if(num == 17){return;}
        
    }

    public void Back(){
        pages.transform.GetChild(num).gameObject.SetActive(false);
        num --;
        pages.transform.GetChild(num).gameObject.SetActive(true);
        if(playerimg.gameObject.activeInHierarchy == false && num == 8){playerimg.gameObject.SetActive(true);}
        else if(playerimg.gameObject.activeInHierarchy == true && num != 8){playerimg.gameObject.SetActive(false);}
    }

   public void GenderSelect()
    {
        string tag = EventSystem.current.currentSelectedGameObject.tag;

        if (tag == "FemaleB")
        {
            if (!player.transform.GetChild(0).gameObject.activeInHierarchy)
            {
                player.transform.GetChild(1).gameObject.SetActive(false);
                player.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        else if (tag == "MaleB")
        {
            if (!player.transform.GetChild(1).gameObject.activeInHierarchy)
            {
                player.transform.GetChild(0).gameObject.SetActive(false);
                player.transform.GetChild(1).gameObject.SetActive(true);
            }
        }
    }
}
