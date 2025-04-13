using UnityEngine;
using DG.Tweening;
using System.Collections.Generic;

public class HeritageMenu : MonoBehaviour
{
    [Header("Sub-Option Panels")]
    public GameObject nobleSubOptions;
    public GameObject merchantSubOptions;
    public GameObject nomadicSubOptions;
    public GameObject exileSubOptions;
    public GameObject scholarySubOptions;
    public GameObject occultSubOptions;

    [Header("Main Buttons (Category Buttons)")]
    public GameObject nobleButton;
    public GameObject merchantButton;
    public GameObject nomadicButton;
    public GameObject exileButton;
    public GameObject scholaryButton;
    public GameObject occultButton;

    private RectTransform nobleButtonRect;
    private RectTransform merchantButtonRect;
    private RectTransform nomadicButtonRect;
    private RectTransform exileButtonRect;
    private RectTransform scholaryButtonRect;
    private RectTransform occultButtonRect;

    private GameObject currentlyActivePanel = null;
    private GameObject currentlyActiveButton = null;

    private Dictionary<RectTransform, float> originalYPositions = new Dictionary<RectTransform, float>();

    private void Start()
    {
        nobleButtonRect = nobleButton.GetComponent<RectTransform>();
        merchantButtonRect = merchantButton.GetComponent<RectTransform>();
        nomadicButtonRect = nomadicButton.GetComponent<RectTransform>();
        exileButtonRect = exileButton.GetComponent<RectTransform>();
        scholaryButtonRect = scholaryButton.GetComponent<RectTransform>();
        occultButtonRect = occultButton.GetComponent<RectTransform>();

        // Cache original Y positions ONCE
        originalYPositions[nobleButtonRect] = nobleButtonRect.anchoredPosition.y;
        originalYPositions[merchantButtonRect] = merchantButtonRect.anchoredPosition.y;
        originalYPositions[nomadicButtonRect] = nomadicButtonRect.anchoredPosition.y;
        originalYPositions[exileButtonRect] = exileButtonRect.anchoredPosition.y;
        originalYPositions[scholaryButtonRect] = scholaryButtonRect.anchoredPosition.y;
        originalYPositions[occultButtonRect] = occultButtonRect.anchoredPosition.y;
    }

    public void ToggleNobleOptions()    => ToggleSubOptions(nobleSubOptions, nobleButtonRect, nobleButton);
    public void ToggleMerchantOptions() => ToggleSubOptions(merchantSubOptions, merchantButtonRect, merchantButton);
    public void ToggleNomadicOptions()  => ToggleSubOptions(nomadicSubOptions, nomadicButtonRect, nomadicButton);
    public void ToggleExileOptions()    => ToggleSubOptions(exileSubOptions, exileButtonRect, exileButton);
    public void ToggleScholarOptions()  => ToggleSubOptions(scholarySubOptions, scholaryButtonRect, scholaryButton);
    public void ToggleOccultOptions()   => ToggleSubOptions(occultSubOptions, occultButtonRect, occultButton);

    private void ToggleSubOptions(GameObject subOptionsPanel, RectTransform buttonRect, GameObject button)
    {
        bool isSamePanel = (currentlyActivePanel == subOptionsPanel);

        // Always restore all button positions before doing anything else
        RestoreAllButtonPositions();

        if (currentlyActivePanel != null && !isSamePanel)
        {
            currentlyActivePanel.SetActive(false);
        }

        bool isActive = subOptionsPanel.activeSelf;
        subOptionsPanel.SetActive(!isActive);

        if (!isActive)
        {
            float moveAmount = subOptionsPanel.GetComponent<RectTransform>().rect.height;
            MoveButtonsBelow(button, moveAmount);
            currentlyActivePanel = subOptionsPanel;
            currentlyActiveButton = button;
        }
        else
        {
            currentlyActivePanel = null;
            currentlyActiveButton = null;
        }
    }

    private void MoveButtonsBelow(GameObject activeButton, float moveAmount)
    {
        float duration = 0.3f;

        List<RectTransform> buttonsToMove = new List<RectTransform>();

        if (activeButton == nobleButton) buttonsToMove.AddRange(new[] { merchantButtonRect, nomadicButtonRect, exileButtonRect, scholaryButtonRect, occultButtonRect });
        else if (activeButton == merchantButton) buttonsToMove.AddRange(new[] { nomadicButtonRect, exileButtonRect, scholaryButtonRect, occultButtonRect });
        else if (activeButton == nomadicButton) buttonsToMove.AddRange(new[] { exileButtonRect, scholaryButtonRect, occultButtonRect });
        else if (activeButton == exileButton) buttonsToMove.AddRange(new[] { scholaryButtonRect, occultButtonRect });
        else if (activeButton == scholaryButton) buttonsToMove.Add(occultButtonRect);

        foreach (var rect in buttonsToMove)
        {
            float originalY = originalYPositions[rect];
            rect.DOAnchorPosY(originalY - moveAmount, duration).SetEase(Ease.OutQuad);
        }
    }

    private void RestoreAllButtonPositions()
    {
        float duration = 0.3f;

        foreach (var kvp in originalYPositions)
        {
            RectTransform rect = kvp.Key;
            float originalY = kvp.Value;
            rect.DOAnchorPosY(originalY, duration).SetEase(Ease.OutQuad);
        }
    }
}
