using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class getVolume_from : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioSource audios;
    void Start()
    {
        GameObject[] manager = GameObject.FindGameObjectsWithTag("GameManager");
        if(manager.Length>0)
        audios.volume = manager[0].GetComponent<GameManagerScript>().getSound()+0.1f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
