using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisorAguaQueLevanta : MonoBehaviour
{
    public bool colidindo;
    public levitacaoAgua agua;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("AguaQueLevanta")) 
        {
            agua.colisor = true;
            Debug.Log("colidiu");
        
        }
    }
}
