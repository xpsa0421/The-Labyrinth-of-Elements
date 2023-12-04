using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIShoot : MonoBehaviour
{
    public float shootingSpeed = -7f;
    public float cooldown = 15f;        // cooldown of shooting
    public GameObject bullet;

    private Rigidbody2D rb;
    private GameObject player;
    private bool facing_right = false;
    private float currentCD = 0f;
    private float frozenCD = 0f;
    private bool isInsideArea = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    
    void Update()
    {      
        currentCD += Time.deltaTime;
        // if player is on the left side and enemy is facing right
        if(player.transform.position.x < transform.position.x && facing_right){
            Flip();
        }else if(player.transform.position.x > transform.position.x && !facing_right){
            Flip();
        }
        if(frozenCD > 0){
            currentCD -= frozenCD;
            frozenCD = 0f;
        }

        if(currentCD >= cooldown && isInsideArea){
            Shoot();
            currentCD = 0f;
        }
    }



    public void setFrozenTime(float time){
        frozenCD = time;
    }

    public void determineInsideArea(bool flag){
        isInsideArea = flag;
    }
    
    private void Shoot(){
        Rigidbody2D bullet_rb = Instantiate(bullet, transform.position, Quaternion.identity).GetComponent<Rigidbody2D>();
        bullet_rb.velocity = new Vector2(shootingSpeed, 0f);
    }

    private void Flip(){
        facing_right = !facing_right;
		// Multiply the enemy's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;

        // Multiply the shooting speed by -1
        shootingSpeed *= -1;
    }
}
