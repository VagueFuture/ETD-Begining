using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class UI_add_tower : MonoBehaviour
{
    // Start is called before the first frame update
    public int price;
    public GameObject buttonOk;
    public GameObject buttonNO;
    private bool pressed;
    private Vector3 targPos;
    public GameObject turret;
    public GameObject turretObjects;
    private GameObject sN;
    private bool access;
    public Transform floor;
    public bool Night;
    public bool cross = false;
    void Start()
    {
        pressed = false;
        buttonNO.SetActive(false);
        buttonOk.SetActive(false);
    }
    
    void OnMouseDown(){
        if(!buttonNO.activeSelf)
        if(!pressed){ 
            buttonNO.SetActive(true);
            buttonOk.SetActive(true);
            pressed = true;
            targPos = new Vector3(0,0,0);
            sN = Instantiate(turret,targPos,turret.transform.rotation) as GameObject;
        }else{
            
        }
        Debug.Log("Press on button");   
    }
    void Update()
    {   
       // Debug.Log("Press "+pressed);
        if(pressed){
            if(Input.GetMouseButtonDown(0)){
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray))
                {
                    //Debug.Log(IsPointerOverUIObject());
                    if (!IsPointerOverUIObject()){//EventSystem.current.IsPointerOverGameObject()){
                        if(floor.GetComponent<Collider>().Raycast(ray,out hit,Mathf.Infinity)){
                            targPos = hit.point;
                            sN.transform.position = targPos;
                        }
                    }
                }
                Debug.Log("Press on screen");
            }
        }
    }

    private bool IsPointerOverUIObject() {
     PointerEventData eventDataCurrentPosition = new PointerEventData(EventSystem.current);
     eventDataCurrentPosition.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
     List<RaycastResult> results = new List<RaycastResult>();
     EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
     return results.Count > 0;
    }

    public void Ok(){
       // Debug.Log("Press "+pressed);
        if(pressed){
            pressed = false;
            if(!cross){
                int money = Camera.main.GetComponent<gamelogick>().money;
                access = sN.GetComponentInChildren<can_build_trigger>().color;
                Debug.Log(access);
                if(access){
                    if(money>=price){
                        Camera.main.GetComponent<gamelogick>().money -= price;
                        GameObject tO = Instantiate(turretObjects,targPos,turretObjects.transform.rotation) as GameObject;
                        tO.GetComponent<tower_hp>().Night = Night;
                    }
                }
            }else{
                int rockets = Camera.main.GetComponent<gamelogick>().rockets;
                if(rockets>0){
                        Camera.main.GetComponent<gamelogick>().rockets -= 1;
                        GameObject tO = Instantiate(turretObjects,targPos,turretObjects.transform.rotation) as GameObject;
                    }
            }
        Destroy(sN);
        buttonNO.SetActive(false);
        buttonOk.SetActive(false);    
        }       
    }

    public void  NO(){
        if(pressed){
        pressed = false;
        Destroy(sN);
        buttonNO.SetActive(false);
        buttonOk.SetActive(false);
       }
    }
}
