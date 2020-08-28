using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mutar : MonoBehaviour
{
    public bool Mutado = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Mutado == true){
            GetComponent<AudioSource>().mute = true;
        }
        if (Mutado == false)
        {
            GetComponent<AudioSource>().mute = false;
        }
    }
}
