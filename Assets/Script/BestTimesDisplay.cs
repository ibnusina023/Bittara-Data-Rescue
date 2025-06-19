using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class BestTimesDisplay : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI sceneTutorBestTimeText;
    [SerializeField] private TextMeshProUGUI scene1BestTimeText;
    [SerializeField] private TextMeshProUGUI scene2BestTimeText;
    [SerializeField] private TextMeshProUGUI scene3BestTimeText;
    [SerializeField] private TextMeshProUGUI scene4BestTimeText;
    
    private void Start()
    {
        DisplayBestTimes();
    }

    private void DisplayBestTimes()
    {
        // Display best time for each specific scene in its own TextMeshProUGUI component
        if (sceneTutorBestTimeText != null)
        {
            sceneTutorBestTimeText.text = GetFormattedBestTime("StageTutorial");
        }

        if (scene1BestTimeText != null)
        {
            scene1BestTimeText.text = GetFormattedBestTime("Stage1");
        }

        if (scene2BestTimeText != null)
        {
            scene2BestTimeText.text = GetFormattedBestTime("Stage2");
        }

        if (scene3BestTimeText != null)
        {
            scene3BestTimeText.text = GetFormattedBestTime("Stage3");
        }

        if (scene4BestTimeText != null)
        {
            scene4BestTimeText.text = GetFormattedBestTime("Stage4");
        }
    }

    private string GetFormattedBestTime(string sceneName)
    {
        string bestTimeKey = "BestTime_" + sceneName;
        float bestTime = PlayerPrefs.GetFloat(bestTimeKey, Mathf.Infinity);

        return bestTime == Mathf.Infinity ? "--:--" : FormatTime(bestTime);
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
