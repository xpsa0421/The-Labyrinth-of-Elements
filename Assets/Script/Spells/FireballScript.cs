using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballScript : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Destroy(this.gameObject);
        }
        if(collision.gameObject.CompareTag("Enemy")){
            Destroy(this.gameObject);
            Destroy(collision.gameObject);
        }
    }


}
