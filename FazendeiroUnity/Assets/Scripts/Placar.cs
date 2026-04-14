using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class Placar : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI TXT_PN;

    private int pontos = 0;

    public void AddPontos(int valor)
    {
        pontos += valor;
        if(TXT_PN != null)
        {
            TXT_PN.text = "" + pontos;
        }
    }
}
