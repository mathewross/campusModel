using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{

    private GameObject targetBuilding;
    private GameObject startingLocation;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameScene>().objective = this;
        FindObjectOfType<SelectStartLocationScript>().objective = this;        
        FindObjectOfType<GoGuideScript>().objective = this;
    }

    // Update is called once per frame
    void Update()
    {
        //
    }

    public void setStartingLocation(GameObject target)
    {
        startingLocation = target;
    }

    public GameObject getStartLocation()
    {
        return startingLocation;
    }

    public void setTarget(GameObject target)
    {
        targetBuilding = target;
    }

    public GameObject getTarget()
    {
        return targetBuilding;
    }
}
