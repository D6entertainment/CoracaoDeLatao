using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Teleporte : MonoBehaviour
{

    public Transform player;
    public Transform posicaoFinal;
    public Text mensagemNaTela;
    public GameObject painelPreto;
    public int TempoTelaPreta = 2;
    public bool verificaTeleporte;
    public AudioSource audio;
 


    private void Start()
    {
        mensagemNaTela.enabled = false;
       

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player") )
        {
            mensagemNaTela.enabled = true;
            verificaTeleporte = true;
            

            
            
            
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            mensagemNaTela.enabled = false;
            verificaTeleporte = false;


        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            
            teleporte();

        }
    


    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && verificaTeleporte == true)
        {
            teleporte();

        }
 

    }

    public void teleporte() 
    {
       
        painelPreto.SetActive(true);
        // play em audio
        audio.Play();
         StartCoroutine(cronometro(TempoTelaPreta));
       
        player.transform.position = posicaoFinal.transform.position;
        

    }
    IEnumerator cronometro(int tempo) 
    {
        yield return new WaitForSeconds(tempo);
        painelPreto.SetActive(false);
    }
   


}
