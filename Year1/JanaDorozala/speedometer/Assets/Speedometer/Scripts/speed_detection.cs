using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class speed_detection : MonoBehaviour
{

    public Text myText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        var speed = (GetComponent<Rigidbody2D>().velocity.magnitude)* 2.237;    //accessing the speed and multiplyibng by a factore to convert it into miles per hour
        myText.text = speed.ToString("F1") + " mph";                             //displaying it to the text on canvas; the "F1" insures ONE decimal place

        //Debug.Log("speed:" + GetComponent<Rigidbody2D>().velocity.magnitude + "m/s"); tocheck if it properly accesses the speed of th ebject
    }
}
