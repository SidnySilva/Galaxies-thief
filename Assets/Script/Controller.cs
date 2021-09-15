using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    private Falas Falas;
    private Life Life;
    //private Sounds Sounds;
    private Spawner Spawner;
    private Camera Camera;
    private SpawnEnemy SpawnEnemy;
    private Timer Timer;
    private Player Player;
    private Buff Buff;
    private Scores Scores;
    private Bullet Bullet;
    private Body Body;
    private CristalSpawner CristalSpawner;
    private Asteroid Asteroid;
    public GameObject Over, Complete, Stop, story, Boss, parabens;

    
    void Start()
    {
        Time.timeScale = 1;
        Camera = FindObjectOfType(typeof(Camera)) as Camera;
        Body = FindObjectOfType(typeof(Body)) as Body;
        SpawnEnemy = FindObjectOfType (typeof(SpawnEnemy))  as SpawnEnemy;
        Timer = FindObjectOfType (typeof(Timer))  as Timer;
        Player = FindObjectOfType(typeof(Player)) as Player;
        Falas = FindObjectOfType(typeof(Falas)) as Falas;
        Life = FindObjectOfType(typeof(Life)) as Life;
        Buff = FindObjectOfType(typeof(Buff)) as Buff;
        CristalSpawner = FindObjectOfType(typeof(CristalSpawner)) as CristalSpawner;
        Scores = FindObjectOfType(typeof(Scores)) as Scores;
        Spawner = FindObjectOfType(typeof(Spawner)) as Spawner;
        Asteroid =FindObjectOfType(typeof(Asteroid)) as Asteroid;


        Spawner.enabled = false;
        CristalSpawner.enabled = false;    
        Boss.SetActive(false);
        Over.SetActive(false);
        Stop.SetActive(false);
        Complete.SetActive(false);

    }
    void Update()
    {
        GameOver();
        Pause();
        fim();
    }
    
    public void Go()
    {
        StartCoroutine(Timer.Tempo());
        Player.enabled = true;
        SpawnEnemy.enabled = true;
        Falas.Texto.enabled = false;
        Timer.enabled = true;
        StartCoroutine(Player.Gas());
    }
    public void Go2()
    {
        Player.enabled = true;
        Spawner.enabled = true;
        Falas.Texto.enabled = false;
        CristalSpawner.enabled = true;
        Spawner.enabled = true;
        StartCoroutine(Player.Gas());
    }
    public void Go3()
    {
        Vector3 P = new Vector3(Player.transform.position.x, Player.transform.position.y, transform.position.z);
        Camera.transform.position = P;
        Player.enabled = true;
        Spawner.enabled = true;
        Falas.Texto.enabled = false;
        CristalSpawner.enabled = true;
        Spawner.enabled = true;
    }
    public void Continue()
    {     
        Time.timeScale = 1;
        Stop.SetActive(false);    
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void GameOver()
    {
        if(Player.GOver == true)
        {
            Over.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
    void Pause()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && Player.GOver == false || Input.GetKeyDown(KeyCode.Escape) && Player.Win == false)
        {
            Time.timeScale = 0;
            Stop.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
            
    }
    public void fim()
    {
        GameObject Boss = GameObject.Find("Cabeca");
        if(Boss==null && Player.cenaAtual == "Fase3")
        {
            Cursor.lockState = CursorLockMode.None;
            Player.enabled= false;
            Cursor.visible = true;
            parabens.SetActive(true);
            
            Player.audioSource.volume = 0;
        }
    }
}
