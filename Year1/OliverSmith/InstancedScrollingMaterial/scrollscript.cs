using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrollscript : MonoBehaviour
{ 
    //Speed of movement along X and Y axis
    public float ScrollX = 0.5f;
    public float ScrollY = 0.5f;
    void Update()
    {
    //Movement of texture
    float MoveX = Time.time * ScrollX;
    float MoveY = Time.time * ScrollY;
    GetComponent<Renderer>().material.mainTextureOffset = new Vector2(MoveX, MoveY);
    }
    
}
