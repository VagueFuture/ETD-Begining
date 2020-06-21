using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class menue_pers : MonoBehaviour
{
    public float time_anim;
    private Animator anim;
    private float _timer;
    private int rnd;
    private float _timer2;
    private bool played;
    // Start is called before the first frame update
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        played = false;
        rnd = 2;
    }

    // Update is called once per frame
    void Update()
    {
         _timer += Time.deltaTime;
        if(_timer>rnd){
            anim.SetBool("perehod",true);
            played  = true;
            _timer2 = 0;
            _timer = 0;
            rnd = Random.Range(5, 30);            
        }
        if(played){
            _timer2 += Time.deltaTime;
            if(_timer2 > time_anim){
                played = false;
                anim.SetBool("perehod",false);
            }
        }
    }
}
