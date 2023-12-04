using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{

    public PlayerController controller;
    public GameObject PauseMenu;

    public float runSpeed = 40f;
    public float fireDelta = 1f;
    public float magicSpeed = 8f;
    public float flyingHeight = 10f;
    private float floatSpeed = .5f;     

    public GameObject fireBall;
    public GameObject ice;
    public GameObject rock;
    
    public SkillBar fireBar;
    public SkillBar airBar;
    public SkillBar waterBar;
    public SkillBar earthBar;


    private bool fireUnlock = false;
    private bool windUnlock = false;
    private bool iceUnlock = false;
    private bool earthUnlock = false;
    private bool usedFly = false;
    
    private float cooldown = 3f;               // Cooldown time for all skills
    private float fireCD = 0f;                 // Current cooldown time of fire
    private float iceCD = 0f;                  // Current cooldown time of ice
    private float windCD = 0f;                 // Current cooldown time of wind
    private float maxFloatTime = 3f;
    private float floatTime = 0f;
    private float earthCD = 0f;                // Current cooldown time of earth


    private float timer = 0f;
    private float horizontalMove = 0f;         // Player's horizontal speed
    private float verticalMove = 0f;           // Player's vertical speed
    private bool jump = false;                 // Whether Player jumps or not
    private bool crouch = false;               // Whether Player crouches or not
    private Vector2 shootingPosition;

    private Rigidbody2D spell_rb;              // Rigid body of Instantiate spell when player casts spell
    private CircleCollider2D feetCollider;      //Player's collider on ground
    private Rigidbody2D rb;
    private Animator animator;


    private void Awake(){
        fireBar.setMaxCoolDown((int) cooldown);
        airBar.setMaxCoolDown((int) cooldown);
        waterBar.setMaxCoolDown((int) cooldown);
        earthBar.setMaxCoolDown((int) cooldown);

        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        feetCollider = gameObject.GetComponent<CircleCollider2D>();
    }
    private void Start()
    {
        
        switch (SceneManager.GetActiveScene().buildIndex)
        {
            case 3:
                fireUnlock = true;
                windUnlock = true;
                break;

            case 4: 
                fireUnlock = true;
                windUnlock = true;
                iceUnlock = true;
                break;

            case 5:
                fireUnlock = true;
                windUnlock = true;
                iceUnlock = true;
                earthUnlock = true;
                break;
                
            default:
                fireUnlock = true;
                break;
        }

        fireBar.setActive(fireUnlock);
        airBar.setActive(windUnlock);
        waterBar.setActive(iceUnlock);
        earthBar.setActive(earthUnlock);

        Invoke("Reborn", 2.5f);

    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetKeyDown(KeyCode.Escape)){
            Debug.Log("Pause");
            PauseMenu.SetActive(true);
            Time.timeScale = 0;
        }
        if(!animator.GetBool("Reborn")){
            horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed ;
            verticalMove = Input.GetAxisRaw("Vertical");
            
            fireCD += Time.deltaTime;
            iceCD += Time.deltaTime;
            windCD += Time.deltaTime;
            earthCD += Time.deltaTime;

            fireBar.setCurrentCoolDown(fireCD);
            waterBar.setCurrentCoolDown(iceCD);
            airBar.setCurrentCoolDown(windCD);
            earthBar.setCurrentCoolDown(earthCD);
        }else{
            feetCollider.offset = new Vector2(-0.02f, 0.11f);
            horizontalMove = 0;     //freeze player's movement when Reborn animation is playing
            verticalMove = 0;
            Invoke("Reborn", 1.5f);
        }
        
        animator.SetBool("Grounded", controller.isGrounded());
        
        if( rb.velocity.y < -1f){
            animator.SetBool("Fall", true);
        }

        if(Input.GetButtonDown("Jump") && controller.isGrounded()){
            jump = true;
            animator.SetBool("Jump", true);
        } 
        
        if((Input.GetKeyDown(KeyCode.Alpha1)||Input.GetKeyDown(KeyCode.Alpha2)||Input.GetKeyDown(KeyCode.Alpha3)||Input.GetKeyDown(KeyCode.Alpha4))){
            CastSpell();
        }
        
        if(Input.GetButtonDown("Crouch")){
            crouch = true;
            animator.SetBool("Crouch", true);

        }else if(Input.GetButtonUp("Crouch")){
            crouch = false;
            animator.SetBool("Crouch", false);
        }
        

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetFloat("vSpeed", Mathf.Abs(verticalMove));


    }

    private void CastSpell()
    {   
        
        // if release fireball 
        if(Input.GetKeyDown(KeyCode.Alpha1) && fireCD > cooldown && fireUnlock){
            Rigidbody2D fireBall_rb = fireBall.GetComponent<Rigidbody2D>();
            spell_rb = Instantiate(fireBall_rb, transform.position,  Quaternion.identity);
            FlipSpell();        // this is to flip the spell when player is facing left; otherwise, it does nothing
                                // no need to set Invoke or InvokeRepeat for timing
            fireCD = 0f;
            animator.SetBool("Cast", true);
        }
        // if FLY 
        if(Input.GetKeyDown(KeyCode.Alpha2) && windCD>cooldown && !usedFly && windUnlock){
            rb.velocity = Vector2.up * flyingHeight;
            usedFly = true;
            windCD = 0f;
            animator.SetBool("Cast", true);
        }
        // if release ice 
        if(Input.GetKeyDown(KeyCode.Alpha3) && iceCD > cooldown && iceUnlock){
            Rigidbody2D ice_rb = ice.GetComponent<Rigidbody2D>();
            spell_rb = Instantiate(ice_rb, transform.position,  Quaternion.identity);
            
            
            FlipSpell();
            iceCD = 0f;
            animator.SetBool("Cast", true);
        }
        // if raise wall 
        if(Input.GetKeyDown(KeyCode.Alpha4) && earthCD > cooldown && earthUnlock){
            Rigidbody2D rock_rb = rock.GetComponent<Rigidbody2D>();
            adjustShootingPosition();
            spell_rb = Instantiate(rock_rb, shootingPosition,  Quaternion.identity);
            earthCD = 0f;
            animator.SetBool("Cast", true);
        }
        

    }

    private void adjustShootingPosition()
    {
        shootingPosition = transform.position;
        if (controller.facingRight())
        {
            shootingPosition.x += 1f;
        }
        else
        {
            shootingPosition.x -= 1f;
        }
    }

    private void FlipSpell()
    {
        if(controller.facingRight()){
            spell_rb.velocity = new Vector2(magicSpeed, 0f);   
        }
        else{
            spell_rb.velocity = new Vector2(-magicSpeed, 0f);
            Vector3 theScale = spell_rb.gameObject.transform.localScale;
            theScale.x *= -1;
            spell_rb.gameObject.transform.localScale = theScale;
        }
    }

    private void Reborn(){
        animator.SetBool("Reborn", false);
        feetCollider.offset = new Vector2(-0.02f, -0.22f);  
    }

    private void Float(){

        Vector2 v = rb.velocity;

        //Allow player to float in air within maxFloatTime
        if ((Input.GetKey(KeyCode.Alpha2))&& (rb.velocity.y<=0) && floatTime <= maxFloatTime && windUnlock == true)
        {
            v.y *= floatSpeed;
            rb.velocity = v;
            floatTime += Time.deltaTime;
        }
    }

    public void onLanding ()
    {
        animator.SetBool("Jump", false);
        animator.SetBool("Fall", false);
        usedFly = false;
        floatTime = 0f;
    }

    void FixedUpdate()
    {
        timer += Time.fixedDeltaTime;
        if(timer > fireDelta){
            animator.SetBool("Cast", false);
            timer = 0f;
        }
        // param: horizontal move, crouch, jump
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;

        Float();
    }


}
