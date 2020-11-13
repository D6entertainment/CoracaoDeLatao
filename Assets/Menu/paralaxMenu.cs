using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paralaxMenu : MonoBehaviour
{
    public float speed = 0.1f;
    public Renderer quad;

    private void Update()
    {
        Vector2 ofset = new Vector2(speed * Time.deltaTime,0);
        quad.material.mainTextureOffset += ofset;
        //quad.material.mainTextureOffset.x = speed * Time.deltaTime;
    }
}
