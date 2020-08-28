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
        Vector3 horizontal = new Vector3(1.0f, 0.0f, 0.0f);
        transform.position = transform.position + horizontal * Velocidade;
    }

    void Flip()
    {
        sprite.flipX = !sprite.flipX;
    }
}
