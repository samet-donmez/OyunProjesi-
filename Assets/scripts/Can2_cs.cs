using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can2_cs : MonoBehaviour
{
    Mych_cs mych_Cs;
    // Start is called before the first frame update
    void Start()
    {
         mych_Cs = FindObjectOfType<Mych_cs>();
    }

    // Update is called once per frame
    void Update()
    {
        if(mych_Cs.can<2){
            Destroy(this.gameObject);
        }
    }
}
