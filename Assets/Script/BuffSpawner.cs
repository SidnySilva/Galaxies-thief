using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffSpawner : MonoBehaviour
{
    private float time;
    [SerializeField]
    private  Transform Spawn;
    [SerializeField]
    private GameObject[] Buffs;
    public bool StopSpawning;
    void Start()
    {
        StartCoroutine(Timer());
    }

    
    void Update()
    {

    }

    IEnumerator Timer()
    {
        while(!StopSpawning)
        {
            yield return new WaitForSeconds(2);
            Vector3 P1 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
            Vector3 P2 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
            Vector3 P3 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
            Vector3 P4 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
            Vector3 P5 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
            Instantiate(Buffs[0], P1, Quaternion.identity);
            Instantiate(Buffs[1], P2, Quaternion.identity);
            Instantiate(Buffs[2], P3, Quaternion.identity);
            Instantiate(Buffs[3], P4, Quaternion.identity);
            yield return new WaitForSeconds(5);
        }   
    }
}

