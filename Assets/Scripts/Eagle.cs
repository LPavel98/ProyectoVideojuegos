using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eagle : MonoBehaviour
{
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
}
