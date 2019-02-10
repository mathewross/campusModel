using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objective : MonoBehaviour
{

    private GameObject targetBuilding;

    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<GameScene>().objective = this;
        FindObjectOfType<GuideToBuildingScript>().objective = this;
        FindObjectOfType<PlayerNavController>().objective = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setTarget(GameObject target)
    {
        targetBuilding = target;
    }

    public GameObject getCurrentTarget()
    {
        return targetBuilding;
    }
}
