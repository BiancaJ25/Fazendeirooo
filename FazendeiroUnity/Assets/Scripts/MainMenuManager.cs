using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{

    public void Jogar()
    {
        SceneManager.LoadScene("Level1");
    }
    public void Backmenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void SairJogo()
    {
        Application.Quit();
    }
}
