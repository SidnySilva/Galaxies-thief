using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public int effect;
    
    public void OnCollisionEnter2D(Collision2D col)
    {
        Player player = col.gameObject.GetComponent<Player>();
        if (player != null)
        {
            effect = 1;
            player.SetItemEffect(effect);
            Destroy(gameObject);
        }
    }

}

