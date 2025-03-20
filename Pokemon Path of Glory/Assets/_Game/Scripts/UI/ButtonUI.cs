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

    public void AdjustStat () {
        var test1 = field1.options[field1.value].text;
        var test2 = field2.options[field2.value].text;
        var test3 = field3.options[field3.value].text;
        var test4 = field4.options[field4.value].text;
        var test5 = field5.options[field5.value].text;

        var c = GetCharacter();
        
        c.Reset();
        Debug.Log(test1);
        switch (test1) {
            case "Acrobatics": c.acrobatics = SkillRank.Apprentice; break;
            case "Athletics": c.athletics = SkillRank.Apprentice; break;                
            case "Combat": c.combat = SkillRank.Apprentice; break;                
            case "Intimidate": c.intimidate = SkillRank.Apprentice; break;                
            case "Stealth": c.stealth = SkillRank.Apprentice; break;
            case "Survival": c.survival = SkillRank.Apprentice; break;
            case "Command": c.command = SkillRank.Apprentice; break;                
            case "Charm": c.charm = SkillRank.Apprentice; break;                
            case "Focus": c.focus = SkillRank.Apprentice; break;                
            case "Intuition": c.intuition = SkillRank.Apprentice; break;
            case "General Ed": c.generalEducation = SkillRank.Apprentice; break;
            case "Medicine Ed": c.medicineEducatoin = SkillRank.Apprentice; break;                
            case "Occult Ed": c.occultEducation = SkillRank.Apprentice; break;                
            case "Pokemon Ed": c.pokemonEducation = SkillRank.Apprentice; break;                
            case "Technology Ed": c.technologyEducation = SkillRank.Apprentice; break;
            case "Guile": c.guile = SkillRank.Apprentice; break;
            case "Perception": c.perception = SkillRank.Apprentice; break;
            default: break;                
        };
        switch (test2) {
            case "Acrobatics": c.acrobatics = SkillRank.Adept; break;
            case "Athletics": c.athletics = SkillRank.Adept; break;                
            case "Combat": c.combat = SkillRank.Adept; break;                
            case "Intimidate": c.intimidate = SkillRank.Adept; break;                
            case "Stealth": c.stealth = SkillRank.Adept; break;
            case "Survival": c.survival = SkillRank.Adept; break;
            case "Command": c.command = SkillRank.Adept; break;                
            case "Charm": c.charm = SkillRank.Adept; break;                
            case "Focus": c.focus = SkillRank.Adept; break;                
            case "Intuition": c.intuition = SkillRank.Adept; break;
            case "General Ed": c.generalEducation = SkillRank.Adept; break;
            case "Medicine Ed": c.medicineEducatoin = SkillRank.Adept; break;                
            case "Occult Ed": c.occultEducation = SkillRank.Adept; break;                
            case "Pokemon Ed": c.pokemonEducation = SkillRank.Adept; break;                
            case "Technology Ed": c.technologyEducation = SkillRank.Adept; break;
            case "Guile": c.guile = SkillRank.Adept; break;
            case "Perception": c.perception = SkillRank.Adept; break;
            default: break;                
        };
        switch (test3) {
            case "Acrobatics": c.acrobatics = SkillRank.Untrained; break;
            case "Athletics": c.athletics = SkillRank.Untrained; break;                
            case "Combat": c.combat = SkillRank.Untrained; break;                
            case "Intimidate": c.intimidate = SkillRank.Untrained; break;                
            case "Stealth": c.stealth = SkillRank.Untrained; break;
            case "Survival": c.survival = SkillRank.Untrained; break;
            case "Command": c.command = SkillRank.Untrained; break;                
            case "Charm": c.charm = SkillRank.Untrained; break;                
            case "Focus": c.focus = SkillRank.Untrained; break;                
            case "Intuition": c.intuition = SkillRank.Untrained; break;
            case "General Ed": c.generalEducation = SkillRank.Untrained; break;
            case "Medicine Ed": c.medicineEducatoin = SkillRank.Untrained; break;                
            case "Occult Ed": c.occultEducation = SkillRank.Untrained; break;                
            case "Pokemon Ed": c.pokemonEducation = SkillRank.Untrained; break;                
            case "Technology Ed": c.technologyEducation = SkillRank.Untrained; break;
            case "Guile": c.guile = SkillRank.Untrained; break;
            case "Perception": c.perception = SkillRank.Untrained; break;
            default: break;                
        };
        switch (test4) {
            case "Acrobatics": c.acrobatics = SkillRank.Untrained; break;
            case "Athletics": c.athletics = SkillRank.Untrained; break;                
            case "Combat": c.combat = SkillRank.Untrained; break;                
            case "Intimidate": c.intimidate = SkillRank.Untrained; break;                
            case "Stealth": c.stealth = SkillRank.Untrained; break;
            case "Survival": c.survival = SkillRank.Untrained; break;
            case "Command": c.command = SkillRank.Untrained; break;                
            case "Charm": c.charm = SkillRank.Untrained; break;                
            case "Focus": c.focus = SkillRank.Untrained; break;                
            case "Intuition": c.intuition = SkillRank.Untrained; break;
            case "General Ed": c.generalEducation = SkillRank.Untrained; break;
            case "Medicine Ed": c.medicineEducatoin = SkillRank.Untrained; break;                
            case "Occult Ed": c.occultEducation = SkillRank.Untrained; break;                
            case "Pokemon Ed": c.pokemonEducation = SkillRank.Untrained; break;                
            case "Technology Ed": c.technologyEducation = SkillRank.Untrained; break;
            case "Guile": c.guile = SkillRank.Untrained; break;
            case "Perception": c.perception = SkillRank.Untrained; break;
            default: break;                
        };
        switch (test5) {
            case "Acrobatics": c.acrobatics = SkillRank.Untrained; break;
            case "Athletics": c.athletics = SkillRank.Untrained; break;                
            case "Combat": c.combat = SkillRank.Untrained; break;                
            case "Intimidate": c.intimidate = SkillRank.Untrained; break;                
            case "Stealth": c.stealth = SkillRank.Untrained; break;
            case "Survival": c.survival = SkillRank.Untrained; break;
            case "Command": c.command = SkillRank.Untrained; break;                
            case "Charm": c.charm = SkillRank.Untrained; break;                
            case "Focus": c.focus = SkillRank.Untrained; break;                
            case "Intuition": c.intuition = SkillRank.Untrained; break;
            case "General Ed": c.generalEducation = SkillRank.Untrained; break;
            case "Medicine Ed": c.medicineEducatoin = SkillRank.Untrained; break;                
            case "Occult Ed": c.occultEducation = SkillRank.Untrained; break;                
            case "Pokemon Ed": c.pokemonEducation = SkillRank.Untrained; break;                
            case "Technology Ed": c.technologyEducation = SkillRank.Untrained; break;
            case "Guile": c.guile = SkillRank.Untrained; break;
            case "Perception": c.perception = SkillRank.Untrained; break;
            default: break;                
        };
    }

    private void Update() {
        if(SceneManager.GetActiveScene().name != "MainMenu"){
            if(num == 0 ){back.interactable = false;}
            else if(num == 17){next.interactable = false;}

            else if(isMain){next.interactable = true; back.interactable = true;}
            
            //change to on value change
            if(pages.transform.GetChild(num) == pages.transform.GetChild(4)){
                if(apprentice.text != "None" && adept.text != "None" && untrained1.text != "None" && untrained2.text != "None" && untrained3.text != "None" && bgname.text.Length >= 6){
                    next.interactable = true;
                }else{
                    next.interactable = false;
                }
            }
        }
    }
    

    public void NewGameButton(){
        SceneManager.LoadScene(newGame);
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

    public void GenderSelect(){
        string tag = EventSystem.current.currentSelectedGameObject.tag;

        if(tag == "FemaleB"){
            if(player.transform.GetChild(0).gameObject.activeInHierarchy == false){
                player.transform.GetChild(1).gameObject.SetActive(false);
                player.transform.GetChild(0).gameObject.SetActive(true);
            }else if(player.transform.GetChild(0).gameObject.activeInHierarchy == true)
                return;
        }else if(tag == "MaleB"){
            if(player.transform.GetChild(1).gameObject.activeInHierarchy == false){
                player.transform.GetChild(0).gameObject.SetActive(false);
                player.transform.GetChild(1).gameObject.SetActive(true);
            }else if(player.transform.GetChild(1).gameObject.activeInHierarchy == true)
                return;
        }
    }
}
