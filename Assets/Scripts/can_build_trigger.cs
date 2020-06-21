using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class can_build_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject mesh;
    public Material green;
    public Material red;
    public bool color = true;
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Road") || other.CompareTag("Tower") || other.CompareTag("Tower_nuke") || other.CompareTag("Enemy")){
            mesh.GetComponent<Renderer>().material = red;
            color = false; 
        }
    }

    void OnTriggerStay(Collider other)
    {
        if(other.CompareTag("Road") || other.CompareTag("Tower")|| other.CompareTag("Tower_nuke") || other.CompareTag("Enemy")){
            mesh.GetComponent<Renderer>().material = red;
            color = false; 
            }
    }

    void OnTriggerExit(Collider other){
        if(other.CompareTag("Road") || other.CompareTag("Tower")|| other.CompareTag("Tower_nuke") || other.CompareTag("Enemy")){
            mesh.GetComponent<Renderer>().material = green;
            color = true;
        }
    }
}
