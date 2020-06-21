using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class load_level : MonoBehaviour
{
    // Start is called before the first frame update
    public int level;
    public bool new_Game;
    void Start()
    {
        load();
    }

    // Update is called once per frame
    void Update()
    {
        bool pres = GetComponent<big_button1>().pressed;
        if(new_Game)
            level = 0;
        if(pres)
            Application.LoadLevel(level);    
    }

    public void load()
    {
        if(File.Exists(Application.persistentDataPath + "/config.option"))
                {
                    StreamReader sr = File.OpenText(Application.persistentDataPath + "/config.option");
                    level =  int.Parse(sr.ReadLine());
                }
        else{
            if(!Directory.Exists("Settings")){
                    Directory.CreateDirectory("Settings");
                    }
            if(!File.Exists("Settings/save.s"))
            {
                File.Create("Settings/save.s");
            }
            else
            {
                string[] readedLines = File.ReadAllLines("Settings/save.s");
                if(readedLines.Length != 0)
                {
                    for(int i=0;i<readedLines.Length;i++){
                        if(i==0)
                            level =  int.Parse(readedLines[i]);
                            Debug.Log(readedLines[i]);
                    }
                }
            }
        }

    }
    
}
