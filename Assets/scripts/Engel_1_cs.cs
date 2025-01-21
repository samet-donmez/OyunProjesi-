using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Engel_1_cs : MonoBehaviour
{

    bool benHizimPlayed = false;

    public AudioSource audioSource;

    public AudioClip BenHizimSesi;
    Manager_cs manager;

    Mych_cs mych_Cs;
     public float speed=1.0f;
     bool goRight;
    // Start is called before the first frame update
    void Start()
    {
          mych_Cs = FindObjectOfType<Mych_cs>();


        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>(); // AudioSource'u al
        }  
        manager = FindObjectOfType<Manager_cs>();
        transform.position = new Vector2( 7.0f , 3.2f);
    }

    // Update is called once per frame
    void Update()
    {
        if(manager.oyunuDurdur==false){
        if(transform.position.x>=7.5f){
         goRight=false;
        }
        else if(transform.position.x<=-7.79f){
         goRight=true;
        }

        if(goRight){
         transform.Translate(Vector2.right * Time.deltaTime * speed);
        }

        else if(goRight == false){
         transform.Translate(Vector2.left * Time.deltaTime * speed);
        }
        }


        if(SceneManager.GetActiveScene().name == "Sahne2"){

           if(manager.score==10 && !benHizimPlayed){

            if(mych_Cs.transform.position.x<transform.position.x){
                audioSource.panStereo=1;
                audioSource.PlayOneShot(BenHizimSesi);
            benHizimPlayed = true;
            }
            else{
                audioSource.panStereo=-1;
                audioSource.PlayOneShot(BenHizimSesi);
            benHizimPlayed = true;
            }
           }
        }
    }

    
    



   
}
