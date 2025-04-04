using UnityEngine;
using DG.Tweening; // For smooth animations

public class HeritageMenu : MonoBehaviour
{
    [Header("Sub-Option Panels")]
    public GameObject nobleSubOptions;  // Panel containing noble sub-options
    public GameObject merchantSubOptions;  // Panel containing merchant sub-options
    public GameObject nomadicSubOptions;  // Panel containing nomadic sub-options
    public GameObject exileSubOptions;  // Panel containing exile sub-options
    public GameObject scholarySubOptions;  // Panel containing scholarly sub-options
    public GameObject occultSubOptions;  // Panel containing occult sub-options

    [Header("Main Buttons (Category Buttons)")]
    public GameObject nobleButton;    // The Noble category button
    public GameObject merchantButton; // The Merchant category button
    public GameObject nomadicButton;  // The Nomadic category button
    public GameObject exileButton;    // The Exile category button
    public GameObject scholaryButton; // The Scholary category button
    public GameObject occultButton;   // The Occult category button

    private RectTransform nobleButtonRect;
    private RectTransform merchantButtonRect;
    private RectTransform nomadicButtonRect;
    private RectTransform exileButtonRect;
    private RectTransform scholaryButtonRect;
    private RectTransform occultButtonRect;

    private void Start()
    {
        // Cache the RectTransform of each button
        nobleButtonRect = nobleButton.GetComponent<RectTransform>();
        merchantButtonRect = merchantButton.GetComponent<RectTransform>();
        nomadicButtonRect = nomadicButton.GetComponent<RectTransform>();
        exileButtonRect = exileButton.GetComponent<RectTransform>();
        scholaryButtonRect = scholaryButton.GetComponent<RectTransform>();
        occultButtonRect = occultButton.GetComponent<RectTransform>();
    }

    public void ToggleNobleOptions()
    {
        ToggleSubOptions(nobleSubOptions, nobleButtonRect, nobleButton);
    }

    public void ToggleMerchantOptions()
    {
        ToggleSubOptions(merchantSubOptions, merchantButtonRect, merchantButton);
    }

    public void ToggleNomadicOptions()
    {
        ToggleSubOptions(nomadicSubOptions, nomadicButtonRect, nomadicButton);
    }

    public void ToggleExileOptions()
    {
        ToggleSubOptions(exileSubOptions, exileButtonRect, exileButton);
    }

    public void ToggleScholarOptions()
    {
        ToggleSubOptions(scholarySubOptions, scholaryButtonRect, scholaryButton);
    }

    public void ToggleOccultOptions()
    {
        ToggleSubOptions(occultSubOptions, occultButtonRect, occultButton);
    }

    // Toggle the visibility of the sub-option and move the inactive buttons down or up
    private void ToggleSubOptions(GameObject subOptionsPanel, RectTransform buttonRect, GameObject button)
    {
        bool isActive = subOptionsPanel.activeSelf;
        subOptionsPanel.SetActive(!isActive);

        // Move inactive buttons down when the sub-options are shown
        // Move inactive buttons back up when the sub-options are hidden
        if (!isActive) 
        {
            MoveInactiveButtons(button, subOptionsPanel); // Move down when turning on
        }
        else
        {
            MoveInactiveButtonsBack(button, subOptionsPanel); // Move back up when turning off
        }
    }

    // Move the inactive buttons down based on the size of the sub-options panel
    private void MoveInactiveButtons(GameObject activeButton, GameObject activeSubPanel)
    {
        // Calculate the height of the active sub-options panel
        float subPanelHeight = activeSubPanel.GetComponent<RectTransform>().rect.height;

        // Use this height to determine how much to move the inactive buttons down
        float moveAmount = subPanelHeight;

        float animationDuration = 0.5f; // Time for the animation

        // Move the buttons that are **below** the currently active one (not the button clicked)
        if (activeButton == nobleButton)
        {
            merchantButtonRect.DOAnchorPosY(merchantButtonRect.anchoredPosition.y - moveAmount, animationDuration).SetEase(Ease.OutQuad);
            nomadicButtonRect.DOAnchorPosY(nomadicButtonRect.anchoredPosition.y - moveAmount, animationDuration).SetEase(Ease.OutQuad);
            exileButtonRect.DOAnchorPosY(exileButtonRect.anchoredPosition.y - moveAmount, animationDuration).SetEase(Ease.OutQuad);
            scholaryButtonRect.DOAnchorPosY(scholaryButtonRect.anchoredPosition.y - moveAmount, animationDuration).SetEase(Ease.OutQuad);
            occultButtonRect.DOAnchorPosY(occultButtonRect.anchoredPosition.y - moveAmount, animationDuration).SetEase(Ease.OutQuad);
        }
        else if (activeButton == merchantButton)
        {
            nomadicButtonRect.DOAnchorPosY(nomadicButtonRect.anchoredPosition.y - moveAmount, animationDuration).SetEase(Ease.OutQuad);
            exileButtonRect.DOAnchorPosY(exileButtonRect.anchoredPosition.y - moveAmount, animationDuration).SetEase(Ease.OutQuad);
            scholaryButtonRect.DOAnchorPosY(scholaryButtonRect.anchoredPosition.y - moveAmount, animationDuration).SetEase(Ease.OutQuad);
            occultButtonRect.DOAnchorPosY(occultButtonRect.anchoredPosition.y - moveAmount, animationDuration).SetEase(Ease.OutQuad);
        }
        else if (activeButton == nomadicButton)
        {
            exileButtonRect.DOAnchorPosY(exileButtonRect.anchoredPosition.y - moveAmount, animationDuration).SetEase(Ease.OutQuad);
            scholaryButtonRect.DOAnchorPosY(scholaryButtonRect.anchoredPosition.y - moveAmount, animationDuration).SetEase(Ease.OutQuad);
            occultButtonRect.DOAnchorPosY(occultButtonRect.anchoredPosition.y - moveAmount, animationDuration).SetEase(Ease.OutQuad);
        }
        else if (activeButton == exileButton)
        {
            scholaryButtonRect.DOAnchorPosY(scholaryButtonRect.anchoredPosition.y - moveAmount, animationDuration).SetEase(Ease.OutQuad);
            occultButtonRect.DOAnchorPosY(occultButtonRect.anchoredPosition.y - moveAmount, animationDuration).SetEase(Ease.OutQuad);
        }
        else if (activeButton == scholaryButton)
        {
            occultButtonRect.DOAnchorPosY(occultButtonRect.anchoredPosition.y - moveAmount, animationDuration).SetEase(Ease.OutQuad);
        }
    }

