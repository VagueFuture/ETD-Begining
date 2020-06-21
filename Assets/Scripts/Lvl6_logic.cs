using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl6_logic : MonoBehaviour
{
    // Start is called before the first frame update
    public gamelogick logik;
    public Dialog_system dial;
    public bool end;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(logik.Train_destroy){
            Application.LoadLevel(0);
        }
        if(end && dial.end){
            Application.LoadLevel(7);
        }
    }
}
