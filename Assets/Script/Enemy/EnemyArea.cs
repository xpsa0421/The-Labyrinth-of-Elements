using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArea : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            
            transform.parent.gameObject.GetComponent<AIShoot>().determineInsideArea(true);
        }
    }
    void OnTriggerExit2D(Collider2D collision){
        if(collision.gameObject.CompareTag("Player")){
            
            transform.parent.gameObject.GetComponent<AIShoot>().determineInsideArea(false);
        }
    }
}
