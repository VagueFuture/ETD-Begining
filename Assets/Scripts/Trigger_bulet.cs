using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_bulet : MonoBehaviour
{

    public float damage;
    public float speed;
    public int type;

    private float _timer;
    public float fireRate;
    private bool go_to;
    private Transform target;
    void Start(){
        Destroy(gameObject,10);
        go_to = false;
    }

    // Start is called before the first frame update
    void Update(){
        _timer += Time.deltaTime;
        if (_timer > 1/fireRate){
            go_to = true;
            _timer = 0;
        }
        if(go_to && type == 2){
            transform.LookAt(target);
        }
        transform.Translate(Vector3.forward*speed*Time.deltaTime);

    }

    void OnTriggerEnter(Collider other){
        if(other.CompareTag("Enemy")){
            other.GetComponent<Enemy_helf>().get_hit(damage);
            Destroy(gameObject);
        }
    }

    public void set_target(Transform targ){
        target = targ;
    }
}
