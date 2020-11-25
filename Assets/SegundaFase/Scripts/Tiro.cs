using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    public float Speed = 10;
    public Inimigo inimigo;
    public int DanoTiro = 1;
    private void Start()
    {
        inimigo = GameObject.FindGameObjectWithTag("daDano").GetComponent<Inimigo>();
        
    }
    private void Update()
    {
        transform.Translate(new Vector2(Speed * Time.deltaTime, 0));
        Destroy(transform.gameObject,2.0f);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals("Limite de Camera")) 
            return;
        
        Destroy(gameObject);
        
       
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("daDano"))
        {
            inimigo.acertou(DanoTiro);
            Destroy(transform.gameObject);
        }

    }



}
