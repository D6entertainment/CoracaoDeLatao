using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedeSecreta : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TornarInvisivel();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            TornarVisivel();
        }
    }

    public void TornarInvisivel()
    {
        Renderer rend = gameObject.GetComponent<Renderer>();
        rend.enabled = false;
    }

    public void TornarVisivel()
    {
        Renderer rend = gameObject.GetComponent<Renderer>();
        rend.enabled = true;
    }
}
