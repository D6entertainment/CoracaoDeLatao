using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoboPerseguidor : MonoBehaviour
{
    public float velocidade = 3.0f;
    public bool EstaPertoPlayer;
    private Animator animator;
    public bool fimDoCaminho;
    public Transform missil;
    public Transform CanoMissil;
    private bool podeAtirar;
    public float tempoDeAtirar = 0f; 
    public bool PodeLançarMissil ;
    public int tiros = 3;
    




    private void Start()
    {
        EstaPertoPlayer = false;
        animator = GetComponent<Animator>();
        fimDoCaminho = false;
        PodeLançarMissil = false;
    }

    void Update()
    {
        if (EstaPertoPlayer && fimDoCaminho == false) 
        {
            transform.Translate(new Vector2(velocidade, 0) * Time.deltaTime);
            animator.SetBool("Andando",true);
            podeAtirar = false;

        }
        else if(EstaPertoPlayer && fimDoCaminho) 
        {
            transform.Translate(new Vector2(0, 0) * Time.deltaTime);
 
                animator.SetBool("Parado", true);
                podeAtirar = true;
            tempoDeAtirar += Time.deltaTime;
            Debug.Log(tempoDeAtirar);
            if(tempoDeAtirar >= 2f) 
            {
                tempoDeAtirar = 0f;

                atirando();
            }    
            
               // fimDoCaminho = false;
            
            

        }
        


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        
        if (collision.CompareTag("Player")) 
        {
            EstaPertoPlayer = true;

        }


    }

    public void atirando() 
    {
        if(podeAtirar) 
        {
            animator.SetBool("Andando", false);
            animator.SetBool("Atirando", true);
           // StartCoroutine(cronometro(tempoDeAtirar));
            
           
            
                Instantiate(missil, CanoMissil.position, CanoMissil.rotation);
                tiros--;
                PodeLançarMissil = false;
            if (tiros <=0) 
            {
                Destroy(gameObject);
            }
           
        }


    }
    IEnumerator cronometro(int tempo)
    {
        yield return new WaitForSeconds(tempo);
        PodeLançarMissil = true;
    }


}
