using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cristal : MonoBehaviour
{
    private float timer;
    [SerializeField]
    private  GameObject Shield;
    [SerializeField]
    private SpriteRenderer img;
    private bool StopSpawning;
    private CristalSpawner CristalSpawner;
    private Scores Scores;
    private Fade Fade;
    private AudioController AudioController;
    private  bool ShieldOn;


    void Start()
    {
        AudioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        Fade = FindObjectOfType(typeof(Fade)) as Fade;
        Scores = FindObjectOfType(typeof(Scores)) as Scores;
        ShieldOn = true;
        CristalSpawner = FindObjectOfType(typeof(CristalSpawner)) as CristalSpawner;
        StartCoroutine(Timer());
    }

    
    void Update()
    {

    }

    IEnumerator Timer()
    {
        while(!StopSpawning)
        {
            yield return new WaitForSeconds(20);

            img.enabled = false;
            yield return new WaitForSeconds(0.5f);
            img.enabled = true;
            yield return new WaitForSeconds(0.5f);
            img.enabled = false;
            yield return new WaitForSeconds(0.5f);
            img.enabled = true;
            yield return new WaitForSeconds(0.5f);
            img.enabled = false;
            yield return new WaitForSeconds(0.5f);
            img.enabled = true;
            yield return new WaitForSeconds(0.5f);
            img.enabled = false;
            yield return new WaitForSeconds(0.5f);
            Destroy(this.gameObject);
        }   
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "SuperBullet")
        {
            Destroy(Shield.gameObject);
            ShieldOn = false;
        }
        if(col.gameObject.tag == "Player" && !ShieldOn)
        {
            Destroy(this.gameObject);
            
            AudioController.PlaySounds(sound.PowerUp);
            Scores.score++;
            CristalSpawner.quantia--;
        }
    }

}
