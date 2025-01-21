using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can1_cs : MonoBehaviour
{
    Mych_cs mych_Cs;
    Manager_cs manager;
    // Start is called before the first frame update
    void Start()
    {
         mych_Cs = FindObjectOfType<Mych_cs>();
         manager = FindObjectOfType<Manager_cs>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mych_Cs.can<1){
            manager.oyunuDurdur = true;
            Destroy(this.gameObject);
        }
    }
}
