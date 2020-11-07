using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JogadorScript : MonoBehaviour
{
    [Header("Movimento")]
    public float speed = 10f;
    public float forcaPulo = 2400f;
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

    public int puloDuplo = 1;
    public int podePuloDuplo = 1;
    public bool UpgradeTiro = false;
    public AudioSource audioUpgradePerna;
    //public Transform tiro;
    //public Transform posicaoCanoDaArma;
    //private alsapao alsapao;


    [Header("Verificador")]
    bool estaPulando = false;
    public bool estaChao = false;
    private Rigidbody2D body;
    SpriteRenderer sprite;
    public bool DanoInimigoBool;



    [Header("outros")]

    // public Text texto;
    public int DanoMissil = 2;
    public int DanoInimigo = 1;
    public float tempoTomarDano = 2f;
    private Text MensagemNaTela;


    [Header("Ataque")]
    public Transform verificaAtaque;
    public float raioAtaque;
    public LayerMask paraBater;
    public float tempoProximoAtaque;

    [Header("Vida")]
    public int Vida = 10;
    // public int vidaCheia = 10;
    public GameObject[] lifeObject;

    [Header("Animator")]
    Animator animator;
    float axis;
    Vector2 velocidade;
    bool ladoDireito = true;
    bool Fire = true;
    //bool Jump = true;



    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        paraJogadorCut = true;
        StartCoroutine(Paradinha());
        roboTransform = GetComponent<Transform>();
        face = true;
        ficaParado = false;
        DanoInimigoBool = false;
        MensagemNaTela = GameObject.FindGameObjectWithTag("MensagemNaTela").GetComponent<Text>();
    }

    IEnumerator Paradinha()
    {
        yield return new WaitForSeconds(3f);
        paraJogadorCut = false;
    }

    private void Update()
    {
         tempoTomarDano -= Time.deltaTime;
        if (DanoInimigoBool && tempoTomarDano <= 0f) 
        {
            DamageTaked(DanoInimigo);
            animator.SetBool("Hurt", true);
            tempoTomarDano = 2f;
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

        if (Input.GetKey(KeyAndarDireita) && ficaParado == false)
        {
            transform.Translate(new Vector2(speed, 0) * Time.deltaTime) ;
            animator.SetBool("Velocidade2", true);
        }
        else if (Input.GetKey(KeyAndarEsquerda))
        {
            transform.Translate(new Vector2(-speed, 0) * Time.deltaTime);

            animator.SetBool("Velocidade2", true);

        } else if (!Input.GetKey(KeyAndarDireita) && !Input.GetKey(KeyAndarEsquerda)) 
        {
            animator.SetBool("Velocidade2", false);
        }
        if (Input.GetKeyDown(KeyBater))
        {
            Fire = true;
            animator.SetBool("Fire", true);
        }
        else
        {
            Fire = false;
            animator.SetBool("Fire", false);
        }

        if (!paraJogadorCut)
        {
            if (paraJogadorIma == 0)
            {
                if (Input.GetKeyDown(KeyPular) && estaChao)
                {
                    animator.SetBool("Jump", true);
                    body.AddForce(new Vector2(0f, forcaPulo));
                }
                else if (body.velocity.y > 0 && !Input.GetKeyDown(KeyPular) && podePuloDuplo > 0)
                {
                    body.velocity += Vector2.up * -0.8f;
                    podePuloDuplo--;
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
        estaChao = Physics2D.OverlapCircle(verificaChao.position, raio, oChao);
        if (estaChao)
        {
            paraJogadorIma = 0;
        }

        if (!paraJogadorCut)
        {
            if (paraJogadorIma == 0)
            {
                if (tempoProximoAtaque <= 0)
                {
                    if (Input.GetKey(KeyBater) && body.velocity == new Vector2(0, 0))
                    {
                        tempoProximoAtaque = 0.2f;
                        JogadorAtaque();
                    }
                }
                else
                {
                    tempoProximoAtaque -= Time.deltaTime;
                }
                if (Vida <= 0)
                {
                    SceneManager.LoadScene("GameOver");
                }
                if (!estaChao)
                    animator.SetBool("Jump", false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("MorteInstantanea"))
        {
            SceneManager.LoadScene("GameOver");
        }

        if (collision.gameObject.tag == "Cutscenes")
        {
            paraJogadorCut = true;
        }

        if (collision.gameObject.tag == "Fim")
        {
            SceneManager.LoadScene("Continua");
        }
        if (collision.CompareTag("UpgradePerna"))
        {
            audioUpgradePerna.Play();
            forcaPulo += forcaPuloDuplo;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("UpgradeTiro"))
        {
            UpgradeTiro = true;
            Destroy(collision.gameObject);
        }
        if (collision.CompareTag("Ausapao"))
        {
            //      texto.enabled = true;
        }
        if (collision.gameObject.tag == "Missil")
        {
            DamageTaked(DanoMissil);
           
        }
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
            //     texto.enabled = false;
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

    public void DamageTaked(int damage)
    {
        
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
        //  if (UpgradeTiro == false) 
        // {
        Collider2D[] AtacarInimigo = Physics2D.OverlapCircleAll(verificaAtaque.position, raioAtaque, paraBater);
        for (int i = 0; i < AtacarInimigo.Length; i++)
        {
            AtacarInimigo[i].SendMessage("acertou", 1);
        }
        //   }
        //    else 
        // {
        //       Instantiate(tiro,posicaoCanoDaArma.position,Quaternion.identity);

        // }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(verificaChao.position, raio);
        Gizmos.DrawWireSphere(verificaAtaque.position, raioAtaque);
    }
}
