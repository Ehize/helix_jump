﻿using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    public static bool gameOver;
    public static bool levelCompleted;
    public static bool isGameStarted;
    public static bool mute = false;

    public GameObject gameOverPanel;
    public GameObject levelCompletedPanel;
    public GameObject gamePlayPanel;
    public GameObject startMenuPanel;

    public static int currentLevelIndex;
    public TextMeshProUGUI currentLevelText;
    public TextMeshProUGUI nextLevelText;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    public Slider gameProgressSlider;

    public static int numberOfPassedRings;
    public static int score = 0;

    private void Awake()
    {
        currentLevelIndex = PlayerPrefs.GetInt("CurrentLevelIndex", 1);
    }

    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
        numberOfPassedRings = 0;
        highScoreText.text = "Best Score\n" + PlayerPrefs.GetInt("HighScore", 0);
        isGameStarted = gameOver = levelCompleted = false;
        AdManager.instance.RequestInterstitial();
    }

    // Update is called once per frame
    void Update()
    {
        //Update our UI
        currentLevelText.text = currentLevelIndex.ToString();
        nextLevelText.text = (currentLevelIndex+1).ToString();

        int progress = numberOfPassedRings * 100 / FindObjectOfType<HelixManager>().numberOfRings;
        gameProgressSlider.value = progress;

        scoreText.text = score.ToString();
        
        //Start level PC
        if(Input.GetMouseButtonDown(0) && !isGameStarted)
        {
            if (EventSystem.current.IsPointerOverGameObject())
               return;

               isGameStarted = true;
               gamePlayPanel.SetActive(true);
               startMenuPanel.SetActive(false);
        }


        //Enable rotation on mobile
        /* if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began && !isGameStarted)
        {
            if(EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            return;
            isGameStarted = true;
            gamePlayPanel.SetActive(true);
            startMenuPanel.SetActive(false);
        } */

        //Game Over
        if (gameOver)
        {
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

          if(Input.GetButtonDown("Fire1")) {
            if(score > PlayerPrefs.GetInt("HighScore", 0))
            {
                PlayerPrefs.SetInt("HighScore", score);
            }
            score = 0;
            SceneManager.LoadScene("Level");
          }

          if(Random.Range(0, 3) == 0)
          {
             AdManager.instance.ShowInterstitial();
          }
        }
        
        //level complete
         if (levelCompleted)
        {
            levelCompletedPanel.SetActive(true);

          if(Input.GetButtonDown("Fire1")) {
            PlayerPrefs.SetInt("CurrentLevelIndex", currentLevelIndex +1);
            SceneManager.LoadScene("Level");
          }
        }
    }
}
