using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barril : MonoBehaviour
{
    public float forca = 1f;
    public bool PlayerEmCima;
    private float PosicaoY;


    private void Start()
    {
        PosicaoY = this.transform.position.y;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerEmCima = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerEmCima = false;
    }
    private void Update()
    {
        if (PlayerEmCima)
        {
            // transform.Translate(new Vector2(0, PosicaoY - forca * Time.deltaTime));
            transform.Translate(new Vector2(0, -forca * Time.deltaTime));
        }
    }
}
