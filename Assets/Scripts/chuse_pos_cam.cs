using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chuse_pos_cam : MonoBehaviour
{
    public Camera cam;
    public int campos;
    // Start is called before the first frame update
    void Start(){
    }
    void Update(){
        if(gameObject.GetComponent<big_button1>().pressed){
            cam.GetComponent<new_camera_pos_menue>().go_to_camer(campos);
        }
    }

}
