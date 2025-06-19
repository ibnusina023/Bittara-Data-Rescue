using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BestScore : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI bestTimeText;

    void Start()
    {
        DisplayBestTime();
    }

    public void DisplayBestTime()
    {
        float bestTime = PlayerPrefs.GetFloat("BestTime", 0);
        int minutes = Mathf.FloorToInt(bestTime / 60);
        int seconds = Mathf.FloorToInt(bestTime % 60);
        bestTimeText.text = string.Format("Best Time: {0:00}:{1:00}", minutes, seconds);
    }
}
