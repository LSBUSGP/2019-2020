
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FpsCounter : MonoBehaviour
{
    private int frameCounter = 0;
    float timeCounter = 0.0f;
    private float refreshTime = 0.1f;
    [SerializeField]
    private Text framerateText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(timeCounter < refreshTime)
        {
            timeCounter += Time.deltaTime;
            frameCounter++;

        }
        else
        {
            float lastFramerate = frameCounter / timeCounter;
            frameCounter = 0;
            timeCounter = 0.0f;
            framerateText.text = lastFramerate.ToString("n2");
        }
    }
}
