using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JogadorScript : MonoBehaviour
{
    [Header("Movimento")]
    public float speed = 10f;
    public float forcaPulo = 800f;
    public float forcaPuloDuplo = 200f;
    public Transform verificaChao;
    public LayerMask oChao;
    public float raio = 0.2f;
    public bool paraJogadorCut = false;
    public int paraJogadorIma = 0;
    public bool imaAtivado = false;
    public float deslizador = 0f;
    public float Levitacao = 0f;

    [Header("Upgrades")]

    public int puloDuplo = 1;
    public int podePuloDuplo = 1;
    public bool UpgradeTiro = false;
    //public Transform tiro;
    //public Transform posicaoCanoDaArma;
    private alsapao alsapao;


    [Header("Verificador")]
    bool estaPulando = false;
    public bool estaChao = false;
    private Rigidbody2D body;
    SpriteRenderer sprite;


    [Header("outros")]

    public Text texto;


    [Header("Ataque")]
    public Transform verificaAtaque;
    public float raioAtaque;
    public LayerMask paraBater;
    public float tempoProximoAtaque;

    [Header("Vida")]
    public int Vida;
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
      
   
    }

    IEnumerator Paradinha()
    {
        yield return new WaitForSeconds(3f);
        paraJogadorCut = false;
    }

    private void Update()
    {

        if (!paraJogadorCut)
        {
            if (paraJogadorIma == 0)
            {
                if (Input.GetButtonDown("Jump") && estaChao  )
                {
                    animator.SetBool("Jump", true);
                    body.AddForce(new Vector2(0f, forcaPulo));
                 


                }
         
       

                else if (body.velocity.y > 0 && !Input.GetButton("Jump") && podePuloDuplo > 0)
                {
                    body.velocity += Vector2.up * -0.8f;
                    podePuloDuplo --;
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
                    if (Input.GetButtonDown("Fire1") && body.velocity == new Vector2(0, 0))
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
                    //SceneManager.LoadScene("GameOver");
                }

                float move = Input.GetAxis("Horizontal");

                Vector3 horizontal = new Vector3(Input.GetAxis("Horizontal") + deslizador, 0.0f + Levitacao, 0.0f);
                transform.position = transform.position + horizontal * speed;

                if ((move > 0 && sprite.flipX == true) || (move < 0 && sprite.flipX == false))
                {
                    Flip();
                }

                axis = Input.GetAxis("Horizontal");

                velocidade = new Vector2(axis * speed, GetComponent<Rigidbody2D>().velocity.y);
                animator.SetFloat("Velocidade", Mathf.Abs(axis));


                if (Input.GetButton("Fire1"))
                {
                    Fire = true;
                    animator.SetBool("Fire", true);

                }
                else
                {
                    Fire = false;
                    animator.SetBool("Fire", false);
                }

                

                if (!estaChao)
                    animator.SetBool("Jump", false);
            }
        }

        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Cutscenes")
        {
            paraJogadorCut = true;
        }

        if (collision.gameObject.tag == "Fim")
        {
            SceneManager.LoadScene("Continua");
        }
        if(collision.CompareTag("UpgradePerna")) 
        {
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
            texto.enabled = true;
        }

    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Ausapao"))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                //tocar som do alsapao
                Destroy(collision.gameObject);
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
            texto.enabled = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "daDano")
        {
            DamageTaked(1);
            animator.SetBool("Hurt", true);
        }
        else
        {
            animator.SetBool("Hurt", false);
        }

        if (collision.gameObject.tag == "Mata")
        {
            Destroy(gameObject);
            SceneManager.LoadScene("GameOver");
        }
    }


    private void DamageTaked(int damage)
    {
        Vida -= damage;
        StartCoroutine(ColorDamageChange());
        lifeObject[Vida].SetActive(false);
        
    }

    IEnumerator ColorDamageChange(){
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(0.7f);
        gameObject.GetComponent<SpriteRenderer>().color = new Color(255f,255f,255f);
    }

    void Flip()
    {
        sprite.flipX = !sprite.flipX;
        verificaAtaque.localPosition = new Vector2(-verificaAtaque.localPosition.x, verificaAtaque.localPosition.y);
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
    