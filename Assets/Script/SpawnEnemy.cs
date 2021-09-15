using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundary
{
    public float xMin, xMax, yMin, yMax;
}

public class SpawnEnemy : MonoBehaviour
{
    public Boundary boundary;
    private bool gameOver = false;
    private Player Player;
    public GameObject enemy;
    private Falas Falas;

    void Start()
    {
        Player= FindObjectOfType(typeof(Player)) as Player;
        Falas = FindObjectOfType(typeof(Falas)) as Falas;
        StartCoroutine(PLEASE());
    }
    void Update()
    {
        if(Player.GOver == true || Player.Win == true)
        {
            gameOver = true;
        }
    }
    IEnumerator PLEASE()
    {
        while(Falas.count != 7)
        {
            yield return new WaitForSeconds(0);

        }
        
        StartCoroutine(Spawn());
        
        
    }
    public IEnumerator Spawn()
    {
        while (!gameOver)
        {
            yield return new WaitForSeconds(Random.Range(1, 2));
            Vector3 spawnPosition = new Vector3(Random.Range(boundary.xMin, boundary.xMax), boundary.yMin, 0);
            Instantiate(enemy, spawnPosition, Quaternion.identity);
        }
    }
}
