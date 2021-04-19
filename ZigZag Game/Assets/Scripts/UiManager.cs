using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiManager : MonoBehaviour
{

    public static UiManager instance;

    public GameObject headerPanel;
    public GameObject gameOverPanelHolder;
    public Text Score;
    public Text HighScoreStart;
    public Text HighScoreInGame;
    public GameObject tapText;

    private void Awake()
    {
        // one single instance
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        HighScoreStart.text = "High Score : " + PlayerPrefs.GetInt("HighScore");
    }

    public void GameStart()
    {
        tapText.SetActive(false);
        // to play the animation
        headerPanel.GetComponent<Animator>().Play("panelUp");
    }

    public void GameOver()
    {
        // setting the text
        Score.text = PlayerPrefs.GetInt ("Score").ToString();
        HighScoreInGame.text = PlayerPrefs.GetInt("HighScore").ToString();
        gameOverPanelHolder.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
