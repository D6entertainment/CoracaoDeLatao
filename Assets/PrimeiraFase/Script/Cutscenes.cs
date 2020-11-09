using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscenes : MonoBehaviour
{
    [Header("Video")]
    private Mutar Mutando;

    public GameObject VideoPlayer;
    public float timeToStop;
    public float timeToPlay;

    void Start()
    {
        Mutando = GameObject.FindWithTag("MainCamera").GetComponent<Mutar>();
        VideoPlayer.SetActive(false);
        timeToPlay = timeToStop - 0.1f;
    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        if(Player.gameObject.tag == "Player")
        {
            Mutando.Mutado = true;
            StartCoroutine(BackPlayerToLive(Player));
            VideoPlayer.SetActive(true);
            Destroy(VideoPlayer, timeToStop);
            Destroy(gameObject, timeToStop);
        }

    }
    IEnumerator BackPlayerToLive(Collider2D Player){

        yield return new WaitForSecondsRealtime(timeToPlay);
        Mutando.Mutado = false;
        Player.GetComponent<JogadorScript>().paraJogadorCut = false;
    }
}
