using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Dialog_system : MonoBehaviour
{
    // Start is called before the first frame update
    public List<string> Dialogs = new List<string>();
    public List<Sprite> image_face = new List<Sprite>();
    public Text dialog_place;
    public GameObject sprite_place;
    public float timeLetter = 10f;
    public AudioSource audit;
    float _timer;
    public int j = 0;
    bool whait = false;
    public bool end;
    int z=0;
    void Start()
    {
        StartCoroutine(printText());
        j++;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            if(!whait){
                whait = true;
                StartCoroutine(printText());
                j++;
            }
            if(j>Dialogs.Count){
                gameObject.SetActive(false);
                z++;
                whait = false;
                dialog_place.text = "Сообщение";
                if(z==2)
                    end = true;
                //Destroy(gameObject);
            }else{
                end = false;
            } 
        }
    }
    IEnumerator printText(){
        string str = Dialogs[j];
        string temp = "";
        
        int i=0;
        while(i<str.Length){
            _timer+=Time.deltaTime;
           // Debug.Log(str[i]);
            if(_timer > timeLetter){
                temp+=str[i];
                dialog_place.text = temp;
                _timer = 0;
                i++;
                audit.Play();
            }
            yield return null;
        }
        whait = false;
    }

    public int Get_Position(){
        return j;
    }
}
