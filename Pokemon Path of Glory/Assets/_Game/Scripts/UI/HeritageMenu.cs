using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;
public class HeritageMenu : MonoBehaviour
{
    [Header("Aspect Options")]
     public GameObject nobleSubOptions; // Assign the Panel containing sub-options
    public GameObject merchantSubOptions; // Assign the Panel containing sub-options
    public GameObject nomadicSubOptions; // Assign the Panel containing sub-options
    public GameObject exileSubOptions; // Assign the Panel containing sub-options
    public GameObject scholarySubOptions; // Assign the Panel containing sub-options
    public GameObject occultSubOptions; // Assign the Panel containing sub-options

    public RectTransform mainPanelRectTransform;  // Assign the RectTransform of the main panel with buttons

    public void ToggleNobleOptions()
    {
        ToggleSubOptions(nobleSubOptions);
    }
    public void ToggleMerchantOptions()
    {
        ToggleSubOptions(merchantSubOptions);
    }
    public void ToggleNomadicOptions()
    {
        ToggleSubOptions(nomadicSubOptions);
    }
    public void ToggleExileOptions()
    {
        ToggleSubOptions(exileSubOptions);
    }
    public void ToggleScholarOptions()
    {
        ToggleSubOptions(scholarySubOptions);
    }
    public void ToggleOccultOptions()
    {
        ToggleSubOptions(occultSubOptions);
    }
     private void ToggleSubOptions(GameObject subOptionsPanel)
    {
        // Toggle the visibility of the sub-panel
        bool isActive = subOptionsPanel.activeSelf;
        subOptionsPanel.SetActive(!isActive);

        // Animate the main panel's size to fit new content
        AdjustMainPanelSize();
    }

    
    private void AdjustMainPanelSize()
    {
        // Animate the resize of the main panel content dynamically
        // You can adjust the height/width according to the total content
        mainPanelRectTransform.DOSizeDelta(new Vector2(mainPanelRectTransform.sizeDelta.x, CalculatePanelHeight()), 0.5f).SetEase(Ease.OutQuad);
    }

    private float CalculatePanelHeight()
    {
        // Calculate the total height of all active sub-panels (this can be based on the active children or any other logic)
        float height = 0;
        
        // Add height of all visible sub-panels (or calculate based on your layout)
        if (nobleSubOptions.activeSelf) height += nobleSubOptions.GetComponent<RectTransform>().sizeDelta.y;
        if (merchantSubOptions.activeSelf) height += merchantSubOptions.GetComponent<RectTransform>().sizeDelta.y;
        if (nomadicSubOptions.activeSelf) height += nomadicSubOptions.GetComponent<RectTransform>().sizeDelta.y;
        if (exileSubOptions.activeSelf) height += exileSubOptions.GetComponent<RectTransform>().sizeDelta.y;
        if (scholarySubOptions.activeSelf) height += scholarySubOptions.GetComponent<RectTransform>().sizeDelta.y;
        if (occultSubOptions.activeSelf) height += occultSubOptions.GetComponent<RectTransform>().sizeDelta.y;

        return height;
    }
}
