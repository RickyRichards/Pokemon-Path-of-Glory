using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class MainMenu : MonoBehaviour{
    [SerializeField]
    private TextMeshProUGUI textMp;
    private Animator animator;
    [SerializeField] GameObject panel;
    private bool firstScreen;
    private bool menu;
    public bool notOpen;




    private void Awake() {
        if(panel.activeInHierarchy == true){
            panel.SetActive(false);
            textMp.gameObject.SetActive(true);
        }
        animator = GameObject.Find("Book").GetComponent<Animator>();

    }

    public IEnumerator Fade(){
        if(firstScreen){
            yield return new WaitForSeconds(2);
            textMp.CrossFadeAlpha(0, 0.5f, false);
            yield return new WaitForSeconds(2);
            textMp.CrossFadeAlpha(1, 0.5f, false);
            yield return new WaitForSeconds(2);
            firstScreen = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(textMp != null && firstScreen != true && menu == false){
            firstScreen = true;
            StartCoroutine(Fade());
        }
        if(notOpen != true){
            if(Input.anyKeyDown){
                menu = true;
                StartCoroutine(Waitfor());
                firstScreen = false;
                textMp.gameObject.SetActive(false);
                notOpen = true;
            }
        }
    }
    IEnumerator Waitfor(){
        animator.Play("BookOpen");
        yield return new WaitForSeconds(1);
        panel.SetActive(true);
    }
}
