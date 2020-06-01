using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
	private int frameCounter = 0;
	private float timeCounter = 0.0f;
	private float refreshTime = 1f;

	[SerializeField]
	private Text framerateText;


    // Update is called once per frame
    void Update()
    {
        if(timeCounter<refreshTime)
		{
			timeCounter += Time.deltaTime;
			frameCounter++;
		}

		else
		{
			float lastFramerate =  frameCounter / timeCounter;
			frameCounter = 0;
			timeCounter = 0.0f;

			framerateText.text = lastFramerate.ToString("n0");
		}
    }
}
