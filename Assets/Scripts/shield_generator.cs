using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shield_generator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] objectsForLook = GameObject.FindGameObjectsWithTag("Enemy");
        foreach(GameObject gO in objectsForLook){
            if(gO.GetComponent<shield_generator>()){
            }else{
                if(!gO.GetComponent<Enemy_helf>().tesla)
                    gO.GetComponent<Enemy_helf>().shield = true;
            }
        }
        if(GetComponent<Enemy_helf>().smert == true){
            foreach(GameObject gO in objectsForLook){
                gO.GetComponent<Enemy_helf>().shield = false;
            } 
        }
    }
}
