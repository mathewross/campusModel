using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameTimer : MonoBehaviour
{
    public Text timerText;
    private float startTime;
    public bool finished = false;
    public bool gameMode = false;

    // Start is called before the first frame update
    void Start()
    {
        //if (SavedSettings.GameMode == true)
       // {
            startTime = Time.time;
        //}
    }

    // Update is called once per frame
    void Update()
    {
        //if (SavedSettings.GameMode == true)
        //{
            if (finished)
            {
                return;
            }

            float t = Time.time - startTime;

            string minutes = ((int)t / 60).ToString();
            string seconds = (t % 60).ToString("f1");

            timerText.text = minutes + ":" + seconds;
        //}
    }

    public void finishTimer()
    {
        finished = true;
        timerText.color = Color.red;
    }
}
