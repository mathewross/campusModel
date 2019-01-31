using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GoButtonScript : MonoBehaviour
{

    public UserMovement userMovement;
    public void goButton()
    {
        userMovement = GameObject.FindObjectOfType(typeof(UserMovement)) as UserMovement;
        userMovement.ChangePosition(SavedSettings.NewX, SavedSettings.NewY, SavedSettings.NewZ);
    }

}
