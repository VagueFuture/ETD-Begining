using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lvl3_scary : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject canvas,ligt;
    public GameObject spawner;
    public List<GameObject> objects = new List<GameObject>();
    public GameObject audit;
    private float _timer;
    private bool flag = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(spawner.GetComponent<spawner>().i+"");
        if(spawner.GetComponent<spawner>().i == 6 && !flag){
            flag = true;
            disable();
        }
        if(flag){
            _timer+=Time.deltaTime;
            if(_timer > 20){
                enable();
            }
        }
    }
    private void disable(){
        canvas.SetActive(false);
        ligt.GetComponent<Light>().color =new Color(1,0.1f,0.1f,0.1f);
        foreach(GameObject g in objects){
            g.SetActive(true);
        }
        audit.SetActive(false);
    }
    private void enable(){
        canvas.SetActive(true);
        ligt.GetComponent<Light>().color =new Color(1,1,1,1);
        foreach(GameObject g in objects){
            g.SetActive(false);
        }
        audit.SetActive(true);
    }
}
