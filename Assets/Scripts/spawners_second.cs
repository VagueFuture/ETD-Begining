using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawners_second : MonoBehaviour
{
    public List<Transform> ways_targets = new List<Transform>();
    public List<GameObject> enemys = new List<GameObject>();
    public List<string> valns = new List<string>();
    public Transform spawn_place;
    public float _timer;
    public float period = 20;
    public AudioSource audit;
    public int i = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        _timer += Time.deltaTime;
        spawn(); 
    }

     private void spawn(){
            if(_timer>period){ 
                _timer = 0;
                GameObject sN = Instantiate(enemys[int.Parse(valns[i].ToString())-1],spawn_place.position,spawn_place.rotation) as GameObject;
                sN.GetComponent<moving>().ways_targets = this.ways_targets;
                sN.GetComponent<Enemy_helf>().anim = sN.GetComponent<Animator>();
                i++;
                if(i>=valns.Count){
                    i=0;
                }
                audit.Play();
            }              
    }
}
