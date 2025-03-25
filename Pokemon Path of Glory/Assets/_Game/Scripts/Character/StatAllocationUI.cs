using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StatAllocationUI : MonoBehaviour
{
   [Header("UI References")]
    [SerializeField] private TextMeshProUGUI pointsLeftText;
    [SerializeField] private Button addHP, removeHP, addAttack, removeAttack;
    [SerializeField] private Button addDefense, removeDefense, addSpAttack, removeSpAttack;
    [SerializeField] private Button addSpDefense, removeSpDefense, addSpeed, removeSpeed;

    [SerializeField] private TextMeshProUGUI hpText, attackText, defenseText;
    [SerializeField] private TextMeshProUGUI spAttackText, spDefenseText, speedText;

    private TrainerData trainerData;

    private void Start() {
        trainerData = GM.Instance.trainerData;
        if (trainerData == null)
        {
            Debug.LogError("TrainerData is NULL! Ensure it's assigned in GameManager.");
            return;
        }

        // Add listeners
        addHP.onClick.AddListener(() => AllocateStat(StatType.HP));
        removeHP.onClick.AddListener(() => RemoveStat(StatType.HP));

        addAttack.onClick.AddListener(() => AllocateStat(StatType.Attack));
        removeAttack.onClick.AddListener(() => RemoveStat(StatType.Attack));

        addDefense.onClick.AddListener(() => AllocateStat(StatType.Defense));
        removeDefense.onClick.AddListener(() => RemoveStat(StatType.Defense));

        addSpAttack.onClick.AddListener(() => AllocateStat(StatType.SpAttack));
        removeSpAttack.onClick.AddListener(() => RemoveStat(StatType.SpAttack));

        addSpDefense.onClick.AddListener(() => AllocateStat(StatType.SpDefense));
        removeSpDefense.onClick.AddListener(() => RemoveStat(StatType.SpDefense));

        addSpeed.onClick.AddListener(() => AllocateStat(StatType.Speed));
        removeSpeed.onClick.AddListener(() => RemoveStat(StatType.Speed));

        UpdateUI();
    }

 private void UpdateUI()
    {
        pointsLeftText.text = $"Points Left: {trainerData.availableStatPoints}";

        hpText.text = trainerData.maxHp.ToString();
        attackText.text = trainerData.attack.ToString();
        defenseText.text = trainerData.defense.ToString();
        spAttackText.text = trainerData.spAttack.ToString();
        spDefenseText.text = trainerData.spDefense.ToString();
        speedText.text = trainerData.speed.ToString();

        // Disable remove buttons if stat is at base value
        removeHP.interactable = trainerData.maxHp > 10;
        removeAttack.interactable = trainerData.attack > 5;
        removeDefense.interactable = trainerData.defense > 5;
        removeSpAttack.interactable = trainerData.spAttack > 5;
        removeSpDefense.interactable = trainerData.spDefense > 5;
        removeSpeed.interactable = trainerData.speed > 5;

        // Disable add buttons if no points left
        bool canAdd = trainerData.availableStatPoints > 0;
        addHP.interactable = canAdd && trainerData.maxHp < 15;
        addAttack.interactable = canAdd && trainerData.attack < 10;
        addDefense.interactable = canAdd && trainerData.defense < 10;
        addSpAttack.interactable = canAdd && trainerData.spAttack < 10;
        addSpDefense.interactable = canAdd && trainerData.spDefense < 10;
        addSpeed.interactable = canAdd && trainerData.speed < 10;
    }

    public void AllocateStat(StatType stat)
    {
        trainerData.AllocateStat(stat);
        UpdateUI();
    }

    public void RemoveStat(StatType stat)
    {
        trainerData.RemoveStat(stat);
        UpdateUI();
    }
}
