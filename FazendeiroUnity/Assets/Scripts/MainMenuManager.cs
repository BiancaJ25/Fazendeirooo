using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string nomeLVLjogo;
    [SerializeField] private GameObject painelMainMenu;
    [SerializeField] private GameObject painelOpcoes;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeLVLjogo);
    }
    public void AbrirOpcoes()
    {
        painelMainMenu.SetActive(false);
        painelOpcoes.SetActive(true);
    }
    public void FecharOpcoes()
    {
        painelOpcoes.SetActive(false);
        painelMainMenu.SetActive(true);
    }
    public void SairJogo()
    {
        Application.Quit();
    }
}
