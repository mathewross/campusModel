﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DropDown : MonoBehaviour
{
    List<string> names = new List<string>() { "Please Select A Building", "Sherrington Building", "Harold Cohen Library", "Electrical Engineering", "Ashton Building", "George Holt", "Harrison Hughes" };
    List<double> locationsX = new List<double>() { 93.27, -55.46398, -391.484, -693.6182, -497.38, -359.2, -600.5 };  //Default position [0] set incase no option is somehow picked
    List<double> locationsY = new List<double>() { 1.5, 1.13, 4.44, 3.01, 1, 1, 1 };
    List<double> locationsZ = new List<double>() { 115.52, 32.87, -40.179, -48.6, 293.89, 246.7, 630.5 };

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
