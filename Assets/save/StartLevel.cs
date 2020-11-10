using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class StartLevel : MonoBehaviour
{
    private CinemachineVirtualCamera CineMachine;
    

    public Transform prefab;
    private JogadorScript player;
    public GameObject SavePrefab;
    public GameObject posicaoSave;
    public GameObject posicaoInicial;
    private GameObject PlayerObjeto;
    private string CenaAtiva;

    private void Awake()
    {
        CenaAtiva = SceneManager.GetActiveScene().name;
        if (CenaAtiva.Equals("configuracao"))
        {
            Instantiate(SavePrefab, posicaoSave.transform.position, Quaternion.identity);
            posicaoInicial = GameObject.FindGameObjectWithTag("posicaoInicial");
            Instantiate(prefab, posicaoInicial.transform.position, Quaternion.identity);
        }
        else
        {


            Instantiate(SavePrefab, posicaoSave.transform.position, Quaternion.identity);
            posicaoInicial = GameObject.FindGameObjectWithTag("posicaoInicial");
            Instantiate(prefab, posicaoInicial.transform.position, Quaternion.identity);
            PlayerObjeto = GameObject.FindGameObjectWithTag("Player");
            //var objetos = GameObject.FindGameObjectsWithTag("GameOver");



            player = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();
            if (player.TemCheckPoint)
            {
                PlayerObjeto.transform.position = player.posicaoCheckPoint;
            }


            // PlayerObjeto = GameObject.FindGameObjectWithTag("Player");
            CineMachine = GameObject.FindGameObjectWithTag("CineMachine").GetComponent<CinemachineVirtualCamera>();
            CineMachine.Follow = PlayerObjeto.transform;
            //Instantiate(prefab, prefab.transform.position, Quaternion.identity);


            // player.PainelGameOver = GameObject.FindGameObjectWithTag("GameOver");
            //player.PainelGameOver.SetActive(false);


        }
    }

    void Start()
    {


    }
}
