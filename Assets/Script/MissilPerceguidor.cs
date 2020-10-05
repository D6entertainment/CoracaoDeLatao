
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
   

    Quaternion rotacaoAoAlvo;
    Vector3 direcao;
    Rigidbody2D rb;

    private void Start()
    {
        alvo = GameObject.FindGameObjectWithTag("alvo");
        rb = GetComponent<Rigidbody2D>();
       
    }

    private void Update()
    {
        direcao = (alvo.transform.position - transform.position).normalized;
        float angulo = Mathf.Atan2(direcao.y, direcao.x) * Mathf.Rad2Deg;
        rotacaoAoAlvo = Quaternion.AngleAxis(angulo, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoAoAlvo, Time.deltaTime * velocidadeRotacao);
        rb.velocity = new Vector2(direcao.x * velocidade , direcao.y * velocidade );

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Instantiate(Explosao, transform.position, Quaternion.identity);
        //chamar animacao


         Destroy(this.gameObject);
    }
}
