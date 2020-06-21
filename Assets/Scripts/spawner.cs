using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
public class spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public string level;
    public List<Transform> ways_targets = new List<Transform>();
    public List<GameObject> enemys = new List<GameObject>();
    public List<string> valns = new List<string>();
    public Transform spawn_place;
    public bool _timer;
    public bool key;
    public bool win;
    public AudioSource audit;
    public float time_to_next_wave;
    private float _timer2;
    private float _timer3;
    public int i,j;
    public int next_lvl=0;
    private bool saved = false;
    public float volume = 0.043f;
    void Start()
    {
        win = false;
        key = false;
        _timer = false;
        _timer2 = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(key){
            spawn();
            _timer3 += Time.deltaTime;
            _timer2 += Time.deltaTime;
            if((_timer && i<valns.Count-1) || (_timer3 >time_to_next_wave && i<valns.Count-1)){
                i++;
                _timer = false;
                _timer3 = 0;
                j = 0;
            }
        }
        GameObject[] enemy=GameObject.FindGameObjectsWithTag("Enemy");

        if((i>=valns.Count-1) && (enemy.Length<=0)){
            win = true;
            save();
            Application.LoadLevel(next_lvl);
        }    
    }
    private void spawn(){
    if(i<valns.Count)
        if(j < valns[i].Length){
            if(_timer2>1.5f){ 
                GameObject sN = Instantiate(enemys[int.Parse(valns[i][j].ToString())-1],spawn_place.position,spawn_place.rotation) as GameObject;
                sN.GetComponent<moving>().ways_targets = this.ways_targets;
                sN.GetComponent<Enemy_helf>().anim = sN.GetComponent<Animator>();
                //sN.GetComponent<AudioSource>().volume = volume;
                j++;
                audit.Play();
                _timer2 = 0;
            }
        }                
    }

     void save(){
        if(!saved){

                StreamWriter sw = File.CreateText(Application.persistentDataPath + "/config.option");
                        sw.WriteLine((Application.loadedLevel+1).ToString());
                sw.Close();

        /*
        if(!Directory.Exists("Settings")){
                Directory.CreateDirectory("Settings");
                }
        if(!File.Exists("Settings/save.s")){
            File.Create("Settings/save.s");
            }
            
        File.WriteAllText("Settings/save.s", (Application.loadedLevel+1).ToString());
        saved = true;
        Debug.Log("save");
        */
        }
    }
}
