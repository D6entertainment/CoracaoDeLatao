using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levitacaoAgua : MonoBehaviour
{
    public float Velocidade = 2f;
    public bool podeSubir;
    public bool colisor;

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
        //  if (collision.CompareTag("Limite"))
        //  {
        //    colisor = true;
        // }



    }
    private void Update()
    {
        if (podeSubir && colisor == false)
        {
            transform.Translate(new Vector2(0, Velocidade) * Time.deltaTime);

        }
        else if (podeSubir && colisor)
        {

            transform.Translate(new Vector2(0, 0));

        }
    }
}
