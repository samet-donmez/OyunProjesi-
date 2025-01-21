using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Yem_cs : MonoBehaviour
{
    private Manager_cs manager; // Manager referansı

    void Start()
    {
        // Manager referansını sahnede dinamik olarak bul
        manager = FindObjectOfType<Manager_cs>();
        if (manager == null)
        {
            Debug.LogError("Manager_cs bulunamadı! Sahneye Manager eklendiğinden emin olun.");
        }
    }

    public void yedilerBeniYem()
    {
        if (manager != null)
        {
            
            manager.Yemolustur();  
            Destroy(this.gameObject); 
              
        }
        else
        {
            Debug.LogError("Manager referansı atanmadı!");
        }
    }

}

