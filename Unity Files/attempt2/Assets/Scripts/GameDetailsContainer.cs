using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDetailsContainer : MonoBehaviour
{
    public static GameDetails LoadedGameDetails = null;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

}
