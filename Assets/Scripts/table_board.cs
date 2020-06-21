using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class table_board : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject left,right,middle,earth,mis_number,images;
    private int i;
    void Start()
    {
        i = 0;
        //earth.GetComponent<earth_missions>().select_mission(i);
    }

    // Update is called once per frame
    void Update()
    {
        bool l = left.GetComponent<text_buttons>().pressed;
        bool r = right.GetComponent<text_buttons>().pressed;
        bool m = middle.GetComponent<text_buttons>().pressed;
        int count = earth.GetComponent<earth_missions>().missions_vrash.Count;
        //Debug.Log(i.ToString());
        mis_number.GetComponent<TextMesh>().text = "Миссия "+(i+1).ToString();
        if(l){
            if(i<count-1){
                i++;
                earth.GetComponent<earth_missions>().select_mission(i);
                left.GetComponent<text_buttons>().press_end();
                images.GetComponent<table_images>().set_sprite(i);
            }
        }
        if(r){
            if(i>0){
                earth.GetComponent<earth_missions>().select_mission(i);
                right.GetComponent<text_buttons>().press_end();
                i--;
                images.GetComponent<table_images>().set_sprite(i);
            }
        }
        if(m){
            middle.GetComponent<text_buttons>().press_end();
            Application.LoadLevel(i+1);
        }
    }
}
