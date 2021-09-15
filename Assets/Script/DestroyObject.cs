using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DestroyObject : MonoBehaviour
{
    public float destroyTime;
    private SpriteRenderer img;
    
    void Start()
    {
        img = GetComponent<SpriteRenderer>();
        StartCoroutine(Finishing());
    }
    void Update()
    {

    }

    IEnumerator Finishing()
    {
        yield return new WaitForSeconds(destroyTime);
        img.enabled = false;
        yield return new WaitForSeconds(0.3f);
        img.enabled = true;
        yield return new WaitForSeconds(0.3f);
        img.enabled = false;
        yield return new WaitForSeconds(0.3f);
        img.enabled = true;
        yield return new WaitForSeconds(0.3f);
        img.enabled = false;
        yield return new WaitForSeconds(0.3f);
        img.enabled = true;
        yield return new WaitForSeconds(0.3f);
        img.enabled = false;
        yield return new WaitForSeconds(0.3f);
        Destroy(this.gameObject);
    }

    
}
