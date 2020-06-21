using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class next_wawe : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawner;
    private bool first;
    private bool can = true;
    float timer = 60;
    void Update(){
        //gameObject.SetActive(can);
        timer += Time.deltaTime;
        GameObject[] enemy=GameObject.FindGameObjectsWithTag("Enemy");
        if((timer>60) || (enemy.Length<=0)){
            can = true;
            }
    }
    void OnMouseDown(){
        if(can){
            timer = 0;
            if(first){
                if(!spawner.GetComponent<spawner>()._timer)
                    spawner.GetComponent<spawner>()._timer = true;
            }else{
                first = true;
                spawner.GetComponent<spawner>().key = true;
            }
            can = false;
        }
    }
}
