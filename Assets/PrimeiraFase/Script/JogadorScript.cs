﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Video;

public class JogadorScript : MonoBehaviour
{

    [Header("Save")]
    //public SaveGameJson save;
    public int fase;
    public Vector3 posicaoCheckPoint;
    //public GameObject posicaoInicioFase;
    public int checPoint1 = 0;
    public bool TemCheckPoint = false;
    public SaveGame SaveGame;

    [Header("Movimento")]

    

    public float speed = 10f;
    public float forcaPulo = 2700f;
    public float forcaPuloDuplo = 1300f;
    public Transform verificaChao;
    public LayerMask oChao;
    public float raio = 0.2f;
    public bool paraJogadorCut = false;
    public int paraJogadorIma = 0;
    public bool imaAtivado = false;
    public float deslizador = 0f;
    public float Levitacao = 0f;
    public KeyCode KeyAndarDireita = KeyCode.D;
    public KeyCode KeyAndarEsquerda = KeyCode.A;
    public KeyCode KeyPular = KeyCode.Space;
    public KeyCode KeyBater = KeyCode.O;
    public KeyCode KeyInteragir = KeyCode.E;
    public bool face = true;
    private Transform roboTransform;
    public bool ficaParado;

    [Header("Upgrades")]
    public bool puloDuplo = false;
    public bool UpgradeTiro = false;
    public AudioSource audioUpgradePerna;
    

    //public Transform tiro;
    //public Transform posicaoCanoDaArma;
   


    [Header("Verificador")]
    bool estaPulando = false;
    public bool estaChao = false;
    private Rigidbody2D body;
    SpriteRenderer sprite;
    public bool DanoInimigoBool;



    [Header("outros")]
    public int DanoMissil = 2;
    public int DanoInimigo = 1;
    public float tempoTomarDano = 2f;
    private Text MensagemNaTela;
    public GameObject Salvando;
    private bool salvo;
    public float TempoTextSalvandoNaTela = 2f;
    
    public Turotial Tutorial;
    public string cenaAtiva;


    [Header("Ataque")]
    public Transform verificaAtaque;
    public float raioAtaque = 2.3f;
    public LayerMask paraBater;
    public float tempoProximoAtaque;
    public GameObject Tiro;
    public GameObject CanoDaArma;
    public AudioSource AudioBater;
    public AudioSource AudioAtirar;
    

    [Header("Vida")]
    public int Vida = 10;
    
    public GameObject[] lifeObject;

    //dificil Pakas

    [Header("Animator")]
    Animator animator;
    float axis;
    Vector2 velocidade;
    bool ladoDireito = true;
    bool Fire = true;
    public bool Awake = false;
    public bool Idle = true;
    public bool ParadoComBota = false;
    public bool ParadoComBotaEArma = false;

    [Header("Vídeo")]
    public GameObject VideoPlayerOBJFinalFase1;
    public GameObject VideoPlayerOBJFinalFase3;
    public float timeToStop;
    public float timeToPlay;
    public bool fimCut;
    public Mutar Mutando;
    private bool TocaVideo = false;
    private bool TocaVideoFinal = false;
    private VideoPlayer videoPlayerFinalFase1;
    private VideoPlayer videoPlayerFinalFase3;

    void Start()
    {

        SaveGame = GameObject.FindGameObjectWithTag("Save").GetComponent<SaveGame>();
        AcharObjetoVida();
        paraBater = LayerMask.GetMask("paraBater");
        oChao = LayerMask.GetMask("Chao");
        Salvando = GameObject.Find("SaveText");
        Salvando.SetActive(false);
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        animator.SetBool("Awake", Awake);
        animator.SetBool("Idle", Idle);
        animator.SetBool("ParadoComBota", ParadoComBota);
        animator.SetBool("ParadoComBotaEArma", ParadoComBotaEArma);

        if(Awake) 
        {
        paraJogadorCut = true;
        StartCoroutine(Paradinha());
            //chamar Painel de Tutorial

        
        }
        
        roboTransform = GetComponent<Transform>();
        face = true;
        ficaParado = false;
        DanoInimigoBool = false;
        MensagemNaTela = GameObject.FindGameObjectWithTag("MensagemNaTela").GetComponent<Text>();
        MensagemNaTela.enabled = false;

        Mutando = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Mutar>();
        videoPlayerFinalFase1 = VideoPlayerOBJFinalFase1.GetComponent<VideoPlayer>();
        videoPlayerFinalFase3 = VideoPlayerOBJFinalFase3.GetComponent<VideoPlayer>();
        videoPlayerFinalFase1.targetCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        videoPlayerFinalFase3.targetCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        cenaAtiva = SceneManager.GetActiveScene().name;

        VideoPlayerOBJFinalFase3.SetActive(false);
        VideoPlayerOBJFinalFase1.SetActive(false);

       // if (Vida < 10) 
       // {
        //    int x = 10 - Vida;
       //     Vida = 10;
       //     DamageTaked(x);
           
       // }

    }


