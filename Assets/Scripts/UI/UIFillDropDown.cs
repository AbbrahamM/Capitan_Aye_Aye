using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIFillDropDown : MonoBehaviour
{
    [SerializeField]
    TMP_Dropdown _Dropdown;
    public void Addoption(string optionname)
    {
        _Dropdown.options.Add(new TMP_Dropdown.OptionData(optionname));
    }

    public void ResetOptions()
    {
        _Dropdown.options.Clear();
    }
}
