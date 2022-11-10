using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    public AudioClip collectorClip;
    private int cherries = 0;
    private int record;

    [SerializeField] private Text cherriesText;
    [SerializeField] private Text puntajeRecord;//

    private AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        puntajeRecord.text = PlayerPrefs.GetInt("PuntajeRecord", 0).ToString();
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Cherry"))
        {
            audioSource.PlayOneShot(collectorClip);
            //collectionSoundEffect.Play();
            Destroy(collision.gameObject);
            cherries++;
            cherriesText.text = "x" + cherries;

            if (cherries > PlayerPrefs.GetInt("PuntajeRecord", cherries))
            {
                PlayerPrefs.SetInt("PuntajeRecord", cherries);
                puntajeRecord.text = cherries.ToString();
            }
                                 
        }
    }
    
}
