using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private string nomeLVLjogo;
    [SerializeField] private GameObject painelMainMenu;

    public void Jogar()
    {
        SceneManager.LoadScene(nomeLVLjogo);
    }
    public void SairJogo()
    {
        Application.Quit();
    }
}
