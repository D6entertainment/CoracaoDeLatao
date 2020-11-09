using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuzPiscante : MonoBehaviour
{
    public Light Luz;
    public float timerLuzAcesa = 0.5f;
    public float timerLuzApagada = 0.2f;
    private void Update()
    {
        timerLuzAcesa -= Time.deltaTime;
        timerLuzApagada -= Time.deltaTime;
        if (timerLuzAcesa <=0) { 
            //tocar som bem de leve
            timerLuzAcesa = 0.5f;
            Luz.enabled = false;
        }
        if (timerLuzApagada <=0) {
            timerLuzApagada = 0.2f;
            Luz.enabled = true;
        }
        
    }
}
