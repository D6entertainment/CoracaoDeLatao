using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float Comprimento;
    private float inicioPos;
    public float parallaxEffect;

    public GameObject Cam;


    // Start is called before the first frame update
    void Start()
    {
        inicioPos = transform.position.x;
        Comprimento = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float Temp = (Cam.transform.position.x * (1 - parallaxEffect));
        float Distancia = (Cam.transform.position.x * parallaxEffect);

        transform.position = new Vector3(inicioPos + Distancia, transform.position.y, transform.position.z);

        if (Temp > inicioPos + Comprimento)
        {
            inicioPos += Comprimento;
        } else 
        if (Temp < inicioPos - Comprimento)
        {
            inicioPos -= Comprimento;
        }
    }
}

