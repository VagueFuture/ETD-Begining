using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera_move : MonoBehaviour
{
    public float leftgran;
    public float rightgran;
    public float forwgran;
    public float backgran;
    public float upgran;
    public float downgran;
    public float speed;
    public float othod;

    private Vector3 startPos;
    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            startPos = cam.ScreenToViewportPoint(Input.mousePosition);
        }
        else if(Input.GetMouseButton(0)){
            if(Input.GetMouseButton(1)){
                float pos = cam.ScreenToViewportPoint(Input.mousePosition).x - startPos.x;
                if(upgran>transform.position.y-pos){
                    if(downgran<transform.position.y-pos){
                        transform.position = new Vector3(transform.position.x,transform.position.y-pos*speed,transform.position.z);
                    }else{transform.position = new Vector3(transform.position.x,transform.position.y+othod,transform.position.z);}
                }else{transform.position = new Vector3(transform.position.x,transform.position.y-othod,transform.position.z);}
            }else{
            float posx = cam.ScreenToViewportPoint(Input.mousePosition).x - startPos.x;
            float posy = cam.ScreenToViewportPoint(Input.mousePosition).y - startPos.y;
            if(forwgran<transform.position.x - (posy*-1))
                {
                    if(backgran>transform.position.x - (posy*-1))
                    {
                        if(leftgran < transform.position.z-posx)
                        {
                            if(rightgran > transform.position.z-posx)
                            {
                                transform.position = new Vector3(transform.position.x - (posy*-1)*speed,transform.position.y,transform.position.z-posx*speed);
                            }else{
                                transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z-othod);}
                        }else{
                            transform.position = new Vector3(transform.position.x,transform.position.y,transform.position.z+othod);}
                    }else{
                        transform.position = new Vector3(transform.position.x +posy - othod,transform.position.y,transform.position.z);}
                }else{
                    transform.position = new Vector3(transform.position.x +posy + othod,transform.position.y,transform.position.z);}
            }
        }

        if(pressup){
            float pos = cam.ScreenToViewportPoint(Input.mousePosition).x - startPos.x;
                if(upgran<transform.position.y-pos){
                    if(downgran<transform.position.y-pos){
                        transform.position = new Vector3(transform.position.x,transform.position.y+pos*speed,transform.position.z);
                    }else{transform.position = new Vector3(transform.position.x,transform.position.y+othod,transform.position.z);}
                }else{transform.position = new Vector3(transform.position.x,transform.position.y+othod,transform.position.z);}
        }

        if(pressdown){
            float pos = cam.ScreenToViewportPoint(Input.mousePosition).x - startPos.x;
                if(downgran>transform.position.y-pos){
                    if(downgran<transform.position.y-pos){
                        transform.position = new Vector3(transform.position.x,transform.position.y-pos*speed,transform.position.z);
                    }else{transform.position = new Vector3(transform.position.x,transform.position.y+othod,transform.position.z);}
                }else{transform.position = new Vector3(transform.position.x,transform.position.y-othod,transform.position.z);}
                }

    }

    bool pressup = false;
    bool pressdown = false;
    public void camera_down(){
        pressdown = !pressdown;
    }

    public void camera_up(){
        pressup = !pressup;
    }
}
