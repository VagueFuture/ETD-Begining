using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class text_buttons : MonoBehaviour
{
    // Start is called before the first frame update
    public bool pressed;

    void start(){
        pressed = false;
    }

    void OnMouseDown(){
        pressed = true;
    }

    void onMouseExit(){
        pressed = false;
    }
    public void press_end(){
        pressed = false;
    }
}
