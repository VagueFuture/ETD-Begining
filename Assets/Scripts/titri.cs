using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titri : MonoBehaviour
{
    // Start is called before the first frame update
    public float time;
    float _timer;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        _timer+= Time.deltaTime;
        if(_timer>=time)
            Application.LoadLevel(0);
    }
}
