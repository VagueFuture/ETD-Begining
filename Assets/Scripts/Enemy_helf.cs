using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_helf : MonoBehaviour
{
    // Start is called before the first frame update
    public float HP;
    public int price;
    private float max_HP;
    public bool smert;
    private bool gifmon;
    public Animator anim;
    public GameObject myshield;
    public bool shield;
    public bool tesla;
    public GameObject particle;
    public AudioSource audit;

    void Start()
    {
        max_HP = HP;
        smert = false;
        gifmon = true;
        shield = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(shield){
            myshield.GetComponent<Renderer>().enabled = true;
        }else{
            myshield.GetComponent<Renderer>().enabled = false;
        }
        if(HP<=0){
            if(gifmon){
                if(Camera.main.GetComponent<gamelogick>()!=null)
                    Camera.main.GetComponent<gamelogick>().money += price;
                audit.Play();
            }
            dead();
        }
        
    }
    public void get_hit(float damage){
        if(!shield)
            HP -= damage; 
    }

    public void get_sheald(){

    }

    public void Heal_me(float heal){
        HP += heal;
        if(HP>max_HP){
            HP = max_HP;
        }
    }
    public void dead(){
        if(anim!=null)
            anim.SetBool("dead", true);
        smert = true;
        gifmon = false;
        if(particle != null){
            particle.SetActive(true);
        }
        Destroy(gameObject,2);
    }

}
