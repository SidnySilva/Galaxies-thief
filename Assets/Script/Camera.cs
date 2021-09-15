using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{

    private Player Player;
    [SerializeField]
    public float speed;
    void Start()
    {
        Player = FindObjectOfType(typeof(Player)) as Player;
    }


    void Update()
    {
        speed = Player.speed;
        float step = speed*Time.deltaTime;
        Vector3 P = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, P,step);
    }
}
