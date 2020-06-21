using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rocet_launcher : MonoBehaviour
{
    // Start is called before the first frame update
    public Animator anim;
    float _timer = 0;
    public bool ready = false;
    public float timetoready = 30;

    public GameObject fire;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!ready){
            _timer += Time.deltaTime;
            if(_timer >=timetoready){
                fire.GetComponent<ParticleSystem>().Stop();
                anim.SetBool("shoot",false);
                ready = true;
                Camera.main.GetComponent<gamelogick>().rockets += 1;
                anim.SetBool("ready",ready);
            }
        }
    }

    public void shoot(){
        gameObject.GetComponent<AudioSource>().Play();
        fire.GetComponent<ParticleSystem>().Play();
        anim.SetBool("shoot",true);
        ready = false;
        anim.SetBool("ready",false);
        _timer = 0;
    }
}
