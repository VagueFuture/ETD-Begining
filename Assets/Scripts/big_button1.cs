using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class big_button1 : MonoBehaviour
{
     // Start is called before the first frame update
    public Transform button;
    public bool pressed;
    private Vector3 startpos;
    private float _timer;
    private bool key;
    void Start()
    {
        startpos = button.position;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(key){
            if(_timer > 0.5){
                button.position = new Vector3(startpos.x,startpos.y,startpos.z);
                key = false;
                pressed = false;
            }
        }
    }

    void OnMouseDown(){
        button.position = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        key = true;
        _timer = 0;
        pressed = true;
    }
}
