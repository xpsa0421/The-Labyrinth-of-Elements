using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticleEffect : MonoBehaviour
{
    public GameObject ParticlePrefab;
    public float rate = 10f;                // production rate of the particles per second

    private float timeSinceLastSpawn = 0f;


    // Update is called once per frame
    void Update()
    {
        
        float deltaTime = 1f/rate;
        timeSinceLastSpawn += Time.deltaTime;
        
        while(timeSinceLastSpawn > deltaTime){
            // time to spawn a particle
            Instantiate(ParticlePrefab, this.transform.position, Quaternion.identity, this.transform );
            timeSinceLastSpawn -= deltaTime;
        }
    }
}
