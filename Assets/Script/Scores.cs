using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Scores : MonoBehaviour
{

    public int score, muni;
    public Text Pontuacao, Municao;
    private Player Player;
    private Controller Controller;
    void Start()
    {
        Controller=  FindObjectOfType(typeof(Controller)) as Controller;
        Player = FindObjectOfType(typeof(Player)) as Player;
    }

    void Update()
    {
        Pontuacao.text = score.ToString();
        Municao.text = muni.ToString();
        Win();
    }
    public void Win()
    {
        if(score == 5)
        {
            Player.enabled=false;
            Player.audioSource.volume = 0;
            Time.timeScale = 0;
            Controller.Complete.SetActive(true);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }
}
