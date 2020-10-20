using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inimigoEsperto : MonoBehaviour
{
  
    public float velocidade = 2f;
    public int vidaInimigo = 3;
    private SpriteRenderer sprite;
    private Vector2 posicaoPlayer;
    public Transform PlayerTransform;
    private Animator animator;
    public float distanciaDeDeteccao = 10f;
    public bool face = true;
    private float posicaoXPlayer;
    private bool limite;

    private void Start()
    {
        limite = false;
        face = true;
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        posicaoXPlayer = PlayerTransform.transform.position.x;
    }

    private void Update()
    {
        if (PlayerTransform.transform.position.x > transform.position.x && !face)
        {
            Flip();
        } else if (PlayerTransform.transform.position.x < transform.position.x && face) 
        {
            Flip ();
        }


        if(vidaInimigo <= 0) 
        {
            Destroy(gameObject);
        }
        if (PlayerTransform.transform.position.x > (transform.position.x - distanciaDeDeteccao) && PlayerTransform.transform.position.x < (transform.position.x + distanciaDeDeteccao))
        {
            if (PlayerTransform.transform.position.x > transform.position.x)
            {
               
                transform.Translate(new Vector2(velocidade, 0) * Time.deltaTime);
                animator.SetBool("Andando",true);
            }
            else if(PlayerTransform.transform.position.x < transform.position.x)
            {
                
                transform.Translate(new Vector2(-velocidade, 0) * Time.deltaTime);
                animator.SetBool("Andando", true);
            }
        }
        else 
        {
            transform.Translate(new Vector2(0, 0));
            animator.SetBool("Andando", false);

        }


    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Limite")) 
        {
            limite = true;
        }
    }


    public void acertou(int valor)
    {
        vidaInimigo = vidaInimigo - valor;
    }

    void Flip()
    {
        face = !face;
        sprite.flipX = !sprite.flipX;
    }
}
