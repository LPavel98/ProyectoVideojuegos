using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public AudioClip deathClip;
    private Rigidbody2D rb;
    private Animator anim;
    

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
                
        }
        

    public void Die()
    {
        
        audioSource.PlayOneShot(deathClip);
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    public void Die2()
    {
        anim.SetTrigger("death");
        
        
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
