using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cabeça : MonoBehaviour
{
    public Animator Anime;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void FixedUpdate()
    {

    }



    public void OnTriggerEnter2D(Collider2D col)
    {

            if(col.gameObject.tag == "Player")
            {   
                Anime.SetBool("Atack",true);              
            }else
            {
                Anime.SetBool("Atack",false);
            }
            
    }
    public void OnTriggerExit2D(Collider2D col)
    {

            if(col.gameObject.tag == "Player")
            {   
                Anime.SetBool("Atack",false);           
            }
            
    }
}
