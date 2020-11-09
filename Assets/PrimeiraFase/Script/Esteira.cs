using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Esteira : MonoBehaviour
{
    public Vector3 m_Axis = Vector3.forward;
    public float motorDaEsteira = 0.3f;
    public bool temFilho = false;
    private List<JogadorScript> m_Characters = new List<JogadorScript>();


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<JogadorScript>().deslizador = motorDaEsteira;
        }
    }


    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<JogadorScript>().deslizador = motorDaEsteira * 0;
        }
    }

    private void Update()
    {

    }
}