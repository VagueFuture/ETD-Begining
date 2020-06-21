using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_rockets : MonoBehaviour
{
    // Start is called before the first frame update
    List<GameObject> enemy = new List<GameObject>();
    public bool shoot = false;
    public bool shoot_end = false;
    public GameObject boom_eff;
    float _timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!shoot){
        GameObject[] towers = GameObject.FindGameObjectsWithTag("Tower_nuke");
        Debug.Log(towers.Length);
        foreach(GameObject g in towers){
            if(g.GetComponent<rocet_launcher>().ready == true){
                Debug.Log("Поехали!");
                g.GetComponent<rocet_launcher>().shoot();
                break;
            }
        }
        shoot = true;
        }
        if(shoot_end)
        {
            _timer += Time.deltaTime;
            if(_timer>2)
                Destroy(gameObject);
        }
    }

    void OnTriggerEnter (Collider other){
        if(other.CompareTag("rocket")){
            shoot_end = true;
            boom_eff.SetActive(true);
            gameObject.GetComponent<AudioSource>().Play();
            boom();
            Destroy(other);
        }

        if(other.CompareTag("Enemy")){
        enemy.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other){
        enemy.Remove(other.gameObject);
    }
    public void boom(){
        foreach(GameObject g in enemy){
            g.GetComponent<Enemy_helf>().shield = false;
            g.GetComponent<Enemy_helf>().HP-=1000;
        }
    }
}
