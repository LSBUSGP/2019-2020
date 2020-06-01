using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedAndDistance : MonoBehaviour
{
	//These are the variables you can adjust in the inspector

	//controls the speed at which the sections move towards the camera
	public float speed;
	//controls the distance
	public float distance;

    // Start is called before the first frame update
    void Start()
    {
		//sets the variables attached to the prefabs to match those in the inspector
		Road_Generator.roadGeneratorSpeed = speed;
		Road_Generator.roadGeneratorDistance = distance;
	}

    // Update is called once per frame
    void Update()
    {
		//updates the variables as they change in the inspector
		Road_Generator.roadGeneratorSpeed = speed;
		Road_Generator.roadGeneratorDistance = distance;
	}
}
