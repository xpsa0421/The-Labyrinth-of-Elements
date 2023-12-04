using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockScript : MonoBehaviour
{
    
    public float existTime = 3.5f;

    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        existTime -= Time.deltaTime;
        if (existTime <= 0)
        {
            Destroy(this.gameObject);
        }
    }
}
