using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonAction : MonoBehaviour
{
    private Timer timer;
    private GameManager managerScript;

    void Start()
    {
        // Find and assign the Timer script
        timer = FindObjectOfType<Timer>();
        managerScript = FindObjectOfType<GameManager>();

    }

    // Start is called before the first frame update
    public void PlayButton(){
        SceneManager.LoadScene("LevelSelect");
        AudioManager.Instance.PlaySFX("Click");
    }
    
    public void QuitButton(){
        AudioManager.Instance.PlaySFX("Click");
        Application.Quit();
    }

    // LEVEL BUTTON //
    public void BackButton(){
        SceneManager.LoadScene("MainMenu");
        AudioManager.Instance.PlaySFX("Click");
    }
    
    public void StageStoryButton1(){
        SceneManager.LoadScene("Story1");
        AudioManager.Instance.PlaySFX("Click");
    }

    public void StageStoryButton2(){
        SceneManager.LoadScene("Story2");
        AudioManager.Instance.PlaySFX("Click");
    }

    public void StageStoryButton3(){
        SceneManager.LoadScene("Story3");
        AudioManager.Instance.PlaySFX("Click");
    }

    public void StageTutorButton(){
        SceneManager.LoadScene("StageTutorial");
        AudioManager.Instance.PlaySFX("Click");
    }

    public void StageButton1(){
        SceneManager.LoadScene("Stage1");
        AudioManager.Instance.PlaySFX("Click");
    }

    public void StageButton2(){
        SceneManager.LoadScene("Stage2");
        AudioManager.Instance.PlaySFX("Click");
    }

    public void StageButton3(){
        SceneManager.LoadScene("Stage3");
        AudioManager.Instance.PlaySFX("Click");
    }

    public void StageButton4(){
        SceneManager.LoadScene("Stage4");
        AudioManager.Instance.PlaySFX("Click");
    }

    public void OnResetButtonClicked()
    {
        AudioManager.Instance.PlaySFX("Click");
        if (timer != null)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            timer.ResetAllBestTimes(); // Call ResetBestTime, no direct access to bestTimeText
        }
        else
        {
            Debug.LogError("Timer script not found!");
        }
        if (managerScript != null)
        {
            managerScript.ResetUnlockedLevels();
        }
        else
        {
            Debug.LogError("GameManager reference is missing in ButtonAction.");
        }

    }
}
