using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    // Controls level of the player
    private bool canGoToNextLevel = false;
    public GameObject gameOver;
    public Text gameOverText;
    public AchievementScript achievementScript;
    private float startTime;

    void Start() {
        startTime = Time.realtimeSinceStartup;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && canGoToNextLevel)
        {
            if (Time.time - startTime <= 60f)
                 achievementScript.UnlockAchievement(1);
                 
            if (SceneManager.GetActiveScene().buildIndex == 1) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                achievementScript.UnlockAchievement(3);
            }
            else
            {
                gameOver.SetActive(true);
                gameOverText.text = "You won!!!";
                CursorController.EnableCursor();
            }
        }
    }

    public void AllowNextLevel()
    {
        canGoToNextLevel = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Home()
    {
        SceneManager.LoadScene(0);
    }
}
