using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body : MonoBehaviour
{

    public GameObject Ca, 
                Part1,
                Part2,
                Part3,
                Part4,
                Part5;
    public bool Cab=false, 
                P1=false,
                P2=false,
                P3=false,
                P4=false,
                P5=false;

    public GameObject Follow, win;
    public int Life;
    public float Speed= 3;
    private bool finish;
    private Vector2 movement;
    private Rigidbody2D enemyRb;
    public Animator anime;
    private Player Player;
    private Controller Controller;

    public static Body instance;
    void Start()
    {
        Player = FindObjectOfType(typeof(Player)) as Player;
        Controller = FindObjectOfType(typeof(Controller)) as Controller;
        instance = this;
        enemyRb = GetComponent<Rigidbody2D>();
        win.SetActive(false);
        Time.timeScale = 1;
        finish = false;
    }

    void Update()
    {
        
        Dano();
        transform.position = Vector2.MoveTowards(transform.position, Follow.transform.position, Speed*Time.deltaTime);
        Vector3 di = Follow.transform.position - transform.position;
        float angle = Mathf.Atan2(di.y, di.x) * Mathf.Rad2Deg;
        enemyRb.rotation = angle;
        di.Normalize();
        movement = di;
    }
    void moveEnemy(Vector2 direction)
    {
        enemyRb.MovePosition((Vector2)transform.position+(direction*Speed*Time.deltaTime));
    }
    private void FixedUpdate()
    {
        
        moveEnemy(movement);
    }

    public void OnTriggerEnter2D(Collider2D col)
    {

        if(col.gameObject.tag == "bullet")
        {   

            if(P5 == false && Bullet.instance.Pa5 == true)
            {
                Life--;
                if(Life <= 0)
                {
                    Destroy(Part5);
                }   
            }

            if(P5 == true && Bullet.instance.Pa4 == true)
            {
                Life--;
                if(Life <= 0)
                {
                    Destroy(Part4);
                }  
            }
            if(P4 == true&& Bullet.instance.Pa3 == true)
            {
                Life--;
                if(Life <= 0)
                {
                    Destroy(Part3);
                }  
            }
            if(P3 == true&& Bullet.instance.Pa2 == true)
            {
                Life--;
                if(Life <= 0)
                {
                    Destroy(Part2);
                }  
            }
            if(P2== true&& Bullet.instance.Pa1 == true)
            {
                Life--;
                if(Life <= 0)
                {
                    Destroy(Part1);
                }  
            }
            if(P1== true)
            {
                Life--;
                if(Life <= 0)
                {                
                    Destroy(Ca);                   
                    finish = true;
                }  
            }
        }
        else if(col.gameObject.tag == "SuperBullet")
        {
            if(P5 == false && Bullet.instance.Pa5 == true)
            {
                Destroy(Part5);
            }

            if(P5 == true && Bullet.instance.Pa4 == true)
            {
                Destroy(Part4);      
            }
            if(P4 == true&& Bullet.instance.Pa3 == true)
            {
                Destroy(Part3);               
            }
            if(P3 == true&& Bullet.instance.Pa2 == true)
            {
                Destroy(Part2);              
            }
            if(P2== true&& Bullet.instance.Pa1 == true)
            {
               Destroy(Part1);
            }
            if(P1== true)
            {              
                Destroy(Ca);                   
                finish = true; 
            }
        }
            
    }

    public void Dano()
    {
        if(Part5==null)
        {
            P5 = true;
        }
        if(Part4==null)
        {
            P4 = true;
        }
        if(Part3==null)
        {
            P3 = true;
        }
        if(Part2==null)
        {
            P2 = true;
        }
        if(Part1==null)
        {
            P1 = true;
        }
    }
}
