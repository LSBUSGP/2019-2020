using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoScript : MonoBehaviour
{

    public ShuffleScript shuffleScript;
    List<string> tracks = new List<string>();
    string lineSeperatedString;

    public Text[] UITexts;

    public void demoButtonClicked()
    {

        foreach(Text txt in UITexts)
        {
            tracks = shuffleScript.Shuffle();

            int trackNum = 0;

            foreach(string t in tracks)
            {
                trackNum++;
                lineSeperatedString += trackNum + ". " + t + "\n";
            }

            txt.text = lineSeperatedString;

            lineSeperatedString = "";
        }

    }

}
