using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text text;
    private float scoreH;
    // Start is called before the first frame update
    void Start()
    {
        scoreH = Carry.cScore;
        text.text = "Score:" + scoreH.ToString("f0");
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
