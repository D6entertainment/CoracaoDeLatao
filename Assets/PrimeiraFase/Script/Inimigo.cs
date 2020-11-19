using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inimigo : MonoBehaviour
{
    public float Velocidade;
    public int vidasInimigo = 3;
    SpriteRenderer sprite;
    private Color CorNormal;



    public void acertou(int valor)
    {
        vidasInimigo = vidasInimigo - valor;
        StartCoroutine(ColorDamageChange());
        

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limite")) 
        {
            Flip();
        }
    }

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
        CorNormal = gameObject.GetComponent<SpriteRenderer>().color;
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

    public void Flip()
    {
        sprite.flipX = !sprite.flipX;
        Velocidade = -Velocidade;
    }

    IEnumerator ColorDamageChange()
    {
       
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.2f);
        gameObject.GetComponent<SpriteRenderer>().color = CorNormal;
    }


}
