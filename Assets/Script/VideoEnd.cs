using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VideoEnd : MonoBehaviour
{
    GameManager managerScript;

    public VideoPlayer videoPlayer; // Reference to the VideoPlayer component

    void Start()
    {
        // Add an event listener for when the video finishes playing
        managerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
        videoPlayer.loopPointReached += OnVideoEnd;
    }

    // void OnVideoEnd(VideoPlayer vp)
    // {
    //     // Load the next scene when the video ends
    //     managerScript.UnlockedNewLevel();
    //     SceneManager.LoadScene("LevelSelect");
    // }

    void OnVideoEnd(VideoPlayer vp)
    {
        Debug.Log("Video selesai! Memanggil UnlockedNewLevel().");
        if (managerScript != null)
        {
            managerScript.UnlockedNewLevel();
        }
        else
        {
            Debug.LogWarning("Manager script tidak ditemukan!");
        }

        SceneManager.LoadScene("LevelSelect");
    }

}
