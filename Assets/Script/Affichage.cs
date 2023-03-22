using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Affichage : MonoBehaviour
{
    public Text texte;
    private PlayerController m_Player;
    public GameObject FenetreGameOver;
    public GameObject FenetreVictoire;

    private void Awake()
    {
        GameObject t_player = GameObject.Find("Player");
        m_Player = t_player.GetComponent<PlayerController>();
    }

    public void Update()
    {
        texte.text = "Points : " + m_Player.Points + "\n" + "Vies : " + m_Player.Vies;
    }

    public void openGameOver()
    {
        FenetreGameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void closeGameOver()
    {
        FenetreGameOver.SetActive(false);
        m_Player.Vies = 3;
        m_Player.Points = 0;
        Time.timeScale = 1;
    }

    public void openVictoire()
    {
        FenetreVictoire.SetActive(true);
        Time.timeScale = 0;
    }

    public void closeVictoire()
    {
        FenetreVictoire.SetActive(false);
        m_Player.Vies = 3;
        m_Player.Points = 0;
        Time.timeScale = 1;
    }
}