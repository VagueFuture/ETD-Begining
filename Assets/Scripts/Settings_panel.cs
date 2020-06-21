using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Settings_panel : MonoBehaviour
{
    public AudioSource audioInMenue;
    public GameObject[] manager;
    public GameObject soundPlus_b;
    public GameObject soundMinus_b;
    public GameObject Text_sound;

    public GameObject sensPlus_b;
    public GameObject sensMinus_b;
    public GameObject Text_sens;


    public GameObject QalityPlus_b;
    public GameObject QalityMinus_b;
    public GameObject Text_Qality;

    public GameObject SaveBut;

    private float volume = 0.040f;
    private float sens = 3f;
    private int Qality = 1;
    List<string> qualstr = new List<string>();
    // Start is called before the first frame update
    void Start()
    { 
        qualstr.Add("Very Low");
        qualstr.Add("Low");
        qualstr.Add("Medium");
        qualstr.Add("Hight");
        qualstr.Add("Very High");
        qualstr.Add("Ultra");

         manager = GameObject.FindGameObjectsWithTag("GameManager");
         load();
         audioInMenue.volume = volume;
         QualitySettings.SetQualityLevel(Qality,true);
    }

    // Update is called once per frame
    void Update()
    {
        if(soundPlus_b.GetComponent<text_buttons>().pressed)
        {
            soundPlus_b.GetComponent<text_buttons>().pressed = false;
            if(volume<0.99f)
                volume+=0.01f;
            manager[0].GetComponent<GameManagerScript>().setSound(volume);
            audioInMenue.volume = volume;
        }
        if(soundMinus_b.GetComponent<text_buttons>().pressed){
            soundMinus_b.GetComponent<text_buttons>().pressed = false;
            if(volume>0.001f)
                volume-=0.01f;
            manager[0].GetComponent<GameManagerScript>().setSound(volume);
            audioInMenue.volume = volume;
        }

        if(sensPlus_b.GetComponent<text_buttons>().pressed)
        {
            sensPlus_b.GetComponent<text_buttons>().pressed = false;
            if(sens<100)
                sens+=1f;
            manager[0].GetComponent<GameManagerScript>().setsens(sens);
        }

        if(sensMinus_b.GetComponent<text_buttons>().pressed){
            sensMinus_b.GetComponent<text_buttons>().pressed = false;
            if(sens>1f)
                sens-=1f;
            manager[0].GetComponent<GameManagerScript>().setsens(sens);
            audioInMenue.volume = volume;
        }
        

        if(QalityPlus_b.GetComponent<text_buttons>().pressed)
        {
            QalityPlus_b.GetComponent<text_buttons>().pressed = false;
            if(Qality<5)
                Qality+=1;
        }

        if(QalityMinus_b.GetComponent<text_buttons>().pressed){
            QalityMinus_b.GetComponent<text_buttons>().pressed = false;
            if(Qality>1)
                Qality-=1;
        }


        if(SaveBut.GetComponent<text_buttons>().pressed){
            SaveBut.GetComponent<text_buttons>().pressed = false;
            save();
        }
        Text_sound.GetComponent<TextMesh>().text = Mathf.Round(volume*1000)+"";
        Text_sens.GetComponent<TextMesh>().text = sens+"";
        Text_Qality.GetComponent<TextMesh>().text = qualstr[Qality]+"";
    }

    void save(){
                StreamWriter sw = File.CreateText(Application.persistentDataPath + "/setting.option");
                        sw.WriteLine(volume);
                        sw.WriteLine(sens);
                        sw.WriteLine(Qality);
                sw.Close();
    }
     public void load()
    {
        if(File.Exists(Application.persistentDataPath + "/setting.option"))
                {
                    StreamReader sr = File.OpenText(Application.persistentDataPath + "/setting.option");
                    volume = float.Parse(sr.ReadLine());
                    sens = float.Parse(sr.ReadLine());
                    Qality = int.Parse(sr.ReadLine());
                    sr.Close();
                }
        else{
        }

    }
}
