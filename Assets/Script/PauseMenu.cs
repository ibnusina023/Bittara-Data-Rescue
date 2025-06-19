using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool IsPause;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
        IsPause = false;
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

    public void PauseGame(){
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        IsPause = true;
    }

    public void ResumeGame(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        IsPause = false;
    }

    public void RestartButton(){
        Time.timeScale = 1f;
        AudioManager.Instance.PlaySFX("Click");
        IsPause = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ResumeButton(){
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        AudioManager.Instance.PlaySFX("Click");
        IsPause = false;
    }

    public void BackToButton(){
        Time.timeScale = 1f;
        AudioManager.Instance.PlaySFX("Click");
        IsPause = false;
        SceneManager.LoadScene("LevelSelect");
    }

}
