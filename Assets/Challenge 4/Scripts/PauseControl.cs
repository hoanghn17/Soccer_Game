using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PauseControl : MonoBehaviour
{
    public TextMeshProUGUI pauseText;

    public static bool gameIsPaused;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }
    void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 0f;
            pauseText.gameObject.SetActive(true);
        }
        else
        {
            Time.timeScale = 1;
            pauseText.gameObject.SetActive(false);
        }
    }
}