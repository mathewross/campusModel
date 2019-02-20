using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoGuideScript : MonoBehaviour
{

    //public UserMovement userMovement;
    //public GameObject arrowBG;
    public GameScene gameScene;
    public Objective objective;

    public void goButton()
    {
        //pass the start and end locations to the guidance routine
        gameScene.beginGuidance(objective.getStartLocation(), objective.getTarget());
    }

}
