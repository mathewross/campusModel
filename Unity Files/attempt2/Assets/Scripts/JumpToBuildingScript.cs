using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpToBuildingScript : MonoBehaviour
{
    List<string> names = new List<string>() { "Please Select A Building", "Sherrington Building", "Harold Cohen Library", "Electrical Engineering", "Ashton Building", "George Holt", "Harrison Hughes" };
    List<double> locationsX = new List<double>() { 65.92, 305.7, -182, -613.35, -330.1, -127.9, -478.1 };  //Default position [0] set incase no option is somehow picked
    List<double> locationsY = new List<double>() { 6.12, 0.26, 5.2, 2.94, 0.26, 0.26, 0.26 };
    List<double> locationsZ = new List<double>() { 115.52, -4.7, -105, -104.1, 383.7, 301.4, 852.1 };

    public Dropdown dropdown;

    public Button goButton;
    private double newX;
    private double newY;
    private double newZ;

    public void Dropdown_INdexChanged(int index)
    {

        if (index == 0)
        {
            goButton.enabled = false;
        }
        else
        {
            goButton.enabled = true;
        }

        SavedSettings.NewX = locationsX[index];
        SavedSettings.NewY = locationsY[index];
        SavedSettings.NewZ = locationsZ[index];
        print(SavedSettings.StartX);
    }

    public double NewX
    {
        get
        {
            return newX;
        }
        set
        {
            newX = value;
        }
    }

    public double NewY
    {
        get
        {
            return newY;
        }
        set
        {
            newY = value;
        }
    }

    public double NewZ
    {
        get
        {
            return newZ;
        }
        set
        {
            newZ = value;
        }
    }

    void Start()
    {
        goButton.enabled = false;
        PopulateList();
    }

    void PopulateList()
    {
        dropdown.AddOptions(names);
    }

}
