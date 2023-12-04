using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingVerticalPlatform : MonoBehaviour
{
    public float upLimit = 3f;          // upper limit of the world position
    public float downLimit = -2.5f;     // lower limit of the world postion
    public float speed = 2.0f;          // speed of the moving platform
    private int direction = 1;          // to detect and turn up and down of platform
    
    private void OnTriggerEnter2D(Collider2D collision){
        if( collision.gameObject.CompareTag("Player")){
            collision.gameObject.transform.SetParent(transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        
        if( collision.gameObject.CompareTag("Player")){
            collision.gameObject.transform.SetParent(null);
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        // collision.collider.transform.SetParent(transform);
        if (transform.position.y > upLimit) {
         direction = -1;
        }
        else if (transform.position.y < downLimit) {
         direction = 1;
        }
        Vector3 movement = Vector3.up * direction * speed * Time.deltaTime; 
        transform.Translate(movement); 
    }


}
