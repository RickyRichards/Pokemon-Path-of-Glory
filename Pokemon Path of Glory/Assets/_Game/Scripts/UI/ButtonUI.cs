using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonUI : MonoBehaviour
{
    public Button next, back;
    public GameObject pages;
    [SerializeField] private TextMeshProUGUI text;
    [SerializeField] private string newGame = "Level";
    [SerializeField] GameObject player;
    [SerializeField] RawImage playerimg;
    [SerializeField] TextMeshProUGUI adept, novice, untrained1, untrained2, untrained3 ;
    public Sprite[] sprites;
    [SerializeField] Image img;
    public bool isMain;
    Color a;
    public int num = 0;
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
    private void Update() {
        if(SceneManager.GetActiveScene().name != "MainMenu"){
            if(num == 0 ){back.interactable = false;}
            else if(num == 17){next.interactable = false;}

            else if(isMain){next.interactable = true; back.interactable = true;}


            if(pages.transform.GetChild(num) == pages.transform.GetChild(4)){
                
                if(adept.text != "None" && novice.text != "None" && untrained1.text != "None" && untrained2.text != "None" && untrained3.text != "None"){
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
        if(playerimg.gameObject.activeInHierarchy == false && num == 8){playerimg.gameObject.SetActive(true);}
        else if(playerimg.gameObject.activeInHierarchy == true && num != 8){playerimg.gameObject.SetActive(false);}
        if(num == 17){return;}
        
    }

    public void Back(){
        pages.transform.GetChild(num).gameObject.SetActive(false);
        num --;
        pages.transform.GetChild(num).gameObject.SetActive(true);
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
