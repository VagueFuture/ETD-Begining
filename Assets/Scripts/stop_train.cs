using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stop_train : MonoBehaviour
{
    bool whait = true;
    public bool end_game = false;
    public int humans = 4;
    float _timer;
    public GameObject display;
 public void OnTriggerEnter(Collider other){
     if(other.tag == "Train" && whait){
         Debug.Log(other.name);
         whait = false;
     if(other.gameObject.GetComponent<movetoTarget>()!= null){
         other.gameObject.GetComponent<movetoTarget>().stop = true;
     }
     GameObject logic = GameObject.FindGameObjectWithTag("MainCamera");
     logic.GetComponent<gamelogick>().money+=humans;

     if(end_game){
         GameObject canvas = GameObject.Find("Game_vindow");
         //GameObject display = GameObject.Find("Dialog_panel");
         canvas.SetActive(false);
         List<string> str = new List<string>();
         str.Add("Спасибо тебе, ты сделал хорошее дело.");
         str.Add("Полномочия отозваны.");
         display.SetActive(true);
         display.GetComponent<Dialog_system>().Dialogs = str;
         display.GetComponent<Dialog_system>().j = 0;
         other.gameObject.GetComponent<movetoTarget>().stop = false;
         other.gameObject.GetComponent<movetoTarget>().speed = 3;
         logic.GetComponent<Lvl6_logic>().end = true;
     }
     }
 }
}
