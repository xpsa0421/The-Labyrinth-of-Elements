using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceScript : MonoBehaviour
{

    public float freezeTime = 5f;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
        if(collision.gameObject.CompareTag("Enemy")){
            if(collision.gameObject.GetComponent<AIPatrol>()!=null){
                collision.gameObject.GetComponent<AIPatrol>().setFrozenTime(freezeTime);
            }
            if(collision.gameObject.GetComponent<AIShoot>()!=null){
                collision.gameObject.GetComponent<AIShoot>().setFrozenTime(freezeTime);
            }
            Destroy(this.gameObject);
        }
    }
}
