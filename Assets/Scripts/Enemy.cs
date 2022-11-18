using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public PlayerMovement playerMovement;
    

    
    private Animator anim;


    private void Start() {
    anim = GetComponent<Animator>();
    
    }
    
    
    public void JumpedOn(){
        anim.SetTrigger("deathEnemy");
    }

    private void deathEnemy(){
        Destroy(this.gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
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

      
    }
}
