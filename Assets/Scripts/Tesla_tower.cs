using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tesla_tower : MonoBehaviour
{
    public AudioSource audit;
    List<GameObject> enemys = new List<GameObject>();
    public int class_torret;
    float speed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
            if(enemys.Count != 0){ 
                    shoot();
                }
            else{
            }

        for(int i = 0;i<enemys.Count;i++){
            if(enemys[i].GetComponent<Enemy_helf>().smert){
                deletenemy(enemys[i]);
            }
        }
    }

    public void addenemy(GameObject enemy,int classenemy){
        audit.Play();
        if(class_torret == 2)
            if(classenemy == 2 || classenemy == 0)
            {
                enemys.Add(enemy);
            }
        if(class_torret == 1)
            if(classenemy == 1 || classenemy == 0)
            {
                enemys.Add(enemy);
            }
        if(class_torret == 0){
                enemys.Add(enemy);
        }
        speed = enemy.GetComponent<moving>().speed;
    }

    public void deletenemy(GameObject enemy){
        enemy.GetComponent<Enemy_helf>().tesla = false;
        enemy.GetComponent<moving>().speed = speed ;
        enemys.Remove(enemy);
    }
    public void shoot(){
        foreach(GameObject g in enemys){
            g.GetComponent<Enemy_helf>().tesla = true;
            g.GetComponent<Enemy_helf>().shield = false;
            g.GetComponent<moving>().speed = 2 ;
        }
    }
}
