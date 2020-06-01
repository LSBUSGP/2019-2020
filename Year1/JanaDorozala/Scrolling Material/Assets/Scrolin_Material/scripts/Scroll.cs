using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
	public float ScrollX = 0.5f;
	public float ScrollY = 0.5f;

	float OffsetX;
	float OffsetY;

    // Update is called once per frame
    void Update()
    {
      OffsetX += Time.deltaTime * ScrollX;
	  OffsetY += Time.deltaTime * ScrollY;
	  
	  GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
    }
}
