using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class ButtonUI : MonoBehaviour
{
    [SerializeField] private string newGame = "Level";
    [SerializeField] GameObject player;
    [SerializeField] private bool Female;
    private void Awake() {
        if(player == null){
            player = GameObject.Find("Player");
        }
        if(player.transform.GetChild(0).gameObject.activeInHierarchy){
            Female = true;
        }
    }
    public void NewGameButton(){
        SceneManager.LoadScene(newGame);
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
        // }else if(Female){

        // }
    }
}
