using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parandoAgua : MonoBehaviour
{
    public levitacaoAgua agua;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("teste"))
        {
            Debug.Log("colidindo");
            agua.podeSubir = false;
        }
    }
}
