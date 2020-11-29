using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditosSubir : MonoBehaviour
{
    public float velocidade = 1.0f;
    public bool podeSubir = true;
    void Update()
    {
        if (podeSubir)
        {
            transform.Translate(new Vector2(0, velocidade * Time.deltaTime));
        }
        else 
        {
            transform.Translate(new Vector2(0,0)*Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limite")) 
        {
            podeSubir = false;
        }
    }
}
