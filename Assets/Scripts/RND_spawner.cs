using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RND_spawner : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Transform> ways_targets = new List<Transform>();
    public List<GameObject> enemys = new List<GameObject>();
    private float _timer;
    void Start()
    {
        _timer = 2;
    }

    // Update is called once per frame
    void Update()
    {
        _timer += Time.deltaTime;
        if(_timer > 2){
            _timer = 0;
            int rnd = Random.Range(0, enemys.Count);
            GameObject sN = Instantiate(enemys[rnd],transform.position,transform.rotation) as GameObject;
            sN.GetComponent<moving>().ways_targets = this.ways_targets;
        }
    }
}
