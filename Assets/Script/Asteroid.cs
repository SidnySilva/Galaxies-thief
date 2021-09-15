using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
    public Rigidbody2D rdb;
    private float speed=50, Rote;
    [SerializeField]
    private int sort;
    [SerializeField]
    private GameObject explode;
    private Player Player;
    private AudioController AudioController;
    private Spawner Spawner;
    private Buff Buff;
    void Start()
    {
        AudioController =FindObjectOfType(typeof(AudioController)) as AudioController;
        Spawner = FindObjectOfType(typeof(Spawner))as Spawner;
        Buff = FindObjectOfType(typeof(Buff))as Buff;
        Player = FindObjectOfType(typeof(Player))as Player;
        rdb = GetComponent<Rigidbody2D>();
        Move();
    }

    void Update()
    {
        if(Player.Win == true)
        {
            Destroy(this.gameObject);
            GameObject pref = Instantiate(explode) as GameObject;
            pref.transform.position = transform.position;
        }
    }
    void Move()
    {
        transform.Rotate(Vector3.forward * Rote * Time.deltaTime);
        float step = speed * Time.deltaTime;
        if(transform.position.y < 0)
        {
            rdb.AddForce(new Vector2(Random.Range(speed*-1, speed), speed));
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step);
        }
        else if(transform.position.y > 0)
        {
            rdb.AddForce(new Vector2(Random.Range(speed*-1, speed), speed*-1));
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step);
        }
        else if(transform.position.x < 0)
        { 
            rdb.AddForce(new Vector2(speed, Random.Range(speed*-1, speed)));
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step);
        }
        else if(transform.position.x > 0)
        {
            rdb.AddForce(new Vector2(speed*-1, Random.Range(speed*-1, speed)));
            transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, step);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
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
            GameObject pref = Instantiate(explode) as GameObject;
            pref.transform.position = transform.position;
            Destroy(explode,(1));
            AudioController.PlaySounds(sound.Destroy);
            Player.Hit();
        }
        
        if(col.gameObject.tag == "bullet" || col.gameObject.tag == "SuperBullet")
        {
            if(tag == "asteroidP")
            {
                Destroy(this.gameObject);
                GameObject pref = Instantiate(explode) as GameObject;
                pref.transform.position = transform.position;
                AudioController.PlaySounds(sound.Destroy);
                Destroy(explode,(1));
               
            }
            else
            {
                
                sort = Random.Range(0, 21);
                if(sort >= 9 && sort <=15)
                { 
                    GameObject Pref= Instantiate(Buff.Fuel)as GameObject;
                    Pref.transform.position = transform.position;
                }
                if(sort >= 0 && sort <=3)
                { 
                    GameObject Pref= Instantiate(Buff.Shield)as GameObject;
                    Pref.transform.position = transform.position;
                }
                if(sort >= 5 && sort <=8)
                { 
                    GameObject Pref= Instantiate(Buff.Fast)as GameObject;
                    Pref.transform.position = transform.position;
                }
                if(sort > 16 && sort <20)
                {
                    GameObject Pref= Instantiate(Buff.DropShoot)as GameObject;
                    Pref.transform.position = transform.position;
                }
                Destroy(this.gameObject);
                GameObject Prefab = Instantiate(Spawner.enemy[Random.Range(3,6)]) as GameObject;
                GameObject Prefab2 = Instantiate(Spawner.enemy[Random.Range(3,6)]) as GameObject;
                Prefab.transform.position = this.gameObject.transform.position;
                Prefab2.transform.position = this.gameObject.transform.position;
                GameObject pref = Instantiate(explode) as GameObject;
                pref.transform.position = transform.position;
                AudioController.PlaySounds(sound.Destroy);
                Destroy(explode,(1));
                
                
            }
        }
        

    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }
}
