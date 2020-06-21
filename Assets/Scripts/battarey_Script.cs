using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class battarey_Script : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject destroy_barrel;
    public GameObject vagon;
    bool smert = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(gameObject.GetComponent<Enemy_helf>().smert){
            if(!smert){
                gamelogick logic = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<gamelogick>();
                logic.battaryDead+=1;
                GameObject sN = Instantiate(destroy_barrel,transform.position,transform.rotation) as GameObject;
                sN.transform.SetParent(vagon.transform); 
                smert = true;
            }
        }
    }
}
