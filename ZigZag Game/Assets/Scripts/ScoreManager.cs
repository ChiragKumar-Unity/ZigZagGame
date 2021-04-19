using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{

    public static ScoreManager instance;

    public int Score;
    public int HighScore;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Score = 0;
        // to save the score value in our computer memory using the key and value pair VERY IMP
        PlayerPrefs.SetInt("Score", Score);
        //                    key  , value
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void incrementScore ()
    {
        Score += 1;
    }

    public void StartScore()
    {
        InvokeRepeating ("incrementScore", 0.1f, 0.5f);
    }

    public void StopScore ()
    {
        // cancelling incrementScore
        CancelInvoke("incrementScore");
        PlayerPrefs.SetInt("Score", Score);

        if (PlayerPrefs.HasKey("HighScore")) // to check if this key is saved
        {
            if (Score > PlayerPrefs.GetInt("HighScore")) // to get the value from the key
            {
                PlayerPrefs.SetInt("HighScore", Score);
            }
        } 
        else {
            PlayerPrefs.SetInt("HighScore", Score);
        }
    }
}
