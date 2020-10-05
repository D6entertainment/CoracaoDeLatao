using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alsapao : MonoBehaviour
{
    private Rigidbody2D Rig; 
    private void Start()
    {
        Rig = GetComponent<Rigidbody2D>();
    }
    public void destruirCorpoRigido() 
    {
        Destroy(Rig);

    }
}
