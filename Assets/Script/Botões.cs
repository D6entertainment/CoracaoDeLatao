using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Botões : MonoBehaviour
{
    [Header("Vídeo")] 
    public GameObject VideoPlayer;
    public float timeToStop;
    public float timeToPlay;
    public bool fimCut;

    private Mutar Mutando;

    void Start()
    {
        Mutando = GameObject.FindWithTag("MainCamera").GetComponent<Mutar>();
        fimCut = false;
        VideoPlayer.SetActive(false);
        timeToPlay = timeToStop - 0.1f;
    }

   
    void Update()
    {
        SairAtalho();
        if (fimCut == true)
        {
            SceneManager.LoadScene("Ferro Velho");
        }
    }

    public void Retornar()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Jogar()
    {
        Mutando.Mutado = true;
        StartCoroutine(BackPlayerToLive());
        VideoPlayer.SetActive(true);
    }
    public void Sair()
    {
        Application.Quit();
    }
    public void Créditos()
    {
        SceneManager.LoadScene("Créditos");
    }

    void SairAtalho()
    {
        //Adicionando ESC como atalho para sair do jogo mais rapido. *Só funciona no executavel*
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
    }
    IEnumerator BackPlayerToLive()
    {
        yield return new WaitForSecondsRealtime(timeToPlay);
        fimCut = true;
    }
    public void configuracao()
    {
        SceneManager.LoadScene("configuracao");
    }

    public void fase1()
    {
        SceneManager.LoadScene("Ferro Velho");
    }

}