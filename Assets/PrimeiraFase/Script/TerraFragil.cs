using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TerraFragil : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            StartCoroutine(Quebrar());
        }
    }
    IEnumerator Quebrar()
    {
        yield return new WaitForSeconds(2f);
        Destroy(gameObject);
    }
}