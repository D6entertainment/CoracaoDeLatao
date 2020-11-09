using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CenaConfiguracao : MonoBehaviour
{
    public GameObject PainelAudio;
    public GameObject PainelInputs;
    private void Start()
    {
        PainelAudio.SetActive(true);
        PainelInputs.SetActive(false);
    }


    public void MostrarPainelAudio() 
    {
        PainelInputs.SetActive(false);
        PainelAudio.SetActive(true);
    }
    public void MostrarPainelInput()
    {
        PainelAudio.SetActive(false);
        PainelInputs.SetActive(true);

    }


}
