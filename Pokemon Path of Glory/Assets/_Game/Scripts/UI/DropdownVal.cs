using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DropdownVal : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown dropdown;

    public void GetValue(){
        int pickedEntry = dropdown.value;
        string selectedOption = dropdown.options[pickedEntry].text;
        Debug.Log(selectedOption);
    }

    private void RemoveSkill(){
        int indexToRemove = 0;

        if(dropdown.value == indexToRemove){
            dropdown.value = 0;
        }

        dropdown.options.RemoveAt(indexToRemove);
        dropdown.RefreshShownValue();
    }
}
