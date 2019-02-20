using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MainMenu : MonoBehaviour
{

    public void playOpenWorld()
    {
        SavedSettings.GameMode = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void playGame()
    {
        SavedSettings.StartX = -1115;
        SavedSettings.StartY = 6;
        SavedSettings.StartZ = -35;
        SavedSettings.RunSpeed = 200;
        SavedSettings.GameMode = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        
    }

    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        
    }

}
