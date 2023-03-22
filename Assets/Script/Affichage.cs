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
    public GameObject FenetreMenu;
    public Text TextWin;

    private void Awake()
    {
        openMenu();
        GameObject t_player = GameObject.Find("Player");
        m_Player = t_player.GetComponent<PlayerController>();
    }

    public void Update()
    {
        texte.text = "Points : " + m_Player.Points + "\n" + "Vies : " + m_Player.Vies;
    }

    public void openMenu()
    {
        FenetreMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void closeMenu()
    {
        FenetreMenu.SetActive(false);
        m_Player.ResetGame();
    }

    public void openGameOver()
    {
        FenetreGameOver.SetActive(true);
        Time.timeScale = 0;
    }

    public void closeGameOver()
    {
        FenetreGameOver.SetActive(false);
        m_Player.ResetGame();
    }

    public void openVictoire()
    {
        TextWin.text = "Victoire ! Points : " + m_Player.Points;
        FenetreVictoire.SetActive(true);
        Time.timeScale = 0;
    }

    public void closeVictoire()
    {
        FenetreVictoire.SetActive(false);
        m_Player.ResetGame();
    }
}
