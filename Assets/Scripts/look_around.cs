using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class look_around : MonoBehaviour
{
    // Start is called before the first frame update
    private bool wait;
    private int i;
    private float _timer;
    List<Transform> enemys = new List<Transform>();
    public GameObject obj;
    public AudioSource audit;
    public Transform bone; 
    public List<Transform> firePlace = new List<Transform>();
    public GameObject snaryad;
    public float fireRate;
    public int class_torret; //0-all 1-earht 2-flying
    void Start()
    {
        wait = true;
        i = firePlace.Count;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        wait w = obj.GetComponent<wait>();
        if(wait){
            w.go_on();
        }else{
            if(enemys.Count != 0){ 
                bone.transform.LookAt(enemys[0],Vector3.forward);
                bone.transform.eulerAngles = new Vector3(0, bone.transform.eulerAngles.y, 0);
                bone.Rotate(new Vector3(bone.transform.rotation.x,bone.transform.rotation.y,-90));
                if (_timer > 1/ fireRate){
                    Shoot();
                    audit.Play();
                    _timer = 0;
                }
            }
            else{
                wait = true;
            }
        }

        for(int i = 0;i<enemys.Count;i++){
            if(enemys[i].GetComponent<Enemy_helf>().smert){
                deletenemy(enemys[i]);
            }
        }
    }
    
    public void addenemy(Transform enemy,int classenemy){
        if(class_torret == 2)
            if(classenemy == 2 || classenemy == 0)
            {
                wait = false;
                enemys.Add(enemy);
            }
        if(class_torret == 1)
            if(classenemy == 1 || classenemy == 0)
            {
                wait = false;
                enemys.Add(enemy);
            }
        if(class_torret == 0){
                wait = false;
                enemys.Add(enemy);
        }
    }

    public void deletenemy(Transform enemy){
        enemys.Remove(enemy);
    }

    private void Shoot(){
        for (int j = 0;j<i;j++){
            GameObject sN = Instantiate(snaryad,firePlace[j].position,firePlace[j].transform.rotation) as GameObject;
            sN.GetComponent<Trigger_bulet>().set_target(enemys[0]);
        }
       
        
    }
}