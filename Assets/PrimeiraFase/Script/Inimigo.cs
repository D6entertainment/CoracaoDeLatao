using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float Velocidade;
    public int vidasInimigo = 3;
    SpriteRenderer sprite;

    public void acertou(int valor)
    {
        vidasInimigo = vidasInimigo - valor;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Limite")
        {
            Velocidade = -Velocidade;
            Flip();
        }
    }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        Mover();
        if (vidasInimigo <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void Mover()
    {
 
        transform.Translate(new Vector2(Velocidade,0)* Time.deltaTime);
    }

    void Flip()
    {
        sprite.flipX = !sprite.flipX;
    }
}
