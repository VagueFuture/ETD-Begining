using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject obj;

    void OnTriggerEnter (Collider other){
        if(other.CompareTag("Enemy")){
            look_around l = obj.GetComponent<look_around>();
            if(other.GetComponent<moving>()!=null){
                moving l2 = other.GetComponent<moving>();
                l.addenemy(other.transform,l2.whalk_in);
            }
            else{
                l.addenemy(other.transform,0);
            }
        }
    }

    void OnTriggerStay (Collider other){

    }

    void OnTriggerExit (Collider other){
        look_around l = obj.GetComponent<look_around>();
        l.deletenemy(other.transform);
    }
}
