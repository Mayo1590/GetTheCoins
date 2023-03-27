using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //private Coin m_Coin;
    public GameObject Coins;
    //déplacements
    private Animator animateur;
    public Rigidbody2D Rb;
    private SpriteRenderer sr;

    private bool grounded;
    public Transform GroundCheck;
    private float rayonGround = 0.2f;
    public LayerMask GroundLayer;

    public float VitesseMax = 10f;
    public bool VersDroite = true;

    private const float JUMP_FORCE = 600f;

    private bool userJump;
    private uint nbrJump = 0;

    //vies et points
    public float Vies = 3;
    private float timerImmunite;
    public uint Points;
    private Affichage m_Affichage;

    //win
    public GameObject CheckpointWin;
    public GameObject CheckpointPlayerStart;
    public GameObject Fell;

    private bool m_fell = false;

    public void Awake()
    {
        animateur = GetComponent<Animator>();
        Rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();

        GameObject a_affichage = GameObject.Find("Canvas");
        m_Affichage = a_affichage.GetComponent<Affichage>();

    }

    private void Update()
    {
        //deplacements
        if (!userJump)
            userJump = Input.GetButtonDown("Jump");

        //pour la vie
        timerImmunite -= Time.deltaTime;
    }

    private void FixedUpdate()
    {
        Vector2 positionPied = new Vector2(GroundCheck.position.x, GroundCheck.position.y);
        grounded = Physics2D.OverlapCircle(positionPied, rayonGround, GroundLayer.value);

        animateur.SetBool("Grounded", grounded);

        if (userJump && grounded)
        {
            Rb.AddForce(Vector2.up * JUMP_FORCE);
            nbrJump++;
            userJump = false;
        }
        else if (grounded)
            nbrJump = 0;

        if (userJump && nbrJump == 1 && !grounded)
        {
            Rb.AddForce(Vector2.up * JUMP_FORCE);
            nbrJump = 0;
            userJump = false;
        }

        

        float movement = Input.GetAxis("Horizontal");

        animateur.SetFloat("Speed", Mathf.Abs(movement));

        if (movement < 0 && VersDroite)
            SetDirection(false);
        else if (movement > 0 && !VersDroite)
            SetDirection(true);

        Rb.velocity = new Vector2(movement * VitesseMax, Rb.velocity.y);
    }

    private void SetDirection(bool versDroite)
    {
        VersDroite = versDroite;
        sr.flipX = !versDroite;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //calcule de la vie
        if (timerImmunite < 0 && collision.gameObject.layer == LayerMask.NameToLayer("Ennemi"))
        {
            Vies--;
            timerImmunite = 1;   
        }

        //calcule des points
        if (collision.gameObject.layer == LayerMask.NameToLayer("Coin"))
        {
            Points++;
        }

        if (collision.gameObject.name == CheckpointWin.name)
        {
            m_Affichage.openVictoire();
        }

        if (collision.gameObject.name == Fell.gameObject.name)
        {
            m_fell = true;
            Rb.position = CheckpointPlayerStart.transform.position;
        }

        if (timerImmunite < 0 && m_fell)
        {
            timerImmunite = 1;
            Vies--;
            if (Points != 0)
            {
                Points--;
            }
            m_fell = false;
        }

        if (Vies == 0)
        {
            m_Affichage.openGameOver();
        }
    }

    public void ResetGame()
    {
        Rb.position = CheckpointPlayerStart.transform.position;
        Time.timeScale = 1;
        Vies = 3;
        Points = 0;
        //m_Coin.ResetCoins();
        /*var coins = Coins.GetComponentsInChildren<Transform>();
        Debug.Log(coins);
        foreach (var coin in coins)
        {
            Debug.Log(coin.gameObject);
            coin.gameObject.SetActive(true);
        }*/

        for (int i = 0; i < Coins.transform.childCount; i++)
        {
            Coins.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}
