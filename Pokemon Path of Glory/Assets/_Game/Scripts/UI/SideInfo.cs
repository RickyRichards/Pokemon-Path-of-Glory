using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SideInfo : MonoBehaviour
{
    public Button[] Buttons;
    public Image image;


    
    // Start is called before the first frame update
    void Awake()
    {
        if(this.isActiveAndEnabled){
            image = this.GetComponentInChildren<Image>();
            Buttons = this.GetComponentsInChildren<Button>();
        }
    }

    void Update(){
        
    }

}
