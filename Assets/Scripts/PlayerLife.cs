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
    public int lives=5;
    

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
        //lives = PlayerPrefs.GetInt("livesText", lives);
        //livesText.text = "x: "+lives.ToString();
    }
    void Update(){
        //livesText.text = "Lives: " +lives;
        PlayerPrefs.SetInt("livesText", lives);
        livesText.text = "Lives: " +lives.ToString(); 
        

    }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            lives = 0;
            PlayerPrefs.SetInt("livesText", lives);
            livesText.text = "Lives: " +lives.ToString(); 
            
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            lives -=1;
            Die2();
            //lives = 5;
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
        
        if (lives==0)
        {
           rb.bodyType = RigidbodyType2D.Static;

            anim.SetTrigger("death");
            //lives = 5;

        }
        
        
        
    }

    private void RestartLevel()
    {
        // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
         SceneManager.LoadScene (sceneBuildIndex:5);
    }
}
