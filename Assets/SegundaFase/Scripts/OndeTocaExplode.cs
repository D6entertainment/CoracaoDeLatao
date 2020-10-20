using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndeTocaExplode : MonoBehaviour
{

    public Transform explosao;
    public RoboPerseguidor robo;
  

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("FimDaVida"))
        {
            Debug.Log("fim da vida");
            Destroy(transform.parent.gameObject);
        }
        if (collision.CompareTag("Explosivel"))
        {
            Instantiate(explosao, collision.transform.position, Quaternion.identity);
            Destroy(collision.gameObject);
            Debug.Log("destuido");
        }
        if (collision.CompareTag("FimDoCaminho"))
        {
            Debug.Log("fim do caminho");
            robo.fimDoCaminho = true;
           // Destroy(collision.gameObject);
        }



    }
}
