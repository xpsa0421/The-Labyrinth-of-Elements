using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireParticle : MonoBehaviour
{
    public float lifeSpan = 1f;
    public float timeAlive = 0f;
    public Vector2 minVelocity = new Vector2(-0.1f, 0.5f);
    public Vector2 maxVelocity = new Vector2(0.1f, 0.75f);


    private Vector2 velocity;


    // Start is called before the first frame update
    void Start()
    {
        velocity = new Vector2(Random.Range(minVelocity.x, maxVelocity.x), Random.Range(minVelocity.y, maxVelocity.y));
        
    }

    // Update is called once per frame
    void Update()
    {
        timeAlive += Time.deltaTime;
        
        if(timeAlive >= lifeSpan){
            Destroy(gameObject);
            return;
        }
        this.transform.Translate(velocity * Time.deltaTime);
    }
}
