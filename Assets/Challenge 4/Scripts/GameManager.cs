using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI timeText;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOverText;

    //public GameObject titleScreen;

    public float time = 30;

    public bool isGameActive;

    private int score;

    // Start is called before the first frame update
    void Start()
    {
        //StartGame();
    }

    // Update is called once per frame
    void Update()
    {
        if (isGameActive == true)
        {
            time -= Time.deltaTime;
            timeText.text = "Time: " + Mathf.Round(time);

            if (time < 0)
            {
                GameOver();
                Time.timeScale = 0;
                Debug.Log("Game Over");
            }
        }
    }

    public void StartGame()
    {
        isGameActive = true;
        score = 0;
        UpdateScore(0);
    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true); // If Gameover show text
        isGameActive = false;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "score " + score;
    }
}
