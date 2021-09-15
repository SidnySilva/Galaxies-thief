using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public GameObject[] ItensDrop;
     public GameObject explode;
    private float rotateSpeed;
    private int chanceToItemDrop;
    private Player Player;
    
    void Start()
    {
        Player = FindObjectOfType(typeof(Player)) as Player;
        rotateSpeed = Random.Range(-10 , 10);
    }

    void FixedUpdate()
    {
        transform.Rotate(new Vector3(0,0,rotateSpeed)* Time.deltaTime);
        if(Player.Win == true)
        {
            Destroy(this.gameObject);
            GameObject pref = Instantiate(explode) as GameObject;
            pref.transform.position = transform.position;
        }
    }
    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "asteroidG" || col.gameObject.tag =="bullet")
        {
            chanceToItemDrop = Random.Range(0, 50);
            if(chanceToItemDrop > 30 )
            {
                Instantiate(ItensDrop[Random.Range(0, ItensDrop.Length)], transform.position, Quaternion.identity);
            }
            chanceToItemDrop = 0;
            Instantiate(explode, transform.position, Quaternion.identity);
            AudioController.PlaySounds(sound.Destroy);
            Destroy(this.gameObject);
        }
        if(col.gameObject.tag == "ShieldP")
        {
            Destroy(this.gameObject);
            GameObject pref = Instantiate(explode) as GameObject;
            pref.transform.position = transform.position;
            Destroy(explode,(1));
            AudioController.PlaySounds(sound.Destroy);
        }
        if(col.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Instantiate(explode, transform.position, Quaternion.identity);
            AudioController.PlaySounds(sound.Destroy);
            Player.Hit();
        }
    }
}
