using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPatrol : MonoBehaviour
{
    public float walkSpeed = 3.5f;
    public float patrol_distance = 50f;
    

    private float frozenCD = -1f;
    private Rigidbody2D rb;
    private float distance_travelled;
    private Vector2 lastPosition;
    private bool mustTurn = false;
    

    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        lastPosition = rb.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        frozenCD -= Time.deltaTime;

        distance_travelled += Vector2.Distance(rb.transform.position, lastPosition);
        // if the monster have walked at certain distance
        if(distance_travelled > patrol_distance){
            mustTurn = true;                         // flip the monster
            distance_travelled = 0f;                 // restart the distance counter
            lastPosition = rb.transform.position;
        }

        Patrol();

    }

    // for setting frozenTime in IceScript
    public void setFrozenTime(float time){
        this.frozenCD = time;
    }

    private void Patrol()
    {
        
        if(mustTurn)
        {
            Flip();
        }
        if (frozenCD > 0f)
        {
            rb.velocity = new Vector2(0f, 0f);
        }
        else
        {
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
        }
    }


    private void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustTurn = false;
    }
}
