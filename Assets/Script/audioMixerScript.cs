using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class audioMixerScript : MonoBehaviour
{
    public AudioMixer am;
    public Slider sliderMusicas;
    public Slider sliderGeral;
    public Slider sliderCutscene;
    private void Start()
    {
        sliderCutscene.value = PlayerPrefs.GetFloat("volumeCutscene");
        sliderGeral.value = PlayerPrefs.GetFloat("volumeGeral");
        sliderMusicas.value = PlayerPrefs.GetFloat("volumeMusica");
    }
    public void sliderMusica ( )
    {
        am.SetFloat("volumeMusica",sliderMusicas.value);
        PlayerPrefs.SetFloat("volumeMusica", sliderMusicas.value);
    }

    public void slideGeral()
    {
        am.SetFloat("volumeGeral",sliderGeral.value);
        PlayerPrefs.SetFloat("volumeGeral", sliderGeral.value);
    }

    public void slideDeCutscenes()
    {
        am.SetFloat("volumeCutscene",sliderCutscene.value);
        PlayerPrefs.SetFloat("volumeCutscene", sliderCutscene.value);
    }


}
