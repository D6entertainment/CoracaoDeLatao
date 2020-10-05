using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InimigoSegundaFase : MonoBehaviour
{
    public Transform Player;
    private Vector2 posicaoPlayer;

    private void Start()
    {
        posicaoPlayer = Player.transform.position;
    }
    void Update()
    {
        transform.Translate (new Vector2(posicaoPlayer.x * Time.deltaTime,0)); 
        
    }
}
