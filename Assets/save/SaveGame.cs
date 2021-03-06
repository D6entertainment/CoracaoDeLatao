﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;
public class SaveGame : MonoBehaviour
{

    private string dataP;
    public infos dados;
    public JogadorScript player;
    public JogadorScript PlayerPrefab;


    [Header("Vídeo")]
    public GameObject VideoPlayer;
    public float timeToStop = 43f;
    public float timeToPlay;
    public bool fimCut;
    public bool NovoJogoBool = false;

    public Mutar Mutando;
    private string Cena;
    private bool TocaVideo = false;


    //apagar depois 


    // public Transform PrefabPlayer;

    private void Start()
    {
        Cena = SceneManager.GetActiveScene().name;
        if (Cena.Equals("Menu"))
        {
            Mutando = GameObject.FindWithTag("MainCamera").GetComponent<Mutar>();
            fimCut = false;
            VideoPlayer = GameObject.Find("Video");
            VideoPlayer.SetActive(false);
            dataP = Path.Combine(Application.dataPath, "infos.json"); // criando o diretorio do arquivo na raiz do projeto e com nome infos.json
            dados = new infos();
            


        }
        if(Cena.Equals("GameOver")) 
        {
            dataP = Path.Combine(Application.dataPath, "infos.json"); // criando o diretorio do arquivo na raiz do projeto e com nome infos.json
            dados = new infos();

        }
            if (Cena.Equals("Ferro Velho") || Cena.Equals("Cidade") || Cena.Equals("TerceiraFase_teste") )
            {
            dataP = Path.Combine(Application.dataPath, "infos.json"); // criando o diretorio do arquivo na raiz do projeto e com nome infos.json
            dados = new infos();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();
            }
        if(Cena.Equals("configuracao"))
        {

            dataP = Path.Combine(Application.dataPath, "infos.json"); // criando o diretorio do arquivo na raiz do projeto e com nome infos.json
            dados = new infos();
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();

        }
    }
    public void salvar()
    {

       // player = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();
        Debug.Log(dados.Vida);
        dados.Vida = player.Vida;
        dados.posicaoCheckPoint = player.posicaoCheckPoint;
        dados.checPoint1 = player.checPoint1;
        dados.TemCheckPoint = player.TemCheckPoint;
        dados.fase = player.fase;
        dados.speed = player.speed;
        dados.forcaPulo = player.forcaPulo;
        dados.forcaPuloDuplo = player.forcaPuloDuplo;
        dados.KeyAndarDireita = player.KeyAndarDireita;
        dados.KeyAndarEsquerda = player.KeyAndarEsquerda;
        dados.KeyBater = player.KeyBater;
        dados.KeyInteragir = player.KeyInteragir;
        dados.KeyPular = player.KeyPular;
        dados.puloDuplo = player.puloDuplo;
        dados.UpgradeTiro = player.UpgradeTiro;
        dados.Awake = player.Awake;
        dados.Idle = player.Idle;
        dados.ParadoComBota = player.ParadoComBota;
        dados.ParadoComBotaEArma = player.ParadoComBotaEArma;


        string jsonS = JsonUtility.ToJson(dados); // convertendo um objeto de informações a serem salvar em json
        File.WriteAllText(dataP, jsonS);//escrevendo no arquivo json com os dados do objeto em json no diretorio datap.
        Debug.Log("salvado");

        CarregarParaPrefabPleyer();

    }

    public void CarregarParaPrefabPleyer() 
    {
        PlayerPrefab.Vida = dados.Vida;
        PlayerPrefab.posicaoCheckPoint = dados.posicaoCheckPoint;
        PlayerPrefab.checPoint1 = dados.checPoint1;
        PlayerPrefab.TemCheckPoint = dados.TemCheckPoint;
        PlayerPrefab.fase = dados.fase;
        PlayerPrefab.speed = dados.speed;
        PlayerPrefab.forcaPulo = dados.forcaPulo;
        PlayerPrefab.forcaPuloDuplo = dados.forcaPuloDuplo;
        PlayerPrefab.KeyAndarDireita = dados.KeyAndarDireita;
        PlayerPrefab.KeyAndarEsquerda = dados.KeyAndarEsquerda;
        PlayerPrefab.KeyBater = dados.KeyBater;
        PlayerPrefab.KeyInteragir = dados.KeyInteragir;
        PlayerPrefab.KeyPular = dados.KeyPular;
        PlayerPrefab.puloDuplo = dados.puloDuplo;
        PlayerPrefab.UpgradeTiro = dados.UpgradeTiro;
        PlayerPrefab.Awake = dados.Awake;
        PlayerPrefab.Idle = dados.Idle;
        PlayerPrefab.ParadoComBota = dados.ParadoComBota;
        PlayerPrefab.ParadoComBotaEArma = dados.ParadoComBotaEArma;



    }



