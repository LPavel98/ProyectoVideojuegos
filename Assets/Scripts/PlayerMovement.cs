using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public AudioClip jumpClip;
    public Rigidbody2D rb;
    private BoxCollider2D coll;
    private SpriteRenderer sprite;
    private Animator anim;
    private Animator animator;

    [SerializeField] private LayerMask jumpableGround;
    private AudioSource audioSource;

    private float dirX = 0f;
    [SerializeField] private float moveSpeed = 7f;
    [SerializeField] private float jumpForce = 14f;

    public enum MovementState { idle, running, jumping, falling }
    public MovementState state;

    private PlayerLife playerlife;

    private Eagle eagle;
    //[SerializeField] private AudioSource jumpSoundEffect;
    // Start is called before the first frame update
    void Start()
    {
        
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        sprite = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        animator = GetComponent<Animator>();

        playerlife = FindObjectOfType<PlayerLife>();

    }

    // Update is called once per frame
    void Update()
    {
        
        dirX = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            audioSource.PlayOneShot(jumpClip);
            //jumpSoundEffect.Play();
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            
        }

        UpdateAnimationState();
    }
    private void UpdateAnimationState()
    {
        // MovementState state;

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

    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "Enemy"){
            Frog frog = other.gameObject.GetComponent<Frog>();
            if (state == MovementState.falling )
            {
                frog.JumpedOn();
                rb.velocity = new Vector2(rb.velocity.x, 5);
                //Destroy(other.gameObject);
                //enemyLife.DieEnemy();
                //eagle.deathEnemy();
                // animator.SetTrigger("deathEnemy");
                //Destroy(other.gameObject);
            }

            if (state != MovementState.falling)
            {
                playerlife.Die();
            }

            
        }
        if (other.gameObject.tag == "Enemy2"){
            Eagle eagle = other.gameObject.GetComponent<Eagle>();
            if (state == MovementState.falling )
            {
                eagle.JumpedOn();
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                //enemyLife.DieEnemy();
                // animator.SetTrigger("deathEnemy");
                //Destroy(other.gameObject);
            }

            if (state != MovementState.falling)
            {
                playerlife.Die();
            }

            
        }
        
        // if (other.gameObject.name == "eagle")
        // {
        //     if (state == MovementState.falling )
        //     {
        //         rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        //         //enemyLife.DieEnemy();
        //         //animator.SetTrigger("deathEnemy");
        //         //Destroy(other.gameObject);
                
        //     }
        //     if (state != MovementState.falling)
        //     {
        //         playerlife.Die();
        //     }
        // }
    
    }

    

    private bool IsGrounded()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, jumpableGround);
    }
}
