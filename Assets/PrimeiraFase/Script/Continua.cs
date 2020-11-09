using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Continua : MonoBehaviour
{
    public bool Fim = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Continuar());
    }

    // Update is called once per frame
    void Update()
    {
        if(Fim == true)
        {
            SceneManager.LoadScene("Menu");
        }
    }

    IEnumerator Continuar()
    {
        yield return new WaitForSeconds(35f);
        Fim = true;
    }
}
