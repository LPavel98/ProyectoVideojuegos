using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    public PlayerMovement playerMovement;

    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    
    public enum MovementState {jumping, falling }
    public MovementState state;
    
    [SerializeField] private float jumpForce = 10f;
      

    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<Collider2D>();
        anim = GetComponent<Animator>();

    }
    private void Update()
    {
         if (rb.velocity.y > .1f)
        {
            state = MovementState.jumping;
        }
        if (rb.velocity.y < -.1f)
        {
            state = MovementState.falling;
        }

        anim.SetInteger("state", (int)state);
 
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.name=="Terrain")
        {
          rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        if (other.gameObject.tag=="Player")
        {
            playerMovement.KBCounter = playerMovement.KBTotalTime;
            if (other.transform.position.x <= transform.position.x)
            {
                playerMovement.KnockFromRight = true;
            }
          if (other.transform.position.x > transform.position.x)
            {
                playerMovement.KnockFromRight = false;
            }

        }

       
        // if (other.gameObject.CompareTag("Player"))
        // {
        //     other.gameObject.GetComponent<PlayerLife>().TomarDaño(other.GetContact(0).normal);
        // }      
    }

}

   
