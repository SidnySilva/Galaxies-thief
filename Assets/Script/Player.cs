using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public string cenaAtual;
    public AudioSource audioSource;
    [HideInInspector]
    public bool playM, ShieldLig = false;
    private Rigidbody2D rdb;
    [SerializeField]
    private GameObject Bullet, SBullet, Explosao, Shield, otherBullet;
    public GameObject Jail;
    public Transform spawn;
    public Transform spawnL;
    public Transform BarraComb, pulso;
    private Animator anima;
    public Animator PulsoAnime;

    public int life = 3;
    public int speed = 4;
    public int Carga = 0;
    [SerializeField]
    private int fase;
    public float combMax;
    public float combustivel;
    private float combPerca;
    private float rotateR = -0.9f, rotateL = 0.9f;
    public bool GOver, Win;

    private Buff Buff;
    private Scores Scores;
    private Life Life;
    private AudioController AudioController;
    void Start()
    {
        cenaAtual = SceneManager.GetActiveScene().name;
        pulso.localScale = new Vector3(0, 0, 0);
        Win = false;
        GOver = false;
        speed = 4;
        life = 3;

        AudioController = FindObjectOfType(typeof(AudioController)) as AudioController;
        audioSource = GetComponent<AudioSource>();
        Life = FindObjectOfType(typeof(Life)) as Life;
        Scores = FindObjectOfType(typeof(Scores)) as Scores;
        Buff = FindObjectOfType(typeof(Buff)) as Buff;
        rdb = GetComponent<Rigidbody2D>();

        combustivel = combMax;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        enabled = false;
        anima = GetComponent<Animator>();
        Jail.SetActive(true);
        //Shield.SetActive(false);
    }
    void Update()
    {
        Shield.SetActive(ShieldLig);
        Move();
        Shoot();
    }
    void Move()
    {
        if (combustivel > 0)
        {
            var h = Input.GetAxisRaw("Horizontal");
            var v = Input.GetAxisRaw("Vertical");
            Vector3 D = new Vector3(0, v, 0);
            transform.Translate(D * speed * Time.deltaTime);

            if (fase == 1)
            {
                transform.position = new Vector2(Mathf.Clamp(transform.position.x, -20f, 20f), Mathf.Clamp(transform.position.y, -20f, 20f));
            }
            if (fase == 2)
            {
                transform.position = new Vector2(Mathf.Clamp(transform.position.x, -30, 30), Mathf.Clamp(transform.position.y, -30, 30));
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                pulso.localScale = new Vector3(1, 1, 1);
            }

            if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.UpArrow))
            {
                pulso.localScale = new Vector3(0, 0, 0);
            }

            if (h == 1)
            {
                transform.Rotate(new Vector3(0, 0, rotateR));
            }
            else if (h == -1)
            {
                transform.Rotate(new Vector3(0, 0, rotateL));
            }
        }
        else
        {
            GOver = true;
            audioSource.enabled = false;
        }
    }
    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (cenaAtual == "Fase3")
            {
                Instantiate(otherBullet, spawn.position, spawn.rotation);
                Instantiate(otherBullet, spawnL.position, spawnL.rotation);
            }

            else
            {
                Instantiate(Bullet, spawn.position, spawn.rotation);
                Instantiate(Bullet, spawnL.position, spawnL.rotation);
            }
            AudioController.PlaySounds(sound.Shoot);
        }
        else if (Input.GetKeyDown(KeyCode.O) && Carga > 0)
        {
            Instantiate(SBullet, spawn.position, spawn.rotation);
            AudioController.PlaySounds(sound.SShoot);
            Scores.muni--;
            Carga--;
        }
    }


    void Over()
    {
        Vector3 theScale = BarraComb.localScale;
        theScale.x = 1;
        combustivel = 1;
        BarraComb.localScale = theScale;
    }
    void CombUP()
    {
        combustivel += 20;
        Vector3 theScale = BarraComb.localScale;
        theScale.x += 20;
        BarraComb.localScale = theScale;
        if (combustivel >= 100)
        {
            combustivel = 100;
            theScale = BarraComb.localScale;
            theScale.x = 100;
            BarraComb.localScale = theScale;
        }
    }
    public void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "BuffT")
        {
            Carga++;
            Scores.muni++;
        }
        if (col.gameObject.tag == "BuffF")
        {
            CombUP();
        }
        if (col.gameObject.tag == "BuffS")
        {
            StartCoroutine(ShieldOn());
        }
        if (col.gameObject.tag == "BuffSpeed")
        {

            speed = 10;
            PulsoAnime.SetBool("Fire", true);
            anima.SetBool("Vel", true);
            StartCoroutine(DuracaoSpeed());
        }
        if (col.gameObject.tag == "Enemy" || col.gameObject.layer == 6)
        {
            Hit();
        }

    }
    public void Hit()
    {

        life--;
        Life.UpdateLives(life);
        if (life < 3 && life > 0)
        {
            StartCoroutine(LifeRecover());
        }
        if (life <= 0 && ShieldLig == false)
        {
            GameObject prefab = Instantiate(Explosao) as GameObject;
            prefab.transform.position = transform.position;
            Destroy(this.gameObject);
            Destroy(Explosao, (2));
            GOver = true;
            audioSource.enabled = false;
            Over();

        }
    }

    IEnumerator DuracaoSpeed()
    {
        yield return new WaitForSeconds(6);
        PulsoAnime.SetBool("Fire", false);
        anima.SetBool("Vel", false);
        speed = 4;
    }

    IEnumerator LifeRecover()
    {
        yield return new WaitForSeconds(10);
        life++;
        Life.UpdateLives(life);
    }
    IEnumerator ShieldOn()
    {
        ShieldLig = true;
        yield return new WaitForSeconds(10);
        ShieldLig = false;
    }
    public IEnumerator Gas()
    {
        while (combustivel > 0)
        {
            yield return new WaitForSeconds(1);
            combPerca = 1;
            Vector3 theScale = BarraComb.localScale;
            theScale.x -= combPerca;
            combustivel -= combPerca;
            BarraComb.localScale = theScale;
        }
    }
    public void SetItemEffect(int effect)
    {
        if (effect == 1)
        {
            StartCoroutine("Speed");
        }
    }
}
