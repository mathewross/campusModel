﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoGuideScript : MonoBehaviour
{

    public UserMovement userMovement;
    public GameObject arrowBG;
    public GameScene gameScene;

    public void goButton()
    {
        arrowBG.SetActive(true);
        gameScene.beginGuidance();
    }

}