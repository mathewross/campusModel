using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class gameTimer : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;
    public GameObject gameOverPanel;
    public Text timerText;
    private float startTime;
    public bool finished = false;
    public bool gameMode = false;
    private float finishedTime;
    private float playersTime = 0;
    // Start is called before the first frame update
    void Start()
    {
       
        startTime = Time.time;
    
    }

    // Update is called once per frame
    void Update()
    {
        //if the game is over, we want to stop playing and record the players time
        if (finished)
        {
            finishedTime = playersTime;
            return;
        }
        //if the game isn't over then we need to maintain the timer
        else
        {
            playersTime = Time.time - startTime;   
            string minutes = ((int)playersTime / 60).ToString();
            string seconds = (playersTime % 60).ToString("f1");
            timerText.text = minutes + ":" + seconds;
        }
    }

    //handle the end of the game
    public void finishTimer()
    {
        finished = true;
        timerText.color = Color.red;
        string minutes = ((int)finishedTime / 60).ToString();
        string seconds = (finishedTime % 60).ToString("f1");
        bool onLeaderBoard = false;
        int positionOnBoard = 0;

   
   
        /*
         * 
         * LOGIC BROKEN HERE SOMEWHERE
         * It is not correctly setting score when a new high score is reached, seconds highest score entered the leaderboard on the 2nd run, and then it set that for all entries in the array
         * It also keeps calling this method from the update function (may  be a part of the problem ) but my logic broke that, need to work on that
         * 
         * 
         * */

        //if there is some saved data (i.e. there have been previous attempts at the game)
        if (GameDetailsContainer.LoadedGameDetails != null)
        {
            for (int i = 0; i < 5; i++)
            {
                if (finishedTime > GameDetailsContainer.LoadedGameDetails.topScores[i])
                {
                    //push the scores down one to make room for new score
                    for (int j = 4; j > i; j--)
                    {
                        GameDetailsContainer.LoadedGameDetails.topScores[j - 1] = GameDetailsContainer.LoadedGameDetails.topScores[j];
                    }
                    onLeaderBoard = true;
                    positionOnBoard = i + 1;
                    GameDetailsContainer.LoadedGameDetails.topScores[i] = finishedTime;
                    break;
                }
            }

            for (int j = 0; j < GameDetailsContainer.LoadedGameDetails.topScores.Length; j++)
            {
                
                print(GameDetailsContainer.LoadedGameDetails.topScores[j]);
            }

            //save the game to the file
            Save(GameDetailsContainer.LoadedGameDetails);

            //if there is data to load and the player made it onto the leaderboard
            if (onLeaderBoard == true)
            {
                //tell the player theyve made it onto the leaderboard
                gameOverText.text = "You made it onto the leaderboard!\nYour position: " + positionOnBoard + ", with a time of: ;" + minutes + " minutes and " + seconds + " seconds";

            }
            else if (GameDetailsContainer.LoadedGameDetails != null && onLeaderBoard == false)
            {
                gameOverPanel.SetActive(true);
                gameOverText.text = "You did not make it onto the leaderboard, better luck next time!";
            }
        }
        //otherwise, this should be the first run of the game
        else
        {
            GameDetails gameDetails = new GameDetails();
            gameDetails.topScores[0] = finishedTime;
            gameOverPanel.SetActive(true);
            
            gameOverText.text = "No other scores have yet been recorded, you are the leader!\n Your time is: " + minutes + " minutes and " + seconds + " seconds.";
            print(gameDetails.topScores.Length);
            print("I am at the end of the game, before the for loop");
            gameDetails.topScores[0] = finishedTime;
            for (int j = 0; j < gameDetails.topScores.Length; j++)
            {
                print("This is within the for loop");
                print(gameDetails.topScores[j]);
            }
            print("I am at the end of the game, after the for loop");
            //save the game to the file
            Save(gameDetails);

            print("I am at the end of the game, after the save");
            return;
        }

        

        
        
    }
    


    //method to save data to file for persistence
    public void Save(GameDetails gameDetails)
    {
        DataAccess.Save(gameDetails);
    }
}
