
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissilPerceguidor : MonoBehaviour
{
    GameObject alvo;
    public GameObject Explosao;
    public float velocidadeRotacao = 3f;
    public float velocidade = 10f;
    public float TempoMorteMissil = 5.0f;
    
    public int dano = 1;
   

    Quaternion rotacaoAoAlvo;
    Vector3 direcao;
    Rigidbody2D rb;

    private void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody2D>();
        
       
    }

    private void Update()
    {
        direcao = (alvo.transform.position - transform.position).normalized;
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        rotacaoAoAlvo = Quaternion.AngleAxis(angulo, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAoAlvo, Time.deltaTime * velocidadeRotacao);
        rb.velocity = new Vector2(direcao.x * velocidade , direcao.y * velocidade );
        TempoMorteMissil -= Time.deltaTime;
        if (TempoMorteMissil <= 0.0f) 
        {
            Destroy(transform.gameObject);
        }
        Destroy(transform.gameObject, TempoMorteMissil);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")) 
        {
            Instantiate(Explosao, transform.position, Quaternion.identity);
           
            Destroy(this.gameObject);
        }

    }
}
