using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class earth_missions : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector3> missions_vrash = new List<Vector3>();
    public bool whait;
    public Vector3 rotation;
    public float speed;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
      if(whait){
        transform.Rotate(rotation* Time.deltaTime*speed);
      }
    }

    public void select_mission(int x){
        whait = false;
        transform.Rotate(missions_vrash[x]);//on = missions_vrash[x];
    }
}
