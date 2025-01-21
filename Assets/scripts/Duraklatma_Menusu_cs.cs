using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duraklatma_Menusu_cs : MonoBehaviour
{
    public static bool gameIsPaused = false; // Oyun durumu kontrolü
    public GameObject DuraklatmaMenusu;     // Duraklatma menüsü referansı
    public GameObject panel;

    public GameObject SesSlider;

    private bool isEscapePressed = false;   // Escape tuşunun basıldığını takip etmek için bayrak

    void Start()
    {
        // Menü başlangıçta kapalı olmalı
        DuraklatmaMenusu.SetActive(false);
        panel.SetActive(false);
        SesSlider.SetActive(false);
    }

    void Update()
    {
        // Escape tuşuna basıldığını kontrol et
        if (Input.GetAxis("Escape") > 0 && !isEscapePressed)
        {
            isEscapePressed = true;  // Escape tuşuna basıldığını kaydet
            if (gameIsPaused)
            {
                Resume(); // Eğer oyun duraklatıldıysa devam ettir
            }
            else
            {
                Pause(); // Eğer oyun duraklatılmadıysa, duraklat
            }
        }

        // Escape tuşu bırakıldığında bayrağı sıfırla
        if (Input.GetAxis("Escape") == 0)
        {
            isEscapePressed = false;
        }
    }

    // Oyunu devam ettir
    public void Resume()
    {
        SesSlider.SetActive(false);
        DuraklatmaMenusu.SetActive(false); // Menü kapatılır
        panel.SetActive(false);
        Time.timeScale = 1f;              // Oyun çok küçük bir değerle devam eder
        gameIsPaused = false;
    }

    // Oyunu duraklat
    public void Pause()
    {
        SesSlider.SetActive(true);
        DuraklatmaMenusu.SetActive(true); // Menü açılır
        panel.SetActive(true);
        Time.timeScale = 0.01f;             // Oyun çok küçük bir değerle durur
        gameIsPaused = true;
    }
}
