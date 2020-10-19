using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cosilorFimDaVida : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (CompareTag("FimDaVida"))
        {
            Debug.Log("Fim da vida");
            Destroy(transform.parent.gameObject);
        }
    }
}