    public void carrregar()
    {

        string jsonS = File.ReadAllText(dataP);
        JsonUtility.FromJsonOverwrite(jsonS, dados);
        if (dados.fase == 1)
        {
            SceneManager.LoadScene("Ferro Velho");


            PlayerPrefab.Vida = dados.Vida;
            PlayerPrefab.posicaoCheckPoint = dados.posicaoCheckPoint;
            PlayerPrefab.checPoint1 = dados.checPoint1;
            PlayerPrefab.TemCheckPoint = dados.TemCheckPoint;
            PlayerPrefab.fase = dados.fase;
            PlayerPrefab.speed = dados.speed;
            PlayerPrefab.forcaPulo = dados.forcaPulo;
            PlayerPrefab.forcaPuloDuplo = dados.forcaPuloDuplo;
            PlayerPrefab.KeyAndarDireita = dados.KeyAndarDireita;
            PlayerPrefab.KeyAndarEsquerda = dados.KeyAndarEsquerda;
            PlayerPrefab.KeyBater = dados.KeyBater;
            PlayerPrefab.KeyInteragir = dados.KeyInteragir;
            PlayerPrefab.KeyPular = dados.KeyPular;
            PlayerPrefab.puloDuplo = dados.puloDuplo;
            PlayerPrefab.UpgradeTiro = dados.UpgradeTiro;
            PlayerPrefab.Awake = dados.Awake;
            PlayerPrefab.Idle = dados.Idle;
            PlayerPrefab.ParadoComBota = dados.ParadoComBota;
            PlayerPrefab.ParadoComBotaEArma = dados.ParadoComBotaEArma;

        }
        if (dados.fase == 2)
        {
            SceneManager.LoadScene("Cidade");



            PlayerPrefab.Vida = dados.Vida;
            PlayerPrefab.posicaoCheckPoint = dados.posicaoCheckPoint;
            PlayerPrefab.checPoint1 = dados.checPoint1;
            PlayerPrefab.TemCheckPoint = dados.TemCheckPoint;
            PlayerPrefab.fase = dados.fase;
            PlayerPrefab.speed = dados.speed;
            PlayerPrefab.forcaPulo = dados.forcaPulo;
            PlayerPrefab.forcaPuloDuplo = dados.forcaPuloDuplo;
            PlayerPrefab.KeyAndarDireita = dados.KeyAndarDireita;
            PlayerPrefab.KeyAndarEsquerda = dados.KeyAndarEsquerda;
            PlayerPrefab.KeyBater = dados.KeyBater;
            PlayerPrefab.KeyInteragir = dados.KeyInteragir;
            PlayerPrefab.KeyPular = dados.KeyPular;
            PlayerPrefab.puloDuplo = dados.puloDuplo;
            PlayerPrefab.UpgradeTiro = dados.UpgradeTiro;
            PlayerPrefab.Awake = dados.Awake;
            PlayerPrefab.Idle = dados.Idle;
            PlayerPrefab.ParadoComBota = dados.ParadoComBota;
            PlayerPrefab.ParadoComBotaEArma = dados.ParadoComBotaEArma;

        }
        if (dados.fase == 3)
        {
            SceneManager.LoadScene("TerceiraFase_teste");



            PlayerPrefab.Vida = dados.Vida;
            PlayerPrefab.posicaoCheckPoint = dados.posicaoCheckPoint;
            PlayerPrefab.checPoint1 = dados.checPoint1;
            PlayerPrefab.TemCheckPoint = dados.TemCheckPoint;
            PlayerPrefab.fase = dados.fase;
            PlayerPrefab.speed = dados.speed;
            PlayerPrefab.forcaPulo = dados.forcaPulo;
            PlayerPrefab.forcaPuloDuplo = dados.forcaPuloDuplo;
            PlayerPrefab.KeyAndarDireita = dados.KeyAndarDireita;
            PlayerPrefab.KeyAndarEsquerda = dados.KeyAndarEsquerda;
            PlayerPrefab.KeyBater = dados.KeyBater;
            PlayerPrefab.KeyInteragir = dados.KeyInteragir;
            PlayerPrefab.KeyPular = dados.KeyPular;
            PlayerPrefab.puloDuplo = dados.puloDuplo;
            PlayerPrefab.UpgradeTiro = dados.UpgradeTiro;
            PlayerPrefab.Awake = dados.Awake;
            PlayerPrefab.Idle = dados.Idle;
            PlayerPrefab.ParadoComBota = dados.ParadoComBota;
            PlayerPrefab.ParadoComBotaEArma = dados.ParadoComBotaEArma;

        }




    }


