using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{

    public GameObject[] enemy;
    
    public Transform[] spawn;
    private int sort;
    private bool StopSpawning;
    private Player Player;
    void Start()
    {
        Player = FindObjectOfType(typeof(Player)) as Player;
        StartCoroutine(spawnRoutine());
    }

    void Update()
    {
        if(Player.GOver == true || Player.Win == true)
        {
            StopSpawning = true;
        }
    }

    public IEnumerator spawnRoutine()
    {
        while(!StopSpawning)
        {
            GameObject Prefab = Instantiate(enemy[Random.Range(0,6)]) as GameObject;
            Prefab.transform.position = spawn[Random.Range(0,4)].position;
            yield return new WaitForSeconds(0.5f);          
        }   
    }

    
}
