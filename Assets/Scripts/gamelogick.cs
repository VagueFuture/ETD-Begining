using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class gamelogick : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject common_panel;
    public int money;
    public Text rocket_Text;
    public int rockets;
    public Text text;
    public Text stat;
    public GameObject spawn;
    bool saved = false;
    public bool Train_destroy;
    bool win;
    public int battaryDead;
    // Update is called once per frame
    void start(){

    }
    void Update()
    {
        text.text = money.ToString();
        if(rocket_Text!=null)
        rocket_Text.text = rockets.ToString();
        if(spawn != null)
            win = spawn.GetComponent<spawner>().win;
        if(win){
            stat.text = "Далее";
            Debug.Log("You win");
        } 

        if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
            {
                Application.LoadLevel(0);
            }
        
        if(rockets>0){
            if(common_panel!= null)
                common_panel.SetActive(true);
            }
        else{
            if(common_panel!= null)
                common_panel.SetActive(false);
        }

        if(battaryDead >=2){
            Train_destroy = true;
        }

    }
        
}
