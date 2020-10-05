using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tiro : MonoBehaviour
{
    private Rigidbody2D Rb;
    public float velocidade;


    private void Start()
    {
        Rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
     
            transform.Translate(new Vector2(velocidade * Time.deltaTime, 0));
        

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("destruivel")) 
        {
            //starta a animação de explosão
            Destroy(collision.gameObject);
        
        }
        else  
        {
            Destroy(this.gameObject);
             
        
        }
    }
}
