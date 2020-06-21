using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Get_my_helth : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject me;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    if(me != null)
        gameObject.GetComponent<Text>().text = me.GetComponent<Enemy_helf>().HP.ToString();   
    }
}
