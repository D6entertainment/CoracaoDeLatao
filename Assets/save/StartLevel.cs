﻿using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartLevel : MonoBehaviour
{
    public CinemachineVirtualCamera CineMachine;
    

    public Transform prefab;
    private JogadorScript player;
    public GameObject Save;
    public GameObject posicaoSave;
    public GameObject posicaoInicial;
    public GameObject PlayerObjeto;


    void Start()
    {

        //var objetos = GameObject.FindGameObjectsWithTag("GameOver");

        Instantiate(Save, posicaoSave.transform.position, Quaternion.identity);
        posicaoInicial = GameObject.FindGameObjectWithTag("posicaoInicial");


        Instantiate(prefab, posicaoInicial.transform.position, Quaternion.identity);
        PlayerObjeto = GameObject.FindGameObjectWithTag("Player");
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();
        if (player.TemCheckPoint)
        {
            PlayerObjeto.transform.position = player.posicaoCheckPoint;
        }


        PlayerObjeto = GameObject.FindGameObjectWithTag("Player");
        CineMachine = GameObject.FindGameObjectWithTag("CineMachine").GetComponent<CinemachineVirtualCamera>();
        CineMachine.Follow = PlayerObjeto.transform;
        //Instantiate(prefab, prefab.transform.position, Quaternion.identity);


        // player.PainelGameOver = GameObject.FindGameObjectWithTag("GameOver");
        //player.PainelGameOver.SetActive(false);




    }
}