    public void VoltarAOJogo()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();
        string jsonS = File.ReadAllText(dataP);
        JsonUtility.FromJsonOverwrite(jsonS, dados);
        if (dados.fase == 1)
        {
            SceneManager.LoadScene("Ferro Velho");


            PlayerPrefab.Vida = dados.Vida;
            PlayerPrefab.posicaoCheckPoint = dados.posicaoCheckPoint;
            PlayerPrefab.checPoint1 = dados.checPoint1;
            PlayerPrefab.TemCheckPoint = dados.TemCheckPoint;
            PlayerPrefab.fase = dados.fase;
            PlayerPrefab.speed = dados.speed;
            PlayerPrefab.forcaPulo = dados.forcaPulo;
            PlayerPrefab.forcaPuloDuplo = dados.forcaPuloDuplo;
            PlayerPrefab.KeyAndarDireita = dados.KeyAndarDireita;
            PlayerPrefab.KeyAndarEsquerda = dados.KeyAndarEsquerda;
            PlayerPrefab.KeyBater = dados.KeyBater;
            PlayerPrefab.KeyInteragir = dados.KeyInteragir;
            PlayerPrefab.KeyPular = dados.KeyPular;
            PlayerPrefab.puloDuplo = dados.puloDuplo;
            PlayerPrefab.UpgradeTiro = dados.UpgradeTiro;
            PlayerPrefab.Awake = dados.Awake;
            PlayerPrefab.Idle = dados.Idle;
            PlayerPrefab.ParadoComBota = dados.ParadoComBota;
            PlayerPrefab.ParadoComBotaEArma = dados.ParadoComBotaEArma;

        }
        if (dados.fase == 2)
        {
            SceneManager.LoadScene("Cidade");


            PlayerPrefab.Vida = dados.Vida;
            PlayerPrefab.posicaoCheckPoint = dados.posicaoCheckPoint;
            PlayerPrefab.checPoint1 = dados.checPoint1;
            PlayerPrefab.TemCheckPoint = dados.TemCheckPoint;
            PlayerPrefab.fase = dados.fase;
            PlayerPrefab.speed = dados.speed;
            PlayerPrefab.forcaPulo = dados.forcaPulo;
            PlayerPrefab.forcaPuloDuplo = dados.forcaPuloDuplo;
            PlayerPrefab.KeyAndarDireita = dados.KeyAndarDireita;
            PlayerPrefab.KeyAndarEsquerda = dados.KeyAndarEsquerda;
            PlayerPrefab.KeyBater = dados.KeyBater;
            PlayerPrefab.KeyInteragir = dados.KeyInteragir;
            PlayerPrefab.KeyPular = dados.KeyPular;
            PlayerPrefab.puloDuplo = dados.puloDuplo;
            PlayerPrefab.UpgradeTiro = dados.UpgradeTiro;
            PlayerPrefab.Awake = dados.Awake;
            PlayerPrefab.Idle = dados.Idle;
            PlayerPrefab.ParadoComBota = dados.ParadoComBota;
            PlayerPrefab.ParadoComBotaEArma = dados.ParadoComBotaEArma;

        }
        if (dados.fase == 3)
        {
            SceneManager.LoadScene("TerceiraFase_teste");



            PlayerPrefab.Vida = dados.Vida;
            PlayerPrefab.posicaoCheckPoint = dados.posicaoCheckPoint;
            PlayerPrefab.checPoint1 = dados.checPoint1;
            PlayerPrefab.TemCheckPoint = dados.TemCheckPoint;
            PlayerPrefab.fase = dados.fase;
            PlayerPrefab.speed = dados.speed;
            PlayerPrefab.forcaPulo = dados.forcaPulo;
            PlayerPrefab.forcaPuloDuplo = dados.forcaPuloDuplo;
            PlayerPrefab.KeyAndarDireita = dados.KeyAndarDireita;
            PlayerPrefab.KeyAndarEsquerda = dados.KeyAndarEsquerda;
            PlayerPrefab.KeyBater = dados.KeyBater;
            PlayerPrefab.KeyInteragir = dados.KeyInteragir;
            PlayerPrefab.KeyPular = dados.KeyPular;
            PlayerPrefab.puloDuplo = dados.puloDuplo;
            PlayerPrefab.UpgradeTiro = dados.UpgradeTiro;
            PlayerPrefab.Awake = dados.Awake;
            PlayerPrefab.Idle = dados.Idle;
            PlayerPrefab.ParadoComBota = dados.ParadoComBota;
            PlayerPrefab.ParadoComBotaEArma = dados.ParadoComBotaEArma;

        }




    }





    private void Update()
    {
        if (TocaVideo)
        {
            timeToStop -= Time.deltaTime;
            if (timeToStop <= 0f)
            {

                SceneManager.LoadScene("Ferro Velho");
            }
        }

    }
    public void NovoJogo()
    {
        string jsonS = JsonUtility.ToJson(dados); // convertendo um objeto de informações a serem salvar em json
        File.WriteAllText(dataP, jsonS);//escrevendo no arquivo json com os dados do objeto em json no diretorio datap.
       
        PlayerPrefab.Vida = 10;
        PlayerPrefab.posicaoCheckPoint = dados.posicaoCheckPoint;
        PlayerPrefab.checPoint1 = 0;
        PlayerPrefab.TemCheckPoint = false;
        PlayerPrefab.fase = 1;
        PlayerPrefab.speed = 10f;
        PlayerPrefab.forcaPulo = 2400f;
        PlayerPrefab.forcaPuloDuplo = 1300f;



        if (PlayerPrefab.KeyAndarDireita == KeyCode.None)
        {
           PlayerPrefab.KeyAndarDireita = KeyCode.D;
        }
        //if(PlayerPrefab.KeyAndarDireita != KeyCode.None) 
        //{
          //  PlayerPrefab.KeyAndarDireita = dados.KeyAndarDireita;
        //}
        if (PlayerPrefab.KeyAndarEsquerda == KeyCode.None)
        {
            PlayerPrefab.KeyAndarEsquerda = KeyCode.A;
        }
        //if(PlayerPrefab.KeyAndarEsquerda != KeyCode.None)
        //{
         //   PlayerPrefab.KeyAndarEsquerda = dados.KeyAndarEsquerda;
        //}
        if (PlayerPrefab.KeyBater == KeyCode.None)
        {
            PlayerPrefab.KeyBater = KeyCode.O;
        }
        //if(PlayerPrefab.KeyBater != KeyCode.None)
        //{
         //   PlayerPrefab.KeyBater = dados.KeyBater;
        //}
        if (PlayerPrefab.KeyInteragir == KeyCode.None)
        {
            PlayerPrefab.KeyInteragir = KeyCode.E;
        }
        //if(PlayerPrefab.KeyInteragir != KeyCode.None)
        //{
        //    PlayerPrefab.KeyInteragir = dados.KeyInteragir;
        //}
        if (PlayerPrefab.KeyPular == KeyCode.None)
        {
            PlayerPrefab.KeyPular = KeyCode.W;
        }
        //if(PlayerPrefab.KeyPular != KeyCode.None)
        //{
          //  PlayerPrefab.KeyPular = dados.KeyPular;
        //}







        
        PlayerPrefab.puloDuplo = false;
        PlayerPrefab.UpgradeTiro = false;
        PlayerPrefab.Awake = true;
        PlayerPrefab.Idle = true;
        PlayerPrefab.ParadoComBota = false;
        PlayerPrefab.ParadoComBotaEArma = false;

        Mutando.Mutado = true;
        video();

    }
    public bool TemChecpointMetodo()
    {

        return dados.TemCheckPoint;
    }
    public void video() 
    {
        
        timeToPlay = timeToStop - 0.1f;
        VideoPlayer.SetActive(true);
        TocaVideo = true;

    }
    IEnumerator BackPlayerToLive()
    {
        yield return new WaitForSecondsRealtime(timeToStop);
        fimCut = true;
    }



}



public class infos
{
    public int fase;
    public Vector3 posicaoCheckPoint;
    public int checPoint1;
    public bool TemCheckPoint;
    public float speed;
    public float forcaPulo;
    public float forcaPuloDuplo;
    public KeyCode KeyAndarDireita;
    public KeyCode KeyAndarEsquerda;
    public KeyCode KeyPular;
    public KeyCode KeyBater;
    public KeyCode KeyInteragir;
    public bool puloDuplo;
    public bool UpgradeTiro;
    public int Vida;
    public bool Awake;
    public bool Idle;
    public bool ParadoComBota;
    public bool ParadoComBotaEArma;
    
}