using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    List<string> names = new List<string>() { "Please Select A Building", "Harold Cohen", "Electrical Eng", "Ashton" };


    public Dropdown dropdown;
    public Text selectedBuilding;
    public Button beginButton;


    public void Dropdown_INdexChanged(int index)
    {
        selectedBuilding.text = names[index];
        if(index == 0)
        {
            beginButton.enabled = false;
        }
        else
        {
            beginButton.enabled = true;
        }
    }

    void Start()
    {
        beginButton.enabled = false;
        PopulateList();
    }

    void PopulateList()
    {
        dropdown.AddOptions(names);
    }

}
