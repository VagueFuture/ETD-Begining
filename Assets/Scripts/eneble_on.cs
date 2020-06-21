using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class eneble_on : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject target;
    
    public void OnTriggerEnter(Collider other){
        if(other.tag == "Train")
        target.SetActive(true);
    }
}
