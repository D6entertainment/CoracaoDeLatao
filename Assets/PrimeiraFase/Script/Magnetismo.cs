using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magnetismo : MonoBehaviour
{
    [Header("Movimento")]
    public Transform[] m_Points;
    public float m_Speed;
    public float m_Accuracy;
    public float m_Delay;
    private int m_Index;
    private float m_Time;
    private bool m_Waiting;

    [Header("Magnetismo")]
    public bool imaCapiturou = false;
    public bool Soltar = false;
    public float ForcaIma = 0f;
    public int Serie = 1;
    public int Zero = 0;

    [Header("Script")]
    private JogadorScript Jogador;
    private Travador Trava;



    private void Start()
    {
        Jogador = GameObject.FindWithTag("Player").GetComponent<JogadorScript>();
        Trava = GameObject.FindWithTag("Travador").GetComponent<Travador>();
        ForcaIma = 1f;
    }

    private void Update()
    {
        if (m_Waiting)
        {
            if (Time.time - m_Time >= m_Delay)
            {
                m_Waiting = false;
                m_Index = ++m_Index % m_Points.Length;
            }
            return;
        }
        if (Vector3.Distance(m_Points[m_Index].position, transform.position) <= m_Accuracy)
        {
            m_Waiting = true;
            m_Time = Time.time;
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, m_Points[m_Index].position, m_Speed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            imaCapiturou = true;
            collision.transform.parent = transform;

            collision.GetComponent<JogadorScript>().Levitacao = ForcaIma;
            collision.GetComponent<JogadorScript>().imaAtivado = imaCapiturou;
        }

        if (collision.CompareTag("Soltar"))
        {
            if (Jogador.paraJogadorIma == Serie)
            {
                Soltar = true;
                collision.transform.parent = null;
                imaCapiturou = false;
                ForcaIma = 0f;

                Jogador.Levitacao = ForcaIma;
                Jogador.imaAtivado = imaCapiturou;

                StartCoroutine(UmaPausa());
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
            imaCapiturou = false;
            collision.GetComponent<JogadorScript>().Levitacao = ForcaIma * 0;
            collision.GetComponent<JogadorScript>().imaAtivado = imaCapiturou;
        }
    }
    IEnumerator UmaPausa()
    {
        yield return new WaitForSeconds(3.0f);
        ForcaIma = 1f;
        Soltar = false;
    }
}
