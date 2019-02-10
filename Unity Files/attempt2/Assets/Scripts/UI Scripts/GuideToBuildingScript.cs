using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GuideToBuildingScript : MonoBehaviour
{
    List<string> names = new List<string>() { "Please Select A Building", "Sherrington Building", "Harold Cohen Library", "Electrical Engineering", "Ashton Building", "George Holt", "Harrison Hughes", "Brodie Tower", "The Guild", "Student Admin Center", "Central Teaching Hub", "Life Sciences", "Sports Hall", "Abercomby Square", "Sydney Jones Library", "Chadwick Building", "The AJ Pub", "Student Services", "The Clock Tower" };
    List<double> locationsX = new List<double>() { 65.92, 305.7, -182, -613.35, -330.1, -127.9, -478.1, -43.3, -1339.9, -1339.9, -2260, 61, -3673, -5214, -5647, -3375, -1375.9, -1357.9, -792.8 };  //Default position [0] set incase no option is somehow picked
    List<double> locationsY = new List<double>() { 6.12, 0.26, 5.2, 2.94, 0.26, 0.26, 0.26, 0.26, 0.26, 0.26, 0.26, -18.45, 0.26, 0.26, 0.26, 0.26, 0.26, 0.26, 0.26 };
    List<double> locationsZ = new List<double>() { 115.52, -4.7, -105, -104.1, 383.7, 301.4, 852.1, 1461, -333.6, 126, -2704, -2286, -516, -1502, -2667, -1577, -1152, -588.9, 446.4 };

    public Dropdown dropdown;

    public Button goGuideButton;
    private GameObject targetObject;
    public Objective objective;
    public GameObject arrowBG;



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

                    targetObject = GameObject.Find("SherringtonPad");
                    objective.setTarget(targetObject);
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
                case 7:
                    targetObject = GameObject.Find("BrodieTowerPad");
                    objective.setTarget(targetObject);
                    break;
                case 8:
                    targetObject = GameObject.Find("GuildPad");
                    objective.setTarget(targetObject);
                    break;
                case 9:
                    targetObject = GameObject.Find("AdminCenterPad");
                    objective.setTarget(targetObject);
                    break;
                case 10:
                    targetObject = GameObject.Find("CentralTeachingPad");
                    objective.setTarget(targetObject);
                    break;
                case 11:
                    targetObject = GameObject.Find("LifeSciencesPad");
                    objective.setTarget(targetObject);
                    break;
                case 12:
                    targetObject = GameObject.Find("SportsHallPad");
                    objective.setTarget(targetObject);
                    break;
                case 13:
                    targetObject = GameObject.Find("AberycombyPad");
                    objective.setTarget(targetObject);
                    break;
                case 14:
                    targetObject = GameObject.Find("SydneyJonesPad");
                    objective.setTarget(targetObject);
                    break;
                case 15:
                    targetObject = GameObject.Find("ChadwickPad");
                    objective.setTarget(targetObject);
                    break;
                case 16:
                    targetObject = GameObject.Find("AJPad");
                    objective.setTarget(targetObject);
                    break;
                case 17:
                    targetObject = GameObject.Find("StudentServicesPad");
                    objective.setTarget(targetObject);
                    break;
                case 18:
                    targetObject = GameObject.Find("ClockTowerPad");
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
