using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScreen : MonoBehaviour
{
    void Start()
    {
        
    }


   public void Jogar(string P)
    {
        SceneManager.LoadScene(P); 
    }

    public void fecharJogo()
    {
        Application.Quit();
    }
}
