using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificadorEstaNaPlataforma : MonoBehaviour
{
    public bool EstaNaPlataforma = false;
    private void Start()
    {
        EstaNaPlataforma = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) 
        {
            EstaNaPlataforma = true;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EstaNaPlataforma = true;
        }
    }
}
