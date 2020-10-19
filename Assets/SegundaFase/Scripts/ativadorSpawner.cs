using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ativadorSpawner : MonoBehaviour
{
    public Transform mob;
    public Transform spawner;
    private Vector2 posicao = new Vector2(0,0);


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Instantiate(mob,spawner.position,Quaternion.identity);
            Debug.Log("instanciando");
            Destroy(gameObject);
        }
    }
}
