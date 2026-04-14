using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DetectCollisions : MonoBehaviour
{
    public int pontos = 0;
    Placar placar;
    
    void Start()
    {
        placar = GameObject.Find("Placar").GetComponent<Placar>();
    }

    private void OnTriggerEnter(Collider other)
    {
        placar.AddPontos(1);
        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}
