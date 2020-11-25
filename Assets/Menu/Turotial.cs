using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Turotial : MonoBehaviour
{
    public JogadorScript Player;
    public Text keyAndarDireita;
    public Text keyAndarEsquerda;
    public Text keyBater;
    public Text keyPular;
    public Text keyInteragir;
    public bool FezTutorial = false;
    public GameObject painelTutorial;
    private void Start()
    {
        if (FezTutorial == false)
        {
            Player = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();
            keyAndarDireita.text = Player.KeyAndarDireita.ToString();
            keyAndarEsquerda.text = Player.KeyAndarEsquerda.ToString();
            keyBater.text = Player.KeyBater.ToString();
            keyPular.text = Player.KeyPular.ToString();
            keyInteragir.text = Player.KeyInteragir.ToString();
        }
        else 
        {

            painelTutorial.SetActive(false);
        }
    }

    


}
