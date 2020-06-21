using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tower_hp : MonoBehaviour
{
    public float helth;
    public GameObject coffin;
    public GameObject light;
    public bool Night;
    // Start is called before the first frame update
    void Start()
    { 
    }

    // Update is called once per frame
    void Update()
    {
        if(Night)
        {
            light.SetActive(true);
        }
        if(helth <=0){
            GameObject sN = Instantiate(coffin,transform.position,transform.rotation) as GameObject;
            Destroy(gameObject);
        }
    }

    public void OnMouseDown(){
        
    }

    public void get_damage(float damage){
        helth-=damage;
    }
}
