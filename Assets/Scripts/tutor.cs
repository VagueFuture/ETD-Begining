using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tutor : MonoBehaviour
{
    public List<Transform> camera_pos = new List<Transform>();
    public Transform cam;
    public GameObject Gameview,panel,buttonStart;
    public Dialog_system Ds;
    int i =0;
    // Start is called before the first frame update
    void Start()
    {
        //Gameview = GameObject.Find("Game_window");
        //panel = GameObject.Find("PanelT");
        //buttonStart = GameObject.Find("ButtonS");
        //Ds = GameObject.Find("Dialog_panel").GetComponent<Dialog_system>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Ds.Get_Position() == 3)
        {
            Gameview.SetActive(true);
        }
        if(Ds.Get_Position() == 8)
        {
            cam.position = new Vector3(camera_pos[0].position.x,camera_pos[0].position.y,camera_pos[0].position.z);
        }
        if(Ds.Get_Position() == 10)
        {
            cam.position = new Vector3(camera_pos[1].position.x,camera_pos[1].position.y,camera_pos[1].position.z);
        }
        if(Ds.Get_Position() == 12)
        {
            panel.SetActive(true);
        }
        if(Ds.Get_Position() == 13)
        {
            buttonStart.SetActive(true);
        }
    }
}
