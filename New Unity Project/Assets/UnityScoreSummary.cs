using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

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

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
