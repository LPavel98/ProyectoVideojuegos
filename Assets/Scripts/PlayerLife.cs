using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    private PlayerMovement playerMovement;
    [SerializeField] private float tiempoPerdidaControl;

    [SerializeField] private Text livesText;
    private int lives=5;
    

    public AudioClip deathClip;
    private Rigidbody2D rb;
    private Animator anim;
    
   
    

    

    private AudioSource audioSource;

    void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
        audioSource = GetComponent<AudioSource>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }
    void Update(){
        livesText.text = "Lives: " +lives;

    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            lives -=1;
            Die2();
        }
                
        }

       

    //  public void TomarDaño(Vector2 posicion){
    //     StartCoroutine(PerderControl());
    //     playerMovement.Rebote(posicion);
    // }
    // private IEnumerator PerderControl(){
    //     playerMovement.sePuedeMover = false;
    //     yield return new WaitForSeconds(tiempoPerdidaControl);
    //     playerMovement.sePuedeMover = true;
    // }
        

    public void Die()
    {        
        audioSource.PlayOneShot(deathClip);
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    public void Die2()
    {
        
        if (lives==0)
        {
           rb.bodyType = RigidbodyType2D.Static;

            anim.SetTrigger("death");

        }
        
        
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
