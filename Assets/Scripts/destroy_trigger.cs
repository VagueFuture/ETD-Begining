using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy_trigger : MonoBehaviour
{
    // Start is called before the first frame update
    public float damage;
    public float time_hit;
    private float _timer;
    void Start()
    {
        _timer = 1;
    }

    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerStay(Collider other){
        if(other.CompareTag("Tower")){
            if(_timer > time_hit)
            {
                Debug.Log("hit");
                other.GetComponent<tower_hp>().get_damage(damage);
                _timer = 0;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
    }
}
