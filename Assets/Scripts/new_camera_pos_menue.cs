using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class new_camera_pos_menue : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> posit = new List<Transform>();
    public float speed_move;
    public float speed_rotate;
    private bool working;
    private int  num;
    private float _timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(working){
            transform.rotation = Quaternion.RotateTowards(transform.rotation,posit[num].rotation,Time.deltaTime * speed_rotate);
            transform.position = Vector3.MoveTowards(transform.position,posit[num].position,Time.deltaTime*speed_move);
        }
        if(_timer > 5){
            working = false;
        }

        if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
            {
                go_to_camer(0);
            }
    }
    public void go_to_camer(int number){
        working = true;
        _timer =  0;
        num = number;
    }
    public int get_my_pos(){
        return num;
    }
} 
