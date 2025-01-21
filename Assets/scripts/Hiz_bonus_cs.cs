using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiz_bonus_cs : MonoBehaviour
{
     
    // Start is called before the first frame update
    void Start()
    {
          
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 3.5f);
    }
    void OnTriggerEnter2D(Collider2D other){


        if(other.tag == "Player"){
            Mych_cs mych_Cs = other.transform.GetComponent<Mych_cs>();
            if(mych_Cs !=null){
                mych_Cs.IksirIcmeSesiCal();
              mych_Cs.HizBonusuAktif();



            
            }
            Destroy(this.gameObject);
        }

    }
}
