using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHorizontalPlatform : MonoBehaviour
{
    public float leftLimit = -2.5f;     // leftmost limit of the world position
    public float rightLimit = 3f;       // rightmost limit of the world postion
    public float speed = 2.0f;          // speed of the moving platform
    private int direction = 1;          // to detect and turn left and right of platform

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
        if (transform.position.x > rightLimit) {
         direction = -1;
        }
        else if (transform.position.x < leftLimit) {
         direction = 1;
        }
        Vector3 movement = Vector3.right * direction * speed * Time.deltaTime; 
        transform.Translate(movement); 
    }

}
