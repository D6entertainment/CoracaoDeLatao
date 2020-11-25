using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StartLevelConf : MonoBehaviour
{
    public Transform prefab;
    private JogadorScript player;
    public GameObject SavePrefab;
    public GameObject posicaoSave;
    private GameObject PlayerObjeto;
    public SaveGame save;


    public Text TextAndarDireiraKey;
    public Text TextAndarEsquerdaKey;
    public Text TextBaterKey;
    public Text TextPularKey;
    public Text TextInteragirKey;



    private void Awake()
    {
        Instantiate(prefab, posicaoSave.transform.position, Quaternion.identity);
        Instantiate(SavePrefab, posicaoSave.transform.position, Quaternion.identity);
        
    }
    void Start()
    {
        

        mudarText();

    }

    public void mudarText() 
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();
       // Debug.Log(save);

        TextAndarDireiraKey.text = player.KeyAndarDireita.ToString();
        TextAndarEsquerdaKey.text = player.KeyAndarEsquerda.ToString();
        TextBaterKey.text = player.KeyBater.ToString();
        TextInteragirKey.text = player.KeyInteragir.ToString();
        TextPularKey.text = player.KeyPular.ToString();

    }

    // Update is called once per frame
  

    

}
