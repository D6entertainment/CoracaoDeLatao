using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoPerceguidor : MonoBehaviour
{
    public float Velocidade = 1.0f;
    public bool LiberaPerceguicao = false;
    public float Distancia;
    public Transform Player;
    public bool face = true;
    private Vector2 posicaoPlayer;
    private Vector2 posicaoThis;

    
    private void Start()
    {
        posicaoPlayer = Player.transform.position;
        posicaoThis = this.transform.position;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            LiberaPerceguicao = true;
        }
    }
    private void Update()
    {
        Distancia = Vector2.Distance(posicaoThis,posicaoPlayer);
        //flip
        if ((posicaoThis.x > posicaoPlayer.x) && !face)
        {
            flip();
        }
        else if ((posicaoThis.x < posicaoPlayer.x) && face) 
        {
            flip();
        }
        if (LiberaPerceguicao && Distancia > 2.8f) 
        {
            if (posicaoPlayer.x < posicaoThis.x) 
            {
                transform.Translate(new Vector2(-Velocidade * Time.deltaTime, 0));
            }
            else if (posicaoPlayer.x > posicaoThis.x) 
            {
                transform.Translate(new Vector2(Velocidade * Time.deltaTime, 0));
            }
        }
    }
    void flip()
    {
        face = !face;
        Vector3 scala = this.transform.localScale;
        scala.x *= -1;
        this.transform.localScale = scala;

    }
}
