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



    private void Awake()
    {
        Instantiate(prefab, posicaoSave.transform.position, Quaternion.identity);
        Instantiate(SavePrefab, posicaoSave.transform.position, Quaternion.identity);
        
    }
    void Start()
    {
        

       // mudarText();

    }

    public void mudarText() 
    {
        save = GameObject.FindGameObjectWithTag("Save").GetComponent<SaveGame>();
        Debug.Log(save);

        TextAndarDireiraKey.text = save.retornaStringKeys("KeyAndarDireita");
    
    }

    // Update is called once per frame
  

    

}
