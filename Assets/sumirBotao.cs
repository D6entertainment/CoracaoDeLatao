using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sumirBotao : MonoBehaviour
{
    private Button botao;
    // Start is called before the first frame update
    void Start()
    {
        botao = GetComponent<Button>();
        botao.interactable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
