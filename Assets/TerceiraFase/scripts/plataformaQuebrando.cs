using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class plataformaQuebrando : MonoBehaviour
{
    public bool estaEmCima = false;
    private Animator animator;
    public float tempo = 0f;
    public float tempoParaQuebrar = 0.8f;
    private void Start()
    {
        tempo = 0f;
        estaEmCima = false;
        animator = GetComponent<Animator>();
      
    }
    void Update()
    {
          tempo += Time.deltaTime; 
        if (estaEmCima) 
        {
            animator.SetBool("quebrando",true);
            if (tempo >= tempoParaQuebrar) 
            {
                tempo = 0;
                Destroy(transform.gameObject);
            }
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            estaEmCima = true;
            tempo = 0f;
        }
    }
}
