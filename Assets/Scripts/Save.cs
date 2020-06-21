using UnityEngine;
using System;
using System.Collections;
using System.IO;

public class Save : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void save(){
        if(!Directory.Exists("Settings")){
                Directory.CreateDirectory("Settings");
                }
               
               
                if(!File.Exists("Settings/Save.ini")){
                File.Create("Settings/Save.ini");
                }
               
               
                File.AppendAllText("Settings/Save.ini", "test line 1" + Environment.NewLine);
    }
}
