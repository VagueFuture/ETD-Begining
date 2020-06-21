using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class move : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform Target;
    public float speed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 wVec = new Vector3(Target.position.x,Target.position.y,Target.position.z);
        transform.position = Vector3.MoveTowards(transform.position,wVec,Time.deltaTime*speed);
    }
}
