using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carry : MonoBehaviour
{
    public static float cScore;
    public static float sfScore;
    public static void Score(float score, float scoreF)
    {
        scoreF = scoreF * 5;
        cScore = score + scoreF;



    }
}
