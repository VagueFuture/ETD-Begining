using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panel_open : MonoBehaviour
{
    public GameObject cam;
    private Animator anim;
    private int pos;
    private float _timer;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        pos = cam.GetComponent<new_camera_pos_menue>().get_my_pos();
        if(pos == 3){
            if(_timer>1)
                anim.SetBool("open",false);
        }else{
            _timer = 0;
           anim.SetBool("open",true); 
        }
    }
}
