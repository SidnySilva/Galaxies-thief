using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CristalSpawner : MonoBehaviour
{
    private float time;
    [SerializeField]
    private  Transform Spawn;
    [SerializeField]
    private GameObject[] Crystal;
    public bool StopSpawning;
    public int quantia;
    private Cristal Cristal;
    void Start()
    {
        Cristal = FindObjectOfType(typeof(Cristal)) as Cristal;
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
            if(quantia == 5)
            {
                Vector3 P1 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
                Vector3 P2 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
                Vector3 P3 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
                Vector3 P4 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
                Vector3 P5 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
                Instantiate(Crystal[0], P1, Quaternion.identity);
                Instantiate(Crystal[1], P2, Quaternion.identity);
                Instantiate(Crystal[2], P3, Quaternion.identity);
                Instantiate(Crystal[3], P4, Quaternion.identity);
                Instantiate(Crystal[4], P5, Quaternion.identity);
                yield return new WaitForSeconds(25);
            }
            else if(quantia == 4)
            {
                Vector3 P1 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
                Vector3 P2 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
                Vector3 P3 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
                Vector3 P4 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
                Instantiate(Crystal[0], P1, Quaternion.identity);
                Instantiate(Crystal[1], P2, Quaternion.identity);
                Instantiate(Crystal[2], P3, Quaternion.identity);
                Instantiate(Crystal[3], P4, Quaternion.identity);
                yield return new WaitForSeconds(25);
            }
            else if(quantia == 3)
            {
                Vector3 P1 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
                Vector3 P2 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
                Vector3 P3 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
                Instantiate(Crystal[0], P1, Quaternion.identity);
                Instantiate(Crystal[1], P2, Quaternion.identity);
                Instantiate(Crystal[2], P3, Quaternion.identity);
                yield return new WaitForSeconds(25);
            }
            else if(quantia == 2)
            {
                Vector3 P1 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
                Vector3 P2 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
                Instantiate(Crystal[0], P1, Quaternion.identity);
                Instantiate(Crystal[1], P2, Quaternion.identity);
                yield return new WaitForSeconds(25);
            }
            else if(quantia == 1)
            {
                Vector3 P1 = new Vector3(Random.Range(-30, 30),Random.Range(-30, 30),0);
                Instantiate(Crystal[0], P1, Quaternion.identity);
                yield return new WaitForSeconds(25);
            }
        }   
    }
}
