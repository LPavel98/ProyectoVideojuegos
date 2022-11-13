using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public bool sePuedeMover = true;
    //[SerializeField] private Vector2 velocidadRebote;

    public float KBForce = 7;
    public float KBCounter;
    public float KBTotalTime = .3f;
    public bool KnockFromRight = true;


    public AudioClip jumpClip;
    public Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;

    // [SerializeField] private int health;

    [SerializeField] private LayerMask jumpableGround;
    private AudioSource audioSource;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    public enum MovementState { idle, running, jumping, falling }
    public MovementState state;

    private PlayerLife playerlife;

    //private Enemy enemy;
    //[SerializeField] private AudioSource jumpSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        playerlife = FindObjectOfType<PlayerLife>();

    }

    // Update is called once per frame
    void Update()
    {
        
        // dirX = Input.GetAxisRaw("Horizontal");
        // rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            audioSource.PlayOneShot(jumpClip);
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }
        
        
             UpdateAnimationState();
        
       
    }

    


    private void UpdateAnimationState()
    {
        if (KBCounter <= 0)
        {
            dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
        }

        else
        {
            if (KnockFromRight==true)
            {
                rb.velocity = new Vector2(-KBForce, KBForce);
            }
            if (KnockFromRight==false)
            {
                rb.velocity = new Vector2(KBForce, KBForce);
            }
            KBCounter -= Time.deltaTime;
        }


            if (dirX > 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
        }
        else if (dirX < 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        else if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
        
            
        

        
        
    }


    // public void Rebote(Vector2 puntoGolpe){
    //      rb.velocity = new Vector2(-moveSpeed * 100, velocidadRebote.y);
    // }

    

   
    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "Enemy"){
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (state == MovementState.falling )
            {
                enemy.JumpedOn();
                rb.velocity = new Vector2(rb.velocity.x, 7);
            }

            if (state != MovementState.falling)
            {
                
               
                playerlife.Die2();
                
            }
          
            
        }
        if (other.gameObject.tag == "Enemy2"){
            Enemy enemy = other.gameObject.GetComponent<Enemy>();
            if (state == MovementState.falling )
            {
                enemy.JumpedOn();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }

            if (state != MovementState.falling)
            {
                playerlife.Die();
            }

            
        }
        
    }

    

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
