using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cam : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float speed = 0.9f;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }
    void FixedUpdate()
    {
        Vector3 startPosition = new Vector3(target.position.x, target.position.y, -1f);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, startPosition, speed);
        transform.position = smoothPosition;        
    }
}
