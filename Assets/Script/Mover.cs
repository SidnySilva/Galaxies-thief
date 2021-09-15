using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float speed;
    
    public bool isDestroyer;
    
    private Rigidbody2D rdb;
    void Start()
    {
        rdb = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        rdb.velocity = transform.up * speed;
        
    }
    void OnBecameInvisible()
    {
        if(isDestroyer)
        Destroy(this.gameObject);
    }
}
