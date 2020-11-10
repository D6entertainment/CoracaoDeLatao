using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;
using System;
public class SaveGame : MonoBehaviour
{
    private string dataP;
    public infos dados;
    public JogadorScript player;


    //apagar depois 


    // public Transform PrefabPlayer;

    private void Start()
    {
        dataP = Path.Combine(Application.dataPath, "infos.json"); // criando o diretorio do arquivo na raiz do projeto e com nome infos.json
        dados = new infos();
        string nomeCenaAtiva = SceneManager.GetActiveScene().name;
        if (nomeCenaAtiva.Equals("Ferro Velho") || nomeCenaAtiva.Equals("Cidade") || nomeCenaAtiva.Equals("TerceiraFase")) {
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();
        }
    }
    public void salvar()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();

        dados.Vida = player.Vida;
        dados.posicaoCheckPoint = player.posicaoCheckPoint;
        dados.checPoint1 = player.checPoint1;
        dados.TemCheckPoint = player.TemCheckPoint;
        dados.fase = player.fase;
        dados.speed = player.speed;
        dados.forcaPulo = player.forcaPulo;
        dados.forcaPuloDuplo = player.forcaPuloDuplo;
        dados.KeyAndarDireita = player.KeyAndarDireita;
        dados.KeyAndarEsquerda = player.KeyAndarEsquerda;
        dados.KeyBater = player.KeyBater;
        dados.KeyInteragir = player.KeyInteragir;
        dados.KeyPular = player.KeyPular;
        dados.puloDuplo = player.puloDuplo;
        dados.UpgradeTiro = player.UpgradeTiro;
        dados.Awake = player.Awake;
        dados.Idle = player.Idle;
        dados.ParadoComBota = player.ParadoComBota;
        dados.ParadoComBotaEArma = player.ParadoComBotaEArma;


