using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    List<string> names = new List<string>() { "Please Select A Building", "Sherrington Building", "Harold Cohen Library", "Electrical Engineering", "Ashton Building", "George Holt", "Harrison Hughes", "Brodie Tower", "The Guild", "Student Admin Center", "Central Teaching Hub", "Life Sciences", "Sports Hall", "Abercomby Square", "Sydney Jones Library", "Chadwick Building", "The AJ Pub", "Student Services", "The Clock Tower" };
    List<double> locationsX = new List<double>() { 65.92, 305.7, -182, -613.35, -330.1, -127.9, -478.1, -43.3, -1339.9, -1339.9, -2260, 61, -3673, -5214, -5647, -3375, -1375.9, -1357.9, -792.8 };  //Default position [0] set incase no option is somehow picked
    List<double> locationsY = new List<double>() { 6.12, 0.26, 5.2, 2.94, 0.26, 0.26, 0.26, 0.26, 0.26, 0.26, 0.26, -18.45, 0.26, 0.26, 0.26, 0.26, 0.26, 0.26, 0.26 };
    List<double> locationsZ = new List<double>() { 115.52, -4.7, -105, -104.1, 383.7, 301.4, 852.1, 1461, -333.6, 126, -2704, -2286, -516, -1502, -2667, -1577, -1152, -588.9, 446.4 };

    public Dropdown dropdown;
    
    public Button beginButton;


    public void Dropdown_INdexChanged(int index)
    {
        
        if(index == 0)
        {
            beginButton.enabled = false;
        }
        else
        {
            beginButton.enabled = true;
        }

        SavedSettings.StartX = locationsX[index];
        SavedSettings.StartY = locationsY[index];
        SavedSettings.StartZ = locationsZ[index];
        print(SavedSettings.StartX);
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
