using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mych_cs : MonoBehaviour
{
    
    public AudioSource audioSource; // Ses kaynağı
    public AudioClip canKaybiSesi;  // Can kaybı sesi
    public AudioClip yemekYemeSesi; // Yemek yeme sesi
    public AudioClip iksirIcmeSesi; // Yemek yeme sesi
    public int can=3;
    // Oyun alanı sınırları
     float minX = -8.6f; // Sol sınır
     float maxX = 8.6f;  // Sağ sınır
     float minY = -5f;       // Alt sınır
     float maxY = 5f;        // Üst sınır

    
    private float halfHeight = 0.3f; // 0.6'nın yarısı (yükseklik)

    Manager_cs manager;

     public float speed = 6.0f;
    

    void Start()
    {

         if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // AudioSource'u al
        }    

        manager = FindObjectOfType<Manager_cs>(); 
    if (manager == null)
    {
        Debug.LogError("Manager referansı bulunamadı!");
    }
        
    }

    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontal * speed * Time.deltaTime);

        float vertical = Input.GetAxis("Vertical");
        transform.Translate(Vector2.up * vertical * speed * Time.deltaTime);

        Vector2 clampedPosition = new Vector2(
            Mathf.Clamp(transform.position.x, minX , maxX ),
            Mathf.Clamp(transform.position.y, minY + halfHeight, maxY - halfHeight)
        );
        transform.position = clampedPosition;
          
    }


    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Engel"))
    {
        Debug.Log("yandın");
        can--;
         if (can > 0)
            {
               
                audioSource.PlayOneShot(canKaybiSesi); // Can kaybı sesini çal
            }
            
        else{
            audioSource.PlayOneShot(canKaybiSesi);
            manager.oyunuDurdur=true;
            
            Time.timeScale = 0f;
        }
    }

    else if (other.CompareTag("Yem"))
    {
        Yem_cs yem_Cs = other.GetComponent<Yem_cs>();  
        if (yem_Cs != null) 
        {
            audioSource.PlayOneShot(yemekYemeSesi); // Yemek yeme sesini çal
            manager.Score();
            yem_Cs.yedilerBeniYem();
            
        }
        else
        {
            Debug.LogError("Yem_cs bileşeni bulunamadı!");
        }
    }

    
}

    public void HizBonusuAktif()
{
    StopAllCoroutines(); // Daha önceki hız bonusu etkisini durdur
    StartCoroutine(HizBonusuSuresi());
}

private IEnumerator HizBonusuSuresi()
{
    speed *= 2; // Hızı artır
    Debug.Log("Hız bonusu aktif!");
    yield return new WaitForSeconds(3); // 5 saniye bekle
    speed /= 2; // Hızı eski haline döndür
    Debug.Log("Hız bonusu sona erdi.");
}

 public void IksirIcmeSesiCal(){
       audioSource.PlayOneShot(iksirIcmeSesi); // Iksir icme sesini cal

 }


   

    
}
