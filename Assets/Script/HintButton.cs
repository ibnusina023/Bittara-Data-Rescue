using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HintButton : MonoBehaviour
{
    public GameObject HintMenu;
    public GameObject menuOver;

    // Start is called before the first frame update
    void Start()
    {
        HintMenu.SetActive(false);
    }

    public void HintPressed(){
        HintMenu.SetActive(true);
        menuOver.SetActive(false);
    }
    
    public void HintBack(){
        HintMenu.SetActive(false);
        menuOver.SetActive(true);
    }
}
