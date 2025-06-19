using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMusicPlayer : MonoBehaviour
{
    public string musicName;

    void Start()
    {
        if (AudioManager.Instance != null)
        {
            // Cek apakah string musicName diisi atau tidak
            if (!string.IsNullOrEmpty(musicName))
            {
                // Jika ada nama musik, putar musiknya
                AudioManager.Instance.PlayMusic(musicName);
            }
            else
            {
                // Jika tidak ada nama musik (kosong), hentikan musik
                AudioManager.Instance.StopMusic();
            }
        }
    }
}