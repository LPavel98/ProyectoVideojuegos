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
    public int lives;
    

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



        lives = PlayerPrefs.GetInt("livesText", 0);
        livesText.text = "x"+lives.ToString();
        
    }
    // void Update(){
    //     PlayerPrefs.SetInt("livesText", lives);
    //     livesText.text = "x" +lives.ToString(); 
        

    // }

   

    private void OnCollisionEnter2D(Collision2D collision)
    {
        

        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
            lives = 5;
            PlayerPrefs.SetInt("livesText", lives);
        }

        if (collision.gameObject.CompareTag("Enemy") || collision.gameObject.CompareTag("Enemy2"))
        {
            lives -=1;
            Die2();
            livesText.text = "x" +lives.ToString();
            if(lives == 0){
                lives = 5;
                PlayerPrefs.SetInt("livesText", lives);
            }
            
            
        }

        
                
    }

    
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("TrapBox") )
        {
            Die();
            PlayerPrefs.SetInt("livesText", lives);
            livesText.text = "x" +lives.ToString(); 
        }  

        if (other.gameObject.name == "Finish")
        {
            PlayerPrefs.SetInt("livesText", lives);
            livesText.text = "x" +lives.ToString(); 
                  
        }
    }

        
    public void Die()
    {        
        audioSource.PlayOneShot(deathClip);
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
        lives = 0;
        PlayerPrefs.SetInt("livesText", lives);
        livesText.text = "x" +lives.ToString(); 
    }

    public void Die2()
    {
        
        if (lives==0)
        {
            audioSource.PlayOneShot(deathClip);
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("death");
            
            lives = 0;
            PlayerPrefs.SetInt("livesText", lives);
            livesText.text = "x" +lives.ToString();
        }
        
        
        
        
    }

    private void RestartLevel()
    {
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene (sceneBuildIndex:5);
    }
}
