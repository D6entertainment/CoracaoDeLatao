
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class testeMapeamentoDeTeclas : MonoBehaviour
{
    private JogadorScript ScriptAndar;
    public Text texto;
    private bool AndarDireita, AndarEsquerda, Pular, Bater, Interagir = false;
    public SaveGame save;


    private void Start()
    {
        ScriptAndar = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();

    }

    private void Update()
    {
        if (AndarDireita == true)
        {
            foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
            {
                ScriptAndar.ficaParado = true;
                if (Input.GetKeyDown(kcode))
                {
                    texto.text = (kcode).ToString();
                    ScriptAndar.KeyAndarDireita = kcode;
                    AndarDireita = false;
                }
            }

        }
        else 
        {

            ScriptAndar.ficaParado = false;
        }
        if (AndarEsquerda == true)
        {
            foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(kcode))
                {
                    texto.text = (kcode).ToString();
                    ScriptAndar.KeyAndarEsquerda = kcode;
                    AndarEsquerda = false;
                }
            }
        }
        if (Pular == true)
        {
            foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(kcode))
                {
                    texto.text = (kcode).ToString();
                    ScriptAndar.KeyPular = kcode;
                    Pular = false;
                }
            }
        }
        if (Bater == true)
        {
            foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(kcode))
                {
                    texto.text = (kcode).ToString();
                    ScriptAndar.KeyBater = kcode;
                    Bater = false;
                }
            }
        }

        if (Interagir == true)
        {
            foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(kcode))
                {
                    texto.text = (kcode).ToString();
                    ScriptAndar.KeyInteragir = kcode;
                    Interagir = false;
                }
            }
        }
    }

    public void mudarTeclaAndarDireita()
    {
        ScriptAndar = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();
        AndarDireita = true;



    }
    public void mudarTeclaAndarEsquerda()
    {
        ScriptAndar = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();
        AndarEsquerda = true;



    }
    public void mudarTeclaAndarPular()
    {
        ScriptAndar = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();
        Pular = true;



    }
    public void mudarTeclaBater()
    {
        ScriptAndar = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();
        Bater = true;



    }
    public void mudarTeclaInteragir()
    {
        ScriptAndar = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();
        Interagir = true;



    }


}

