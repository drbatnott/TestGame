using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
using System;

public class UnityScoreSummary : MonoBehaviour
{
    public class ScoreSummary
    {
        double highScore;
        public double HighScore { get { return highScore; } }
        public ScoreSummary(double hs = 0)
        {
            highScore = hs;
        }
    }
    ScoreSummary scoreSummary;
    public Text highScoreText;
    float timeNowSecs;
    int timeNowMins;
    bool running;
    string timeString;
    string totalTime;
    void DisplayTime()
    {
        timeNowSecs += Time.deltaTime;
        if (timeNowSecs > 60)
        {
            timeNowMins++;
            timeNowSecs = 0;
        }
        timeString = String.Format("{0:0.#}", timeNowSecs);
        Debug.Log(timeString);
        Debug.Log(timeNowMins);
    }

    // Start is called before the first frame update
    void Start()
    {
        TextReader textReader = new StreamReader("Scores.csv");
        string input = textReader.ReadLine();
        textReader.Close();
        string[] parts = input.Split(',');
        double hs = double.Parse(parts[1]);
        scoreSummary = new ScoreSummary(hs);
        Debug.Log(scoreSummary.HighScore);
        highScoreText.text = "High score " + scoreSummary.HighScore;
        Debug.Log(highScoreText.text);
        running = false;
        timeString = "";
        /*
         * We made the following so we would know the file was 
         * where we needed it to be
        TextWriter textWriter = new StreamWriter("Scores.csv");
        textWriter.WriteLine("High Score,150");
        textWriter.WriteLine("Score,15");
        textWriter.WriteLine("Time,300");
        textWriter.WriteLine("BestTime,30");
        textWriter.Close();
        */
        timeNowSecs = 0;
        timeNowMins = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*
         * So we could see how deltaTime changed we logged the changes
        Debug.Log(Time.deltaTime);
        */
        if (running) {
            DisplayTime();
        }
    }
    public void StartButtonClicked()
    {
        running = true;
    }
    public void StopButtonClicked()
    {
        running = false;
        totalTime = timeNowMins + ":" + timeString;
        Debug.Log(totalTime);
        totalTime = "";
        timeNowSecs = 0;
        timeNowMins = 0;
    }
}
