using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move_to_Target : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Target;
    public Transform PlatformTarget;
    private Transform tmpTarget;
    public float speed;
    public float othod = 10;
    private Vector3 wVec  = new Vector3(0,0,0);
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Target.GetComponent<movetoTarget>()!=null){
           speed = Target.GetComponent<movetoTarget>().speed;
           if(Target.GetComponent<movetoTarget>().stop){
               speed +=10;
               tmpTarget = PlatformTarget;
               transform.rotation = Quaternion.RotateTowards(transform.rotation,tmpTarget.rotation,Time.deltaTime*speed*3);
               wVec = new Vector3(tmpTarget.position.x,tmpTarget.position.y,tmpTarget.position.z);
           }else{
               tmpTarget = Target;
               transform.position = new Vector3(transform.position.x,PlatformTarget.position.y+othod,transform.position.z);
               wVec = new Vector3(tmpTarget.position.x,transform.position.y,tmpTarget.position.z);
           }
        }
         transform.position = Vector3.MoveTowards(transform.position,wVec,Time.deltaTime*speed);
    }
}
