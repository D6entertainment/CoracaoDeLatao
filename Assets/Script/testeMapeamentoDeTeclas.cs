
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class testeMapeamentoDeTeclas : MonoBehaviour
{
    public JogadorScript ScriptAndar;
    public Text texto;
    private bool AndarDireita, AndarEsquerda, Pular, Bater = false;




    private void Update()
    {
        if (AndarDireita == true)
        {
            foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
            {
                if (Input.GetKey(kcode))
                {
                    texto.text = (kcode).ToString();
                    ScriptAndar.KeyAndarDireita = kcode;
                    AndarDireita = false;
                }
            }
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
    }

    public void mudarTeclaAndarDireita()
    {
        AndarDireita = true;



    }
    public void mudarTeclaAndarEsquerda()
    {
        AndarEsquerda = true;



    }
    public void mudarTeclaAndarPular()
    {
        Pular = true;



    }
    public void mudarTeclaBater()
    {
        Bater = true;



    }


}

