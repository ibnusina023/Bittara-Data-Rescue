using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    public bool Locked;
    private Animator anim;
    [SerializeField] GameObject player;
    GameManager managerScript;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        Locked = true;
        managerScript = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        
        if(!Locked && distance < 2f)
        {
            managerScript.CompleteLevel();
            UnlockedNewLevel1();
            SceneManager.LoadScene("LevelSelect");
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Key")){
            anim.SetTrigger("Open");
            Locked = false;
        }
    }

    public void UnlockedNewLevel1(){
        if(SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReachedIndex", SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("UnlockedLevel", 1) + 1);
            PlayerPrefs.Save();
        }
    }
}
