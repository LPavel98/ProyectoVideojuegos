using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLife : MonoBehaviour
{
    //public AudioClip deathClip;
    private Rigidbody2D rb;
    private Animator anim;
    

    //[SerializeField] private AudioSource deathSoundEffect;
    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         DieEnemy();
    //     }
    // }

    // public void DieEnemy()
    // {
    //     //audioSource.PlayOneShot(deathClip);
    //     //deathSoundEffect.Play();
    //     rb.bodyType = RigidbodyType2D.Static;
    //     //anim.SetTrigger("deathEnemy");
    //     //Destroy(this.gameObject);
    //    // Destroy(this.gameObject);
    // }

    // private void RestartLevel()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }
}
