using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    public Vector3 positions;
    public List<Transform> ways_targets = new List<Transform>();
    private Rigidbody rb;
    public float speed = 10f;
    public int whalk_in; //0-all 1-earth 2-flyght
    public bool circle;
    private int j;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        j=0;

    }

    // Update is called once per frame
    void Update()
    {
        if(circle){
            if(j>=ways_targets.Count-1)
                j=0;
        }
        Vector3 wVec = new Vector3(ways_targets[j].transform.position.x,transform.position.y,ways_targets[j].transform.position.z);
        transform.LookAt(wVec);
        transform.position = Vector3.MoveTowards(transform.position,wVec,Time.deltaTime*speed);
        if(transform.position == wVec){
            if(j<ways_targets.Count-1){
                j++;
            }
        }
    }
}
