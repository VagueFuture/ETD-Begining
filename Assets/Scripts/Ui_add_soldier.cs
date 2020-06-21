using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Ui_add_soldier : MonoBehaviour
{
    public int price;
    public GameObject buttonOk;
    public GameObject buttonNO;
    private bool pressed;
    private Vector3 targPos;
    public GameObject solder_can;
    public GameObject solderObjects;
    private GameObject sN;
    private bool access;
    public List<Transform> floors = new List<Transform>();

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
            sN = Instantiate(solder_can,targPos,solder_can.transform.rotation) as GameObject;
        }else{
            
        }
        Debug.Log("Press on button");   
    }
    // Update is called once per frame
    void Update()
    {
         if(pressed){
            if(Input.GetMouseButtonDown(0)){
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray))
                {
                    //Debug.Log(IsPointerOverUIObject());
                    if (!IsPointerOverUIObject()){//EventSystem.current.IsPointerOverGameObject()){
                        foreach(Transform floor in floors)
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
                int money = Camera.main.GetComponent<gamelogick>().money;
                access = sN.GetComponentInChildren<can_build_trigger>().color;
                Debug.Log(access);
                if(access){
                    if(money>=price){
                        Camera.main.GetComponent<gamelogick>().money -= price;
                        GameObject tO = Instantiate(solderObjects,targPos,solderObjects.transform.rotation) as GameObject;
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
