using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travador : MonoBehaviour
{
    [Header("Ativaveis")]
    public bool Travar = false;
    public int Serie = 1;


    // Start is called before the first frame update
    private void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            Travar = true;
            Player.GetComponent<JogadorScript>().imaAtivado = true;
            Player.GetComponent<JogadorScript>().paraJogadorIma = Serie;
        }
    }
    private void OnTriggerExit2D(Collider2D Player)
    {
        if (Player.gameObject.tag == "Player")
        {
            //Travar = false;
            //collision.transform.parent = null;

            //collision.GetComponent<JogadorScript>().Levitacao = ForcaIma * 0;
            //collision.GetComponent<JogadorScript>().paraJogador = false;
        }
    }
}
