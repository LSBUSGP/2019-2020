using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Distance : MonoBehaviour
{
    public Text tScore;
    public Text snowflakes;
    public float distance;
    public Transform player;
    static float cScore;
    public Player_Movement pm;
    public float sfScore;
    static float flakeScore;

    void Start()
    {
        transform.position = player.position;
        distance = 0;
    }
    void Update()
    {
        if (pm.alive == true)
        {
            distance = Vector3.Distance(player.position, transform.position);
            string distanceScore = distance.ToString("f0");
            tScore.text = distanceScore;
            cScore = distance;
            flakeScore = sfScore;
            Carry.Score(cScore,flakeScore);
            string snowflakeScore = sfScore.ToString("f0");
            snowflakes.text = snowflakeScore;


        }

    }


}
