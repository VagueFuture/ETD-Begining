using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class movetoTarget : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sostav;
    public Transform Target;
    public bool stop;
    public float speed = 3;
    public float angle = 90;
    private Vector3 onRail = new Vector3(0,0,0);
    private Vector3 wVec  = new Vector3(0,0,0);
    public float damageFromOnePerson = 15;
    public float heat = 0;
    int coll_passager = 0;
    float _timer;
    public Text temperature;
    public Text speedText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!stop){
        wVec = new Vector3(Target.position.x,transform.position.y,Target.position.z);
        }
        Ray ray = new Ray(this.gameObject.transform.position, Vector3.down);
        RaycastHit hit;
        Debug.DrawRay(transform.position, Vector3.down, Color.green);
        if (Physics.Raycast(ray, out hit, Mathf.Infinity))
        {
            if(hit.collider.tag == "Rail")
            {
                onRail = new Vector3(hit.point.x,transform.position.y,hit.point.z);
                //onRail = new Vector3(hit.transform.position.x,transform.position.y,hit.transform.position.z);
                transform.rotation = hit.transform.rotation;
                transform.Rotate(new Vector3(transform.rotation.x,angle,transform.rotation.z));
                if(!stop)
                    transform.position = Vector3.MoveTowards(transform.position,wVec,Time.deltaTime*speed);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position,onRail,Time.deltaTime*speed);
            }
        }
        if(sostav != null){
            stop = sostav.GetComponent<movetoTarget>().stop;
            speed = sostav.GetComponent<movetoTarget>().speed;
        }else{
            heating();
            speedText.text = "Передача поезда "+ speed;
        }
        GameObject[] passagers = GameObject.FindGameObjectsWithTag("Enemy");
        coll_passager = passagers.Length-2;
        gameObject.GetComponent<destroy_trigger>().damage=damageFromOnePerson*coll_passager;
        if(coll_passager<=0)
            coll_passager = 1;
        gameObject.GetComponent<destroy_trigger>().time_hit=1/coll_passager;
    }

    public void OnTriggerEnter(Collider other){
        if(other.tag == "Enemy"){
            other.gameObject.transform.SetParent(this.gameObject.transform);
        }
    }

    public void setStop(){
        stop = false;
    }

    public void PSpeed(){
        if(speed < 15)
            speed += 1;
    }
    public void Mspeed(){
        if(speed>0)
            speed-=1;
    }

    private void heating(){
        _timer+=Time.deltaTime;
        temperature.text = heat+"%";
        if(_timer>0.3){
            if(heat>=0){
                heat+=speed-4;
            }else{
                heat = 0;
            }
            _timer = 0;
        }
        if(heat>=100){
            speed = 0;
        }
    }
}
