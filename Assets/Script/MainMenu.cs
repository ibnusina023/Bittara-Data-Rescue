using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject settingMenu;
    public GameObject mainMenu;
    public GameObject creditScreen;
    // Start is called before the first frame update
    void Start()
    {
        settingMenu.SetActive(false);
        mainMenu.SetActive(true);
        creditScreen.SetActive(false);
    }

    public void PlayButton(){
        SceneManager.LoadScene("StageTutorial");
    }

    public void SettingButton(){
        AudioManager.Instance.PlaySFX("Click");
        settingMenu.SetActive(true);
        mainMenu.SetActive(false);
    }

    public void SettingBack(){
        AudioManager.Instance.PlaySFX("Click");
        settingMenu.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void CreditButton(){
        AudioManager.Instance.PlaySFX("Click");
        settingMenu.SetActive(false);
        creditScreen.SetActive(true);
    }

    public void CreditBackButton(){
        AudioManager.Instance.PlaySFX("Click");
        settingMenu.SetActive(true);
        creditScreen.SetActive(false);
    }
    
    public void QuitButton(){
        AudioManager.Instance.PlaySFX("Click");
        Application.Quit();
    }
}
