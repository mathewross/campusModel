using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class GameDetails
{
    public string[] topScoreNames = new string[5];
    public float[] topScores = new float[5];


    public GameDetails()
    {
        //initialise arrays to be empty
        for(int i =0; i < topScores.Length; i++)
        {
            topScoreNames[i] = "";
            topScores[i] = 0;
        }
    }


}
