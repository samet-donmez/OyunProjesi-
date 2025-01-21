using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Manager_cs : MonoBehaviour
{
    private static Audio_Manager_cs instance; // Burada AudioManager yerine Audio_Manager_cs olmalı

    public AudioSource backgroundMusic; // AudioSource referansı

    void Awake()
    {
        // Eğer daha önce bir AudioManager var ise, bu objeyi yok et
        if (instance != null)
        {
            Destroy(gameObject); // Mevcut objeyi sil
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Bu objenin sahne geçişlerinde yok olmasını engelle
        }
    }

    void Start()
    {
        // İstediğiniz işlemler burada yapılabilir
    }

    void Update()
    {
        // Müzik ya da diğer işlemler burada yapılabilir
    }

    public void StopMusic()
    {
        backgroundMusic.Stop();
    }
}
