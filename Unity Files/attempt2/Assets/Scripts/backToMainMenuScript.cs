﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class backToMainMenuScript : MonoBehaviour
{
    public void backToMainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
