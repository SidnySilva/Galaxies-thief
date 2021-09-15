using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BG : MonoBehaviour
{
    public MeshRenderer mr;
    public float vel;
    GameObject Player;
    void Start()
    {
        Player = GameObject.Find("Player");
    }

    
    void Update()
    {
        if(Player.transform.position.x >0 ){
        mr.material.mainTextureOffset += new Vector2(-vel*Time.deltaTime,0);
        }
        if(Player.transform.position.x <0 ){
        mr.material.mainTextureOffset += new Vector2(vel*Time.deltaTime,0);
        }
        if(Player.transform.position.y >0 ){
        mr.material.mainTextureOffset += new Vector2(0,-vel*Time.deltaTime);
        }
        if(Player.transform.position.y <0 ){
        mr.material.mainTextureOffset += new Vector2(0,vel*Time.deltaTime);
        }
    }
}
