using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpToBuildingScript : MonoBehaviour
{
    List<string> names = new List<string>() { "Please Select A Building", "Sherrington Building", "Harold Cohen Library", "Electrical Engineering", "Ashton Building", "George Holt", "Harrison Hughes" };
    List<double> locationsX = new List<double>() { 93.27, -55.46398, -391.484, -693.6182, -497.38, -359.2, -600.5 };  //Default position [0] set incase no option is somehow picked
    List<double> locationsY = new List<double>() { 1.5, 1.13, 4.44, 3.01, 1, 1, 1 };
    List<double> locationsZ = new List<double>() { 115.52, 32.87, -40.179, -48.6, 293.89, 246.7, 630.5 };

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
