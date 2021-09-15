using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text minutos;
    public Text segundos;
    [SerializeField]
    private GameObject Clear, time;
    private Player Player;
    private int _minutos = 3;
    private float _segundos = 0;
    void Start()
    {
        Player = FindObjectOfType(typeof(Player)) as Player;
        Clear.SetActive(false);
        time.SetActive(true);
    }

    public IEnumerator Tempo()
    {
        while (_minutos > -1)
        {
            yield return new WaitForSeconds(1);
            if(_segundos > 0)
            {
                _segundos -= 1;
                segundos.text = _segundos.ToString();
            }
            if(_segundos == 0)
            {
                _minutos--;
                minutos.text = _minutos.ToString();
                _segundos = 59;
                segundos.text = _segundos.ToString();
                
            }
            if(_minutos == -1)
            {
                Player.enabled = false;
                Player.Win = true;
                Time.timeScale = 0;
                Player.audioSource.volume = 0;
                time.SetActive(false);
                Clear.SetActive(true);
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;                
            }
        }
        
    }
}
