using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levitacaoAgua : MonoBehaviour
{
    public float Velocidade = 2f;
    public bool podeSubir;

    private void Start()
    {
        podeSubir = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player")) 
        {
            podeSubir = true;
        }


    }
    private void Update()
    {
        if(podeSubir == false) 
        {
            transform.Translate(new Vector2(0,0));
        
        }
        else 
        {

            transform.Translate(new Vector2(0, Velocidade) * Time.deltaTime) ;

        }
    }
}
