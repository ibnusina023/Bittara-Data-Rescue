using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video; // Add this to access VideoPlayer

public class SkipMenu : MonoBehaviour
{
    GameManager managerScript;
    public GameObject skipMenu;
    public static bool IsPause;
    public VideoPlayer videoPlayer; // Reference to the VideoPlayer

    // Start is called before the first frame update
    void Start()
    {
        skipMenu.SetActive(false);
        IsPause = false;
        managerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();

        // Optionally, get the VideoPlayer component if attached to the same GameObject
        if (videoPlayer == null)
            videoPlayer = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            if(IsPause){
                ResumeGame();
            }
            else{
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        skipMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPause = true;

        // Pause the video if it's playing
        if (videoPlayer != null && videoPlayer.isPlaying)
            videoPlayer.Pause();
    }

    public void ResumeGame()
    {
        skipMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPause = false;

        // Resume the video if it was paused
        if (videoPlayer != null && !videoPlayer.isPlaying)
            videoPlayer.Play();
    }

    public void SkipButton()
    {
        Time.timeScale = 1f;
        IsPause = false;
        managerScript.UnlockedNewLevel();
        SceneManager.LoadScene("LevelSelect");
    }

    public void ResumeButton()
    {
        skipMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPause = false;

        // Resume the video if it was paused
        if (videoPlayer != null && !videoPlayer.isPlaying)
            videoPlayer.Play();
    }
}