    // Move the inactive buttons back up after hiding the sub-options panel
    private void MoveInactiveButtonsBack(GameObject activeButton, GameObject activeSubPanel)
    {
        // Calculate the height of the active sub-options panel
        float subPanelHeight = activeSubPanel.GetComponent<RectTransform>().rect.height;

        // Use this height to determine how much to move the inactive buttons back up
        float moveAmount = subPanelHeight;

        float animationDuration = 0.5f; // Time for the animation

        // Move the buttons that are **below** the currently active one (not the button clicked)
        if (activeButton == nobleButton)
        {
            merchantButtonRect.DOAnchorPosY(merchantButtonRect.anchoredPosition.y + moveAmount, animationDuration).SetEase(Ease.OutQuad);
            nomadicButtonRect.DOAnchorPosY(nomadicButtonRect.anchoredPosition.y + moveAmount, animationDuration).SetEase(Ease.OutQuad);
            exileButtonRect.DOAnchorPosY(exileButtonRect.anchoredPosition.y + moveAmount, animationDuration).SetEase(Ease.OutQuad);
            scholaryButtonRect.DOAnchorPosY(scholaryButtonRect.anchoredPosition.y + moveAmount, animationDuration).SetEase(Ease.OutQuad);
            occultButtonRect.DOAnchorPosY(occultButtonRect.anchoredPosition.y + moveAmount, animationDuration).SetEase(Ease.OutQuad);
        }
        else if (activeButton == merchantButton)
        {
            nomadicButtonRect.DOAnchorPosY(nomadicButtonRect.anchoredPosition.y + moveAmount, animationDuration).SetEase(Ease.OutQuad);
            exileButtonRect.DOAnchorPosY(exileButtonRect.anchoredPosition.y + moveAmount, animationDuration).SetEase(Ease.OutQuad);
            scholaryButtonRect.DOAnchorPosY(scholaryButtonRect.anchoredPosition.y + moveAmount, animationDuration).SetEase(Ease.OutQuad);
            occultButtonRect.DOAnchorPosY(occultButtonRect.anchoredPosition.y + moveAmount, animationDuration).SetEase(Ease.OutQuad);
        }
        else if (activeButton == nomadicButton)
        {
            exileButtonRect.DOAnchorPosY(exileButtonRect.anchoredPosition.y + moveAmount, animationDuration).SetEase(Ease.OutQuad);
            scholaryButtonRect.DOAnchorPosY(scholaryButtonRect.anchoredPosition.y + moveAmount, animationDuration).SetEase(Ease.OutQuad);
            occultButtonRect.DOAnchorPosY(occultButtonRect.anchoredPosition.y + moveAmount, animationDuration).SetEase(Ease.OutQuad);
        }
        else if (activeButton == exileButton)
        {
            scholaryButtonRect.DOAnchorPosY(scholaryButtonRect.anchoredPosition.y + moveAmount, animationDuration).SetEase(Ease.OutQuad);
            occultButtonRect.DOAnchorPosY(occultButtonRect.anchoredPosition.y + moveAmount, animationDuration).SetEase(Ease.OutQuad);
        }
        else if (activeButton == scholaryButton)
        {
            occultButtonRect.DOAnchorPosY(occultButtonRect.anchoredPosition.y + moveAmount, animationDuration).SetEase(Ease.OutQuad);
        }
    }
}
