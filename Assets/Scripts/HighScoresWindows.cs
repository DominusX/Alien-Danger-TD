using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class HighScoresWindows : MonoBehaviour
{

    const string privateCode = "_o9I4WdLj0SOrleD45fnVwyIg3pEOeWUirsvAUDATK4w";
    const string publicCode = "5672ddb36e51b608e4448b8e";
    const string webURL = "http://dreamlo.com/lb/";
    public Text scoreText;

  
    public Highscore[] highscoresList;
    public static HighScoresWindows instance;
    
    public int SCORE_MAX = 5;

    void Start()
    {
        
        DownloadHighscores();
        
      // AddNewHighscore("Harry", 1500);
    }

    void Awake()
    {
        
        instance = this;
    }

    public static void AddNewHighscore(string username, int score)
    {
        instance.StartCoroutine(instance.UploadNewHighscore(username, score));
    }

    IEnumerator UploadNewHighscore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            print("Upload Successful");
            DownloadHighscores();
        }
        else {
            print("Error uploading: " + www.error);
        }
    }

    public void DownloadHighscores()
    {
        StartCoroutine("DownloadHighscoresFromDatabase");
    }

    IEnumerator DownloadHighscoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
          
        }
        else {
            print("Error Downloading: " + www.error);
        }
    }

    void FormatHighscores(string textStream)
    {
         string tempScore = " ";
        string[] entries = textStream.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entries.Length];
        
        for (int i = 0; i < SCORE_MAX; i++)
        {
            string[] entryInfo = entries[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
            
            tempScore+= highscoresList[i].username + ": " + highscoresList[i].score +"\n" ;
           
        }
        scoreText.text = tempScore;
    }

}

public struct Highscore
{
    public string username;
    public int score;

    public Highscore(string _username, int _score)
    {
        username = _username;
        score = _score;
    }

}