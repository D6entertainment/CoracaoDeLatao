using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditosSubir : MonoBehaviour
{
    public float velocidade = 1.0f;
    void Update()
    {
        transform.Translate(new Vector2(0,velocidade * Time.deltaTime));
    }
}
