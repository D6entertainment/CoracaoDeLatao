using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sumirBotao : MonoBehaviour
{
    public Button botao;
    public JogadorScript player;
    // Start is called before the first frame update
    void Start()
    {
       // botao = GetComponent<Button>();

       
    }

    // Update is called once per frame
    void Update()
    {
        if (player.checPoint1 > 0)
        {
            botao.interactable = true;
        }
        else 
        {
            botao.interactable = false;
        }

    }
}
