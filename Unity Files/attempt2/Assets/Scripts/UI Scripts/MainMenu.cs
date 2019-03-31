using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    public Text userInput;

    public void playOpenWorld()
    {
        SavedSettings.GameMode = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void playGame()
    {
        
        if (userInput.text.ToString() == "")
        {
            //EditorUtility.DisplayDialog("Invalid input", "Nickname cannot be null, please try again", "Ok");
        }
        else
        {
            string userName = userInput.text.ToString();
            SavedSettings.UserName = userName;
            GameDetailsContainer.LoadedGameDetails = DataAccess.Load();
            SavedSettings.StartX = -1115;
            SavedSettings.StartY = 6;
            SavedSettings.StartZ = -35;
            SavedSettings.RunSpeed = 200;
            SavedSettings.GameMode = true;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
        }
    }

    public void quitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
        
    }

}
