using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerHealth : MonoBehaviour
{
    public DeathMenu deathMenu;
    public HealthBar healthBar;
    public GameObject bloodOverlay;

    private Animator animator;
    private Player player;
    private List<GameObject> spawnPoints;
    private Transform spawnPoint;

    void Awake(){
        animator = gameObject.GetComponent<Animator>();
        player = gameObject.GetComponent<Player>();
    }    

    void Start()
    {
        ResetPlayerHealth();
        spawnPoints = new List<GameObject>();
        if(spawnPoint == null){
            spawnPoint = GameObject.FindGameObjectsWithTag("Respawn")[0].transform;
        }

    }

    void FixedUpdate()
    {
        animator.SetBool("Beaten", false);
        showBloodOverlay();
        
    }

    // Players has a hitbox so we don't need to use OnColliderEnter2D
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fire"))
        {
            TakeDamage(1);
            KnockBack(collision);
        }
        if (collision.gameObject.CompareTag("FallDetect"))
        {
            TakeDamage(player.health);
        }
        if(collision.gameObject.CompareTag("Lava")){
            TakeDamage(2);
            spawnPoint = FindClosestSpawnPoint();
            gameObject.transform.position = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        }
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(1);
            KnockBack(collision);
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            TakeDamage(2);
            KnockBack(collision);
        }
        // auto save player progress
        if(collision.gameObject.CompareTag("Respawn")){
            if(!spawnPoints.Contains(collision.gameObject)){
                spawnPoints.Add(collision.gameObject);
                Debug.Log("Add respawn point");
            }
            player.SaveLevel();
            player.SavePlayer();
        }
    }
    // reset player health to maximum health
    public void ResetPlayerHealth()
    {
        player.health = player.maxHealth;
        healthBar.SetHealth(player.health);
        Debug.Log("health set to original");
    }

    // when hit, reduce health and call animation
    private void TakeDamage(int damage)
    {
        player.health -= damage;
        healthBar.SetHealth(player.health);
        animator.SetBool("Beaten", true);
        // StartCoroutine(ShowAndHide(bloodOverlay, 1.0f));

        // game over
        if (player.health <= 0)
        {   
            deathMenu.gameObject.SetActive(true);
            Time.timeScale = 0;
            // ResetPlayerHealth();
            animator.SetBool("Reborn", true);
            
            // gameObject.transform.position = new Vector3(spawnPoints[0].transform.position.x, spawnPoints[0].transform.position.y, spawnPoints[0].transform.position.z);
        }
    }

    private void KnockBack(Collider2D collision){
        if (collision.gameObject.transform.position.x > transform.position.x)
        {
            // if enemy on my right, move left
            Vector3 pos = transform.position;
            pos.x -= 0.5f;
            transform.position = pos;
        }
        else
        {
            // if enemy on my left, move right
            Vector3 pos = transform.position;
            pos.x += 0.5f;
            transform.position = pos;
        }
    }

    private Transform FindClosestSpawnPoint(){
        GameObject closest = null;
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject point in spawnPoints)
        {
            Vector3 diff = point.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if(curDistance < distance){
                closest = point;
                distance = curDistance;
            }
        }
        return closest.transform;
    }

    private void showBloodOverlay(){
        if(player.health <= 5){
            bloodOverlay.SetActive(true);
        }else{
            bloodOverlay.SetActive(false);
        }
    }
}
