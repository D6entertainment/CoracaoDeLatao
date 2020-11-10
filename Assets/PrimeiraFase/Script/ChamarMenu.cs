using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChamarMenu : MonoBehaviour
{
    private JogadorScript Player;


    public void chamarMenu()
    {

        SceneManager.LoadScene("Menu");
    }

    public void save() 
    {

        Player = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();
        Player.SaveGame.salvar();
    
    }


}
