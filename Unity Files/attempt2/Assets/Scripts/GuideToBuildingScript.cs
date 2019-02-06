using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideToBuildingScript : MonoBehaviour
{
    List<string> names = new List<string>() { "Please Select A Building", "Sherrington Building", "Harold Cohen Library", "Electrical Engineering", "Ashton Building", "George Holt", "Harrison Hughes" };
    List<double> locationsX = new List<double>() { 93.27, -55.46398, -391.484, -693.6182, -497.38, -359.2, -600.5 };  //Default position [0] set incase no option is somehow picked
    List<double> locationsY = new List<double>() { 1.5, 1.13, 4.44, 3.01, 1, 1, 1 };
    List<double> locationsZ = new List<double>() { 115.52, 32.87, -40.179, -48.6, 293.89, 246.7, 630.5 };

    public Dropdown dropdown;

    public Button goGuideButton;
    private GameObject targetObject;
    public Objective objective;
    public GameObject arrowBG;
    public GameObject sheringtonPad;
    public GameObject cohenPad;
    public GameObject electricalPad;
    public GameObject ashtonPad;
    public GameObject gHoltPad;
    public GameObject hHughesPad;


    public void Dropdown_INdexChanged(int index)
    {

        if (index == 0)
        {
            goGuideButton.enabled = false;
        }
        else
        {
            //switch on dropdown index, change target based on user input
            switch (index)
            {
                case 1:
                    targetObject = GameObject.Find("SherringtonPad");
                    objective.setTarget(targetObject);
                    break;
                case 2:
                    
                    print("Inside Switch Case 2, Find Game Objejct CohenPad");
                    objective.setTarget(cohenPad);
                    break;
                case 3:
                    targetObject = GameObject.Find("ElectricalPad");
                    objective.setTarget(targetObject);
                    break;
                case 4:
                    targetObject = GameObject.Find("AshtonPad");
                    objective.setTarget(targetObject);
                    break;
                case 5:
                    targetObject = GameObject.Find("GHoltPad");
                    objective.setTarget(targetObject);
                    break;
                case 6:
                    targetObject = GameObject.Find("HHughesPad");
                    objective.setTarget(targetObject);
                    break;
            }

            goGuideButton.enabled = true;

            //in the usermovement scripts / areapad scripts, if the pad the user is stood on is the target, then clear arrow
        }

       
    }


    void Start()
    {
        goGuideButton.enabled = false;
        arrowBG.SetActive(false);
        PopulateList();
    }

    void PopulateList()
    {
        dropdown.AddOptions(names);
    }

}
