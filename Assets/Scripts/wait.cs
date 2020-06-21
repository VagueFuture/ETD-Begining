using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wait : MonoBehaviour
{
    // Start is called before the first frame update
    public bool go;
    public Transform bone;
    public Vector3 rotation;
    public float speed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(go){
            bone.Rotate(rotation* Time.deltaTime*speed);
        }
    }

    public void go_on(){
        go = true;
    }

    public void go_off(){
        go = false;
    }
}
