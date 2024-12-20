using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MainMenuBg : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI textMp;

    public bool firsScreen;

    // Start is called before the first frame update
    void Start()
    {
        textMp = GameObject.Find("Start").GetComponent<TextMeshProUGUI>();
        
    }

    public IEnumerator Fade(){
        if(firsScreen){
            yield return new WaitForSeconds(2);
            textMp.CrossFadeAlpha(0, 0.5f, false);
            yield return new WaitForSeconds(2);
            textMp.CrossFadeAlpha(1, 0.5f, false);
            yield return new WaitForSeconds(2);
            firsScreen = false;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(textMp != null && firsScreen != true){
            firsScreen = true;
            StartCoroutine(Fade());
        }
    }
}
