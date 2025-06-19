using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI bestTimeText;
    private float elapsedTime;
    private bool timerRunning = true;
    private string bestTimeKey;

    // Add an array to specify all scene names for which you want to clear best times
    [SerializeField] private string[] sceneNames;

    void Start()
    {
        // Unique key for the scene
        bestTimeKey = "BestTime_" + UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

        // Display best time from PlayerPrefs, if bestTimeText is assigned
        float bestTime = PlayerPrefs.GetFloat(bestTimeKey, Mathf.Infinity);
        if (bestTimeText != null)
        {
            bestTimeText.text = bestTime == Mathf.Infinity ? "--:--" : FormatTime(bestTime);
        }
    }

    void Update()
    {
        if (timerRunning)
        {
            elapsedTime += Time.deltaTime;

            // Only update timerText if it exists (assigned in the Inspector)
            if (timerText != null)
            {
                timerText.text = FormatTime(elapsedTime);
            }
        }
    }

    public void StopTimer()
    {
        timerRunning = false;

        // Update best time if the elapsed time is shorter
        float bestTime = PlayerPrefs.GetFloat(bestTimeKey, Mathf.Infinity);
        if (elapsedTime < bestTime)
        {
            PlayerPrefs.SetFloat(bestTimeKey, elapsedTime);
            PlayerPrefs.Save();

            // Only update bestTimeText if it exists
            if (bestTimeText != null)
            {
                bestTimeText.text = FormatTime(elapsedTime);
            }
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        return string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Method to reset the best time for the current scene
    public void ResetBestTime()
    {
        PlayerPrefs.DeleteKey(bestTimeKey);

        if (bestTimeText != null)
        {
            bestTimeText.text = "--:--";
        }

        Debug.Log("Best time has been reset for this scene.");
    }

    // Method to reset the best times for all specified scenes
    public void ResetAllBestTimes()
    {
        foreach (string sceneName in sceneNames)
        {
            string key = "BestTime_" + sceneName;
            PlayerPrefs.DeleteKey(key);
        }

        if (bestTimeText != null)
        {
            bestTimeText.text = "--:--";
        }

        Debug.Log("Best times have been reset for all specified scenes.");
    }
}


// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class Timer : MonoBehaviour
// {
//     [SerializeField] TextMeshProUGUI timerText;
//     float elapsedTime;

//     // Update is called once per frame
//     void Update()
//     {
//         elapsedTime += Time.deltaTime;
//         int minutes = Mathf.FloorToInt(elapsedTime / 60);
//         int seconds = Mathf.FloorToInt(elapsedTime % 60);

//         timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
//     }
// }


/////////////////////////////////////////////////////////////////////////////////

// using UnityEngine;
// using TMPro;

// public class Timer : MonoBehaviour
// {
//     [SerializeField] TextMeshProUGUI timerText;
//     [SerializeField] TextMeshProUGUI bestTimeText;
//     private float elapsedTime;
//     private bool timerRunning = true;
    
//     void Start()
//     {
//         if (timerText == null)
//         {
//             Debug.LogError("timerText is not assigned in the Inspector!");
//         }
//         // Display best time from PlayerPrefs, defaulting to 0 if none exists
//         float bestTime = PlayerPrefs.GetFloat("BestTime", 0);
//         bestTimeText.text = FormatTime(bestTime);
//     }

//     void Update()
//     {
//         if (timerText != null)
//         {
//             // Update timer text here
//             timerText.text = "some text"; 
//         }
//         if (timerRunning)
//         {
//             elapsedTime += Time.deltaTime;
//             timerText.text = FormatTime(elapsedTime);
//         }
//     }

//     public void StopTimer()
//     {
//         timerRunning = false;

//         // Update best time if this is the new best
//         float bestTime = PlayerPrefs.GetFloat("BestTime", 0);
//         if (elapsedTime > bestTime)
//         {
//             PlayerPrefs.SetFloat("BestTime", elapsedTime);
//             bestTimeText.text = FormatTime(elapsedTime);
//         }
//     }

//     private string FormatTime(float time)
//     {
//         int minutes = Mathf.FloorToInt(time / 60);
//         int seconds = Mathf.FloorToInt(time % 60);
//         return string.Format("{0:00}:{1:00}", minutes, seconds);
//     }

//     public void ResetBestTime()
//     {
//         PlayerPrefs.DeleteKey("BestTime");
//         bestTimeText.text = "--:--";
//     }
// }

////////////////////////////////////////////////////////

// using UnityEngine;
// using TMPro;

// public class Timer : MonoBehaviour
// {
//     [SerializeField] TextMeshProUGUI timerText;
//     [SerializeField] TextMeshProUGUI bestTimeText;
//     private float elapsedTime;
//     private bool timerRunning = true;
    
//     void Start()
//     {
//         if (timerText == null)
//         {
//             Debug.LogError("timerText is not assigned in the Inspector!");
//         }

//         // Display best time from PlayerPrefs, defaulting to a high value if none exists
//         float bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);
//         bestTimeText.text = bestTime == Mathf.Infinity ? "--:--" : FormatTime(bestTime);
//     }

//     void Update()
//     {
//         if (timerRunning)
//         {
//             elapsedTime += Time.deltaTime;
//             timerText.text = FormatTime(elapsedTime);
//         }
//     }

//     public void StopTimer()
//     {
//         timerRunning = false;

//         // Update best time if the elapsed time is shorter
//         float bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);
//         if (elapsedTime < bestTime)
//         {
//             PlayerPrefs.SetFloat("BestTime", elapsedTime);
//             PlayerPrefs.Save();
//             bestTimeText.text = FormatTime(elapsedTime);
//         }
//     }

//     private string FormatTime(float time)
//     {
//         int minutes = Mathf.FloorToInt(time / 60);
//         int seconds = Mathf.FloorToInt(time % 60);
//         return string.Format("{0:00}:{1:00}", minutes, seconds);
//     }

//     public void ResetBestTime()
//     {
//         PlayerPrefs.DeleteKey("BestTime");
//         bestTimeText.text = "--:--";
//     }
// }

//////////////////////////////////////////

// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using TMPro;

// public class Timer : MonoBehaviour
// {
//     [SerializeField] private TextMeshProUGUI timerText;
//     [SerializeField] private TextMeshProUGUI bestTimeText;
//     private float elapsedTime;
//     private bool timerRunning = true;

//     void Start()
//     {
//         if (bestTimeText == null)
//         {
//             Debug.LogError("bestTimeText is not assigned in the Inspector!");
//         }

//         // Display best time from PlayerPrefs, defaulting to a high value if none exists
//         float bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);
//         bestTimeText.text = bestTime == Mathf.Infinity ? "--:--" : FormatTime(bestTime);
//     }

//     void Update()
//     {
//         if (timerRunning)
//         {
//             elapsedTime += Time.deltaTime;

//             // Only update timerText if it exists (assigned in the Inspector)
//             if (timerText != null)
//             {
//                 timerText.text = FormatTime(elapsedTime);
//             }
//         }
//     }

//     public void StopTimer()
//     {
//         timerRunning = false;

//         // Update best time if the elapsed time is shorter
//         float bestTime = PlayerPrefs.GetFloat("BestTime", Mathf.Infinity);
//         if (elapsedTime < bestTime)
//         {
//             PlayerPrefs.SetFloat("BestTime", elapsedTime);
//             PlayerPrefs.Save();
//             bestTimeText.text = FormatTime(elapsedTime);
//         }
//     }

//     private string FormatTime(float time)
//     {
//         int minutes = Mathf.FloorToInt(time / 60);
//         int seconds = Mathf.FloorToInt(time % 60);
//         return string.Format("{0:00}:{1:00}", minutes, seconds);
//     }

//     public void ResetBestTime()
//     {
//         PlayerPrefs.DeleteKey("BestTime");
//         bestTimeText.text = "--:--";
//     }
// }
/////////////////////////////////////////