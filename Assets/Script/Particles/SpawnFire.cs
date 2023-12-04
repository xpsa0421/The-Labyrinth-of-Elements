using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFire : MonoBehaviour
{
    public GameObject fire;
    public float spawnTime = 2f;
    public float timeToLive = 10f;

    private GameObject fireClone;

    // Start is called before the first frame update
    void Start()
    {
        float spawnRate = 1f/spawnTime;
        InvokeRepeating("addFire", spawnTime,timeToLive);
        InvokeRepeating("destroyFire",timeToLive,timeToLive);
    }

    void addFire(){
        fireClone = Instantiate(fire, transform.position, Quaternion.identity);
    }

    void destroyFire(){
        if(fireClone!=null){
            Destroy(fireClone);
        }
    }

}
