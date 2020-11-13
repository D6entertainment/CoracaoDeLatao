using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class turnInimigo : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Inimigo inimigo = collision.GetComponent<Inimigo>();
       // Debug.Log(collision.name);
        if (inimigo) 
        {
            inimigo.Flip();
        }
    }
}
