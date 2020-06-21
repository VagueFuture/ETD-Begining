using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerScript: MonoBehaviour {
public static GameManagerScript instance;
    public static int points = 100;
    public static float sensivity = 2;
    public static float sound_volume = 0.043f;
    public static float sens = 3f;

    void Awake() {
    if (!instance) {
        instance = this;
        DontDestroyOnLoad(transform.gameObject);
    } else {
        Destroy(gameObject);
    }            
    }

    void OnLevelWasLoaded(int level) {
         //Text ui =  GameObject.Find("/Canvas/Text").GetComponent<Text>();
         Debug.Log("scene was loaded" + points);
         points++;

         GameObject[] audio_incam=GameObject.FindGameObjectsWithTag("MainCamera");
         GameObject[] audio_inspawn=GameObject.FindGameObjectsWithTag("Audio");

         foreach(GameObject g in audio_incam){
             g.GetComponent<AudioSource>().volume = sound_volume;
             if(g.GetComponent<camera_move>() != null)
                g.GetComponent<camera_move>().speed = sens;
         }

        foreach(GameObject g in audio_inspawn){
             g.GetComponent<AudioSource>().volume = sound_volume;
             g.GetComponent<spawner>().volume = sound_volume;
         }

    }

    public void setSound(float x){
        sound_volume = x;
    }
    public float getSound(){
        return sound_volume;
    }

    public void setsens(float x){
        sens = x;
    }
    public float getsens(){
        return sens;
    }
}
