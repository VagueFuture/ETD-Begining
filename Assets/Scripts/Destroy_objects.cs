using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy_objects : MonoBehaviour
{
    // Start is called before the first frame update
    public float time_death;
    void Start()
    {
        Destroy(gameObject,time_death);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
