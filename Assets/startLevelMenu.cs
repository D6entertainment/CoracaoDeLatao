using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class startLevelMenu : MonoBehaviour
{
    public SaveGame dados;
    public Button botaocarregar;
    private bool temCheckPoint;
    void Start()
    {
        //dados = GameObject.FindGameObjectWithTag("Save").GetComponent<SaveGame>();
        temCheckPoint = dados.TemChecpointMetodo();
        if (temCheckPoint == false)
        {
            botaocarregar.interactable = false;
        }
        else if (temCheckPoint)
        {
            botaocarregar.interactable = false;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
