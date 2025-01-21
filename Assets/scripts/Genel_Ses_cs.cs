using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Genel_Ses_cs : MonoBehaviour
{

public TextMeshProUGUI volumeAmount;
public Slider slider;
    public void SetAudio(float value){
        AudioListener.volume=value;
        volumeAmount.text = ((int)(value*100)).ToString();
        SaveAudio();
    }
    private void SaveAudio(){
        PlayerPrefs.SetFloat("audioVolume",AudioListener.volume);
    }   
    private void LoadAudio(){

         if(PlayerPrefs.HasKey("audioVolume")){
            AudioListener.volume=PlayerPrefs.GetFloat("audioVolume");
            slider.value=PlayerPrefs.GetFloat("audioVolume");
         }
         else{
            PlayerPrefs.SetFloat("audioVolume",0.5f);
            AudioListener.volume=PlayerPrefs.GetFloat("audioVolume");
            slider.value=PlayerPrefs.GetFloat("audioVolume");
            
         }

        
    }
    // Start is called before the first frame update
    void Start()
    {
        LoadAudio();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
