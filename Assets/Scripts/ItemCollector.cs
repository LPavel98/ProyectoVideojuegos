using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public AudioClip collectorClip;
    private int cherries; /*= 0*/
    private int record;

    [SerializeField] private Text cherriesText;
    [SerializeField] private Text puntajeRecord;//

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        puntajeRecord.text = PlayerPrefs.GetInt("PuntajeRecord", 0).ToString();
        cherries = PlayerPrefs.GetInt("cherriesText", 0);
        cherriesText.text = "x"+cherries.ToString();
       
        
    }

    private void OnCollisionEnter2D(Collision2D other) {
        
        if (other.gameObject.tag == "Enemy" || other.gameObject.tag == "Enemy2"||other.gameObject.tag == "Trap"){
            cherries = 0;
            PlayerPrefs.SetInt("cherriesText", cherries);
            cherriesText.text = "x" +cherries.ToString(); 
            
        }
        
        
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            
            audioSource.PlayOneShot(collectorClip);
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "x" + cherries;

            if (cherries > PlayerPrefs.GetInt("PuntajeRecord", cherries))
            {
                PlayerPrefs.SetInt("PuntajeRecord", cherries);
                puntajeRecord.text = cherries.ToString();
            }
                                 
        }

        if (collision.gameObject.name == "Finish")
        {
            Debug.Log("Tocó la bandera");
           //PlayerPrefs.SetInt("CherriesRecord", cherries);
            PlayerPrefs.SetInt("cherriesText", cherries);
                cherriesText.text = "x"+cherries.ToString();
                
            // cherries =  cherries;
            // cherriesText.text = "xxx" + cherries;

         
        }
    }

    
    
}
