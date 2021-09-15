using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buff : MonoBehaviour
{
    public GameObject DropShoot;
    public GameObject Explosao;
    public GameObject Fuel;
    public GameObject Shield;
    public GameObject Fast;
    private AudioController AudioController;
    
    void Start()
    {
        AudioController = FindObjectOfType(typeof(AudioController)) as AudioController;
    }

    
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player")
        { 
            Destroy(this.gameObject);
            AudioController.PlaySounds(sound.PowerUp);
        }
        else if(col.gameObject.tag == "bullet" || col.gameObject.tag == "SuperBullet" ||col.gameObject.tag == "asteroidG")
        {
            Destroy(this.gameObject);
            GameObject prefab = Instantiate(Explosao) as GameObject;
            prefab.transform.position = transform.position;
            AudioController.PlaySounds(sound.Destroy);   
        }
    }
}
