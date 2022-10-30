using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Frog : MonoBehaviour
{
    private Rigidbody2D rb;
    private Collider2D coll;
    private Animator anim;
    public enum MovementState {jumping, falling }
    public MovementState state;
    
    [SerializeField] private float jumpForce = 10f;
    
    

    //private enum MovementState {idle, jumping, falling }
    //private MovementState stateFrog;
   

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
    
    }

    public void JumpedOn(){
        anim.SetTrigger("deathEnemy");
    }

    private void deathEnemy(){
        Destroy(this.gameObject);
    }

}

   
