using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public bool Cabe=false, 
                Pa1=false,
                Pa2=false,
                Pa3=false,
                Pa4=false,
                Pa5=false;

    private float speed = 20;
    private Rigidbody2D rdb;
  
    public GameObject bullet;

    public static Bullet instance;
    void Start()
    {
        instance = this;
        rdb = GetComponent<Rigidbody2D>();    
        rdb.velocity = transform.up * speed;
    }
    
    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnCollisionEnter2D(Collision2D col) 
    {
        if(tag == "bullet")
        {
            if(col.gameObject.tag == "asteroidP" || col.gameObject.tag == "asteroidG" ||
            col.gameObject.tag == "Buff" || col.gameObject.tag == "cristal"||
            col.gameObject.tag == "Enemy"||col.gameObject.tag == "Part1"||col.gameObject.tag == "Part2"||
            col.gameObject.tag == "Part3"||col.gameObject.tag == "Part4"||col.gameObject.tag == "Part5")
            {
                Destroy(this.gameObject);
            }
        }
        else if(tag == "SuperBullet")
        {
            if(col.gameObject.tag == "cristal")
            {
                Destroy(bullet.gameObject);
                
            }
        }
    }

     public void OnTriggerEnter2D(Collider2D col)
    {
              if(col.gameObject.tag=="Enemy"||col.gameObject.tag=="Meteoro"||
              col.gameObject.tag=="Part5"||col.gameObject.tag=="Part4"||col.gameObject.tag=="Part3"||
              col.gameObject.tag=="Part2"||col.gameObject.tag=="Part1")
              {
                Destroy(this.gameObject);
                
              }
              if(col.gameObject.tag == "Part5")
              {
                Pa5 = true;
              }
              if(col.gameObject.tag == "Part4")
              {
                Pa4 = true;
              }
              if(col.gameObject.tag == "Part3")
              {
                Pa3 = true;
              }
              if(col.gameObject.tag == "Part2")
              {
                Pa2 = true;
              }
              if(col.gameObject.tag == "Part1")
              {
                Pa1 = true;
              }
              if(col.gameObject.tag == "Cabeça")
              {
                Cabe = true;
              }
    }
              
}
