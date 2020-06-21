using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class end_plase_exit : MonoBehaviour
{
    private float _timer;
    private float _timer2;
    public int count = 0;
    int c = 0;
    public Text less;
   void OnTriggerEnter (Collider other){
       _timer = 0;
        if(other.CompareTag("Enemy")){
            other.GetComponent<Enemy_helf>().smert = true;
            c ++;
            less.text = c.ToString();
            if(c >= count){
                less.text = "Game Over";
                Application.LoadLevel(0);
            }
        }
    }

    void OnTriggerStay (Collider other){
        _timer += Time.deltaTime;
        _timer2 = 1;
        if(_timer >= _timer2)
            Destroy(other.gameObject);
    }

    void OnTriggerExit (Collider other){
        
    }
}
