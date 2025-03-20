using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AchievementScript : MonoBehaviour
{
    // Stores achievements and displays them on a panel
    public static AchievementScript Instance;
    public GameObject achievement1;
    public GameObject achievement2;
    public GameObject achievement3;

    private bool achievementUnlocked1;
    private bool achievementUnlocked2;
    private bool achievementUnlocked3;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            LoadAchievementState();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void LoadAchievementState()
    {
        achievementUnlocked1 = PlayerPrefs.GetInt("Achievement1", 0) == 1;
        achievementUnlocked2 = PlayerPrefs.GetInt("Achievement2", 0) == 2;
        achievementUnlocked3 = PlayerPrefs.GetInt("Achievement3", 0) == 3;

        if (achievementUnlocked1)
            GetAchievement1();
        if (achievementUnlocked2)
            GetAchievement2();
        if (achievementUnlocked3)
            GetAchievement3();
    }

    public void UnlockAchievement(int num)
    {
        if (num == 1)
        {
            achievementUnlocked1 = true;
            PlayerPrefs.SetInt("Achievement1", 1);
            GetAchievement1();
        }
        else if (num == 2)
        {
            achievementUnlocked2 = true;
            PlayerPrefs.SetInt("Achievement2", 2);
            GetAchievement2();
        }
        else if (num == 3)
        {
            achievementUnlocked3 = true;
            PlayerPrefs.SetInt("Achievement3", 3);
            GetAchievement3();
        }

        PlayerPrefs.Save();
    }

    public void GetAchievement1()
    {
        achievement1.SetActive(true);
    }

    public void GetAchievement2()
    {
        achievement2.SetActive(true);
    }

    public void GetAchievement3()
    {
        achievement3.SetActive(true);
    }

    private void OnApplicationQuit()
    {
        PlayerPrefs.DeleteAll();
    }
}
