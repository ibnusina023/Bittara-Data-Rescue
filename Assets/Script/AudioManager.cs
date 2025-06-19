using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] musicSounds, sfxSounds;
    public AudioSource musicSource, sfxSource;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // Musik tidak lagi otomatis diputar di sini
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);

        if (s == null)
        {
            Debug.LogWarning("Music not found: " + name);
            musicSource.Stop(); // Hentikan musik jika nama tidak ditemukan
            return;
        }

        // Cegah restart jika musik yang sama sudah diputar
        if (musicSource.clip == s.clip && musicSource.isPlaying)
            return;

        musicSource.clip = s.clip;
        musicSource.Play();
    }

    // --- FUNGSI BARU DITAMBAHKAN DI SINI ---
    public void StopMusic()
    {
        musicSource.Stop();
    }
    // ----------------------------------------

    public void PlaySFX(string name)
    {
        // Fungsi PlaySFX tidak berubah
        Sound s = Array.Find(sfxSounds, x => x.name == name);

        if (s == null)
        {
            Debug.LogWarning("SFX not found: " + name);
            return;
        }

        sfxSource.PlayOneShot(s.clip); // Disarankan menggunakan PlayOneShot untuk SFX
    }
}