using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Finish : MonoBehaviour
{
    public AudioClip finishClip;
    private AudioSource audioSource;
    private bool levelCompleted = false;

    private int nivel;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
                    
            levelCompleted = true;
            audioSource.PlayOneShot(finishClip);
            Invoke("CompleteLevel", 1f);
                     
        }
    }


    private void CompleteLevel()
    {
         SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