        string jsonS = JsonUtility.ToJson(dados); // convertendo um objeto de informações a serem salvar em json
        File.WriteAllText(dataP, jsonS);//escrevendo no arquivo json com os dados do objeto em json no diretorio datap.
        Debug.Log("salvado");
    }

    public void carrregar()
    {

        string jsonS = File.ReadAllText(dataP);
        JsonUtility.FromJsonOverwrite(jsonS, dados);
        if (dados.fase == 1)
        {
            SceneManager.LoadScene("Ferro Velho");



            player.Vida = dados.Vida;
            player.posicaoCheckPoint = dados.posicaoCheckPoint;
            player.checPoint1 = dados.checPoint1;
            player.TemCheckPoint = dados.TemCheckPoint;
            player.fase = dados.fase;
            player.speed = dados.speed;
            player.forcaPulo = dados.forcaPulo;
            player.forcaPuloDuplo = dados.forcaPuloDuplo;
            player.KeyAndarDireita = dados.KeyAndarDireita;
            player.KeyAndarEsquerda = dados.KeyAndarEsquerda;
            player.KeyBater = dados.KeyBater;
            player.KeyInteragir = dados.KeyInteragir;
            player.KeyPular = dados.KeyPular;
            player.puloDuplo = dados.puloDuplo;
            player.UpgradeTiro = dados.UpgradeTiro;
            player.Awake = dados.Awake;
            player.Idle = dados.Idle;
            player.ParadoComBota = dados.ParadoComBota;
            player.ParadoComBotaEArma = dados.ParadoComBotaEArma;

        }
        if (dados.fase == 2)
        {
            SceneManager.LoadScene("Cidade");



            player.Vida = dados.Vida;
            player.posicaoCheckPoint = dados.posicaoCheckPoint;
            player.checPoint1 = dados.checPoint1;
            player.TemCheckPoint = dados.TemCheckPoint;
            player.fase = dados.fase;
            player.speed = dados.speed;
            player.forcaPulo = dados.forcaPulo;
            player.forcaPuloDuplo = dados.forcaPuloDuplo;
            player.KeyAndarDireita = dados.KeyAndarDireita;
            player.KeyAndarEsquerda = dados.KeyAndarEsquerda;
            player.KeyBater = dados.KeyBater;
            player.KeyInteragir = dados.KeyInteragir;
            player.KeyPular = dados.KeyPular;
            player.puloDuplo = dados.puloDuplo;
            player.UpgradeTiro = dados.UpgradeTiro;
            player.Awake = dados.Awake;
            player.Idle = dados.Idle;
            player.ParadoComBota = dados.ParadoComBota;
            player.ParadoComBotaEArma = dados.ParadoComBotaEArma;

        }
        if (dados.fase == 3)
        {
            SceneManager.LoadScene("TerceiraFase");



            player.Vida = dados.Vida;
            player.posicaoCheckPoint = dados.posicaoCheckPoint;
            player.checPoint1 = dados.checPoint1;
            player.TemCheckPoint = dados.TemCheckPoint;
            player.fase = dados.fase;
            player.speed = dados.speed;
            player.forcaPulo = dados.forcaPulo;
            player.forcaPuloDuplo = dados.forcaPuloDuplo;
            player.KeyAndarDireita = dados.KeyAndarDireita;
            player.KeyAndarEsquerda = dados.KeyAndarEsquerda;
            player.KeyBater = dados.KeyBater;
            player.KeyInteragir = dados.KeyInteragir;
            player.KeyPular = dados.KeyPular;
            player.puloDuplo = dados.puloDuplo;
            player.UpgradeTiro = dados.UpgradeTiro;
            player.Awake = dados.Awake;
            player.Idle = dados.Idle;
            player.ParadoComBota = dados.ParadoComBota;
            player.ParadoComBotaEArma = dados.ParadoComBotaEArma;

        }




    }

    public void NovoJogo()
    {
        string jsonS = JsonUtility.ToJson(dados); // convertendo um objeto de informações a serem salvar em json
        File.WriteAllText(dataP, jsonS);//escrevendo no arquivo json com os dados do objeto em json no diretorio datap.
        player.Vida = 10;
        player.posicaoCheckPoint = dados.posicaoCheckPoint;
        player.checPoint1 = 0;
        player.TemCheckPoint = false;
        player.fase = 1;
        player.speed = 10f;
        player.forcaPulo = 2400f;
        player.forcaPuloDuplo = 1300f;
        player.KeyAndarDireita = KeyCode.D; ;
        player.KeyAndarEsquerda = KeyCode.A;
        player.KeyBater = KeyCode.O;
        player.KeyInteragir = KeyCode.E;
        player.KeyPular = KeyCode.Space;
        player.puloDuplo = false;
        player.UpgradeTiro = false;
        player.Awake = true;
        player.Idle = false;
        player.ParadoComBota = false;
        player.ParadoComBotaEArma = false;

        SceneManager.LoadScene("Ferro Velho");

    }

    public string retornaStringKeys(string Key) 
    {
        if (Key.Equals("KeyAndarDireita"))
        {
            return dados.KeyAndarDireita.ToString();
        }
        else if (Key.Equals("KeyAndarEsquerda")) 
        {
            return dados.KeyAndarDireita.ToString();
        
        }
        else if (Key.Equals("KeyPular"))
        {
            return dados.KeyPular.ToString();

        }
        else if (Key.Equals("KeyBater"))
        {
            return dados.KeyBater.ToString();

        }
        else if (Key.Equals("KeyInteragir"))
        {
            return dados.KeyInteragir.ToString();

        }
        else 
        {
            return "erro";
        }

    }




}



public class infos
{
    public int fase;
    public Vector3 posicaoCheckPoint;
    public int checPoint1;
    public bool TemCheckPoint;
    public float speed;
    public float forcaPulo;
    public float forcaPuloDuplo;
    public KeyCode KeyAndarDireita;
    public KeyCode KeyAndarEsquerda;
    public KeyCode KeyPular;
    public KeyCode KeyBater;
    public KeyCode KeyInteragir;
    public bool puloDuplo;
    public bool UpgradeTiro;
    public int Vida;
    public bool Awake;
    public bool Idle;
    public bool ParadoComBota;
    public bool ParadoComBotaEArma;
}