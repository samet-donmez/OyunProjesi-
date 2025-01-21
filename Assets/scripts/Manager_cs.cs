    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    using TMPro;
    using UnityEngine.SceneManagement;

    public class Manager_cs : MonoBehaviour
    {
        public bool oyunuDurdur = false;
        public GameObject yemPrefab; // Prefab referansı

        private float hizBonusOlusmSuresi = 7.0f; // Hız bonusu oluşturma süresi

        [SerializeField]
        GameObject hizBonusPrefab;
        public int score = 0; // Skor değişkeni

        public TextMeshProUGUI scoreText; //skor yazısı
        Mych_cs mych_Cs;
        Engel_1_cs engel_1_Cs;
        Engel_2_cs engel_2_Cs;
        Engel_3_cs engel_3_Cs;

        void Start() { 
            
            
            Yemolustur();
            InvokeRepeating("HizBonusuOlustur", hizBonusOlusmSuresi, hizBonusOlusmSuresi); // Hız bonusunu düzenli oluştur
        
            engel_1_Cs = FindObjectOfType<Engel_1_cs>();
            engel_2_Cs = FindObjectOfType<Engel_2_cs>();
            engel_3_Cs = FindObjectOfType<Engel_3_cs>();
            mych_Cs = FindObjectOfType<Mych_cs>();
            
        }

        void Update()
        {
            // Skora göre engellerin hızını ayarla
            if(SceneManager.GetActiveScene().name == "Sahne2"){
            if (score >= 10 && score < 20)
            {
                engel_1_Cs.speed = 2.0f;
                engel_2_Cs.speed = 2.0f;
                engel_3_Cs.speed = 2.0f;
            }
            else if (score >= 20 && score < 30)
            {
                engel_1_Cs.speed = 3.0f;
                engel_2_Cs.speed = 3.0f;
                engel_3_Cs.speed = 3.0f;
            }
            else if (score >= 30 && score < 40)
            {
                engel_1_Cs.speed = 4.0f;
                engel_2_Cs.speed = 4.0f;
                engel_3_Cs.speed = 4.0f;
            }
            else if (score >= 40 && score < 50)
            {
                engel_1_Cs.speed = 5.0f;
                engel_2_Cs.speed = 5.0f;
                engel_3_Cs.speed = 5.0f;
            }
            }

            // Skor 11 olduğunda ve Sahne 1'deyken sahne geçişi yap
        if (score == 10 && SceneManager.GetActiveScene().name == "Sahne1")
    {
        
        SceneManager.LoadScene("Sahne2");  // Sahne 2'ye geçiş
    }

        }
        
        public void GameOver()
        {
            Debug.Log("Oyun Bitti!");
            
        }

        public void Score()
        {
            score++; // Skoru artır
            Debug.Log("Skor: " + score); // Güncel skoru yazdır
            SkoruGuncelle();
            
            
            
        }

        public void Yemolustur()
        {
            float rastgeleSayix = Random.Range(-8.3561f, 8.3561f);
            float rastgeleSayiy = Random.Range(-4.5f, 4.5f);
            Vector2 newPosition = new Vector2(rastgeleSayix, rastgeleSayiy);

            Instantiate(yemPrefab, newPosition, Quaternion.identity); // Prefab'dan yeni yem oluştur
        }

        void HizBonusuOlustur()
    {
        float rastgeleX = Random.Range(-8.3561f, 8.3561f);
        float rastgeleY = Random.Range(-4.5f, 4.5f);
        Vector2 yeniPozisyon = new Vector2(rastgeleX, rastgeleY);
        if(oyunuDurdur==false){
        Instantiate(hizBonusPrefab, yeniPozisyon, Quaternion.identity); // Prefab'dan yeni hız bonusu oluştur
    }
    }

        public void SkoruGuncelle(){
        scoreText.text = "Skor: " + score;
        }

        

        
    }
