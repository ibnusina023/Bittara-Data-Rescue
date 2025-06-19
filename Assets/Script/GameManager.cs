using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private Timer timer;

    void Start()
    {
        timer = FindObjectOfType<Timer>(); // Automatically finds the Timer in the scene
    }

    public void CompleteLevel()
    {
        if (timer != null)
        {
            timer.StopTimer();
        }
        else
        {
            Debug.LogWarning("Timer not found!");
        }
    }

    public void ResetButton()
    {
        if (timer != null)
        {
            timer.ResetBestTime(); // Call ResetBestTime in Timer
        }
        else
        {
            Debug.LogError("Timer script not found!");
        }
    }

    public void UnlockedNewLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int reachedIndex = PlayerPrefs.GetInt("ReachedIndex", 1);
        int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

        Debug.Log("[DEBUG] Current Scene Index: " + currentIndex);
        Debug.Log("[DEBUG] ReachedIndex: " + reachedIndex);
        Debug.Log("[DEBUG] UnlockedLevel: " + unlockedLevel);

        if(currentIndex >= reachedIndex)
        {
            PlayerPrefs.SetInt("ReachedIndex", currentIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel + 1);
            PlayerPrefs.Save();
            Debug.Log(">> Level Unlocked!");
        }
        else
        {
            Debug.Log(">> No new level unlocked. CurrentIndex too low.");
        }
    }


    // public void UnlockedNewLevel(){
    //     if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
    //     {
    //         PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
    //         PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
    //         PlayerPrefs.Save();
    //     }
    // }

    // public void UnlockedNewLevel()
    // {
    //     int currentIndex = SceneManager.GetActiveScene().buildIndex;
    //     int reachedIndex = PlayerPrefs.GetInt("ReachedIndex", 0);
    //     int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);

    //     Debug.Log($"[DEBUG] Current Scene Index: {currentIndex}");
    //     Debug.Log($"[DEBUG] ReachedIndex: {reachedIndex}");
    //     Debug.Log($"[DEBUG] UnlockedLevel: {unlockedLevel}");

    //     if(currentIndex >= reachedIndex)
    //     {
    //         PlayerPrefs.SetInt("ReachedIndex", currentIndex + 1);
    //         PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel + 1);
    //         PlayerPrefs.Save();
    //         Debug.Log(">> New level unlocked!");
    //     }
    //     else
    //     {
    //         Debug.Log(">> No new level unlocked.");
    //     }
    // }

//     public void UnlockedNewLevel()
// {
//     int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1);
//     PlayerPrefs.SetInt("UnlockedLevel", unlockedLevel + 1);
//     PlayerPrefs.Save();
//     Debug.Log(">> Level unlocked up to: " + (unlockedLevel + 1));
// }



    // public void UnlockedNewLevel()
    // {
    //     int currentLevelIndex = SceneManager.GetActiveScene().buildIndex;
    //     int unlockedLevel = PlayerPrefs.GetInt("UnlockedLevel", 1); // Default to 1 if not set

    //     // Unlock the next level if the current level is the last unlocked one
    //     if (currentLevelIndex >= unlockedLevel)
    //     {
    //         PlayerPrefs.SetInt("UnlockedLevel", currentLevelIndex + 1); // Unlock the next level
    //         PlayerPrefs.Save(); // Save changes to PlayerPrefs
    //     }
    // }

    public void ResetUnlockedLevels()
    {
        PlayerPrefs.SetInt("ReachedIndex", 0); // Reset the highest reached level to 0 (or starting level)
        PlayerPrefs.SetInt("UnlockedLevel", 1); // Reset unlocked levels to the first level
        PlayerPrefs.Save(); // Save the changes
    }

}
