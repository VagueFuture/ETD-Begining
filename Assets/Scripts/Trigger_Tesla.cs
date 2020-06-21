using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_Tesla : MonoBehaviour
{
    public GameObject obj;
    // Start is called before the first frame update
   void OnTriggerEnter (Collider other){
        if(other.CompareTag("Enemy")){
        Tesla_tower l = obj.GetComponent<Tesla_tower>();
        moving l2 = other.GetComponent<moving>();
        l.addenemy(other.gameObject,l2.whalk_in);
        }
    }

    void OnTriggerStay (Collider other){

    }

    void OnTriggerExit (Collider other){
        Tesla_tower l = obj.GetComponent<Tesla_tower>();
        l.deletenemy(other.gameObject);
    }
}
