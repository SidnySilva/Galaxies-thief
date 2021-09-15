using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Falas : MonoBehaviour
{
    
    private Controller Controller;
    private Player Player;
    private Scores Scores;
    private SpawnEnemy SpawnEnemy;
    public Text Texto;
    public string txt, txt2, txt3, txt4, txt5, txt6, txt7, txtwin;
    public float espera;
    public int count = 0;
    public bool fase1, fase2, fase3, fasefinal, Fim, Inicio, Intro;
    public GameObject go;
    private AudioController AudioController;

    void Start()
    {
        Time.timeScale = 1;
        AudioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        Controller = FindObjectOfType(typeof(Controller)) as Controller;
        SpawnEnemy = FindObjectOfType(typeof(SpawnEnemy)) as SpawnEnemy;
        Player = FindObjectOfType(typeof(Player)) as Player;
        Scores = FindObjectOfType(typeof(Scores)) as Scores;
        StartCoroutine("soletrar", txt);
        count=1;
        go.SetActive(false);
       
    }

    
    void Update()
    {
        Type();
        Skip();
    }

    public void Type()
    {
        if(count == 1 && Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("soletrar");
            count ++;
            StartCoroutine("soletrar", txt2);
            
        }
        else if(count == 2 && Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("soletrar");
            count ++;
            StartCoroutine("soletrar", txt3);
        }
        else if(count == 3 && Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("soletrar");
            count ++;
            StartCoroutine("soletrar", txt4);
        }
        else if(count == 4 && Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("soletrar");
            count ++;
            StartCoroutine("soletrar", txt5);
        }
        else if(count == 5 && Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("soletrar");
            count ++;
            StartCoroutine("soletrar", txt6);
        }
        else if(count == 6 && Input.GetKeyDown(KeyCode.Space))
        {
            StopCoroutine("soletrar");
            StartCoroutine("soletrar", txt7);
            count = 7;
        }
        // else if(Scores.score >= 100 && Texto == true)
        // {
        //     StartCoroutine("Winning", txtwin);
        // }  
    }
    void Skip()
    {
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            StopCoroutine("soletrar");
            Texto.text = "";
            count = 7;
            StartCoroutine("StartFase");
        }
    }
    IEnumerator soletrar(string texto)
    {
        if(count <= 7)
        {
            
            int letra = 0;
            Texto.text = "";
            while(letra <= texto.Length -1)
            {
                Texto.text += texto[letra];
                letra += 1;
                yield return new WaitForSeconds(espera);
                AudioController.PlaySounds(sound.Bip);
            }         
        }  
        if(count == 7)
        {
            StartCoroutine("StartFase");
        }
    }
    IEnumerator StartFase()
    {
        if(Intro == true && count==7)
        {
            yield return new WaitForSeconds(2);
            go.SetActive(true);
        }

        if(fase1 == true && count == 7)
        {
            yield return new WaitForSeconds(2);
            Controller.Go();
        }
        else if(fase2 == true && count == 7)
        {
            yield return new WaitForSeconds(2);
            Controller.Go2();
        }
        else if(fase3 == true && count == 7)
        {
            
            yield return new WaitForSeconds(2);
            Texto.enabled = false;
            Player.Jail.SetActive(false);
            StartCoroutine(Player.Gas());
            Controller.Go3();
        }
//         else if(Fim == true && count == 7)
//         {
//             yield return new WaitForSeconds(2);
//             W.SetActive(true);
//         }
            
     }
}