    private void Update()
    {





        if (TocaVideo)
        {

            timeToStop -= Time.deltaTime;
            if (timeToStop <= 0f)
            {

                SaveGame.carrregar();
            }
        }
        if (TocaVideoFinal) 
        {
            timeToStop -= Time.deltaTime;
            if (timeToStop <= 0f)
            {
                Time.timeScale = 1;
                SceneManager.LoadScene("Creditos");
            }
        }



        if (salvo) 
        {
            Salvando.SetActive(true);
            TempoTextSalvandoNaTela -= Time.deltaTime;
            if (TempoTextSalvandoNaTela <= 0) 
            {
                Salvando.SetActive(false);
            }
        }

        tempoTomarDano -= Time.deltaTime;
        if (DanoInimigoBool && tempoTomarDano <= 0f) 
        {
            tempoTomarDano = 3f;
            DamageTaked(DanoInimigo);
            animator.SetBool("Hurt", true);
        }
        else
        {
            animator.SetBool("Hurt", false);
        }

        if (ficaParado) 
        {
            transform.Translate(new Vector2(0,0) * Time.deltaTime);
        }

        if (Input.GetKey(KeyAndarDireita) && !face)
        {
            Flip();
        }
        else if (Input.GetKey(KeyAndarEsquerda) && face) 
        {
            Flip();
        
        }


        estaChao = Physics2D.OverlapCircle(verificaChao.position, raio, oChao);





        if (!paraJogadorCut)
        {
            if (paraJogadorIma == 0)
            {
                if (Input.GetKeyDown(KeyPular) && estaChao && puloDuplo == false)
                {



                    body.AddForce(new Vector2(0f, forcaPulo));
                    animator.SetBool("jump", true);
                    Debug.Log(forcaPulo);


                }
                if (Input.GetKeyDown(KeyPular) && estaChao && puloDuplo)
                {

                    body.AddForce(new Vector2(0f, forcaPulo + forcaPuloDuplo));

                }



                if (Input.GetKey(KeyAndarDireita) && ficaParado == false && estaChao)
                {
                    animator.SetBool("Velocidade2", true);
                    transform.Translate(new Vector2(speed, 0) * Time.deltaTime);
                }
                if (Input.GetKey(KeyAndarDireita) && ficaParado == false && !estaChao)
                {
                    transform.Translate(new Vector2(speed, 0) * Time.deltaTime);

                }


                else if (Input.GetKey(KeyAndarEsquerda) && estaChao)
                {

                    animator.SetBool("Velocidade2", true);
                    transform.Translate(new Vector2(-speed, 0) * Time.deltaTime);

                }
                if (Input.GetKey(KeyAndarEsquerda) && !estaChao)
                {
                    transform.Translate(new Vector2(-speed, 0) * Time.deltaTime);



                }




                else if (!Input.GetKey(KeyAndarDireita) && !Input.GetKey(KeyAndarEsquerda))
                {
                    animator.SetBool("Velocidade2", false);
                }
                //if (Input.GetKeyDown(KeyBater))
                //{
                //   Fire = true;
                //   animator.SetBool("Fire", true);
                // }
                //else
                //{
                //    Fire = false;
                //    animator.SetBool("Fire", false);
                // }

                tempoProximoAtaque -= Time.deltaTime;
                if (Input.GetKey(KeyBater) && tempoProximoAtaque <= 0)
                {
                    // && body.velocity == new Vector2(0, 0)
                    tempoProximoAtaque = 0.2f;
                    Fire = true;
                    animator.SetBool("Fire", true);

                }
                else
                {
                    Fire = false;
                    animator.SetBool("Fire", false);
                }






            }
        }






    }
    private void FixedUpdate()
    {













        if (imaAtivado == true)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
        }
        if (imaAtivado == false)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 2;
        }
        if (estaChao)
        {
            paraJogadorIma = 0;
        }

        if (!paraJogadorCut)
        {
            if (paraJogadorIma == 0)
            {
                

                if (Vida <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
                if (!estaChao) 
                {
                
                    animator.SetBool("Jump", true);
                }

                if (estaChao)
                {

                    animator.SetBool("Jump", false);
                }


            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Vida")) 
        {
            if(Vida + 1 <= 10) 
            {
                DaVida(1);
                Destroy(collision.gameObject);
            }
        }



        if(collision.CompareTag("Awak")) 
        {
            Awake = false;
        }


        if (collision.CompareTag("FimFase")) 
        {
            
            fase += 1;
            Mutando.Mutado = true;
            video();
            SaveGame.salvar();
        }
        if (collision.CompareTag("FimFase1"))
        {

            fase += 1;
            Mutando.Mutado = true;
            //video();
            SaveGame.salvar();
            SceneManager.LoadScene("TerceiraFase_teste");
        }
        if (collision.CompareTag("FimFase2"))
        {

            fase = 3;
            Mutando.Mutado = true;
           
            videoFaseFinal();
            SaveGame.salvar();
        }

        if (collision.CompareTag("checPoint"))
        {

            if (checPoint1 != 1)
            {
                Debug.Log("cacatua");
                posicaoCheckPoint = collision.transform.position;
                checPoint1 = 1;
                TemCheckPoint = true;
                SaveGame.salvar();
                salvo = true;

            }

            // varialvel carregar jogo  = true;

        }
        if (collision.CompareTag("checPoint2"))
        {

            if (checPoint1 != 2)
            {
                
                posicaoCheckPoint = collision.transform.position;
                checPoint1 = 2;
                TemCheckPoint = true;
                SaveGame.salvar();
                salvo = true;
            }
        }
        if (collision.CompareTag("checPoint3"))
        {

            if (checPoint1 != 3)
            {
                
                posicaoCheckPoint = collision.transform.position;
                checPoint1 = 3;
                TemCheckPoint = true;
                SaveGame.salvar();
                salvo = true;
            }
        }
        if (collision.CompareTag("checPoint4"))
        {

            if (checPoint1 != 4)
            {
                
                posicaoCheckPoint = collision.transform.position;
                checPoint1 = 4;
                TemCheckPoint = true;
                SaveGame.salvar();
                salvo = true;
            }
        }
        if (collision.CompareTag("checPoint5"))
        {

            if (checPoint1 != 5)
            {

                posicaoCheckPoint = collision.transform.position;
                checPoint1 = 5;
                TemCheckPoint = true;
                SaveGame.salvar();
                salvo = true;
            }
        }
        if (collision.CompareTag("checPoint6"))
        {

            if (checPoint1 != 6)
            {

                posicaoCheckPoint = collision.transform.position;
                checPoint1 = 6;
                TemCheckPoint = true;
                SaveGame.salvar();
                salvo = true;
            }
        }
        if (collision.CompareTag("checPoint7"))
        {

            if (checPoint1 != 7)
            {

                posicaoCheckPoint = collision.transform.position;
                checPoint1 = 7;
                TemCheckPoint = true;
                SaveGame.salvar();
                salvo = true;
            }
        }
        if (collision.CompareTag("checPoint8"))
        {

            if (checPoint1 != 8)
            {

                posicaoCheckPoint = collision.transform.position;
                checPoint1 = 8;
                TemCheckPoint = true;
                SaveGame.salvar();
                salvo = true;
            }
        }










        if (collision.CompareTag("MorteInstantanea"))
        {
            SceneManager.LoadScene("GameOver");
        }

        if (collision.gameObject.tag == "Cutscenes")
        {
            paraJogadorCut = true;
        }


        if (collision.CompareTag("UpgradePerna"))
        {
            paraJogadorCut = true;
            StartCoroutine(ParadaUpgrade());
            animator.SetBool("jump",false);
            animator.SetBool("Velocidade2", false);
            animator.SetBool("Hurt", false);
            animator.SetBool("Fire", false);
            audioUpgradePerna.Play();
                puloDuplo = true;
                Awake = false;
                Idle = false;
                ParadoComBota = true;
                ParadoComBotaEArma = false;
                MudarEstado();
                Destroy(collision.gameObject);
        }
        if (collision.CompareTag("UpgradeTiro"))
        {
            UpgradeTiro = true;
            paraJogadorCut = true;
            StartCoroutine(ParadaUpgrade());
            animator.SetBool("jump", false);
            animator.SetBool("Velocidade2", false);
            animator.SetBool("Hurt", false);
            animator.SetBool("Fire", false);
            audioUpgradePerna.Play();
            puloDuplo = true;
            Awake = false;
            Idle = false;
            ParadoComBota = false;
            ParadoComBotaEArma = true;
            MudarEstado();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "Missil")
        {
            DamageTaked(DanoMissil);
           
        }
    }
    public void video()
    {

        timeToPlay = timeToStop - 0.1f;
        VideoPlayerOBJFinalFase1.SetActive(true);
        timeToStop = 35.0f;
        TocaVideo = true;

    }
    public void videoFaseFinal() 
    {
        timeToPlay = timeToStop - 0.1f;
        VideoPlayerOBJFinalFase3.SetActive(true);
        timeToStop = 62.0f;
        TocaVideoFinal = true;

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ausapao"))
        {
            MensagemNaTela.enabled = true;
            if (Input.GetKey(KeyCode.E))
            {
                //tocar som do alsapao
                Destroy(collision.gameObject);
                MensagemNaTela.enabled = false;
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cutscenes")
        {
            paraJogadorCut = false;
        }
        if (collision.CompareTag("Ausapao"))
        {
                 MensagemNaTela.enabled = false;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
    
        if (collision.gameObject.tag == "Mata")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "daDano")
        {
            DanoInimigoBool = true;

        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "daDano")
        {
            DanoInimigoBool = false;
        }
    }


    public void AcharObjetoVida() 
    {
        lifeObject[0] = GameObject.Find("Image0");
        lifeObject[1] = GameObject.Find("Image1");
        lifeObject[2] = GameObject.Find("Image2");
        lifeObject[3] = GameObject.Find("Image3");
        lifeObject[4] = GameObject.Find("Image4");
        lifeObject[5] = GameObject.Find("Image5");
        lifeObject[6] = GameObject.Find("Image6");
        lifeObject[7] = GameObject.Find("Image7");
        lifeObject[8] = GameObject.Find("Image8");
        lifeObject[9] = GameObject.Find("Image9");

    }

    public void DamageTaked(int damage)
    {
        Debug.Log(damage);
        Debug.Log("tamanho do array de vida = " + lifeObject.Length);
        for (int i = 0; i<= damage; i++) 
        {
        Vida = Vida - 1;
            if (Vida >= 0)
            {
                lifeObject[Vida].SetActive(false);
                StartCoroutine(ColorDamageChange());

            }
            else 
            {
                SceneManager.LoadScene("GameOver");
            }

        }
        Debug.Log("tamanho do array de vida depois do dano = " + lifeObject.Length);
    }

    public void DaVida(int MaisVida) 
    {
            if (Vida < 10) 
            {
       
        for (int i = 1; i <= MaisVida; i++) 
        {
                Debug.Log(Vida);
            lifeObject[Vida].SetActive(true);
            Vida += 1;
                

        }
            
            }
    
    } 

    public void MudarEstado() 
    {
        animator.SetBool("Awake", Awake);
        animator.SetBool("Idle", Idle);
        animator.SetBool("ParadoComBota", ParadoComBota);
        animator.SetBool("ParadoComBotaEArma", ParadoComBotaEArma);
    }
    IEnumerator Paradinha()
    {
        yield return new WaitForSeconds(3f);
        paraJogadorCut = false;
    }
    IEnumerator TempoDeEspera(float tempo)
    {
        yield return new WaitForSeconds(tempo);
        timeToStop = 0.0f;
    }
    IEnumerator ParadaUpgrade()
    {
        yield return new WaitForSeconds(1.5f);
        paraJogadorCut = false;
    }
    IEnumerator ColorDamageChange()
    {
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.7f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f);
    }
    void Flip()
    {
        face = !face;

        Vector3 scala = roboTransform.localScale;
        scala.x *= -1;
        roboTransform.localScale = scala;
    }
    void JogadorAtaque()
    {
        
        Debug.Log("entrouAtaque");
        if (UpgradeTiro == false)
        {
            Collider2D[] AtacarInimigo = Physics2D.OverlapCircleAll(verificaAtaque.position, raioAtaque, paraBater);
            Debug.Log("NumeroDeInimigos " + AtacarInimigo.Length);
            for (int i = 0; i < AtacarInimigo.Length; i++)
            {
                AtacarInimigo[i].SendMessage("acertou", 1);
                 AudioBater.Play();
              
            }
        }
        else if (UpgradeTiro)
        {
            AudioAtirar.Play();
            GameObject cloneTiro =  Instantiate(Tiro, CanoDaArma.transform.position, Quaternion.identity);
            if (face == false)
            {
                cloneTiro.transform.eulerAngles = new Vector3 (0,0,180);;
            }
            
        } 
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(verificaChao.position, raio);
        Gizmos.DrawWireSphere(verificaAtaque.position, raioAtaque);
    }
}
