using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


public class SideInfo : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public string Sname;
    public Image image;
    public Sprite newImage;

    public void OnPointerEnter(PointerEventData eventData)
    {
        ChangeImage();
    }

    void ChangeImage(){
        var tempcolor = image.color;
            image.sprite = newImage;
            tempcolor.a = 1f;
            image.color = tempcolor;
    }

    // Start is called before the first frame update
    void Awake()
    {
        if(this.isActiveAndEnabled){
            image = GameObject.Find("sideImage").GetComponentInChildren<Image>();
            }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        var tempcolor = image.color;
        image.sprite = null;
        tempcolor.a = 0f;
        image.color = tempcolor; 
    }
}
