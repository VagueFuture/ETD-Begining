using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class table_images : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Sprite> spr = new List<Sprite>();
    void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = spr[0];
    }

    // Update is called once per frame
    public void set_sprite(int i){
        gameObject.GetComponent<SpriteRenderer>().sprite = spr[i];
    }
}
