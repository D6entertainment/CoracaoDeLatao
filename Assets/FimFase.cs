using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FimFase : MonoBehaviour
{
    public GameObject Player;
    public JogadorScript PlayerScript;
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        PlayerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<JogadorScript>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            PlayerScript.fase += 1;
            PlayerScript.SaveGame.salvar();
            Destroy(collision.gameObject);
            SceneManager.LoadScene("Cidade");
        }
        
    }


}
